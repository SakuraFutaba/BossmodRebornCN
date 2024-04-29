namespace BossMod.Endwalker.Dungeon.D09Alzadaal.D092ArmoredChariot;

public enum OID : uint
{
    Boss = 0x386C,
    Helper = 0x233C, // R0.500, x23, 523 type
    Actor1eb69c = 0x1EB69C, // R0.500, x0 (spawn during fight), EventObj type
    Unknown = 0x3932, // R7.000, x0 (spawn during fight)
    ArmoredDrudge = 0x386D, // R1.800, x8
}

public enum AID : uint
{
    AutoAttack = 29132, // Boss->player, no cast, single-target
    ArticulatedBits = 28441, // Boss->self, 3.0s cast, range 6 circle
    Assail1 = 28456, // Boss->self, no cast, single-target
    Assail2 = 28457, // Boss->self, no cast, single-target
    AssaultCannon1 = 28442, // ArmoredDrudge->self, 8.0s cast, single-target
    AssaultCannon2 = 28443, // ArmoredDrudge->self, 8.0s cast, single-target
    AssaultCannon3 = 28444, // Helper->self, no cast, range 40 width 8 rect
    AssaultCannon4 = 28445, // Helper->self, no cast, range 28 width 8 rect
    CannonReflection1 = 28454, // Helper->self, 8.0s cast, single-target
    CannonReflection2 = 28455, // Helper->self, no cast, range 30 ?-degree cone
    DiffusionRay = 28446, // Boss->self, 5.0s cast, range 40 circle
    GravitonCannon = 29555, // Helper->player, 8.5s cast, range 6 circle
    UnknownAbility1 = 28448, // Boss->self, no cast, single-target
    UnknownAbility2 = 28449, // Boss->self, no cast, single-target
    UnknownAbility3 = 28450, // Boss->self, no cast, single-target
    UnknownAbility4 = 28451, // Boss->self, no cast, single-target
    UnknownAbility5 = 28452, // Boss->self, no cast, single-target
    UnknownAbility6 = 28453, // Boss->self, no cast, single-target
}

public enum SID : uint
{
    Electrocution1 = 3073, // none->player, extra=0x0
    UnknownStatus1 = 2552, // none->ArmoredDrudge, extra=0x180/0x181
    UnknownStatus2 = 2195, // none->Boss, extra=0x183/0x182
    Electrocution2 = 3074, // none->player, extra=0x0
}

public enum IconID : uint
{
    Icon_329 = 329, // player
}

class D092ArmoredChariotStates : StateMachineBuilder
{
    public D092ArmoredChariotStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 844, NameID = 11239)] // 
public class D092ArmoredChariot(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(0, -182), 20));