namespace BossMod.Endwalker.Variant.V01SS.V014ZelessGah;

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