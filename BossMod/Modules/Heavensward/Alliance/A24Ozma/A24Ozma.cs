namespace BossMod.Heavensward.Alliance.A24Ozma;

class MeteorImpact(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.MeteorImpact), new AOEShapeCircle(20));
class HolyKB(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.Holy), 3);
class Holy(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.Holy));
class ExecrationAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ExecrationAOE), new AOEShapeRect(60, 5));

class AccelerationBomb(BossModule module) : Components.StayMove(module)
{
    public override void OnStatusGain(Actor actor, ActorStatus status)
    {
        if ((SID)status.ID is SID.AccelerationBomb)
        {
            if (Raid.FindSlot(actor.InstanceID) is var slot && slot >= 0 && slot < Requirements.Length)
                Requirements[slot] = Requirement.Stay;
        }
    }

    public override void OnStatusLose(Actor actor, ActorStatus status)
    {
        if ((SID)status.ID is SID.AccelerationBomb)
        {
            if (Raid.FindSlot(actor.InstanceID) is var slot && slot >= 0 && slot < Requirements.Length)
                Requirements[slot] = Requirement.None;
        }
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 168, NameID = 4896)]
public class A24Ozma(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsUnion([new ArenaBoundsDonut(new(280, -410), 18, 25),
        new ArenaBoundsRect(new(280, -386), 5, 12), //center
        new ArenaBoundsRect(new(260, -422), 5, 12, -120.Degrees()),
        new ArenaBoundsRect(new(300, -422), 5, 12, 120.Degrees())]))

{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityFragment), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityEcho), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.SingularityRipple), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.Ozmasphere), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.Ozmashade), ArenaColor.Enemy);
    }
}