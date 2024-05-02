namespace BossMod.Endwalker.Variant.V01SS.V011Geryon;

class ColossalStrike(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.ColossalStrike));

class ColossalCharge1(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.ColossalCharge1), 7);
class ColossalCharge2(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.ColossalCharge2), 7);

class ColossalLaunch(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalLaunch), new AOEShapeRect(20, 20));
class ExplosionAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ExplosionAOE), new AOEShapeCircle(15));
class ExplosionDonut(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ExplosionDonut), new AOEShapeDonut(5, 17));

class ColossalSlam(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalSlam), new AOEShapeCone(60, 30.Degrees()));
class ColossalSwing(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalSwing), new AOEShapeCone(60, 180.Degrees()));

class SubterraneanShudder(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.SubterraneanShudder));
class RunawaySludge(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.RunawaySludge), 9);

class Shockwave(BossModule module) : Components.Knockback(module)
{
    private readonly List<Source> _sources = [];
    private static readonly AOEShapeRect _shape = new(40, 40);

    public override IEnumerable<Source> Sources(int slot, Actor actor) => _sources;

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        if ((AID)spell.Action.ID is AID.Shockwave)
        {
            _sources.Clear();
            // knockback rect always happens through center, so create two sources with origin at center looking orthogonally
            _sources.Add(new(Module.Bounds.Center, 15, spell.NPCFinishAt, _shape, spell.Rotation + 90.Degrees(), Kind.DirForward));
            _sources.Add(new(Module.Bounds.Center, 15, spell.NPCFinishAt, _shape, spell.Rotation - 90.Degrees(), Kind.DirForward));
        }
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        if ((AID)spell.Action.ID == AID.Shockwave)
        {
            _sources.Clear();
            ++NumCasts;
        }
    }

    public override bool DestinationUnsafe(int slot, Actor actor, WPos pos) => (Module.FindComponent<RunawaySludge>()?.ActiveAOEs(slot, actor).Any(z => z.Shape.Check(pos, z.Origin, z.Rotation)) ?? false) || !Module.Bounds.Contains(pos);
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11442)]
public class V011Geryon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(183, 176.99f), 19.5f))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegRed), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegBlue), ArenaColor.Enemy);
    }

    protected override void UpdateModule()
    {
        if (Enemies(OID.Boss).Any(e => e.Position.AlmostEqual(new(-212, 124), 50)))
            Arena.Bounds = new ArenaBoundsSquare(new(-213, 101), 19.5f);
        if (Enemies(OID.Boss).Any(e => e.Position.AlmostEqual(new(0, 0), 50)))
            Arena.Bounds = new ArenaBoundsSquare(new(0, 0), 19.5f);
        if (Enemies(OID.Boss).Any(e => e.Position.AlmostEqual(new(183, 176.99f), 50)))
            Arena.Bounds = new ArenaBoundsSquare(new(183, 176.99f), 19.5f); 
    }
}