namespace BossMod.Endwalker.Dungeon.D10FellCourt.D101EvilDreamers;

public enum OID : uint
{
	Boss = 0x3988,
}

class D101EvilDreamersStates : StateMachineBuilder
{
    public D101EvilDreamersStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 869, NameID = 11382)] // 11383
public class D101EvilDreamers(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(168, 0), 20));