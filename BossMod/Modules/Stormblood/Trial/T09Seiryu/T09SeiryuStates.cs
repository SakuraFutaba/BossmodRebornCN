namespace BossMod.Stormblood.Trial.T09Seiryu;

class T09SeiryuStates : StateMachineBuilder
{
    public T09SeiryuStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}