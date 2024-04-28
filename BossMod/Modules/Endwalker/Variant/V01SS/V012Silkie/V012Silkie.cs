namespace BossMod.Endwalker.Variant.V01SS.V012Silkie;

class CarpetBeater(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.CarpetBeater));
class TotalWash(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.TotalWash), "Raidwide");
class DustBlusterKnockback(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.DustBlusterKnockback), 16, shape: new AOEShapeCircle(60));
class WashOutKnockback(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.WashOutKnockback), 35, shape: new AOEShapeRect(60, 60));

class BracingDuster1(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BracingDuster1), new AOEShapeDonut(3, 60));
class BracingDuster2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BracingDuster2), new AOEShapeDonut(3, 60));

class ChillingDuster1(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ChillingDuster1), new AOEShapeCross(60, 5));
class ChillingDuster2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ChillingDuster2), new AOEShapeCross(60, 5));
class ChillingDuster3(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ChillingDuster3), new AOEShapeCross(60, 5));

class SlipperySoap(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.SlipperySoap), 5);
class SpotRemover2(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.SpotRemover2), 5);

class SqueakyCleanAOE1E(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE1E), new AOEShapeCone(60, 45.Degrees()));
class SqueakyCleanAOE2E(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE2E), new AOEShapeCone(60, 45.Degrees()));
class SqueakyCleanAOE3E(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE3E), new AOEShapeCone(60, 112.5f.Degrees()));

class SqueakyCleanAOE1W(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE1W), new AOEShapeCone(60, 45.Degrees()));
class SqueakyCleanAOE2W(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE2W), new AOEShapeCone(60, 45.Degrees()));
class SqueakyCleanAOE3W(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SqueakyCleanAOE3W), new AOEShapeCone(60, 112.5f.Degrees()));

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11369)]
public class V012Silkie(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(-335, -155), 20));
