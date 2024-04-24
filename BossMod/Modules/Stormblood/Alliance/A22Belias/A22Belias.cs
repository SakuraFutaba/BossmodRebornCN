namespace BossMod.Stormblood.Alliance.A22Belias;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 550, NameID = 7223)]
public class A22Belias : BossModule
{
    public A22Belias(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(-200, -541), 30)) { }
}