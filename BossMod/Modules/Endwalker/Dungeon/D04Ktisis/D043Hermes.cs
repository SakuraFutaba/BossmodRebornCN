namespace BossMod.Endwalker.Dungeon.D04Ktisis.D043Hermes;

public enum OID : uint
{
    Boss = 0x348A, // R4.200, x1
    Helper = 0x233C, // R0.500, x12, 523 type
    Meteor = 0x348C, // R2.400, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 872, // Boss->player, no cast, single-target
    CosmicKiss = 25891, // Meteor->self, 5.0s cast, range 40 circle
    Double = 25892, // Boss->self, 3.0s cast, single-target
    Hermetica1 = 25888, // Boss->self, 3.0s cast, single-target
    Hermetica2 = 25893, // Boss->self, 6.0s cast, single-target
    Hermetica3 = 25895, // Boss->self, 12.0s cast, single-target
    Meteor = 25890, // Boss->self, 3.0s cast, single-target
    Quadruple = 25894, // Boss->self, 3.0s cast, single-target
    Trismegistos = 25886, // Boss->self, 5.0s cast, range 40 circle
    TrueAero1 = 25899, // Boss->self, 5.0s cast, single-target
    TrueAero2 = 25900, // Helper->player, no cast, range 40 width 6 rect
    TrueAero3 = 25901, // Helper->self, 2.5s cast, range 40 width 6 rect
    TrueAeroII1 = 25896, // Boss->self, 5.0s cast, single-target
    TrueAeroII2 = 25897, // Helper->player, 5.0s cast, range 6 circle
    TrueAeroII3 = 25898, // Helper->location, 3.5s cast, range 6 circle
    TrueAeroIV1 = 25889, // 348B->self, 4.0s cast, range 50 width 10 rect
    TrueAeroIV2 = 27836, // 348B->self, 4.0s cast, range 50 width 10 rect
    TrueAeroIV3 = 27837, // 348B->self, 10.0s cast, range 50 width 10 rect
    TrueBravery = 25907, // Boss->self, 5.0s cast, single-target
    TrueTornado1 = 25902, // Boss->self, 5.0s cast, single-target
    TrueTornado2 = 25903, // Boss->self, no cast, single-target
    TrueTornado3 = 25904, // Boss->self, no cast, single-target
    TrueTornado4 = 25905, // Helper->player, no cast, range 4 circle
    TrueTornado5 = 25906, // Helper->location, 2.5s cast, range 4 circle
    UnknownAbility = 25887, // Helper->player, no cast, single-target
}

public enum SID : uint
{
    Double = 661, // Boss->Boss, extra=0x0
    VulnerabilityUp = 1789, // Helper->player, extra=0x1
    Quadruple = 2732, // Boss->Boss, extra=0x0

}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_139 = 139, // player
}

public enum TetherID : uint
{
    Tether_160 = 160, // 348B->Boss
}

class D043HermesStates : StateMachineBuilder
{
    public D043HermesStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 787, NameID = 10363)] // 10399
public class D043Hermes(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(0, -50), 20));