namespace BossMod.Endwalker.Dungeon.D02TowerOfBabil.D021Barnabas;

public enum OID : uint
{
    Boss = 0x33F7,
    Helper = 0x233C,
	Thunderball = 0x33F8, // R1.000, x0 (spawn during fight)
}

public enum AID : uint
{
	AutoAttack = 872, // Boss->player, no cast, single-target
	DynamicPound = 25157, // Boss->self, 7.0s cast, range 40 width 6 rect
	DynamicScrapline = 25158, // Boss->self, 7.0s cast, range 8 circle
	ElectromagneticRelease1 = 25327, // Helper->self, 9.5s cast, range 40 width 6 rect
	ElectromagneticRelease2 = 25329, // Helper->self, 9.5s cast, range 8 circle
	GroundAndPound1 = 25159, // Boss->self, 3.5s cast, range 40 width 6 rect
	GroundAndPound2 = 25322, // Boss->self, 3.5s cast, range 40 width 6 rect
	RollingScrapline = 25323, // Boss->self, 3.0s cast, range 8 circle
	Shock = 25330, // Thunderball->self, 3.0s cast, range 8 circle
	ShockingForce = 25324, // Boss->players, 5.0s cast, range 6 circle
	Thundercall = 25325, // Boss->self, 3.0s cast, single-target
	Unknown1 = 24693, // Helper->self, no cast, range 50 width 50 rect
	Unknown2 = 24694, // Helper->self, no cast, range 50 width 50 rect
	Unknown3 = 25053, // Helper->self, no cast, range 50 circle
	Unknown4 = 25054, // Helper->self, no cast, range 50 circle
}

public enum SID : uint
{
	Eukrasia = 2606, // none->player, extra=0x0
	VulnerabilityUp = 1789, // Boss->33F9/player, extra=0x1
	Stun = 149, // Boss->33F9, extra=0x0
	Stun2 = 2953, // none->player, extra=0x0
	Electrocution = 2086, // none->player, extra=0x0

}

public enum IconID : uint
{
	Icon_163 = 163, // player
	Icon_162 = 162, // player
	Icon_290 = 290, // Boss
	Icon_62 = 62, // player
}

public enum TetherID : uint
{
	Tether_28 = 28, // player->Boss
}

class D021BarnabasStates : StateMachineBuilder
{
    public D021BarnabasStates(BossModule module) : base(module)
    {
        TrivialPhase();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 785, NameID = 10279)]
public class D021Barnabas(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(-300, 71), 20));