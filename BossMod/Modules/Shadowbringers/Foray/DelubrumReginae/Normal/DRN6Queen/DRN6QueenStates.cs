namespace BossMod.Shadowbringers.Foray.DelubrumReginae.Normal.DRN6Queen;
class DRN6QueenStates : StateMachineBuilder
{
    public DRN6QueenStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<NorthswainsGlow>()
            .ActivateOnEnter<GodsSaveTheQueen>()
            .ActivateOnEnter<OptimalPlaySword>()
            .ActivateOnEnter<OptimalPlayShield>()
            .ActivateOnEnter<OptimalPlayCone>()
            .ActivateOnEnter<JudgmentBlade>()
            .ActivateOnEnter<HeavensWrathAOE>()
            .ActivateOnEnter<HeavensWrathKnockback>()
            //.ActivateOnEnter<Chess>() breaks modules
            .ActivateOnEnter<QueensWill>()
            .ActivateOnEnter<QueensEdict>()
            .ActivateOnEnter<TurretsTour>()
            .ActivateOnEnter<AboveBoard>()
            .ActivateOnEnter<PawnOff>();
    }
}