namespace BossMod.Endwalker.Dungeon.D04Ktisis.D041Lyssa;

public enum OID : uint
{
    Boss = 0x3323,
    Helper = 0x233C,
    IcePillar = 0x3324, // R2.000, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 6497, // Boss->player, no cast, single-target
    FrigidStomp = 25181, // Boss->self, 5.0s cast, range 50 circle
    FrostbiteAndSeek = 25175, // Boss->self, 3.0s cast, single-target
    HeavySmash = 25180, // Boss->players, 5.0s cast, range 6 circle
    IcePillar = 25179, // IcePillar->self, 3.0s cast, range 4 circle
    Icicall = 25178, // Boss->self, 3.0s cast, single-target
    PillarPierce = 25375, // IcePillar->self, 5.0s cast, range 80 width 4 rect
    PunishingSlice1 = 25176, // Boss->self, no cast, single-target
    PunishingSlice2 = 25177, // Helper->self, 2.0s cast, range 50 width 50 rect
    SkullDasher = 25182, // Boss->player, 5.0s cast, single-target
    Unknown = 28304, // Helper->self, no cast, single-target
}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_62 = 62, // player
}

class D041LyssaStates : StateMachineBuilder
{
    public D041LyssaStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 787, NameID = 10396)] // 
public class D041Lyssa(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-134, 54), 20));