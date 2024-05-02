namespace BossMod.Endwalker.Variant.V01SS.V014ZelessGah;

class Burn(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Burn), new AOEShapeCircle(12));
class PureFire2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PureFire2), new AOEShapeCircle(6));

class CastShadowFirst(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowFirst), new AOEShapeCone(50, 45.Degrees()));
class CastShadowNext(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowNext), new AOEShapeCone(50, 45.Degrees()));

class FiresteelFracture(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.FiresteelFracture), new AOEShapeCone(50, 45.Degrees()));

class InfernGaleKnockback(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.Unknown2), 20, shape: new AOEShapeCircle(80));

class ShowOfStrength(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ShowOfStrength));

class CastShadow(BossModule module) : Components.GenericAOEs(module, ActionID.MakeSpell(AID.CastShadow))
{
    private List<Actor> _castersShadowFirst = new();
    private List<Actor> _castersShadowNext = new();

    private static readonly AOEShape _shapeShadowFirst = new AOEShapeCone(50, 15.Degrees());
    private static readonly AOEShape _shapeShadowNext = new AOEShapeCone(50, 15.Degrees());

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        if (_castersShadowFirst.Count > 0)
            return _castersShadowFirst.Select(c => new AOEInstance(_shapeShadowFirst, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
        else
            return _castersShadowNext.Select(c => new AOEInstance(_shapeShadowNext, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Add(caster);
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Remove(caster);
    }

    private List<Actor>? CastersForSpell(ActionID spell) => (AID)spell.ID switch
    {
        AID.CastShadowFirst => _castersShadowFirst,
        AID.CastShadowNext => _castersShadowNext,
        _ => null
    };
}

class BlazingBenifice(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BlazingBenifice), new AOEShapeRect(100, 5, 100));


[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11394)]
public class V014ZelessGah(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsRect(new(289, -105), 15, 20));
