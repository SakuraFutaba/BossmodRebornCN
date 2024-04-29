namespace BossMod.Endwalker.Dungeon.D09Alzadaal.D093Kapikulu;

public enum OID : uint
{
    Boss = 0x36C1,
}

class D093KapikuluStates : StateMachineBuilder
{
    public D093KapikuluStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 844, NameID = 11238)]
public class D093Kapikulu(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsRect(new(110, -68), 20, 15));