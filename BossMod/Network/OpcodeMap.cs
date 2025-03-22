using BossMod.Network.ServerIPC;
namespace BossMod.Network;

// map betweek network message opcodes (which are randomized every build) to more-or-less stable indices
public class OpcodeMap
{
    public readonly List<int> _opcodeToID = [];
    private readonly List<int> _idToOpcode = [];
    private readonly List<OpcodeMapEntry> _opcodeMapTable = [];

    public IReadOnlyList<int> OpcodeToID => _opcodeToID;
    public IReadOnlyList<int> IDToOpcode => _idToOpcode;
    public IReadOnlyList<OpcodeMapEntry> OpcodeMapTable => _opcodeMapTable;
    public PacketID ID(int opcode) => (PacketID)(opcode >= 0 && opcode < _opcodeToID.Count ? _opcodeToID[opcode] : -1);
    public int Opcode(PacketID id) => (int)id >= 0 && (int)id < _idToOpcode.Count ? _idToOpcode[(int)id] : -1;
    public String OpcodeToName(int opcode) => Enum.IsDefined(typeof(PacketID), ID(opcode)) ? ID(opcode).ToString() : string.Empty;
    public String IDToName(int id) => Enum.IsDefined(typeof(PacketID), id) ? ((PacketID)id).ToString() : string.Empty;
    public readonly nint Func;
    public readonly int MinCase;
    public readonly int JumptableSize;
    public nint DefaultAddr;
    public readonly nint ImagebaseAddr;
    public readonly nint JumptableRVA;
    public readonly nint JumptableAddr;

    public unsafe OpcodeMap()
    {
        // look for an internal tracing function - it's a giant switch on opcode that calls virtual function corresponding to the opcode; we use vf indices as 'opcode index'
        // function starts with:
        // mov rax, [r8+10h]                            49 8B 40 10
        // mov r10, [rax+38h]                           4C 8B 50 38
        // movzx eax, word ptr [r10+2]                  41 0F B7 42 02
        // add eax, -<min_case>                         83 C0 ??                    func + 15
        // cmp eax, <max_case-min_case>                 3D ?? ?? ?? ??              func + 17
        // ja <default_off>                             0F 87 ?? ?? ?? ??           func + 23
        // lea r11, <__ImageBase_off>                   4C 8D 1D ?? ?? ?? ??        func + 30
        // cdqe                                         48 98
        // mov r9d, ds::<jumptable_rva>[r11+rax*4]      45 8B 8C 83 ?? ?? ?? ??     func + 40
        Func = Service.SigScanner.ScanText("49 8B 40 10  4C 8B 50 38  41 0F B7 42 02  83 C0 ??  3D ?? ?? ?? ??  0F 87 ?? ?? ?? ??  4C 8D 1D ?? ?? ?? ??  48 98  45 8B 8C 83 ?? ?? ?? ??");

        var func = (byte*)Func;
        var minCase = -*(sbyte*)(func + 15);
        var jumptableSize = *(int*)(func + 17) + 1;
        var defaultAddr = ReadRVA(func + 23);
        var imagebase = ReadRVA(func + 30);
        var jumptable = (int*)(imagebase + *(int*)(func + 40));

        MinCase = -*(sbyte*)(Func + 15);
        JumptableSize = *(int*)(Func + 17) + 1;
        DefaultAddr = ReadRVA(Func + 23);
        ImagebaseAddr = ReadRVA(Func + 30);
        JumptableRVA = *(int*)(Func + 40);
        JumptableAddr = ImagebaseAddr + JumptableRVA;

        for (var i = 0; i < jumptableSize; ++i)
        {
            var bodyAddr = imagebase + jumptable[i];
            if (bodyAddr == defaultAddr)
                continue;

            var opcode = minCase + i;
            var index = ReadIndexForCaseBody(bodyAddr, out var vtoff);
            if (index < 0)
                Service.Log($"[OpcodeMap] Unexpected body for opcode {opcode}");
            else
                AddMapping(opcode, index);

            // OpcodeMapEntry
            OpcodeMapEntry entry = new OpcodeMapEntry();
            entry.Index = i;
            entry.bodyAddr = ImagebaseAddr + jumptable[i];
            // entry.bodyAddr = ImagebaseAddr + *((int*)JumptableAddr + 4 * i);
            entry.Opcode = MinCase + entry.Index;
            entry.VtableIndex = ReadIndexForCaseBody(bodyAddr, out entry.Vtoff);
            entry.Name = IDToName(entry.VtableIndex);
            _opcodeMapTable.Add(entry);
        }
        _opcodeMapTable.Sort((a, b) => a.VtableIndex - b.VtableIndex);
    }

    private static unsafe byte* ReadRVA(byte* p) => p + 4 + *(int*)p;
    private static unsafe nint ReadRVA(nint p) => p + 4 + *(int*)p;

    // assume each case has the following body:
    // mov rax, [rcx]
    // lea r9, [r10+10h]
    // jmp qword ptr [rax+<vfoff>]
    private static readonly byte[] BodyPrefix = [0x48, 0x8B, 0x01, 0x4D, 0x8D, 0x4A, 0x10, 0x48, 0xFF];

    private static unsafe bool isNotCaseBody(byte* bodyAddr)
    {
        return BodyPrefix.Where((t, i) => bodyAddr[i] != t).Any();
    }

    private static unsafe int ReadIndexForCaseBody(byte* bodyAddr, out int vtoff)
    {
        if (isNotCaseBody(bodyAddr))
        {
            vtoff = -2;
            return -1;
        }
        vtoff = bodyAddr[BodyPrefix.Length] switch
        {
            // 48: REX.W（64 位操作数前缀）
            // FF: 组指令（用于 INC, DEC, CALL, JMP, PUSH 等）
            // 60/A0(01 100 000/10 100 000):
            // 前 2 位    01/10  代表 ModR/M，决定了 寻址方式
            // 中间 3 位  100    代表操作码 JMP 指令
            // 最后 3 位  000    目标寄存器或内存地址(000 代表 RAX 寄存器)
            // 48 FF D0             直接调用 RAX                CALL RAX
            // 48 FF 20             跳转到 [RAX] 存储的地址      JMP QWORD PTR [RAX]
            // 48 FF 60 ??          跳转到 [RAX+??] 存储的地址   JMP QWORD PTR [RAX+??]
            // 48 FF A0 ?? ?? ?? ?? 跳转到 [RAX+??] 存储的地址   JMP QWORD PTR [RAX+??]
            0x60 => *(bodyAddr + BodyPrefix.Length + 1),
            0xA0 => *(int*)(bodyAddr + BodyPrefix.Length + 1),
            _ => -1
        };
        if (vtoff < 0x10 || (vtoff & 7) != 0)
        {
            Service.Log($"unexpected vtoff : {vtoff:X8}");
            return -1;
        }
        // first two vfs are dtor and exec, vtable contains qwords
        // 前两个虚函数为析构函数和执行函数，虚表包含8字节
        return (vtoff >> 3) - 2;
    }

    private void AddMapping(int opcode, int id)
    {
        if (!AddEntry(_opcodeToID, opcode, id))
            Service.Log($"[OpcodeMap] Trying to define several mappings for opcode {opcode} ({ID(opcode)} and ({(PacketID)id})");
        if (!AddEntry(_idToOpcode, id, opcode))
            Service.Log($"[OpcodeMap] Trying to map multiple opcodes to same index {(PacketID)id} ({IDToOpcode[id]} and {opcode})");
    }

    private static bool AddEntry(List<int> list, int index, int value)
    {
        if (list.Count <= index)
            list.AddRange(Enumerable.Repeat(-1, index + 1 - list.Count));
        if (list[index] != -1)
            return false;
        list[index] = value;
        return true;
    }
}

public class OpcodeMapHeader
{
    public nint Func;
    public int MinCase;
    public int JumptableSize;
    public nint DefaultAddr;
    public nint Imagebase;
    public nint Jumptable;

    public OpcodeMapHeader()
    {
    }
}

public class OpcodeMapEntry
{
    public int Index;
    public int VtableIndex = -1;
    public int Opcode = -1;
    public string Name = string.Empty;
    public int Vtoff;
    public nint bodyAddr;
    public nint Jumptable;
}
