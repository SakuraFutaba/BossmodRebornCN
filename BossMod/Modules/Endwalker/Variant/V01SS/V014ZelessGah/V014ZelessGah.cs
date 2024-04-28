namespace BossMod.Endwalker.Variant.V01SS.V014ZelessGah;

class Burn(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Burn), new AOEShapeCircle(12));
class PureFire2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PureFire2), new AOEShapeCircle(6));


class CastShadowFirst(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowFirst), new AOEShapeCone(50, 45.Degrees()));
class CastShadowNext(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.CastShadowNext), new AOEShapeCone(50, 45.Degrees()));

class FiresteelFracture(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.FiresteelFracture), new AOEShapeCone(50, 45.Degrees()));

class InfernGaleKnockback(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.Unknown2), 20, shape: new AOEShapeCircle(80));

class ShowOfStrength(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ShowOfStrength));

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11394)]
public class V014ZelessGah(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsRect(new(289, -105), 15, 20));
