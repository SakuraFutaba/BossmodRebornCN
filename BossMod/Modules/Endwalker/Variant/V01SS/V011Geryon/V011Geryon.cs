namespace BossMod.Endwalker.Variant.V01SS.V011Geryon;

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11442)]
public class V011Geryon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(183, 176.99f), 19.5f))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegRed), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegBlue), ArenaColor.Enemy);
    }
}