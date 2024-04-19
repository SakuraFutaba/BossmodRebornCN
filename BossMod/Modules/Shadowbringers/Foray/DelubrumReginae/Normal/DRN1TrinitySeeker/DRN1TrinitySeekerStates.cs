namespace BossMod.Shadowbringers.Foray.DelubrumReginae.Normal.DRN1TrinitySeeker;

class DRN1TrinitySeekerStates : StateMachineBuilder
{
    public DRN1TrinitySeekerStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<MercifulBreeze>()
            .ActivateOnEnter<MercifulBlooms>()
            .ActivateOnEnter<MercifulArc>()
            .ActivateOnEnter<BurningChains>()
            .ActivateOnEnter<IronImpact>()
            .ActivateOnEnter<IronRose>()
            //.ActivateOnEnter<ActOfMercy>() cross aoes always on
            //.ActivateOnEnter<BalefulBlade>() hide behind barrier always on
            //.ActivateOnEnter<BalefulSwathe>() side aoes always on
            .ActivateOnEnter<IronSplitter>()
            .ActivateOnEnter<MercyFourfold>()
            //.ActivateOnEnter<MercifulMoon>() gaze mechanic does not disable
            .ActivateOnEnter<DeadIron>();
    }
}

//class DRN1TrinitySeekerStates : StateMachineBuilder
//{
//    public DRN1TrinitySeekerStates(BossModule module) : base(module)
//    {
//        SimplePhase(0, Phase1, "P1")
//            .Raw.Update = () => Module.PrimaryActor.IsDestroyed || Module.PrimaryActor.HP.Cur <= 1 || (Module.PrimaryActor.CastInfo?.IsSpell(AID.VerdantPathSword) ?? false);
//        SimplePhase(1, Phase2, "P2")
//            .Raw.Update = () => Module.PrimaryActor.IsDestroyed || Module.PrimaryActor.HP.Cur <= 1 || (Module.PrimaryActor.CastInfo?.IsSpell(AID.VerdantPathFist) ?? false);
//        SimplePhase(2, Phase3, "P3")
//            .Raw.Update = () => Module.PrimaryActor.IsDestroyed || Module.PrimaryActor.HP.Cur <= 1 || (Module.PrimaryActor.CastInfo?.IsSpell(AID.VerdantPathKatana) ?? false);
//        SimplePhase(3, Phase4, "P4")
//            .Raw.Update = () => Module.PrimaryActor.IsDestroyed || Module.PrimaryActor.HP.Cur <= 1;
//    }
//}