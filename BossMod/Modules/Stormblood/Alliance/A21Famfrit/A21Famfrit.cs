namespace BossMod.Stormblood.Alliance.A21Famfrit;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 550, NameID = 7245)]
public class A21Famfrit : BossModule
{
    public A21Famfrit(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(-200, 66), 35)) { }
}