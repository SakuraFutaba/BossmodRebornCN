namespace BossMod.Endwalker.Dungeon.D06DeadEnds.D061Grebuloff;

public enum OID : uint
{
    Boss = 0x34C4,
    Helper = 0x233C,
    WeepingMiasma = 0x34C5, // R1.000, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 872, // Boss->player, no cast, single-target
    Befoulment1 = 25923, // Boss->self, 5.0s cast, single-target
    Befoulment2 = 25924, // Helper->player, 5.2s cast, range 6 circle
    BlightedWater1 = 25921, // Boss->self, 5.0s cast, single-target
    BlightedWater2 = 25922, // Helper->players, 5.2s cast, range 6 circle
    CertainSolitude = 28349, // Boss->self, no cast, range 40 circle
    CoughUp1 = 25917, // Boss->self, 4.0s cast, single-target
    CoughUp2 = 25918, // Helper->location, 4.0s cast, range 6 circle
    Miasmata = 25916, // Boss->self, 5.0s cast, range 40 circle
    NecroticFluid = 25919, // WeepingMiasma->self, 6.5s cast, range 6 circle
    NecroticMist = 28348, // Helper->location, 1.3s cast, range 6 circle
    PoxFlail = 25920, // Boss->player, 5.0s cast, single-target
    WaveOfNausea = 28347, // Boss->self, 5.5s cast, range ?-40 donut
}

public enum SID : uint
{
    VulnerabilityUp = 1789, // Helper->player, extra=0x1/0x2
    Necrosis = 2965, // Helper->player, extra=0x0
    Weakness = 43, // none->player, extra=0x0
    Transcendent = 418, // none->player, extra=0x0
    CravenCompanionship = 2966, // Boss->player, extra=0x0

}

public enum IconID : uint
{
    Icon_55 = 55, // player
    Icon_218 = 218, // player
    Icon_62 = 62, // player
    Icon_139 = 139, // player
}

class D061GrebuloffStates : StateMachineBuilder
{
    public D061GrebuloffStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 792, NameID = 10313)] // 
public class D061Grebuloff(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(266.5f, -178), 20));