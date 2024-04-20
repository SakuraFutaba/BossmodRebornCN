namespace BossMod.Shadowbringers.Foray.DelubrumReginae.Normal.DRN4Phantom;

class UndyingHatred(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.UndyingHatred), 30, kind: Kind.DirForward);

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 760, NameID = 9755)]
public class DRN4Phantom(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsSquare(new(202, -370), 24));