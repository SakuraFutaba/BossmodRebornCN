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
        ImGuiEx.TextCopy($"ID of Input Opcode: {opcodeMap.OpcodeToID[opcode]} {opcodeMap.OpcodeToName(opcode)}");
        ImGui.InputInt("id", ref id);
        ImGuiEx.TextCopy($"Opcode of Input ID: {opcodeMap.IDToOpcode[id]} {opcodeMap.IDToName(id)}");

        ImGuiEx.TextCopy($"Func: {opcodeMap.Func:X16}");
        ImGuiEx.TextCopy($"MinCase: {opcodeMap.MinCase}");
        ImGuiEx.TextCopy($"JumptableSize: {opcodeMap.JumptableSize}");
        ImGuiEx.TextCopy($"DefaultAddr: {opcodeMap.DefaultAddr:X16}");
        ImGuiEx.TextCopy($"ImagebaseAddr: {opcodeMap.ImagebaseAddr:X16}");
        ImGuiEx.TextCopy($"JumptableRVA: {opcodeMap.JumptableRVA:X16}");
        ImGuiEx.TextCopy($"JumptableAddr: {opcodeMap.JumptableAddr:X16}");

        // TODO: 提供选项按照 Opcode 排列
        ImGui.BeginTable("Opcode Table", 6, ImGuiTableFlags.Resizable | ImGuiTableFlags.BordersInner | ImGuiTableFlags.RowBg);
        ImGui.TableSetupColumn("VtableIndex");
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Opcode");
        ImGui.TableSetupColumn("Index");
        ImGui.TableSetupColumn("Vtoff");
        ImGui.TableSetupColumn("bodyAddr");
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
            ImGui.TextUnformatted($"{entry.bodyAddr:X16}");
        }
        ImGui.EndTable();
    }
}
