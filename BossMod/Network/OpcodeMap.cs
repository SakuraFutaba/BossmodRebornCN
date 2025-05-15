using BossMod.Log;
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
    public readonly nint VtableAddr;
    public readonly nint ZoneBaseInstance;
    public readonly nint VtableAddrDebug;
    public readonly nint VtableAddrDebug2;
    public readonly nint VtableAddrDebug3;
    public readonly nint VtableAddrDebug4;
    public readonly nint VtableAddrDebug5;
    public readonly nint VtableAddrDebug6;
    public readonly nint VtableAddrDebug7;
    public readonly nint VtableAddrDebug8;
    public readonly nint VtableAddrDebug9;
    public readonly int MinCase;
    public readonly int JumptableSize;
    public readonly nint DefaultRVA;
    public readonly nint DefaultAddr;
    public readonly nint ImagebaseRVA;
    public readonly nint ImagebaseAddr;
    public readonly nint JumptableRVA;
    public readonly nint JumptableAddr;
    public readonly nint JumpTableZoneDown;

    public readonly nint VtableAddrOffset;

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
        JumptableSize = Marshal.ReadInt32(Func + 17) + 1;
        DefaultRVA = Marshal.ReadInt32(Func + 23);
        DefaultAddr = ReadRVA(Func + 23);
        ImagebaseRVA = Marshal.ReadInt32(Func + 30);
        ImagebaseAddr = ReadRVA(Func + 30);
        JumptableRVA = Marshal.ReadInt32(Func + 40);
        JumptableAddr = ImagebaseAddr + JumptableRVA;
        // if (Service.SigScanner.TryScanText("4C 89 B4 24 D8 00 00 00 41 8B 8C 80 ?? ?? ?? ??", out var addr) // 7.15
        //     || Service.SigScanner.TryScanText("48 8D 15 ?? ?? ?? ?? 49 63 C7 8B 8C 82 ?? ?? ?? ??", out addr)) // 7.21
        // {
        //     JumpTableZoneDown = ImagebaseAddr + Marshal.ReadInt32(addr + 12); // 7.15
        //     // JumpTableZoneDown = ImagebaseAddr + Marshal.ReadInt32(addr + 13); // 7.21
        // }
        JumpTableZoneDown = ImagebaseAddr + Marshal.ReadInt32(Service.SigScanner.ScanText("4C 89 B4 24 D8 00 00 00 41 8B 8C 80 ?? ?? ?? ??") + 12); // 7.15


        // VtableAddr = Marshal.ReadIntPtr(Service.SigScanner.GetStaticAddressFromSig("48 8D 35 ?? ?? ?? ?? 4C 8B C7 33 D2"));
        VtableAddr = Service.SigScanner.GetStaticAddressFromSig("48 8D 35 ?? ?? ?? ?? 4C 8B C7 33 D2");
        VtableAddrDebug = Service.SigScanner.ScanText("48 8D 35 ?? ?? ?? ?? 4C 8B C7 33 D2 48 89 74 24 30 48 8D 4C 24 30 E8 ?? ?? ?? ??");
        VtableAddrDebug2 = Service.SigScanner.ResolveRelativeAddress(VtableAddrDebug + 7, Marshal.ReadInt32(VtableAddrDebug + 3));
        VtableAddrDebug3 = Marshal.ReadIntPtr(VtableAddrDebug2);
        ZoneBaseInstance = Service.SigScanner.GetStaticAddressFromSig("C7 83 10 01 00 00 03 00 00 00 48 8D 4C 24 ?? 48 89 74 24 ?? E8 ?? ?? ?? ??", 21);
        VtableAddrDebug4 = Service.SigScanner.ScanText("C7 83 10 01 00 00 03 00 00 00 48 8D 4C 24 ?? 48 89 74 24 ?? E8 ?? ?? ?? ??");
        VtableAddrDebug5 = Service.SigScanner.ResolveRelativeAddress(VtableAddrDebug4 + 25, Marshal.ReadInt32(VtableAddrDebug4 + 21));
        VtableAddrDebug6 = Service.SigScanner.ResolveRelativeAddress(VtableAddrDebug5 + 7, Marshal.ReadInt32(VtableAddrDebug5 + 3));


        LogWindow.Log($"ZoneBaseInstance: {ZoneBaseInstance:X12}");
        LogWindow.Log($"debug4: {VtableAddrDebug4:X12}");
        LogWindow.Log($"debug5: {VtableAddrDebug5:X12}");
        LogWindow.Log($"debug6: {VtableAddrDebug6:X12}");
        LogWindow.Log($"debug7: {VtableAddrDebug7:X12}");
        LogWindow.Log($"JumpTableZoneDown: {JumpTableZoneDown:X12}");
        LogWindow.Log($"DEBUG: {Service.SigScanner.ScanText("4C 89 B4 24 D8 00 00 00 41 8B 8C 80 ?? ?? ?? ??"):X12}");
        LogWindow.Log($"DEBUG: {JumpTableZoneDown:X12}");

        for (var i = 0; i < jumptableSize; ++i)
        {
            var bodyAddr = imagebase + jumptable[i];
            if (bodyAddr == defaultAddr) // 纯虚函数占位
                continue;

            var opcode = minCase + i;
            var index = ReadIndexForCaseBody(bodyAddr, out _);
            if (index < 0)
                Service.Log($"[OpcodeMap] Unexpected body for opcode {opcode}");
            else
                AddMapping(opcode, index);

            // OpcodeMapEntry
            OpcodeMapEntry entry = new OpcodeMapEntry();
            entry.Index = i;
            entry.bodyAddrOffset = jumptable[i];
            entry.Opcode = MinCase + entry.Index;
            entry.VtableIndex = ReadIndexForCaseBody(bodyAddr, out entry.Vtoff);
            entry.Name = IDToName(entry.VtableIndex);
            entry.ZoneVfAddr = Marshal.ReadIntPtr(VtableAddr, entry.Vtoff);
            entry.ZoneFuncAddr = ImagebaseAddr + Marshal.ReadInt32(JumpTableZoneDown, i * 4);
            // entry.ZoneFuncAddr = JumpTableZoneDown;
            _opcodeMapTable.Add(entry);
        }

        var addressDict = _opcodeMapTable
            .Select(e => e.ZoneFuncAddr)
            .Distinct()
            .OrderBy(addr => addr)
            .Pairwise()
            .ToDictionary(pair => pair.Item1, pair => (int)(pair.Item2 - pair.Item1));

        _opcodeMapTable
            .OrderBy(entry => entry.ZoneFuncAddr)
            .Where(e => addressDict.ContainsKey(e.ZoneFuncAddr))
            .ToList()
            .ForEach(entry =>
            {
                entry.ZoneFuncInsLength = addressDict[entry.ZoneFuncAddr];
                entry.ZoneFuncIns = new byte[entry.ZoneFuncInsLength];
                Marshal.Copy(entry.ZoneFuncAddr, entry.ZoneFuncIns, 0, entry.ZoneFuncInsLength);
            });
        SortByFuncAddr();
    }
    public void SortByVtableIndex()
    {
        _opcodeMapTable.Sort((a, b) => a.VtableIndex - b.VtableIndex);
    }
    public void SortByOpcode()
    {
        _opcodeMapTable.Sort((a, b) => a.Opcode - b.Opcode);
    }
    public void SortByFuncAddr()
    {
        _opcodeMapTable.Sort((a, b) => (int)(a.ZoneFuncAddr - b.ZoneFuncAddr));
    }

    private static unsafe byte* ReadRVA(byte* p) => p + 4 + *(int*)p;
    private static unsafe nint ReadRVA(nint p) => p + 4 + *(int*)p;

    // assume each case has the following body:
    // mov rax, [rcx]               48 8B 01
    // lea r9, [r10+10h]            4D 8D 4A 10
    // jmp qword ptr [rax+<vfoff>]  48 FF 60/A0 vfoff
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
            return -12;
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
            _ => -13
        };
        if (vtoff < 0x10 || (vtoff & 7) != 0)
        {
            Service.Log($"unexpected vtoff : {vtoff:X8}");
            return -14;
        }
        // first two vfs are dtor and exec, vtable contains qwords
        // 前两个虚函数为析构函数和执行函数，虚表包含很多8字节地址
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

    public unsafe ushort FindOpcodeOfJumpTableValue(int value)
    {
        for (var i = 0; i < JumptableSize; i++)
        {
            if (*(int*)(JumptableAddr + 4 * i) == value)
            {
                return (ushort)(i + 101);
            }
        }
        return 0;
    }
}

public class OpcodeMapEntry
{
    public int Index;
    public int VtableIndex = -11;
    public int Opcode = -1;
    public string Name = string.Empty;
    public int Vtoff;
    public nint bodyAddrOffset;
    public nint ZoneVfAddr = IntPtr.Zero;
    public nint ZoneFuncAddr = IntPtr.Zero;
    public int ZoneFuncInsLength;
    public byte[] ZoneFuncIns = [];
}
