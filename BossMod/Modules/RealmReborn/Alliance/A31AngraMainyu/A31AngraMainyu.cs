namespace BossMod.RealmReborn.Alliance.A31AngraMainyu;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 111, NameID = 3231)]
public class A31AngraMainyu(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-145, 300), 30));
