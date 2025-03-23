using ImGuiNET;
using ECommons.ImGuiMethods;
using BossMod.Network;
namespace BossMod;

public class DebugOpcodes
{
    private static readonly OpcodeMap opcodeMap = new();
    private int opcode = opcodeMap.MinCase;
    private int id = 2;
    public void Draw()
    {
        // TODO: 看OpcodeMapTable是否更有效率
        ImGui.InputInt("opcode", ref opcode);
        ImGuiEx.TextCopy($"ID: {opcodeMap.OpcodeToID[opcode]} {opcodeMap.OpcodeToName(opcode)}");
        ImGui.InputInt("id", ref id);
        ImGuiEx.TextCopy($"Opcode: {opcodeMap.IDToOpcode[id]} {opcodeMap.IDToName(id)}");

        ImGui.BeginTable("Opcode Table", 3, ImGuiTableFlags.Resizable | ImGuiTableFlags.BordersInner | ImGuiTableFlags.RowBg);
        ImGui.TableSetupColumn("Field");
        ImGui.TableSetupColumn("Expression");
        ImGui.TableSetupColumn("Value");
        ImGui.TableHeadersRow();

        #region Field/Expression/Value Table
        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("Func");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("ScanText(\"49 8B 40 10 ...\")");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.Func:X16}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("MinCase");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+15]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.MinCase}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableSize");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+17] + 1");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.JumptableSize}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("DefaultRVA");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+23]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.DefaultRVA:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("DefaultAddr Off");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("23 + 4 + [Func+23]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.DefaultAddr - opcodeMap.Func:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("ImagebaseRVA");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+30]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"-{-opcodeMap.ImagebaseRVA:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("ImagebaseAddr");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("Func + 30 + 4 + [Func+30]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.ImagebaseAddr:X16}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableRVA");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+40]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.JumptableRVA:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableAddr Off");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("30 + 4 + [Func+30] + [Func+40]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.JumptableAddr - opcodeMap.Func:X8}");

        ImGui.EndTable();
        #endregion

        if (ImGui.Button("Sort By VtableIndex"))
        {
            opcodeMap.SortByVtableIndex();
        }
        ImGui.SameLine();
        if (ImGui.Button("Sort By Opcode"))
        {
            opcodeMap.SortByOpcode();
        }
        // (byte*) imagebase = ReadRVA(Func + 30) = Func + 30 + 4 + [Func+30]
        // (int*) jumptable = imagebase + [Func + 40] = Func + 30 + 4 + [Func+30] + [Func + 40]
        // jumptable[i] = [jumptable + 4 * i] = [Func + 30 + 4 + [Func+30] + [Func + 40] + 4 * i]
        // (byte*) bodyAddr = imagebase + jumptable[i] = Func + 30 + 4 + [Func+30] + [Func + 30 + 4 + 4 * i + [Func+30] + [Func + 40]]
        // vtoff = [bodyAddr + 9] switch { 0x60 => [bodyAddr + 10], 0xA0 => [(int*)(bodyAddr + 10)]}
        // VtableIndex = (vtoff >> 3) - 2
        // opcode = mincase + i
        //
        // ImagebaseAddr = ReadRVA(func + 30)
        // DefaultAddr = ReadRVA(func + 23)
        // JumptableRVA = *(int*)(Func + 40)
        // ImagebaseAddr + JumptableRVA - Func = 276C
        // DefaultAddr - Func = 23 + 4 + [Func+23] = 2768
        // DefaultAddr = ReadRVA(Func + 23);
        // ImagebaseAddr + JumptableRVA = JumptableAddr = DefaultAddr + 4 = Func + 276C
        // JumptableAddr = ReadRVA(func + 30) + [func + 40]
        // bodyAddrOffset = ((int*)JumptableAddr))[i] = [JumptableAddr + 4 * i]
        // bodyAddr = ImagebaseAddr + bodyAddrOffset
        //          = ImagebaseAddr + [JumptableAddr + 4 * i]
        //          = ImagebaseAddr + [ImagebaseAddr + JumptableRVA + 4 * i]
        //          = ReadRVA(func + 30) + [ReadRVA(func + 30) + [func + 40] + 4 * i]
        // vtoff = [bodyAddr + 9] switch { 0x60 => [bodyAddr + 10], 0xA0 => [(int*)(bodyAddr + 10)]}
        // VtableIndex = (vtoff >> 3) - 2
        // opcode = minCase + i
        //
        // JumptableRVA = *(int*)(Func + 40)
        //              = JumptableAddr - ImagebaseAddr
        // bodyAddrOffset = ((int*)JumptableAddr))[i] = [JumptableAddr + 4 * i]
        //              = [ReadRVA(func + 30) + [func + 40] + 4 * i]
        //              = bodyAddr - ImagebaseAddr
        // JumptableRVA ~= bodyAddrOffset
        // bodyToJumpTable = JumptableAddr - bodyAddr = JumptableRVA - bodyAddrOffset

        // bodyAddrOffset + ImagebaseRVA = [ReadRVA(func + 30) + [func + 40] + 4 * i] + [func + 30]
        //  = bodyAddr - ImagebaseAddr + ImagebaseAddr - func - 30 - 4
        //  = bodyAddr - func - 34

        ImGui.BeginTable("Opcode Table", 7, ImGuiTableFlags.Resizable | ImGuiTableFlags.BordersInner | ImGuiTableFlags.RowBg);
        ImGui.TableSetupColumn("VtableIndex");
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Opcode");
        ImGui.TableSetupColumn("Index");
        ImGui.TableSetupColumn("Vtoff");
        ImGui.TableSetupColumn("bodyAddrOffset(jumptable[i])");
        ImGui.TableSetupColumn("bdOff+ImgRVA-0x10");
        ImGui.TableHeadersRow();
        foreach (var entry in opcodeMap.OpcodeMapTable)
        {
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.VtableIndex}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted(entry.Name);
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.Opcode}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.Index}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.Vtoff}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.bodyAddrOffset:X8}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{opcodeMap.ImagebaseRVA + entry.bodyAddrOffset - 0x10:X8}");
        }
        ImGui.EndTable();
    }
}
