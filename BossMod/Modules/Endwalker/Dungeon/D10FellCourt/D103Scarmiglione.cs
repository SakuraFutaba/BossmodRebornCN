namespace BossMod.Endwalker.Dungeon.D10FellCourt.D103Scarmiglione;

public enum OID : uint
{
    Boss = 0x39C5,
}

class D103ScarmiglioneStates : StateMachineBuilder
{
    public D103ScarmiglioneStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 869, NameID = 11372)] //  11407
public class D103Scarmiglione(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-35, -298), 20));