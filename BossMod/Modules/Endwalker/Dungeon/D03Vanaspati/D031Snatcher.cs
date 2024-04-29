namespace BossMod.Endwalker.Dungeon.D03Vanaspati.D031Snatcher;

public enum OID : uint
{
    Boss = 0x33E8,
    Helper = 0x233C,
}

public enum AID : uint
{
    AutoAttack = 872, // Boss->player, no cast, single-target
    LastGasp = 25141, // Boss->player, 5.0s cast, single-target
    LostHope = 25143, // Boss->self, 4.0s cast, range 20 circle
    MouthOff = 25137, // Boss->self, 3.0s cast, single-target
    NoteOfDespair = 25144, // Boss->self, 5.0s cast, range 40 circle
    Vitriol = 25138, // Helper->self, 9.0s cast, range 13 circle
    Wallow = 25142, // Helper->player, 5.0s cast, range 6 circle
    WhatIsLeft = 25140, // Boss->self, 8.0s cast, range 20 180-degree cone
    WhatIsRight = 25139, // Boss->self, 8.0s cast, range 20 180-degree cone
}

public enum SID : uint
{
    TemporaryMisdirection = 1422, // Boss->player, extra=0x2D0
}

public enum IconID : uint
{
    Icon_218 = 218, // player
    Icon_304 = 304, // player
}


class D031SnatcherStates : StateMachineBuilder
{
    public D031SnatcherStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 789, NameID = 10717)] // 11049
public class D031Snatcher(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-375, 80), 20));