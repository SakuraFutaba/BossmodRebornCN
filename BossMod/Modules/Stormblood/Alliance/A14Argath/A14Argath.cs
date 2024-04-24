namespace BossMod.Stormblood.Alliance.A14Argath;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 281, NameID = 6925)]
public class A14Argath : BossModule
{
    public A14Argath(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(106, -385), 20)) { }
}