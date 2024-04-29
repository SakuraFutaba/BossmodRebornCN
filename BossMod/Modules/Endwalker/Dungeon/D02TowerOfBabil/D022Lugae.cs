namespace BossMod.Endwalker.Dungeon.D02TowerOfBabil.D022Lugae;

public enum OID : uint
{
    Boss = 0x33FA,
    Helper = 0x233C,
	MagitekChakram = 0x33FB, // R3.000, x0 (spawn during fight)
	MagitekExplosive = 0x33FC, // R2.000, x0 (spawn during fight)
}

public enum AID : uint
{
	AutoAttack = 872, // Boss->player, no cast, single-target
	Downpour = 25333, // Boss->self, 5.0s cast, single-target
	Explosion = 25337, // MagitekExplosive->self, 7.0s cast, range 40 width 8 cross
	MagitekChakram = 25331, // Boss->self, 5.0s cast, single-target
	MagitekExplosive = 25336, // Boss->self, 5.0s cast, single-target
	MagitekMissile = 25334, // Boss->self, 3.0s cast, single-target
	MagitekRay = 25340, // Boss->self, 3.0s cast, range 50 width 6 rect
	MightyBlow = 25332, // MagitekChakram->self, 7.0s cast, range 40 width 8 rect
	SurfaceMissile = 25335, // Helper->location, 3.5s cast, range 6 circle
	ThermalSuppression = 25338, // Boss->self, 5.0s cast, range 60 circle
}

public enum SID : uint
{
	Minimum = 2504, // none->player, extra=0x14
	Breathless = 2672, // none->player, extra=0x1/0x2/0x3/0x4/0x5/0x6
	Heavy = 2391, // none->player, extra=0x32
	Toad = 2671, // none->player, extra=0x1B1
}

class D022LugaeStates : StateMachineBuilder
{
    public D022LugaeStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 785, NameID = 10281)] // 10282
public class D022Lugae(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(221, 306), 20));