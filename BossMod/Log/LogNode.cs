using ImGuiNET;
using BossMod.Network;
using BossMod.Network.ClientIPC;
using BossMod.Network.ServerIPC;
using Dalamud.Interface.Colors;
using Dalamud.Memory;
using Dalamud.Game.Text.SeStringHandling;
using ECommons.ImGuiMethods;

namespace BossMod.Log;

public interface ILogNode
{
    List<ILogNode> Children { get; }
    bool IsLeaf => Children.Count == 0;
    ILogNode AddChild(ILogNode child)
    {
        Children.Add(child);
        return child;
    }
    void Draw();
    void Draw(LogUITree tree) => Draw();
}

public class LogNode<T>(T value) : ILogNode
{
    public T Value { get; } = value;
    public List<ILogNode> Children { get; } = [];

    public virtual void Draw()
    {
        var type = typeof(T);
        var fields = type.GetFields();
        var count = 0;
        foreach (var field in fields)
        {
            ImGui.TextColored(LogColor.Property, $"{field.Name}: ");
            ImGui.SameLine(0, 0);
            var value = field.GetValue(Value);
            var formattedValue = value switch
            {
                ulong ulongValue => $"{ulongValue:X16} ",
                uint uintValue and >= 1 << 25 => $"{uintValue:X8} ",
                _ => $"{value} "
            };
            ImGui.TextColored(LogColor.Number, formattedValue);
            ImGui.SameLine(0, 0);

            count++;
            if (count % 20 == 0) ImGui.NewLine();
        }
        ImGui.NewLine();
    }
}

public static class TextNodeExtensions
{
    public static ILogNode AsILogNode(this PacketDecoder.TextNode node)
    {
        return new TextNodeAdapter(node);
    }
    private class TextNodeAdapter : LogNode<string>
    {
        public TextNodeAdapter(PacketDecoder.TextNode node) : base(node.Text)
        {
            node.Children?.ForEach(child => Children.Add(child.AsILogNode()));
        }
        public override void Draw()
        {
            ImGui.Text(Value);
        }
    }
}

public class ServerIPCNode(NetworkState.ServerIPC ipc) : LogNode<NetworkState.ServerIPC>(ipc)
{
    private readonly DateTimeOffset _now = DateTimeOffset.Now;
    private string _payloadStr = ipc.Payload.ToHexString();
    private readonly GameObjectInfo? _info = new();

    private void DrawTime()
    {
        ImGui.TextColored(ImGuiColors.DalamudGrey, $"[{_now:HH:mm:ss.fff}] ");
    }
    private void DrawPackedID(PacketID id)
    {
        var isDefined = Enum.IsDefined(typeof(PacketID), id);
        var color = isDefined ? ImGuiColors.ParsedGold : ImGuiColors.DalamudRed;
        ImGuiEx.TextCopy(color, $"{id} ");
        ImGuiEx.Tooltip(isDefined ? $"id: {(int)id} opcode: {ipc.Opcode}" : $"opcode: {ipc.Opcode}");
        if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            ImGui.OpenPopup($"PacketIDMenu##{GetHashCode()}");
        if (ImGui.BeginPopup($"PacketIDMenu##{GetHashCode()}"))
        {
            if (ImGui.MenuItem($"only log this PacketID")) LogWindow.AddToLogWhiteList(id);
            if (ImGui.MenuItem($"dont log this PacketID")) LogWindow.AddToLogBlackList(id);
            if (ImGui.MenuItem($"only show this PacketID")) LogWindow.AddToDrawWhiteList(id);
            if (ImGui.MenuItem($"dont show this PacketID")) LogWindow.AddToDrawBlackList(id);
            ImGui.EndPopup();
        }
    }
    private void DrawActorInfo()
    {
        ImGui.TextColored(ImGuiColors.HealerGreen, ObjectString(Value.SourceServerActor));
        if (ImGui.IsItemHovered())
        {
            ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
            ImGui.BeginTooltip();
            ImGui.TextUnformatted($"""
                                   Name: {_info?.Name}
                                   EntityId: {_info?.EntityId:X8}
                                   DataId: {_info?.DataId:X4}
                                   ObjectKind: {_info?.ObjectKind}
                                   OwnerId: {_info?.OwnerId:X8}
                                   OwnerName: {_info?.OwnerName}
                                   """);
            ImGui.EndTooltip();
        }
    }
    private void DrawPayload(byte[] payload)
    {
        ImGuiEx.TextWrappedCopy(ImGuiColors.DalamudGrey, _payloadStr);
        if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            ImGui.OpenPopup($"PayloadMenu##{GetHashCode()}");
        if (ImGui.BeginPopup($"PayloadMenu##{GetHashCode()}"))
        {
            if (ImGui.MenuItem($"Convert to Byte")) _payloadStr = payload.ToByteString();
            if (ImGui.MenuItem($"Convert to Ushort")) _payloadStr = payload.ToUshortString();
            if (ImGui.MenuItem($"Convert to Int")) _payloadStr = payload.ToIntString();
            if (ImGui.MenuItem($"Convert to UInt")) _payloadStr = payload.ToUIntString();
            if (ImGui.MenuItem($"Convert to Float")) _payloadStr = payload.ToFloatString();
            if (ImGui.MenuItem($"Convert to Ulong")) _payloadStr = payload.ToUlongString();
            if (ImGui.MenuItem($"Raw Data")) _payloadStr = payload.ToHexString();
            ImGui.EndPopup();
        }
    }
    public ILogNode AddChild(ILogNode child)
    {
        Children.Add(child);
        return child;
    }
    private string ObjectString(ulong id) => $"'{_info?.Name ?? "(not found)"}' <{id:X}> ";
    public override void Draw()
    {
        DrawTime();
        _info?.UpdateGameObjectInfoByEntityID(Value.SourceServerActor);
        ImGui.SameLine(0, 0);
        ImGui.TextColored(ImGuiColors.HealerGreen, "Server IPC ");
        ImGui.SameLine(0, 0);
        DrawPackedID(Value.ID);
        ImGui.SameLine(0, 0);
        DrawActorInfo();
        // ImGui.SameLine(0, 0);
        // ImGui.Text($", sent {(_now - Value.SendTimestamp).TotalMilliseconds:f3}ms ago, epoch={Value.Epoch}, data=");
        ImGui.SameLine(0, 0);
        DrawPayload(Value.Payload);
    }
}

// 不够优雅，待重构
// Server Client 共通的部分换成接口实现再继承
// Node 里考虑传指针 IPCNode(*ipc)
public class ClientIPCNode(NetworkState.ClientIPC ipc) : LogNode<NetworkState.ClientIPC>(ipc)
{
    private readonly DateTimeOffset _now = DateTimeOffset.Now;
    private string _payloadStr = ipc.Payload.ToHexString();

    private void DrawTime()
    {
        ImGui.TextColored(ImGuiColors.DalamudGrey, $"[{_now:HH:mm:ss.fff}] ");
    }
    private void DrawPackedID(PacketID id)
    {
        var isDefined = Enum.IsDefined(typeof(PacketID), id);
        var color = isDefined ? ImGuiColors.ParsedGold : ImGuiColors.DalamudRed;
        ImGuiEx.TextCopy(color, $"{id} ");
        ImGuiEx.Tooltip(isDefined ? $"id: {(int)id} opcode: {ipc.Opcode}" : $"opcode: {ipc.Opcode}");
        if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            ImGui.OpenPopup($"PacketIDMenu##{GetHashCode()}");
        if (ImGui.BeginPopup($"PacketIDMenu##{GetHashCode()}"))
        {
            if (ImGui.MenuItem($"only log this PacketID")) LogWindow.AddToLogWhiteList(id);
            if (ImGui.MenuItem($"dont log this PacketID")) LogWindow.AddToLogBlackList(id);
            if (ImGui.MenuItem($"only show this PacketID")) LogWindow.AddToDrawWhiteList(id);
            if (ImGui.MenuItem($"dont show this PacketID")) LogWindow.AddToDrawBlackList(id);
            ImGui.EndPopup();
        }
    }
    private void DrawPayload(byte[] payload)
    {
        ImGuiEx.TextWrappedCopy(ImGuiColors.DalamudGrey, _payloadStr);
        if (ImGui.IsItemClicked(ImGuiMouseButton.Right))
            ImGui.OpenPopup($"PayloadMenu##{GetHashCode()}");
        if (ImGui.BeginPopup($"PayloadMenu##{GetHashCode()}"))
        {
            if (ImGui.MenuItem($"Convert to Byte")) _payloadStr = payload.ToByteString();
            if (ImGui.MenuItem($"Convert to Ushort")) _payloadStr = payload.ToUshortString();
            if (ImGui.MenuItem($"Convert to Int")) _payloadStr = payload.ToIntString();
            if (ImGui.MenuItem($"Convert to UInt")) _payloadStr = payload.ToUIntString();
            if (ImGui.MenuItem($"Convert to Float")) _payloadStr = payload.ToFloatString();
            if (ImGui.MenuItem($"Convert to Ulong")) _payloadStr = payload.ToUlongString();
            if (ImGui.MenuItem($"Raw Data")) _payloadStr = payload.ToHexString();
            ImGui.EndPopup();
        }
    }
    public ILogNode AddChild(ILogNode child)
    {
        Children.Add(child);
        return child;
    }
    public override void Draw()
    {
        DrawTime();
        ImGui.SameLine(0, 0);
        ImGui.TextColored(ImGuiColors.DalamudViolet, "Client IPC ");
        ImGui.SameLine(0, 0);
        DrawPackedID(Value.ID);
        ImGui.SameLine(0, 0);
        DrawPayload(Value.Payload);
    }
}
public unsafe class CountdownNode(Countdown x) : LogNode<Countdown>(x)
{
    public override void Draw()
    {
        ImGui.Text($"Countdown: Sender={Value.SenderID}, Time={Value.Time}");
    }
}

public class CFRoleInNeedNode(CFRoleInNeed x) : LogNode<CFRoleInNeed>(x)
{
    public override void Draw()
    {
        var type = typeof(CFRoleInNeed);
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            ImGui.TextColored(LogColor.Property,$"{field.Name}: ");
            ImGui.SameLine(0, 0);
            var color = field.GetValue(Value) switch
            {
                CFRole.Tank => ImGuiColors.TankBlue,
                CFRole.Healer => ImGuiColors.HealerGreen,
                CFRole.DPS => ImGuiColors.DPSRed,
                CFRole.DPS2 => ImGuiColors.DPSRed,
                _ => LogColor.Number,
            };
            ImGui.TextColored(color, field.GetValue(Value)?.ToString());
            ImGui.SameLine();
        }
        ImGui.NewLine();
    }
}

public class PFUpdateRecruitNumNode(PFUpdateRecruitNum x) : LogNode<PFUpdateRecruitNum>(x)
{
}

public class MountNode(Mount x) : LogNode<Mount>(x)
{
    public override void Draw()
    {
        var mountName =
            (Service.LuminaRow<Lumina.Excel.Sheets.Mount>(Value.MountID)?.Singular.ToString() ?? "<not found>") + $"({Value.MountID}) ";
        ImGui.TextColored(LogColor.Property, "Mount: ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.String, mountName);
        if (Value.MountID == 1)
        {
            var color = Service.LuminaRow<Lumina.Excel.Sheets.Stain>(Value.StainID)?.Color ?? 0xBDBDBD;
            var colorName = Service.LuminaRow<Lumina.Excel.Sheets.Stain>(Value.StainID)?.Name.ToString();
            ImGui.SameLine(0, 0);
            ImGui.TextColored(Utils.UIntToImGuiColor(color), $"Color: {colorName}#{color:X6} ModelTop: {Value.ModelTop} ModelBody: {Value.ModelBody} ModelLegs: {Value.ModelLegs}");
        }
    }
}

public unsafe class SpawnNPCNode(SpawnNPC x) : LogNode<SpawnNPC>(x)
{
    public override void Draw()
    {
        base.Draw();
        var value = Value;
        var p = (IntPtr)value.NPCName;
        var str = MemoryHelper.ReadString(p, 74);
        ImGui.TextColored(LogColor.String, str);
    }
}

public class FirstAttackNode(FirstAttack x) : LogNode<FirstAttack>(x)
{
    private readonly GameObjectInfo _info = new();
    public override void Draw()
    {
        ImGui.TextColored(LogColor.Property, "type: ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Enum, Value.Type.ToString());
        switch (Value.Type)
        {
            case 0:
                return;
            case 1:
                ImGui.SameLine(0, 0);
                ImGui.TextColored(LogColor.Property, _info.ObjectAndOwnerString(Value.ID));
                break;
            case 2:
                ImGui.SameLine(0, 0);
                ImGui.TextColored(LogColor.Property, $"{Value.ID:X8} {Value.U2:X8}");
                break;
        }
    }
}

public class RemainingPlayTimeNode(RemainingPlayTime x) : LogNode<RemainingPlayTime>(x)
{
    public override void Draw()
    {
        ImGui.TextColored(LogColor.Inactive, "包月时间：剩余 ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Number, $"{Value.Days / 60:D2}");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Inactive, $" 分 ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Number, $"{Value.Days % 60:D2}");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Inactive, $" 秒 点卡时间：剩余 ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Number, $"{Value.Minutes / 60:D2}");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Inactive, $" 分 ");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Number, $"{Value.Minutes % 60:D2}");
        ImGui.SameLine(0, 0);
        ImGui.TextColored(LogColor.Inactive, $" 秒");
    }
}

public unsafe class ServerNoticeNode(ServerNotice x) : LogNode<ServerNotice>(x)
{
    public override void Draw()
    {
        var value = Value;
        ImGui.TextColored(LogColor.Inactive, MemoryHelper.ReadString((IntPtr)value.Message, 700));
    }
}

public unsafe class ChatSentNode(ChatSent x) : LogNode<ChatSent>(x)
{
    public override void Draw()
    {
        var value = Value;
        var color = value.MessageType switch
        {
            0x0A => LogColor.Say,
            0x0B => LogColor.Shout,
            0x1C => LogColor.Emote,
            0x1E => LogColor.Yell,
            _ => LogColor.Error
        };
        var msg = SeString.Parse(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(value.Message));
        ImGui.TextColored(LogColor.Number, $"MessageType : {value.MessageType:X2}");
        ImGuiEx.TextCopy(color, $"{value.EntityId:X8} : {msg}");
    }
}

public unsafe class ChatReceivedNode(ChatReceived x) : LogNode<ChatReceived>(x)
{
    public override void Draw()
    {
        var value = Value;
        var worldName = Service.LuminaRow<Lumina.Excel.Sheets.World>(Value.WorldId)?.Name.ToString();
        var color = value.MessageType switch
        {
            0x0A => LogColor.Say,
            0x0B => LogColor.Shout,
            0x1C => LogColor.Emote,
            0x1E => LogColor.Yell,
            _ => LogColor.Error
        };
        // 这个 Opcode Payload 包含的 SeString 为 02 2E 开头
        // 在 Dalamud/Game/Text/SeStringHandling/Payload.cs 会被识别成定型文
        // 需要改 Dalamud 本体逻辑，先开摆了
        ImGuiEx.TextCopy(color, $"{SeString.Parse(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(value.Name))}@{worldName}<{value.EntityId:X8}> : {SeString.Parse(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(value.Message))}");
        ImGuiEx.TextCopy(LogColor.Number, $"MessageType: {value.MessageType:X2}");
    }
}
