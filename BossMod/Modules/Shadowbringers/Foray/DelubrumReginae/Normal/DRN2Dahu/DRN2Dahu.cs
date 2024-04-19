namespace BossMod.Shadowbringers.Foray.DelubrumReginae.Normal.DRN2Dahu;

class FallingRock(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.FallingRock), 4);
class HotCharge(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.HotCharge), 4);
class Firebreathe(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Firebreathe), new AOEShapeCone(60, 45.Degrees()));
class HeadDown(BossModule module) : Components.ChargeAOEs(module, ActionID.MakeSpell(AID.HeadDown), 2);
class HuntersClaw(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.HuntersClaw), new AOEShapeCircle(8));

[ModuleInfo(BossModuleInfo.Maturity.Contributed, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 760, NameID = 9751)]
public class DRN2Dahu(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(82, 138), 30))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        base.DrawEnemies(pcSlot, pc);
        Arena.Actors(Enemies(OID.Marchosias), ArenaColor.Enemy);
    }
}