namespace BossMod.Stormblood.Alliance.A12Hashmal;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 281, NameID = 6922)]
public class A12Hashmal : BossModule
{
    public A12Hashmal(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(-320, -46), 30)) { }
}