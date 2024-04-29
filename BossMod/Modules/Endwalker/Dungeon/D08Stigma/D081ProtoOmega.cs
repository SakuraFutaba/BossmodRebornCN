namespace BossMod.Endwalker.Dungeon.D08Stigma.D081ProtoOmega;

public enum OID : uint
{
    Boss = 0x3417,
    Helper = 0x233C,
    MarkIIGuidedMissile = 0x3418, // R1.000, x0 (spawn during fight)
    Actor1eb24e = 0x1EB24E, // R0.500, x0 (spawn during fight), EventObj type
    Actor1e8d9b = 0x1E8D9B, // R0.500, x0 (spawn during fight), EventObj type
}

public enum AID : uint
{
    AutoAttack = 872, // Boss->player, no cast, single-target
    Burn = 25385, // Helper->player, no cast, range 6 circle
    ChemicalMissile = 25384, // Boss->self, 3.0s cast, single-target
    ElectricSlide = 25386, // Boss->players, 5.0s cast, range 6 circle
    GuidedMissile = 25382, // Boss->self, 3.0s cast, single-target
    IronKiss = 25383, // MarkIIGuidedMissile->self, no cast, range 3 circle
    MustardBomb = 25387, // Boss->player, 5.0s cast, range 5 circle
    SideCannons1 = 25376, // Boss->self, 7.0s cast, range 60 180-degree cone
    SideCannons2 = 25377, // Boss->self, 7.0s cast, range 60 180-degree cone
}

public enum SID : uint
{
    VulnerabilityUp = 1789, // MarkIIGuidedMissile->player, extra=0x1
    Burns = 2194, // none->player, extra=0x0
    Bleeding = 2088, // Boss->player, extra=0x0

}

public enum IconID : uint
{
    Icon_139 = 139, // player
    Icon_289 = 289, // player
    Icon_218 = 218, // player
}

public enum TetherID : uint
{
    Tether_17 = 17, // MarkIIGuidedMissile->player
}

class D081ProtoOmegaStates : StateMachineBuilder
{
    public D081ProtoOmegaStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 784, NameID = 10401)] // 
public class D081ProtoOmega(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-150, -140), 20));