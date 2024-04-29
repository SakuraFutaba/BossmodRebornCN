namespace BossMod.Endwalker.Dungeon.D06DeadEnds.D063Rala;

public enum OID : uint
{
    Boss = 0x34C7,
    Helper = 0x233C,
    GoldenWings = 0x34C8, // R1.000, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 870, // Boss->player, no cast, single-target
    Benevolence1 = 25945, // Boss->self, 5.0s cast, single-target
    Benevolence2 = 25946, // Helper->players, 5.4s cast, range 6 circle
    LamellarLight1 = 25939, // Helper->self, 6.0s cast, range 15 circle
    LamellarLight2 = 25942, // GoldenWings->self, 3.0s cast, single-target
    LamellarLight3 = 25951, // Helper->self, 3.0s cast, range 40 width 4 rect
    Lifesbreath = 25940, // Boss->self, 4.0s cast, range 50 width 10 rect
    LovingEmbrace1 = 25943, // Boss->self, 7.0s cast, range 45 180-degree cone
    LovingEmbrace2 = 25944, // Boss->self, 7.0s cast, range 45 180-degree cone
    Pity = 25949, // Boss->player, 5.0s cast, single-target
    Prance1 = 25937, // Boss->location, 5.0s cast, single-target
    Prance2 = 25938, // Boss->location, no cast, single-target
    StillEmbrace1 = 25947, // Boss->self, 5.0s cast, single-target
    StillEmbrace2 = 25948, // Helper->player, 5.4s cast, range 6 circle
    Unknown = 25941, // Boss->location, no cast, single-target
    WarmGlow = 25950, // Boss->self, 5.0s cast, range 40 circle
}

public enum SID : uint
{
    VulnerabilityUp = 1789, // Helper->player, extra=0x1
    UnknownStatus = 2056, // none->34C8, extra=0x16C
    Weakness = 43, // none->player, extra=0x0
    Transcendent = 418, // none->player, extra=0x0
}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_62 = 62, // player
    Icon_139 = 139, // player
}

class D063RalaStates : StateMachineBuilder
{
    public D063RalaStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 792, NameID = 10316)] // 
public class D063Rala(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-380, -145), 20));