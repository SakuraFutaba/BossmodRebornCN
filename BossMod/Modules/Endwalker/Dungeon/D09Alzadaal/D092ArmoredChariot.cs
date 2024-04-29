namespace BossMod.Endwalker.Dungeon.D09Alzadaal.D092ArmoredChariot;

public enum OID : uint
{
    Boss = 0x386C,
}

class D092ArmoredChariotStates : StateMachineBuilder
{
    public D092ArmoredChariotStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 844, NameID = 11239)] // 
public class D092ArmoredChariot(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(0, -182), 20));