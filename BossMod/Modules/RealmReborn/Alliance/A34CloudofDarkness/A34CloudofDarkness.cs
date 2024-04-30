namespace BossMod.RealmReborn.Alliance.A34CloudofDarkness;

class FeintParticleBeam1(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.FeintParticleBeam1), 8);
class ZeroFormParticleBeam(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ZeroFormParticleBeam), new AOEShapeRect(74, 12));
class ParticleBeam2(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ParticleBeam2));

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 111, NameID = 3240)]
public class A34CloudofDarkness(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-300, -400), 30))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.DarkCloud), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.DarkStorm), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.HyperchargedCloud), ArenaColor.Enemy);
    }
}
