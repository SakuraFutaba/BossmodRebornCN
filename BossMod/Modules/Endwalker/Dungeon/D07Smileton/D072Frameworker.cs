namespace BossMod.Endwalker.Dungeon.D07Smileton.D072Frameworker;

public enum OID : uint
{
    Boss = 0x34D1,
    Helper = 0x233C,
    Helper2 = 0x1E8FB8, // R2.000, x3 (spawn during fight), EventObj type
    Helper3 = 0x1EA1A1, // R2.000, x4 (spawn during fight), EventObj type
    SmileySupporter = 0x34D2, // R2.300, x2
    PrintedWorker = 0x34E9, // R4.050, x2
}

public enum AID : uint
{
    AutoAttack = 870, // Boss->player, no cast, single-target
    CircularSaw = 26437, // Boss->self, 5.0s cast, range 40 circle
    LeapForward1 = 26438, // Boss->location, 7.0s cast, range 15 circle
    LeapForward2 = 26439, // PrintedWorker->location, 7.0s cast, range 15 circle
    OmnidimensionalOnslaught1 = 26440, // Boss->self, 5.0s cast, single-target
    OmnidimensionalOnslaught2 = 26441, // Helper->self, 5.0s cast, range 40 45-degree cone
    PrintWorkers1 = 26443, // SmileySupporter->self, no cast, single-target
    PrintWorkers2 = 28092, // Boss->self, 3.0s cast, single-target
    UnknownAbility = 26442, // Helper->Boss, no cast, single-target
}

public enum SID : uint
{
    UnknownStatus = 2056, // none->Boss/PrintedWorker, extra=0xE1
}

public enum TetherID : uint
{
    Tether_23 = 23, // SmileySupporter->Boss
}

class D072FrameworkerStates : StateMachineBuilder
{
    public D072FrameworkerStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 794, NameID = 10333)] // 
public class D072Frameworker(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(65, -110), 20));