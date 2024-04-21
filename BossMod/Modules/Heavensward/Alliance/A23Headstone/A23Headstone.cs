namespace BossMod.Heavensward.Alliance.A23Headstone;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 168, NameID = 4868)]

class A23Headstone(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsUnion([
    new ArenaBoundsCircle(new(-171, 225), 20), new ArenaBoundsCircle(new(-152, 252), 20), new ArenaBoundsCircle(new(-184, 197), 20)]))

{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actors(Enemies(OID.Boss), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.Parthenope), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.VoidFire), ArenaColor.Enemy);
    }
}