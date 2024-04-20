namespace BossMod.RealmReborn.Alliance.A33Cerberus;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 111, NameID = 3224)]
public class A33Cerberus(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsRect(new(0, -197), 20, 40));