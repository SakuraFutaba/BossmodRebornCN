namespace BossMod.Endwalker.Dungeon.D05Aitiascope.D053Amon;

public enum OID : uint
{
    Boss = 0x346E,
    Helper = 0x233C,
    YsaylesSpirit = 0x346F, // R2.000, x1
    Ice = 0x1EB26D, // R0.500, x0 (spawn during fight), EventObj type
}

public enum AID : uint
{
    AutoAttack = 24712, // Boss->player, no cast, single-target
    Antistrophe = 25694, // Boss->self, 3.0s cast, single-target
    CurtainCall = 25702, // Boss->self, 32.0s cast, range 40 circle
    DarkForte = 25700, // Boss->player, 5.0s cast, single-target
    DreamsOfIce = 27756, // Helper->self, 14.7s cast, range 6 circle
    Entracte = 25701, // Boss->self, 5.0s cast, range 40 circle
    Epode = 25695, // Helper->self, 8.0s cast, range 70 width 12 rect
    EruptionForte1 = 24709, // Boss->self, 3.0s cast, single-target
    EruptionForte2 = 25704, // Helper->location, 4.0s cast, range 8 circle
    LeftFiragaForte = 25697, // Boss->self, 7.0s cast, range 40 width 20 rect
    RightFiragaForte = 25696, // Boss->self, 7.0s cast, range 40 width 20 rect
    Strophe = 25693, // Boss->self, 3.0s cast, single-target
    ThundagaForte1 = 25690, // Boss->location, 5.0s cast, range 40 circle
    ThundagaForte2 = 25691, // Helper->self, 5.0s cast, range 20 ?-degree cone
    ThundagaForte3 = 25692, // Helper->self, 11.0s cast, range 20 ?-degree cone
    Unknown = 25703, // YsaylesSpirit->self, no cast, single-target
}

public enum IconID : uint
{
    Icon_218 = 218, // player
}

class D053AmonStates : StateMachineBuilder
{
    public D053AmonStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 786, NameID = 10293)] // 
public class D053Amon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(0, -500), 20));