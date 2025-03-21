﻿namespace BossMod.Endwalker.Savage.P7SAgdistis;

class HemitheosHoly(BossModule module) : Components.StackWithCastTargets(module, ActionID.MakeSpell(AID.HemitheosHolyAOE), 6, 4, 4);
class BoughOfAttisBack(BossModule module) : Components.SimpleAOEs(module, ActionID.MakeSpell(AID.BoughOfAttisBackAOE), 25);
class BoughOfAttisFront(BossModule module) : Components.SimpleAOEs(module, ActionID.MakeSpell(AID.BoughOfAttisFrontAOE), 19);
class BoughOfAttisSide(BossModule module) : Components.SimpleAOEs(module, ActionID.MakeSpell(AID.BoughOfAttisSideAOE), new AOEShapeRect(50, 12.5f));
class HemitheosAeroKnockback1(BossModule module) : Components.SimpleKnockbacks(module, ActionID.MakeSpell(AID.HemitheosAeroKnockback1), 16); // TODO: verify distance...
class HemitheosAeroKnockback2(BossModule module) : Components.SimpleKnockbacks(module, ActionID.MakeSpell(AID.HemitheosAeroKnockback2), 16);
class HemitheosHolySpread(BossModule module) : Components.SpreadFromCastTargets(module, ActionID.MakeSpell(AID.HemitheosHolySpread), 6);
class HemitheosTornado(BossModule module) : Components.SimpleAOEs(module, ActionID.MakeSpell(AID.HemitheosTornado), 25);
class HemitheosGlareMine(BossModule module) : Components.SimpleAOEs(module, ActionID.MakeSpell(AID.HemitheosGlareMine), new AOEShapeDonut(5, 30)); // TODO: verify inner radius

[ModuleInfo(BossModuleInfo.Maturity.Verified, GroupType = BossModuleInfo.GroupType.CFC, GroupID = 877, NameID = 11374, PlanLevel = 90)]
public class P7S(WorldState ws, Actor primary) : BossModule(ws, primary, new(100, 100), new ArenaBoundsCircle(27));
