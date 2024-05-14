namespace BossMod.Stormblood.Trial.T09Seiryu;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "The Combat Reborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 637, NameID = 7922)]
public class T09Seiryu(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(100, 100), 20));