namespace BossMod.Stormblood.Alliance.A33ThunderGod;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 636, NameID = 7899)] //7917
public class A33ThunderGod : BossModule
{
    public A33ThunderGod(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(-600, -600), 30)) { }
}