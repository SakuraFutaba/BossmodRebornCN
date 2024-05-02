namespace BossMod.Endwalker.Variant.V01SS.V013Gladiator;

class V013GladiatorStates : StateMachineBuilder
{
    public V013GladiatorStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<SunderedRemains>()
            .ActivateOnEnter<BitingWindBad>()
            .ActivateOnEnter<RingOfMight1>()
            .ActivateOnEnter<RingOfMight2>()
            .ActivateOnEnter<RingOfMight3>()
            .ActivateOnEnter<RushOfMight>()
            .ActivateOnEnter<FlashOfSteelMeteor>()
            .ActivateOnEnter<RackAndRuin>()
            .ActivateOnEnter<FlashOfSteel1>()
            .ActivateOnEnter<FlashOfSteel2>()
            .ActivateOnEnter<SculptorsPassion>()
            .ActivateOnEnter<MightySmite>();
    }
}