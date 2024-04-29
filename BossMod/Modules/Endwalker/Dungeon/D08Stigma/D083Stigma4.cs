namespace BossMod.Endwalker.Dungeon.D08Stigma.D083Stigma4;

public enum OID : uint
{
    Boss = 0x3428,
    Helper = 0x233C,
    OmegaFrame = 0x342A, // R8.995, x0 (spawn during fight)
    HybridDragon = 0x342B, // R5.000, x0 (spawn during fight)
    ProtoRocketPunch = 0x3429, // R2.500, x0 (spawn during fight)
}
public enum AID : uint
{
    AITakeover = 25641, // Boss->self, 5.0s cast, single-target
    AtomicRay = 25654, // Boss->self, 5.0s cast, range 50 circle
    ElectromagneticRelease1 = 25649, // Boss->self, no cast, single-target
    ElectromagneticRelease2 = 25650, // Helper->self, 10.0s cast, range ?-60 donut
    ElectromagneticRelease3 = 25651, // Boss->self, no cast, single-target
    ElectromagneticRelease4 = 25652, // Helper->self, 10.0s cast, range 16 circle
    FireBreath = 25646, // HybridDragon->self, 7.0s cast, range 40 120-degree cone
    Mindhack = 25648, // Boss->self, 5.0s cast, range 50 circle
    MultiAITakeover = 27723, // Boss->self, 5.0s cast, single-target
    Plasmafodder = 25653, // Helper->player, no cast, single-target
    ProtoWaveCannon1 = 25642, // OmegaFrame->self, 7.0s cast, range 60 180-degree cone
    ProtoWaveCannon2 = 25643, // OmegaFrame->self, 7.0s cast, range 60 180-degree cone
    Rush = 25645, // ProtoRocketPunch->location, 5.0s cast, width 5 rect charge
    SelfDestruct1 = 25644, // OmegaFrame->self, 15.0s cast, range 60 circle
    SelfDestruct2 = 25647, // HybridDragon->self, 15.0s cast, range 60 circle
    Touchdown = 26873, // HybridDragon->self, 2.0s cast, range 7 circle
}

public enum SID : uint
{
    VulnerabilityUp = 1789, // HybridDragon/Helper->player, extra=0x1/0x2/0x3
    AboutFace = 1959, // Boss->player, extra=0x0
    ForwardMarch = 1958, // Boss->player, extra=0x0
    RightFace = 1961, // Boss->player, extra=0x0
    LeftFace = 1960, // Boss->player, extra=0x0
    ForcedMarch = 1257, // Boss->player, extra=0x2/0x1/0x8
    Bleeding = 2088, // Boss->player, extra=0x0
}

class D083Stigma4States : StateMachineBuilder
{
    public D083Stigma4States(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 784, NameID = 10404)] // 
public class D083Stigma4(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(0, 0), 20));