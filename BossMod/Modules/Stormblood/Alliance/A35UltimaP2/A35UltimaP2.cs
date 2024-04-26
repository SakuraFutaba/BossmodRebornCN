namespace BossMod.Stormblood.Alliance.A35UltimaP2;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 636, NameID = 7909)] //7909 7657
public class A35UltimaP2(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(600, -600), 40)) { }