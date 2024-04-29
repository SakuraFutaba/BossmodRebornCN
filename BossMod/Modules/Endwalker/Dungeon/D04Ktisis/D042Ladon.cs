namespace BossMod.Endwalker.Dungeon.D04Ktisis.D042Ladon;

public enum OID : uint
{
    Boss = 0x3425,
    Helper = 0x233C,
    PyricSphere = 0x3426, // R0.700, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 872, // Boss->player, no cast, single-target
    Inhale1 = 25732, // Boss->self, 4.0s cast, single-target
    Inhale2 = 25915, // Boss->self, no cast, single-target
    Intimidation = 25741, // Boss->self, 6.0s cast, range 40 circle
    PyricBlast = 25742, // Boss->players, 4.0s cast, range 6 circle
    PyricBreath1 = 25734, // Boss->self, 7.0s cast, range 40 ?-degree cone
    PyricBreath2 = 25735, // Boss->self, 7.0s cast, range 40 ?-degree cone
    PyricBreath3 = 25736, // Boss->self, 7.0s cast, range 40 ?-degree cone
    PyricBreath4 = 25737, // Boss->self, no cast, range 40 ?-degree cone
    PyricBreath5 = 25738, // Boss->self, no cast, range 40 ?-degree cone
    PyricSphere1 = 25744, // PyricSphere->self, 5.0s cast, single-target
    PyricSphere2 = 25745, // Helper->self, 10.0s cast, range 50 width 4 cross
    Scratch = 25743, // Boss->player, 5.0s cast, single-target
    UnknownAbility = 25733, // Boss->location, no cast, single-target
    UnknownSpell = 25740, // Boss->self, no cast, ???
}

public enum SID : uint
{
    Unknown1 = 2195, // none->Boss, extra=0x144/0x145/0x149/0x146/0x148/0x147
    Unknown2 = 2812, // none->Boss, extra=0x9F6
    Unknown3 = 2813, // none->Boss, extra=0x177F
    Unknown4 = 2814, // none->Boss, extra=0x21A8
    VulnerabilityUp = 1789, // Helper->player, extra=0x2
}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_62 = 62, // player
}

class D042LadonStates : StateMachineBuilder
{
    public D042LadonStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 787, NameID = 10398)] // 
public class D042Ladon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(0, 48), 20));