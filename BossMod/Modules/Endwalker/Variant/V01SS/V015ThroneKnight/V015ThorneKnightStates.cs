namespace BossMod.Endwalker.Variant.V01SS.V015ThorneKnight;

class BlisteringBlow(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.BlisteringBlow));

class BlazingBeacon1(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BlazingBeacon1), new AOEShapeRect(50, 16));
class BlazingBeacon2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BlazingBeacon2), new AOEShapeRect(50, 16));
class BlazingBeacon3(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BlazingBeacon3), new AOEShapeRect(50, 16));

class SignalFlareAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SignalFlareAOE), new AOEShapeCircle(10));

class Explosion(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Explosion), new AOEShapeCross(50, 6));

class SacredFlay1(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SacredFlay1), new AOEShapeCone(50, 50.Degrees()));
class SacredFlay2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SacredFlay2), new AOEShapeCone(50, 50.Degrees()));
class SacredFlay3(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SacredFlay3), new AOEShapeCone(50, 50.Degrees()));

class ForeHonor(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ForeHonor), new AOEShapeCone(50, 180.Degrees()));

class Cogwheel(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.Cogwheel));

class V015ThorneKnightStates : StateMachineBuilder
{
    public V015ThorneKnightStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<BlisteringBlow>()
            .ActivateOnEnter<BlazingBeacon1>()
            .ActivateOnEnter<BlazingBeacon2>()
            .ActivateOnEnter<BlazingBeacon3>()
            .ActivateOnEnter<SignalFlareAOE>()
            .ActivateOnEnter<Explosion>()
            .ActivateOnEnter<SacredFlay1>()
            .ActivateOnEnter<SacredFlay2>()
            .ActivateOnEnter<SacredFlay3>()
            .ActivateOnEnter<ForeHonor>()
            .ActivateOnEnter<Cogwheel>();
    }
}