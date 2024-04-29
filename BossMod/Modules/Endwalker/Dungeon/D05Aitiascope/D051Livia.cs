namespace BossMod.Endwalker.Dungeon.D05Aitiascope.D051Livia;

public enum OID : uint
{
    Boss = 0x3469, // R7.000, x1
    Helper = 0x233C, // R0.500, x12, mixed types
}

public enum AID : uint
{
    AutoAttack = 24771, // Boss->player, no cast, single-target
    AglaeaBite = 25673, // Boss->self/player, 5.0s cast, range 9 ?-degree cone
    AglaeaClimb1 = 25666, // Boss->self, 7.0s cast, single-target
    AglaeaClimb2 = 25667, // Boss->self, 7.0s cast, single-target
    AglaeaClimb3 = 25668, // Helper->self, 7.0s cast, range 20 90-degree cone
    AglaeaShot1 = 25669, // Boss->self, 3.0s cast, single-target
    AglaeaShot2 = 25670, // 346A->location, 3.0s cast, range 20 width 4 rect
    AglaeaShot3 = 25671, // 346A->location, 1.0s cast, range 40 width 4 rect
    Disparagement = 25674, // Boss->self, 5.0s cast, range 40 120-degree cone
    Frustration = 25672, // Boss->self, 5.0s cast, range 40 circle
    IgnisAmoris = 25676, // Helper->location, 4.0s cast, range 6 circle
    IgnisOdi = 25677, // Helper->players, 5.0s cast, range 6 circle
    OdiEtAmo = 25675, // Boss->self, 3.0s cast, single-target
}

public enum SID : uint
{
    VulnerabilityUp = 1789, // 346A->player, extra=0x2
}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_161 = 161, // player
}

class D051LiviaStates : StateMachineBuilder
{
    public D051LiviaStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 786, NameID = 10290)] // 
public class D051Livia(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-6, 470), 20));