using System.Linq;

namespace BossMod.Endwalker.Variant.V01SS.V013Gladiator;

class SunderedRemains(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SunderedRemains), new AOEShapeCircle(10));

class RackAndRuin(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RackAndRuin), new AOEShapeRect(40, 2.5f), 8);
class FlashOfSteel1(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.FlashOfSteel1), "Raidwide");
class FlashOfSteel2(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.FlashOfSteel2), "Raidwide");
class MightySmite(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.MightySmite), "Tankbuster");

class BitingWindBad(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.BitingWindBad), 4);

class ShatteringSteel(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ShatteringSteel), "Get in bigger Whirlwind to dodge");
class ViperPoisonPatterns(BossModule module) : Components.PersistentVoidzoneAtCastTarget(module, 6, ActionID.MakeSpell(AID.BitingWindBad), m => m.Enemies(OID.WhirlwindBad).Where(z => z.EventState != 7), 0);

class RingOfMight1(BossModule module) : Components.GenericAOEs(module, ActionID.MakeSpell(AID.RingOfMightVisual))
{
    private List<Actor> _castersRingOfMightOut = new();
    private List<Actor> _castersRingOfMightIn = new();

    private static readonly AOEShape _shapeRingOfMightOut = new AOEShapeCircle(13);
    private static readonly AOEShape _shapeRingOfMightIn = new AOEShapeDonut(13, 30);

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        if (_castersRingOfMightOut.Count > 0)
            return _castersRingOfMightOut.Select(c => new AOEInstance(_shapeRingOfMightOut, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
        else
            return _castersRingOfMightIn.Select(c => new AOEInstance(_shapeRingOfMightIn, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Add(caster);
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Remove(caster);
    }

    private List<Actor>? CastersForSpell(ActionID spell) => (AID)spell.ID switch
    {
        AID.RingOfMight1Out => _castersRingOfMightOut,
        AID.RingOfMight1In => _castersRingOfMightIn,
        _ => null
    };
}

class RingOfMight2(BossModule module) : Components.GenericAOEs(module, ActionID.MakeSpell(AID.RingOfMightVisual))
{
    private List<Actor> _castersRingOfMightOut = new();
    private List<Actor> _castersRingOfMightIn = new();

    private static readonly AOEShape _shapeRingOfMightOut = new AOEShapeCircle(18);
    private static readonly AOEShape _shapeRingOfMightIn = new AOEShapeDonut(18, 30);

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        if (_castersRingOfMightOut.Count > 0)
            return _castersRingOfMightOut.Select(c => new AOEInstance(_shapeRingOfMightOut, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
        else
            return _castersRingOfMightIn.Select(c => new AOEInstance(_shapeRingOfMightIn, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Add(caster);
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Remove(caster);
    }

    private List<Actor>? CastersForSpell(ActionID spell) => (AID)spell.ID switch
    {
        AID.RingOfMight2Out => _castersRingOfMightOut,
        AID.RingOfMight2In => _castersRingOfMightIn,
        _ => null
    };
}

class RingOfMight3(BossModule module) : Components.GenericAOEs(module, ActionID.MakeSpell(AID.RingOfMightVisual))
{
    private List<Actor> _castersRingOfMightOut = new();
    private List<Actor> _castersRingOfMightIn = new();

    private static readonly AOEShape _shapeRingOfMightOut = new AOEShapeCircle(8);
    private static readonly AOEShape _shapeRingOfMightIn = new AOEShapeDonut(8, 30);

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        if (_castersRingOfMightOut.Count > 0)
            return _castersRingOfMightOut.Select(c => new AOEInstance(_shapeRingOfMightOut, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
        else
            return _castersRingOfMightIn.Select(c => new AOEInstance(_shapeRingOfMightIn, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Add(caster);
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Remove(caster);
    }

    private List<Actor>? CastersForSpell(ActionID spell) => (AID)spell.ID switch
    {
        AID.RingOfMight3Out => _castersRingOfMightOut,
        AID.RingOfMight3In => _castersRingOfMightIn,
        _ => null
    };
}

class RushOfMight(BossModule module) : Components.GenericAOEs(module, ActionID.MakeSpell(AID.RingOfMightVisual))
{
    private List<Actor> _castersRushOfMightFront = new();
    private List<Actor> _castersRushOfMightBack = new();

    private static readonly AOEShape _shapeRushOfMightFront = new AOEShapeCone(60, 90.Degrees());
    private static readonly AOEShape _shapeRushOfMightBack = new AOEShapeCone(60, 90.Degrees());

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        if (_castersRushOfMightFront.Count > 0)
            return _castersRushOfMightFront.Select(c => new AOEInstance(_shapeRushOfMightFront, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
        else
            return _castersRushOfMightBack.Select(c => new AOEInstance(_shapeRushOfMightBack, c.Position, c.CastInfo!.Rotation, c.CastInfo!.NPCFinishAt));
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Add(caster);
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        CastersForSpell(spell.Action)?.Remove(caster);
    }

    private List<Actor>? CastersForSpell(ActionID spell) => (AID)spell.ID switch
    {
        AID.RushOfMightFront => _castersRushOfMightFront,
        AID.RushOfMightBack => _castersRushOfMightBack,
        _ => null
    };
}

class FlashOfSteelMeteor(BossModule module) : Components.CastLineOfSightAOE(module, ActionID.MakeSpell(AID.FlashOfSteelMeteor), 60, false)
{
    public override IEnumerable<Actor> BlockerActors() => Module.Enemies(OID.AntiqueBoulder).Where(a => !a.IsDead);
}

class SculptorsPassion(BossModule module) : Components.GenericWildCharge(module, 4, ActionID.MakeSpell(AID.SculptorsPassion))
{
    public override void OnEventCast(Actor caster, ActorCastEvent spell)
    {
        base.OnEventCast(caster, spell);
        if ((AID)spell.Action.ID == AID.SculptorsPassion)
        {
            Source = Module.PrimaryActor;
            foreach (var (slot, player) in Raid.WithSlot(true))
                PlayerRoles[slot] = player.InstanceID == spell.MainTargetID ? PlayerRole.Target : player.Role == Role.Tank ? PlayerRole.Share : PlayerRole.ShareNotFirst;
        }
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11387)]
public class V013Gladiator(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(-35, -270), 20));