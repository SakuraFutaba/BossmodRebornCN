namespace BossMod.Stormblood.Trial.T09Seiryu;

public enum OID : uint
{
    Boss = 0x25F4, // R4.400, x1
    Helper = 0x233C, // R0.500, x30, 523 type
    AkaNoShiki = 0x2786, // R2.600, x0 (spawn during fight)
    AoNoShiki = 0x2787, // R3.000, x0 (spawn during fight)
    IwaNoShiki = 0x2788, // R4.000, x0 (spawn during fight)
    BlueOrochi = 0x2672, // R1.000, x0 (spawn during fight)
    TenNoShiki = 0x25F8, // R2.700, x0 (spawn during fight)
    NumaNoShiki = 0x25F6, // R2.400, x0 (spawn during fight)
    DoroNoShiki = 0x25F7, // R1.440, x0 (spawn during fight)
    BlueOrochi1 = 0x25F5, // R1.000, x0 (spawn during fight)
    BlueOrochi2 = 0x2658, // R1.000, x0 (spawn during fight)
    BlueOrochi3 = 0x2659, // R1.000, x0 (spawn during fight)
}

public enum AID : uint
{
    AutoAttack = 870, // Boss->player, no cast, single-target
    MobAutoAttack = 872, // NumaNoShiki/DoroNoShiki->player, no cast, single-target

    HundredTonzeSwing = 15390, // IwaNoShiki->self, 4.0s cast, range 16 circle
    BlueBolt = 15388, // AoNoShiki->self, no cast, range 80+R width 5 rect
    CoursingRiver1 = 14325, // BlueOrochi1->self, 5.0s cast, single-target
    CoursingRiver2 = 14349, // Helper->self, 7.5s cast, range 21 circle
    CoursingRiver3 = 14350, // Helper->self, 7.5s cast, range 90+R width 90 rect
    CoursingRiver4 = 14626, // BlueOrochi2->self, 5.0s cast, single-target
    CoursingRiver5 = 14627, // BlueOrochi3->self, 5.0s cast, single-target
    DragonsWake1 = 14282, // Boss->self, no cast, single-target
    DragonsWake2 = 14336, // Helper->self, 24.0s cast, range 80 circle
    Explosion1 = 14347, // NumaNoShiki->self, no cast, range 80 circle
    Explosion2 = 14348, // DoroNoShiki->self, no cast, range 80 circle
    FifthElement = 14334, // Boss->self, 4.0s cast, range 100 circle
    ForbiddenArts1 = 14277, // Helper->player, no cast, single-target
    ForbiddenArts2 = 15474, // Boss->self, no cast, range 80+R width 8 rect
    ForbiddenArts3 = 15490, // Boss->self, no cast, range 80+R width 8 rect
    FortuneBladeSigil = 14342, // Helper->self, 6.5s cast, range 50+R width 4 rect
    GreatTyphoon1 = 14352, // Helper->self, 3.0s cast, range ?-28 donut
    GreatTyphoon2 = 14353, // Helper->self, 3.0s cast, range ?-34 donut
    GreatTyphoon3 = 14354, // Helper->self, 3.0s cast, range ?-40 donut
    InfirmSoul = 14333, // Boss->player, 5.0s cast, range 4 circle
    Kanabo1 = 15391, // IwaNoShiki->self, 3.0s cast, range 40+R 60-degree cone
    Kanabo2 = 15392, // IwaNoShiki->self, 6.0s cast, single-target
    KujiKiri = 14305, // Boss->self, 4.0s cast, single-target
    OnmyoSigil1 = 14338, // Boss->self, no cast, single-target
    OnmyoSigil2 = 14855, // Helper->self, 3.0s cast, range 12 circle
    RedRush = 15389, // AkaNoShiki->self, no cast, range 80+R width 5 rect
    SerpentAscending = 14300, // Boss->self, no cast, single-target
    SerpentDescending = 14340, // Helper->player, 6.0s cast, range 5 circle
    SerpentEyeSigil1 = 14339, // Boss->self, no cast, single-target
    SerpentEyeSigil2 = 14856, // Helper->self, 3.0s cast, range ?-30 donut
    StrengthOfSpirit = 14281, // Boss->self, 5.0s cast, range 80 circle
    SummonShiki1 = 14286, // Boss->self, 3.0s cast, single-target
    SummonShiki2 = 14287, // Boss->self, 3.0s cast, single-target
    SummonShiki3 = 14288, // Boss->self, 5.0s cast, single-target
    UnknownAbility1 = 14276, // Boss->location, no cast, ???
    UnknownAbility2 = 14293, // Boss->location, no cast, ???
    UnknownAbility3 = 14316, // IwaNoShiki->location, no cast, ???
    UnknownAbility4 = 14319, // Helper->player, no cast, single-target
    YamaKagura = 14355, // TenNoShiki->self, 5.0s cast, range 60+R width 6 rect
}


public enum SID : uint
{
    Fetters = 1726, // Boss->player, extra=0xEC7
    VulnerabilityUp = 1054, // none->player, extra=0x0
    Drowning = 1696, // none->player, extra=0x1818
}

public enum IconID : uint
{
    Icon_169 = 169, // player
}

public enum TetherID : uint
{
    Tether_17 = 17, // AkaNoShiki/AoNoShiki/IwaNoShiki->player
}