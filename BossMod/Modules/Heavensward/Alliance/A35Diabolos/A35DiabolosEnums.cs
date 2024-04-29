namespace BossMod.Heavensward.Alliance.A35Diabolos;

public enum OID : uint
{
    Boss = 0x1908, // R3.000, x?
    Diabolos = 0x19A, // R0.500, x?, 523 type
    Deathgate = 0x190A, // R3.200, x0 (spawn during fight)
    DiabolicGate = 0x190B, // R3.200, x0 (spawn during fight)
    Shadowsphere = 0x19AF, // R1.500, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 7742, // Boss->player, no cast, single-target
    Blindside = 7208, // Boss->self, no cast, range 9+R ?-degree cone
    CriticalGravity = 7767, // Shadowsphere->self, no cast, range 8+R circle
    DeepFlow = 7189, // DiabolicGate->self, 28.0s cast, range 40 circle
    DoubleEdge = 7211, // Boss->self, 3.0s cast, single-target
    EarthShaker1 = 7209, // Boss->self, 4.0s cast, single-target
    EarthShaker2 = 7210, // Diabolos->self, no cast, range 60+R ?-degree cone
    HollowCamisado = 7193, // Boss->player, 3.0s cast, single-target
    HollowNight = 7197, // Boss->players, no cast, range 8 circle
    HollowNightmare = 7200, // Boss->self, 4.0s cast, range 50 circle
    HollowOmen1 = 7202, // Boss->self, 15.0s cast, range 50 circle
    HollowOmen2 = 7203, // Diabolos->self, 20.0s cast, range 30 circle
    Hollowshield = 7198, // Boss->self, no cast, single-target
    Nox1 = 7195, // Diabolos->location, no cast, range 10 circle
    Nox2 = 7196, // Diabolos->location, 5.0s cast, range 10 circle
    PavorInanis = 7199, // Boss->self, 4.0s cast, range 40 circle
    Shadethrust = 7194, // Boss->location, 3.0s cast, range 40+R width 5 rect
    UnknownAbility = 7192, // Boss->location, no cast, ???
    VoidCall = 7188, // Diabolos->self, 9.0s cast, single-target
}

public enum SID : uint
{
    DiabolicCurse = 424, // Boss->player, extra=0x1
    Doom = 910, // Boss->player, extra=0x0
    FleshWound = 264, // Boss->player, extra=0x0
    HelpingHand = 368, // none->player, extra=0xA
    Hysteria = 296, // Boss->player, extra=0x0
    Invincibility = 325, // none->DiabolicGate, extra=0x0
    Invincibility2 = 776, // none->player, extra=0x0
    Jackpot = 902, // none->player, extra=0xA
    KeenEdge = 1145, // Boss->Boss, extra=0x0
    ReducedRates = 364, // none->player, extra=0x1E
    TheHeatOfBattle = 365, // none->player, extra=0xA
    Transcendent = 418, // none->player, extra=0x0
    VulnerabilityDown = 929, // Boss->Boss/Diabolos, extra=0x0
    Weakness = 43, // none->player, extra=0x0

}

public enum IconID : uint
{
    Icon_197 = 197, // player
    Icon_91 = 91, // player
    Icon_93 = 93, // player
    Icon_40 = 40, // player
}
