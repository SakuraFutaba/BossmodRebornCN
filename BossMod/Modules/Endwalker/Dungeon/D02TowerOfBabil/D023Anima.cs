namespace BossMod.Endwalker.Dungeon.D02TowerOfBabil.D023Anima;

public enum OID : uint
{
    Boss = 0x33FD,
    LowerAnima = 0x3400,
    Helper = 0x233C,
	MagitekCrane = 0x3320, // R0.600, x3
	IronNail = 0x3401, // R1.000, x0 (spawn during fight)
	LunarNail = 0x33FE, // R1.000, x0 (spawn during fight)
	MegaGraviton = 0x33FF, // R1.000, x0 (spawn during fight)
	Actor1eb239 = 0x1EB239, // R0.500, x0 (spawn during fight), EventObj type
}

public enum AID : uint
{
	AutoAttack = 25341, // Boss->player, no cast, single-target
	AetherialPull = 25345, // MegaGraviton->player, 8.0s cast, single-target
	BoundlessPain1 = 25347, // Boss->self, 8.0s cast, single-target
	BoundlessPain2 = 25348, // Helper->location, no cast, range 6 circle
	BoundlessPain3 = 25349, // Helper->location, no cast, range 6 circle
	CharnelClaw = 25357, // IronNail->self, 6.0s cast, range 40 width 5 rect
	CoffinScratch = 25358, // Helper->location, 3.5s cast, range 3 circle
	Imperatum = 25353, // Boss->self, 5.0s cast, range 60 circle
	LunarNail = 25342, // Boss->self, 3.0s cast, single-target
	MegaGraviton = 25344, // Boss->self, 5.0s cast, range 60 circle
	ObliviatingClaw1 = 25354, // LowerAnima->self, 3.0s cast, single-target
	ObliviatingClaw2 = 25355, // LowerAnima->self, 3.0s cast, single-target
	ObliviatingClaw3 = 25356, // IronNail->self, 6.0s cast, range 3 circle
	Oblivion1 = 23697, // Helper->location, no cast, range 60 circle
	Oblivion2 = 23872, // Helper->location, no cast, range 60 circle
	Oblivion3 = 25359, // LowerAnima->self, 6.0s cast, single-target
	PaterPatriae1 = 24168, // Helper->self, 3.5s cast, range 60 width 8 rect
	PaterPatriae2 = 25350, // Boss->self, 3.5s cast, single-target
	PhantomPain1 = 21182, // Boss->self, 7.0s cast, single-target
	PhantomPain2 = 25343, // Helper->self, 7.0s cast, range 20 width 20 rect
	Unknown1 = 23929, // Helper->player, no cast, single-target
	Unknown2 = 26229, // Helper->self, no cast, range 60 circle
	Unknown3 = 27228, // LowerAnima->self, no cast, single-target
}

public enum SID : uint
{
	AreaOfInfluenceUp = 1749, // none->Helper, extra=0x1/0x2/0x3/0x4/0x5/0x6/0x7/0x8/0x9/0xA/0xB/0xC
    UnknownStatus = 2849, // none->player, extra=0xEC7
}

public enum IconID : uint
{
	Icon_197 = 197, // player
}

public enum TetherID : uint
{
	Tether_162 = 162, // Helper->Helper
	Tether_57 = 57, // MegaGraviton->player
	Tether_17 = 17, // MegaGraviton->player
	Tether_22 = 22, // Helper->Boss
}


class D023AnimaStates : StateMachineBuilder
{
    public D023AnimaStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 785, NameID = 10285)] // 10288
public class D023Anima(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(0, -180), 20))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actors(Enemies(OID.Boss), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.LowerAnima), ArenaColor.Enemy);
    }

    protected override void UpdateModule()
	{
		if (Enemies(OID.Boss).Any(e => e.Position.AlmostEqual(new(0, -180), 50)))
			Arena.Bounds = new ArenaBoundsSquare(new(0, -180), 20);
		if (Enemies(OID.LowerAnima).Any(e => e.Position.AlmostEqual(new(0, -400), 50)))
			Arena.Bounds = new ArenaBoundsSquare(new(0, -400), 20);
	}
}