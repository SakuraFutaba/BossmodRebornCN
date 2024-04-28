namespace BossMod.Endwalker.Variant.V01SS.V013Gladiator;

class SunderedRemains(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SunderedRemains), new AOEShapeCircle(10));

class RingOfMight1Out(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight1Out), new AOEShapeCircle(8));
class RingOfMight2Out(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight2Out), new AOEShapeCircle(13));
class RingOfMight3Out(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight3Out), new AOEShapeCircle(18));
class RingOfMight1In(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight1In), new AOEShapeDonut(8, 30));
class RingOfMight2In(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight2In), new AOEShapeDonut(13, 30));
class RingOfMight3In(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RingOfMight3In), new AOEShapeDonut(18, 30));

class RackAndRuin(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RackAndRuin), new AOEShapeRect(40, 2.5f), 8);
class FlashOfSteel1(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.FlashOfSteel1), "Raidwide");
class FlashOfSteel2(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.FlashOfSteel2), "Raidwide");
class MightySmite(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.MightySmite), "Tankbuster");

class RushOfMightFront(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RushOfMightFront), new AOEShapeCone(60, 90.Degrees()));
class RushOfMightBack(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RushOfMightBack), new AOEShapeCone(60, 90.Degrees()));
//class RushOfMight1(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.RushOfMight1), new AOEShapeCone(40, 180.Degrees()));
//class RushOfMight2(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.RushOfMight2), new AOEShapeCone(40, 180.Degrees()));
//class RushOfMight3(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.RushOfMight3), new AOEShapeCone(40, 180.Degrees()));

class BitingWindBad(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.BitingWindBad), 4);

class ShatteringSteel(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ShatteringSteel), "Get in bigger Whirlwind to dodge");
class ViperPoisonPatterns(BossModule module) : Components.PersistentVoidzoneAtCastTarget(module, 6, ActionID.MakeSpell(AID.BitingWindBad), m => m.Enemies(OID.WhirlwindBad).Where(z => z.EventState != 7), 0);

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