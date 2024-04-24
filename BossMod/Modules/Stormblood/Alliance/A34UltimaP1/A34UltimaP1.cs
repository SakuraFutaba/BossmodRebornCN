namespace BossMod.Stormblood.Alliance.A34Ultima;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 636, NameID = 7657)] //7909 7657
public class A34UltimaP1(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(600, -630), 30)) { }