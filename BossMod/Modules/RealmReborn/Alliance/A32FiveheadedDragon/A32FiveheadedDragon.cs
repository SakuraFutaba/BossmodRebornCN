namespace BossMod.RealmReborn.Alliance.A32FiveheadedDragon;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 111, NameID = 3227)]
public class A32FiveheadedDragon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(200, 180), 30));
