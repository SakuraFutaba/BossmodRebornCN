namespace BossMod.Heavensward.Alliance.A24Ozma;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 168, NameID = 4896)]
public class A24Ozma(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsUnion([new ArenaBoundsDonut(new(280, -410), 20, 30),
new ArenaBoundsRect(new(260, -420), 5, 15, 240.Degrees()), new ArenaBoundsRect(new(280, -385), 5, 15, 180.Degrees()), new ArenaBoundsRect(new(300, -420), 5, 15, 110.Degrees())]))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actors(Enemies(OID.Boss), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityFragment), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityEcho), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityRipple), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.Ozmasphere), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.Ozmashade), ArenaColor.Enemy);
    }
}