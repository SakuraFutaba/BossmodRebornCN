namespace BossMod.Endwalker.Dungeon.D10FellCourt.D103Scarmiglione;

public enum OID : uint
{
    Boss = 0x39C5,
    Necroserf1 = 0x39C7, // R1.400, x8
    Necroserf2 = 0x39C6, // R1.400, x2
    Helper = 0x233C, // R0.500, x24, 523 type
}

public enum AID : uint
{
    AutoAttack = 30258, // Boss->player, no cast, single-target
    AutoAttackMob = 872, // Necroserf1->player, no cast, single-target

    BlightedBedevilment = 30235, // Boss->self, 4.9s cast, range 9 circle
    BlightedBladework1 = 30259, // Boss->location, 10.0s cast, single-target
    BlightedBladework2 = 30260, // Helper->self, 11.0s cast, range 25 circle
    BlightedSweep = 30261, // Boss->self, 7.0s cast, range 40 180-degree cone
    CorruptorsPitch1 = 30245, // Boss->self, no cast, single-target
    CorruptorsPitch2 = 30247, // Helper->self, no cast, range 60 circle
    CorruptorsPitch3 = 30248, // Helper->self, no cast, range 60 circle
    CorruptorsPitch4 = 30249, // Helper->self, no cast, range 60 circle
    CreepingDecay = 30240, // Boss->self, 4.0s cast, single-target
    CursedEcho = 30257, // Boss->self, 4.0s cast, range 40 circle
    Nox = 30241, // Helper->self, 5.0s cast, range 10 circle
    RottenRampage1 = 30231, // Boss->self, 8.0s cast, single-target
    RottenRampage2 = 30232, // Helper->location, 10.0s cast, range 6 circle
    RottenRampage3 = 30233, // Helper->players, 10.0s cast, range 6 circle
    UnknownAbility1 = 30237, // Boss->location, no cast, single-target
    UnknownAbility2 = 30244, // Boss->self, no cast, single-target
    UnknownWeaponskill = 30234, // Boss->self, no cast, single-target
    VacuumWave = 30236, // Helper->self, 5.4s cast, range 40 circle
    VoidVortex1 = 30243, // Helper->players, 5.0s cast, range 6 circle
    VoidVortex2 = 30253, // Boss->self, no cast, single-target
    VoidVortex3 = 30254, // Helper->players, 5.0s cast, range 6 circle
}

public enum SID : uint
{
    Bleeding = 2088, // Boss->player, extra=0x0
    BrainRot = 3282, // Helper->player/39C8, extra=0x1
    VulnerabilityUp = 1789, // Helper->player, extra=0x4
    Weakness = 43, // none->player, extra=0x0
    Transcendent = 418, // none->player, extra=0x0
}

public enum IconID : uint
{
    Icon_353 = 353, // player
    Icon_161 = 161, // player
}

public enum TetherID : uint
{
    Tether_206 = 206, // Boss->3AE4
}

class D103ScarmiglioneStates : StateMachineBuilder
{
    public D103ScarmiglioneStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 869, NameID = 11372)] //  11407
public class D103Scarmiglione(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-35, -298), 20));