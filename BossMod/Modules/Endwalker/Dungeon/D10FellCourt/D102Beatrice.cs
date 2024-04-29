namespace BossMod.Endwalker.Dungeon.D10FellCourt.D102Beatrice;

public enum OID : uint
{
    Boss = 0x396D,
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
