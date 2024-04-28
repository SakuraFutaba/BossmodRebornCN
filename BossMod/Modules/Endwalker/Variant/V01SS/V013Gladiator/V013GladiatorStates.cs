namespace BossMod.Endwalker.Variant.V01SS.V013Gladiator;

class V013GladiatorStates : StateMachineBuilder
{
    public V013GladiatorStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<SunderedRemains>()
            .ActivateOnEnter<BitingWindBad>()
            .ActivateOnEnter<RingOfMight1Out>()
            .ActivateOnEnter<RingOfMight2Out>()
            .ActivateOnEnter<RingOfMight3Out>()
            .ActivateOnEnter<RingOfMight1In>()
            .ActivateOnEnter<RingOfMight2In>()
            .ActivateOnEnter<RingOfMight3In>()
            .ActivateOnEnter<RackAndRuin>()
            .ActivateOnEnter<FlashOfSteel1>()
            .ActivateOnEnter<FlashOfSteel2>()
            .ActivateOnEnter<RushOfMightFront>()
            .ActivateOnEnter<RushOfMightBack>()
            //.ActivateOnEnter<RushOfMight1>()
            //.ActivateOnEnter<RushOfMight2>()
            //.ActivateOnEnter<RushOfMight3>()
            .ActivateOnEnter<SculptorsPassion>()
            .ActivateOnEnter<MightySmite>();
    }
}