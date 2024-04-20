namespace BossMod.RealmReborn.Alliance.A34CloudofDarkness;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 111, NameID = 3240)]
public class A34CloudofDarkness(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-300, -400), 30));