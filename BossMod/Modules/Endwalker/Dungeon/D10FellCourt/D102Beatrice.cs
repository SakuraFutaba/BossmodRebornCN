namespace BossMod.Endwalker.Dungeon.D10FellCourt.D102Beatrice;

public enum OID : uint
{
    Boss = 0x396D,
    Actor1e8fb8 = 0x1E8FB8, // R2.000, x2 (spawn during fight), EventObj type
    Actor1e8f2f = 0x1E8F2F, // R0.500, x1 (spawn during fight), EventObj type
    Helper = 0x233C, // R0.500, x26, 523 type
}

public enum AID : uint
{
    _AutoAttack_Attack = 872, // Boss->player, no cast, single-target
    BeatificScorn1 = 29811, // Boss->self, 4.0s cast, single-target
    BeatificScorn2 = 29814, // Boss->self, no cast, single-target
    BeatificScorn3 = 29815, // Boss->self, no cast, single-target
    BeatificScorn4 = 29816, // Boss->self, no cast, single-target
    BeatificScorn5 = 29817, // Helper->self, 10.0s cast, range 9 circle
    DeathForeseen1 = 29821, // Helper->self, 5.0s cast, range 40 circle
    DeathForeseen2 = 29828, // Helper->self, 8.0s cast, range 40 circle
    EyeOfTroia = 29818, // Boss->self, 4.0s cast, range 40 circle
    Hush = 29824, // Boss->player, 5.0s cast, single-target
    UnknownAbility1 = 29819, // Boss->self, no cast, single-target
    UnknownAbility2 = 29820, // Boss->location, no cast, single-target
    VoidNail = 29823, // Helper->player, 5.0s cast, range 6 circle
    Voidshaker = 29822, // Boss->self, 5.0s cast, range 20 120-degree cone
}

public enum IconID : uint
{
    _Gen_Icon_218 = 218, // player
    _Gen_Icon_139 = 139, // player
}

class D102BeatriceStates : StateMachineBuilder
{
    public D102BeatriceStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 869, NameID = 11384)] //
public class D102Beatrice(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(0, -148), 20));