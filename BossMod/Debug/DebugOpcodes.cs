using ImGuiNET;
using ECommons.ImGuiMethods;
using BossMod.Network;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
namespace BossMod;

public class DebugOpcodes
{
    private static readonly OpcodeMap opcodeMap = new();
    private int opcode = opcodeMap.MinCase;
    private int id = 2;

    private string str =
        "E5 AF B9 02 27 01 C9 02 F2 04 99 FF 13 E5 8A A0 E9 9B B7 E9 A9 AC E7 9C 8B E9 97 A8 E7 8B 97 03 E4 BD BF E7 94 A8 E4 BA 86 E5 B0 8F E7 8C AB E4 BA B2 E4 BA B2 3E 33 3C 7E 7E 7E 7E 7E 7E 7E 7E E2 99 A5 E2 99 A5 E2 99 A5";
    private SeString ss = SeString.Parse([0xE5, 0xAF, 0xB9, 0x02, 0x27, 0x01, 0xC9, 0x02, 0xF2, 0x04, 0x99, 0xFF, 0x13, 0xE5, 0x8A, 0xA0, 0xE9, 0x9B, 0xB7, 0xE9, 0xA9, 0xAC, 0xE7, 0x9C, 0x8B, 0xE9, 0x97, 0xA8, 0xE7, 0x8B, 0x97, 0x03, 0xE4, 0xBD, 0xBF, 0xE7, 0x94, 0xA8, 0xE4, 0xBA, 0x86, 0xE5, 0xB0, 0x8F, 0xE7, 0x8C, 0xAB, 0xE4, 0xBA, 0xB2, 0xE4, 0xBA, 0xB2, 0x3E, 0x33, 0x3C, 0x7E, 0x7E, 0x7E, 0x7E, 0x7E, 0x7E, 0x7E, 0x7E, 0xE2, 0x99, 0xA5, 0xE2, 0x99, 0xA5, 0xE2, 0x99, 0xA5
    ]);

    private SeString sigua = "丝瓜卡夫卡";
    private SeString partySigua = "丝瓜卡夫卡";
    private SeString allianceSigua = "丝瓜卡夫卡";
    public void Draw()
    {
        ImGui.InputText("", ref str, 2000);
        ss = SeString.Parse(new Span<byte>(
            str.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(h => Convert.ToByte(h, 16))
                .ToArray()
        ));
        ImGui.Text($"ss : {ss}");
        ImGui.Text($"ss.ToJson : {ss.ToJson()}");
        if (ImGui.Button("Print to Chat Log"))
        {
            Service.ChatGui.Print(ss);
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.TellIncoming,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = SeString.CreateMapLinkWithInstance("陌迪翁牢狱", 3, 3.5f, 3.5f),
                Type = XivChatType.TellOutgoing,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.Say,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.Yell,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.Shout,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.FreeCompany,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.CrossLinkShell8,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.NPCDialogue,
                Name = sigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.Party,
                Name = partySigua,
            });
            Service.ChatGui.Print(new XivChatEntry
            {
                Message = ss,
                Type = XivChatType.Alliance,
                Name = allianceSigua,
            });
        }

        foreach (var payload in ss.Payloads)
        {
            ImGui.Text($"payload.type : {payload.Type} {payload.Encode(force:true).ToHexString()}");
        }
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
        ImGuiEx.TextCopy($"{opcodeMap.Func:X12}");

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
        ImGui.TextUnformatted($"0x{opcodeMap.DefaultRVA:X4}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("DefaultAddr Off");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("23 + 4 + [Func+23]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"0x{opcodeMap.DefaultAddr - opcodeMap.Func:X4}");

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
        ImGuiEx.TextCopy($"{opcodeMap.ImagebaseAddr:X12}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableRVA");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[Func+40]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"{opcodeMap.JumptableRVA:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableAddr");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("Func + 30 + 4 + [Func+30] + [Func+40]");
        ImGui.TableNextColumn();
        ImGuiEx.TextCopy($"0x{opcodeMap.JumptableAddr:X8}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("JumptableAddr Off");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("30 + 4 + [Func+30] + [Func+40]");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted($"0x{opcodeMap.JumptableAddr - opcodeMap.Func:X4}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("VtableAddr");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("GetStaticAddressFromSig(\"48 8D 35 ?? ?? ?? ?? 4C 8B C7 33 D2\")");
        ImGui.TableNextColumn();
        ImGuiEx.TextCopy($"{opcodeMap.VtableAddr:X12}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("VtableAddrDebug");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("ScanText(\"48 8D 35 ?? ?? ?? ?? 4C 8B C7 33 D2\")");
        ImGui.TableNextColumn();
        ImGuiEx.TextCopy($"{opcodeMap.VtableAddrDebug:X12}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("VtableAddrDebug2");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("VtableAddrDebug + 7 + [VtableAddrDebug + 3]");
        ImGui.TableNextColumn();
        ImGuiEx.TextCopy($"{opcodeMap.VtableAddrDebug2:X12}");

        ImGui.TableNextRow();
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("VtableAddrDebug3");
        ImGui.TableNextColumn();
        ImGui.TextUnformatted("[VtableAddrDebug2]");
        ImGui.TableNextColumn();
        ImGuiEx.TextCopy($"{opcodeMap.VtableAddrDebug3:X12}");

        ImGui.EndTable();
        #endregion

        if (ImGui.Button("Sort By VtableIndex"))
            opcodeMap.SortByVtableIndex();
        ImGui.SameLine();
        if (ImGui.Button("Sort By Opcode"))
            opcodeMap.SortByOpcode();

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

        // for opcode in range(101,999)
        // i = opcode - 101;
        // ImagebaseAddr = RVA(Func+30);
        // jumptableAddr = ImagebaseAddr + [Func+40];
        // bodyAddr = ImagebaseAddr + jumptable[i];
        // vtoff = bodyAddr[9] switch { 0x60 => bodyAddr[10], 0xA0 => (int*)bodyAddr[10] };
        // id = vtoff >> 8 - 2;

        ImGui.BeginTable("Opcode Table", 8, ImGuiTableFlags.Resizable | ImGuiTableFlags.BordersInner | ImGuiTableFlags.RowBg);
        ImGui.TableSetupColumn("VtableIndex");
        ImGui.TableSetupColumn("Name");
        ImGui.TableSetupColumn("Opcode");
        ImGui.TableSetupColumn("Index");
        ImGui.TableSetupColumn("Vtoff");
        ImGui.TableSetupColumn("bodyAddrOffset(jumptable[i])");
        // ImGui.TableSetupColumn("bdOff+ImgRVA-0x10");
        ImGui.TableSetupColumn("VtAddr");
        ImGui.TableSetupColumn("VtAddrValue");
        // ImGui.TableSetupColumn("VtAddrIDA");
        ImGui.TableHeadersRow();
        foreach (var entry in opcodeMap.OpcodeMapTable)
        {
            ImGui.TableNextRow();
            ImGui.TableNextColumn();
            ImGuiEx.TextCopy($"{entry.VtableIndex}");
            ImGui.TableNextColumn();
            ImGuiEx.TextCopy(entry.Name);
            ImGui.TableNextColumn();
            ImGuiEx.TextCopy($"{entry.Opcode}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.Index}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"0x{entry.Vtoff:X4} / {entry.Vtoff}");
            ImGui.TableNextColumn();
            ImGui.TextUnformatted($"{entry.bodyAddrOffset:X8}");
            ImGui.TableNextColumn();
            ImGuiEx.TextCopy($"{entry.VtableFuncAddr:X12}");
            ImGui.TableNextColumn();
            ImGuiEx.TextCopy($"{entry.VtableFuncValue:X16}");
            // ImGui.TableNextColumn();
            // ImGuiEx.TextCopy($"{entry.VtableFuncAddr - opcodeMap.ImagebaseAddr + 0x140000000:X8}");
            // ImGui.TableNextColumn();
            // ImGui.TextUnformatted($"{opcodeMap.ImagebaseRVA + entry.bodyAddrOffset - 0x10:X4}");
        }
        ImGui.EndTable();
    }
}
