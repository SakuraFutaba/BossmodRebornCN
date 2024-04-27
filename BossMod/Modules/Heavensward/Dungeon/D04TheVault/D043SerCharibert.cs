namespace BossMod.Heavensward.Dungeon.D04TheVault.D043SerCharibert;

public enum OID : uint
{
    Boss = 0x1056, // R2.200, x1
    Helper = 0xD25, // R0.500, x13, mixed types
    Charibert = 0xF71EE, // R0.500, x0 (spawn during fight), EventNpc type
    DawnKnight = 0x1057, // R2.000, x0 (spawn during fight)
    DuskKnight = 0x1058, // R2.000, x0 (spawn during fight)
    HolyFlame = 0x1059, // R1.500, x0 (spawn during fight)
    Actor1e9872 = 0x1E9872, // R2.000, x0 (spawn during fight), EventObj type
}

public enum AID : uint
{
    Unknown1 = 4121, // Boss->self, no cast, single-target
    Unknown2 = 4120, // Boss->self, no cast, single-target

    AutoAttack = 4143, // Boss->player, no cast, single-target
    AltarCandle = 4144, // Boss->player, no cast, single-target tankbuster

    HeavensflameTelegraph = 4145, // Boss->self, 2.5s cast, single-target
    HeavensflameAOE = 4146, // Helper->location, 3.0s cast, range 5 circle ground targetted aoe
    HolyChainTelegraph = 4147, // Boss->self, 2.0s cast, single-target
    HolyChainPlayerTether = 4148, // Helper->self, no cast, ??? tether

    AltarPyre = 4149, // Boss->location, 3.0s cast, range 80 circle raidwide
    Unknown3 = 4150, // Boss->self, no cast, single-target
    PureOfHeart = 4151, // Boss->location, no cast, range 80 circle raidewide

    WhiteKnightsTour = 4152, // DawnKnight->self, 3.0s cast, range 40+R width 4 rect
    BlackKnightsTour = 4153, // DuskKnight->self, 3.0s cast, range 40+R width 4 rect

    TurretChargeStart = 4154, // Helper->player, no cast, single-target mob march, exoflare?
    TurretChargeRest = 4155, // Helper->player, no cast, single-target mob march, exoflare?
    SacredFlame = 4156, // HolyFlame->self, no cast, range 80+R circle raidewide
}

public enum SID : uint
{
    Slow = 9, // Helper->player, extra=0x0
    BurningChains = 769, // none->player, extra=0x0
    Weakness = 43, // none->player, extra=0x0
    Transcendent = 418, // none->player, extra=0x0
    Bleeding = 273, // Helper->player, extra=0x0
}

public enum TetherID : uint
{
    HolyChain = 9, // player->player
}

class WhiteKnightsTour(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.WhiteKnightsTour), new AOEShapeRect(40, 2));
class BlackKnightsTour(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BlackKnightsTour), new AOEShapeRect(40, 2));

class AltarCandle(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.AltarCandle));

class AltarPyre(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.AltarPyre), "Raidwide");
class PureOfHeart(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.PureOfHeart), "Raidwide");
class SacredFlame(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.SacredFlame), "Raidwide");

class HeavensflameAOE(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.HeavensflameAOE), 5);

class HolyChain(BossModule module) : Components.Chains(module, (uint)TetherID.HolyChain, ActionID.MakeSpell(AID.HolyChainPlayerTether));


class TurretCharge(BossModule module) : Components.Exaflare(module, 4)
{
    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        if ((AID)spell.Action.ID == AID.TurretChargeStart)
        {
            Lines.Add(new() { Next = caster.Position, Advance = 8 * spell.Rotation.ToDirection(), NextExplosion = spell.NPCFinishAt, TimeToMove = 0.8f, ExplosionsLeft = 8, MaxShownExplosions = 4 });
        }
    }

    public override void OnEventCast(Actor caster, ActorCastEvent spell)
    {
        if ((AID)spell.Action.ID is AID.TurretChargeStart or AID.TurretChargeRest)
        {
            var pos = (AID)spell.Action.ID == AID.TurretChargeStart ? caster.Position : spell.TargetXZ;
            int index = Lines.FindIndex(item => item.Next.AlmostEqual(pos, 1));
            if (index == -1)
            {
                ReportError($"Failed to find entry for {caster.InstanceID:X}");
                return;
            }

            AdvanceLine(Lines[index], pos);
            if (Lines[index].ExplosionsLeft == 0)
                Lines.RemoveAt(index);
        }
    }
}

class D043SerCharibertStates : StateMachineBuilder
{
    public D043SerCharibertStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<WhiteKnightsTour>()
            .ActivateOnEnter<BlackKnightsTour>()
            .ActivateOnEnter<AltarCandle>()
            .ActivateOnEnter<AltarPyre>()
            .ActivateOnEnter<PureOfHeart>()
            .ActivateOnEnter<SacredFlame>()
            .ActivateOnEnter<HeavensflameAOE>()
            .ActivateOnEnter<HolyChain>()
            .ActivateOnEnter<TurretCharge>();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team, Xyzzy", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 34, NameID = 3642)]
public class D043SerCharibert(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(0, 4), 20))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.HolyFlame), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.DawnKnight), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.DuskKnight), ArenaColor.Enemy);
 
    }
}