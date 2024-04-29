namespace BossMod.Endwalker.Dungeon.D09Alzadaal.D091Ambujam;

public enum OID : uint
{
    Boss = 0x3879,
}

class D091AmbujamStates : StateMachineBuilder
{
    public D091AmbujamStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 844, NameID = 11241)] // 
public class D091Ambujam(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(124, -90), 20));