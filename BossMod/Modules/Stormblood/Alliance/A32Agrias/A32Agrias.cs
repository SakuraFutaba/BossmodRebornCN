namespace BossMod.Stormblood.Alliance.A32Agrias;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 636, NameID = 7916)] // 7931
public class A32Agrias : BossModule
{
    public A32Agrias(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(600, -54), 30)) { }
}