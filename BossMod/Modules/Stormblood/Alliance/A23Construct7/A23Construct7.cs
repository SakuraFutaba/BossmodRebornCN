namespace BossMod.Stormblood.Alliance.A23Construct7;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 550, NameID = 7237)]
public class A23Construct7 : BossModule
{
    public A23Construct7(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(800, -146), 30)) { }
}