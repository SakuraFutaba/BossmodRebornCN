namespace BossMod.Heavensward.Alliance.A31DeathgazeHollow;

class DarkII(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.DarkII), new AOEShapeCone(50, 30.Degrees()));
class BoltOfDarkness3(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.BoltOfDarkness3), new AOEShapeRect(31, 10));
class VoidDeath(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.VoidDeath), new AOEShapeCircle(10));
class VoidAeroII(BossModule module) : Components.BaitAwayCast(module, ActionID.MakeSpell(AID.VoidAeroII), new AOEShapeCircle(5), true);
class VoidBlizzardIIIAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.VoidBlizzardIIIAOE), new AOEShapeCone(60, 10.Degrees()));

class VoidAeroIVKB1(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.VoidAeroIVKB1), 37, kind: Kind.DirLeft, stopAtWall: true);
class VoidAeroIVKB2(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.VoidAeroIVKB2), 37, kind: Kind.DirRight, stopAtWall: true);

class Unknown3(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.Unknown3), 20, stopAtWall: true);
class VoidDeathKB2(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.VoidDeathKB2), 15, kind: Kind.TowardsOrigin, stopAtWall: true);
class VoidDeathKB(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.VoidDeathKB), 40, kind: Kind.TowardsOrigin, stopAtWall: true);

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 220, NameID = 5507)]
public class A31DeathgazeHollow(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsRect(new(300, 410), 30, 15))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor, ArenaColor.Enemy);
        Arena.Actors(Enemies(OID.VoidSprite), ArenaColor.Enemy);
    }
}