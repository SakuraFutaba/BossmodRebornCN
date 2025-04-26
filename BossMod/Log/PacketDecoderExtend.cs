using BossMod.Log;
using BossMod.Network.ClientIPC;
using BossMod.Network.ServerIPC;
using System.Runtime.CompilerServices;

namespace BossMod.Network;

public abstract unsafe partial class PacketDecoder
{
    public ServerIPCNode DecodeServerIPCNode(NetworkState.ServerIPC ipc)
    {
        var node = new ServerIPCNode(ipc);
        // 重构时考虑 Node 里传指针
        var ptr = (byte*)Unsafe.AsPointer(ref ipc.Payload[0]);
        var child = ipc.ID switch
        {
            PacketID.CFRoleInNeed when (CFRoleInNeed*)ptr is var p => new CFRoleInNeedNode(*p),
            PacketID.PFUpdateRecruitNum when (PFUpdateRecruitNum*)ptr is var p => new PFUpdateRecruitNumNode(*p),
            PacketID.Mount when (Mount*)ptr is var p => new MountNode(*p),
            PacketID.SpawnNPC when (SpawnNPC*)ptr is var p => new SpawnNPCNode(*p),
            PacketID.FirstAttack when (FirstAttack*)ptr is var p => new FirstAttackNode(*p),
            PacketID.RemainingPlayTime when (RemainingPlayTime*)ptr is var p => new RemainingPlayTimeNode(*p),
            PacketID.ServerNotice when (ServerNotice*)ptr is var p => new ServerNoticeNode(*p),
            PacketID.ChatReceived when (ChatReceived*)ptr is var p => new ChatReceivedNode(*p),
            _ => DecodePacket(ipc.ID, ptr)?.AsILogNode(),
        };
        if (child != null)
            node.AddChild(child);
        return node;
    }

    public ClientIPCNode DecodeClientIPCNode(NetworkState.ClientIPC ipc)
    {
        var node = new ClientIPCNode(ipc);
        var ptr = (byte*)Unsafe.AsPointer(ref ipc.Payload[0]);
        var child = ipc.ID switch
        {
            PacketID.ChatSent when (ChatSent*)ptr is var p => new ChatSentNode(*p),
            _ => DecodePacket(ipc.ID, ptr)?.AsILogNode(),
        };
        if (child != null)
            node.AddChild(child);
        return node;
    }
}
