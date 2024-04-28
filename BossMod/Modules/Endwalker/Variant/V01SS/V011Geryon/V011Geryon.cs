namespace BossMod.Endwalker.Variant.V01SS.V011Geryon;

class ColossalStrike(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.ColossalStrike));

class ColossalCharge1(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.ColossalCharge1), 7);
class ColossalCharge2(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.ColossalCharge2), 7);

class ColossalLaunch(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalLaunch), new AOEShapeRect(20, 20));
class ExplosionAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ExplosionAOE), new AOEShapeCircle(15));
class ExplosionDonut(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ExplosionDonut), new AOEShapeDonut(5, 17));

class ColossalSlam(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalSlam), new AOEShapeCone(60, 60.Degrees()));
class ColossalSwing(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ColossalSwing), new AOEShapeCone(60, 180.Degrees()));

class SubterraneanShudder(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.SubterraneanShudder));

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Boss, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 868, NameID = 11442)]
public class V011Geryon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(183, 176.99f), 19.5f)) //left path -213, 100 // middle path 0, 0
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegRed), ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.PowderKegBlue), ArenaColor.Enemy);
    }
}