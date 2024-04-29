namespace BossMod.Endwalker.Dungeon.D07Smileton.D071Face;

public enum OID : uint
{
    Boss = 0x34CF,
    Helper = 0x233C,
    RelativelySmallFace = 0x34D0, // R3.060, x8
}

public enum AID : uint
{
    AutoAttack = 26433, // Boss->player, no cast, single-target
    FrownyFace = 26422, // RelativelySmallFace->self, 7.0s cast, range 45 width 6 rect
    LinesOfFire = 26421, // Boss->self, 3.0s cast, single-target
    MixedFeelings = 26424, // Helper->self, 7.0s cast, range 60 width 2 rect
    OffMyLawn1 = 26430, // Boss->self, 5.0s cast, single-target
    OffMyLawn2 = 27742, // Helper->self, 5.0s cast, range 31 width 30 rect
    SmileyFace = 26423, // RelativelySmallFace->self, 7.0s cast, range 45 width 6 rect
    TempersFlare = 26435, // Boss->self, 5.0s cast, range 60 circle
    TemperTemper = 26432, // Helper->player, 5.0s cast, range 5 circle
    UnknownAbility1 = 26426, // RelativelySmallFace->self, no cast, single-target
    UnknownAbility2 = 26427, // RelativelySmallFace->self, no cast, single-target
    UnknownAbility3 = 26428, // RelativelySmallFace->self, no cast, single-target
    UnknownAbility4 = 26429, // RelativelySmallFace->self, no cast, single-target
    UpsideDown = 26425, // Boss->self, 3.0s cast, single-target
}

public enum SID : uint
{
    SmileyFace = 2763, // 34D0->player, extra=0x1
    FrownyFace = 2764, // 34D0->player, extra=0x1/0x2
    DownForTheCount = 783, // 34D0->player, extra=0xEC7
    Weakness = 43, // none->player, extra=0x0
    Transcendent = 418, // none->player, extra=0x0
}

public enum IconID : uint
{
    Icon_136 = 136, // player
    Icon_96 = 96, // player
    Icon_137 = 137, // player
}

public enum TetherID : uint
{
    Tether_169 = 169, // 34D0->Boss
}

class D071FaceStates : StateMachineBuilder
{
    public D071FaceStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 794, NameID = 10331)] // 
public class D071Face(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-45, -0), 20));