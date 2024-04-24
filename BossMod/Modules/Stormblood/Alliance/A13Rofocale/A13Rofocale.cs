namespace BossMod.Stormblood.Alliance.A13Rofocale;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 281, NameID = 6941)]
public class A13Rofocale : BossModule
{
    public A13Rofocale(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(106, -190), 30)) { }
}