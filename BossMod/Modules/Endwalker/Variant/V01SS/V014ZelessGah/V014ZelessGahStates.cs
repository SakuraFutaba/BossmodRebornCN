namespace BossMod.Endwalker.Variant.V01SS.V014ZelessGah;

class Burn(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Burn), new AOEShapeCircle(12));
class PureFire2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PureFire2), new AOEShapeCircle(6));


class CastShadowFirst(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowFirst), new AOEShapeCone(50, 45.Degrees()));
class CastShadowNext(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowNext), new AOEShapeCone(50, 45.Degrees()));

class FiresteelFracture(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.FiresteelFracture), new AOEShapeCone(50, 45.Degrees()));

class InfernGaleKnockback(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.Unknown2), 20, shape: new AOEShapeCircle(80));

class ShowOfStrength(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ShowOfStrength));

class V014ZelessGahStates : StateMachineBuilder
{
    public V014ZelessGahStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<Burn>()
            .ActivateOnEnter<PureFire2>()
            .ActivateOnEnter<CastShadowFirst>()
            .ActivateOnEnter<CastShadowNext>()
            .ActivateOnEnter<FiresteelFracture>()
            .ActivateOnEnter<InfernGaleKnockback>()
            .ActivateOnEnter<ShowOfStrength>();
    }
}