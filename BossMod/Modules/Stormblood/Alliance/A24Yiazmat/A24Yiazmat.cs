namespace BossMod.Stormblood.Alliance.A24Yiazmat;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 550, NameID = 7070)]
public class A24Yiazmat : BossModule
{
    public A24Yiazmat(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(800, -400), 30)) { }
}