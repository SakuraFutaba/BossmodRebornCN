namespace BossMod.Shadowbringers.Foray.DelubrumReginae.Normal.DRN3QueensGuard;

class OptimalPlaySword(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.OptimalPlaySword), new AOEShapeCircle(10));
class OptimalPlayShield(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.OptimalPlayShield), new AOEShapeDonut(5, 60));
//class OptimalPlayCone(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.OptimalPlayCone), new AOEShapeCone(60, 135.Degrees()));

class PawnOff(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PawnOffReal), new AOEShapeCircle(20));

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", PrimaryActorOID = (uint)OID.Knight, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 760, NameID = 9838)]
public class DRN3QueensGuard : BossModule
{
    private IReadOnlyList<Actor> _warrior;
    private IReadOnlyList<Actor> _soldier;
    private IReadOnlyList<Actor> _gunner;

    public Actor? Knight() => PrimaryActor.IsDestroyed ? null : PrimaryActor;
    public Actor? Warrior() => _warrior.FirstOrDefault();
    public Actor? Soldier() => _soldier.FirstOrDefault();
    public Actor? Gunner() => _gunner.FirstOrDefault();
    public IReadOnlyList<Actor> GunTurrets;

    public DRN3QueensGuard(WorldState ws, Actor primary) : base(ws, primary, new ArenaBoundsCircle(new(244, -162), 25))
    {
        _warrior = Enemies(OID.Warrior);
        _soldier = Enemies(OID.Soldier);
        _gunner = Enemies(OID.Gunner);
        GunTurrets = Enemies(OID.GunTurret);
    }

    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(Knight(), ArenaColor.Enemy);
        Arena.Actor(Warrior(), ArenaColor.Enemy);
        Arena.Actor(Soldier(), ArenaColor.Enemy);
        Arena.Actor(Gunner(), ArenaColor.Enemy);
        Arena.Actors(GunTurrets, ArenaColor.Enemy);
    }
}
