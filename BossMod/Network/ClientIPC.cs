using System.Runtime.InteropServices;

namespace BossMod.Network.ClientIPC;

public enum ClientPacketID
{
    Ping = 0,
    Init = 1,
    PFRecruitCancel = 19,
    PFRecruitStart = 37,
    ChatSent = 89,
    MarketBoardRequestItemListingInfo = 122,
    MarketBoardPurchaseHandler = 125,
    ClientTrigger = 180,
    UseAction = 183,
    UpdatePositionHandler = 187,
    InventoryModifyHandler = 195,
    UpdatePositionInstance = 265,
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionRequest
{
    public byte ActionProcState; // see ActionManager.GetAdjustedCastTime implementation, last optional arg
    public ActionType Type;
    public ushort u1;
    public uint ActionID;
    public ushort Sequence;
    public ushort IntCasterRot; // 0 = N, increases CCW, 0xFFFF = 2pi
    public ushort IntDirToTarget; // 0 = N, increases CCW, 0xFFFF = 2pi
    public ushort u3;
    public ulong TargetID;
    public ushort ItemSourceSlot;
    public ushort ItemSourceContainer;
    public uint u4;
    public ulong u5;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionRequestGroundTargeted
{
    public byte ActionProcState; // see ActionManager.GetAdjustedCastTime implementation, last optional arg
    public ActionType Type;
    public ushort u1;
    public uint ActionID;
    public ushort Sequence;
    public ushort IntCasterRot; // 0 = N, increases CCW, 0xFFFF = 2pi
    public ushort IntDirToTarget; // 0 = N, increases CCW, 0xFFFF = 2pi
    public ushort u3;
    public float LocX;
    public float LocY;
    public float LocZ;
    public uint u4;
    public ulong u5;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ChatSent
{
    public uint Unk1;
    public uint EntityId;
    public uint Unk3;
    public uint Unk4;
    public uint Unk5;
    public uint Unk6;
    public ushort MessageType;
    public fixed byte Message[1024]; // 1030
}
