namespace BossMod.Endwalker.Dungeon.D05Aitiascope.D053Amon;

public enum OID : uint
{
    Boss = 0x346E,
    Helper = 0x233C,
    YsaylesSpirit = 0x346F, // R2.000, x1
    Ice = 0x1EB26D, // R0.500, x0 (spawn during fight), EventObj type
}

public enum AID : uint
{
    AutoAttack = 24712, // Boss->player, no cast, single-target
    Antistrophe = 25694, // Boss->self, 3.0s cast, single-target
    CurtainCall = 25702, // Boss->self, 32.0s cast, range 40 circle //Lethal Raidwide, needs to hide behind Ice

    DarkForte = 25700, // Boss->player, 5.0s cast, single-target //Tankbuster
    Entracte = 25701, // Boss->self, 5.0s cast, range 40 circle //Raidwide

    DreamsOfIce = 27756, // Helper->self, 14.7s cast, range 6 circle
    Epode = 25695, // Helper->self, 8.0s cast, range 70 width 12 rect

    EruptionForteVisual = 24709, // Boss->self, 3.0s cast, single-target
    EruptionForteAOE = 25704, // Helper->location, 4.0s cast, range 8 circle // BaitedAOE

    LeftFiragaForte = 25697, // Boss->self, 7.0s cast, range 40 width 20 rect
    RightFiragaForte = 25696, // Boss->self, 7.0s cast, range 40 width 20 rect

    Strophe = 25693, // Boss->self, 3.0s cast, single-target

    ThundagaForte1 = 25690, // Boss->location, 5.0s cast, range 40 circle //proximity-based AoE
    ThundagaForte2 = 25691, // Helper->self, 5.0s cast, range 20 45-degree cone
    ThundagaForte3 = 25692, // Helper->self, 11.0s cast, range 20 45-degree cone

    Unknown = 25703, // YsaylesSpirit->self, no cast, single-target
}

public enum IconID : uint
{
    Icon_218 = 218, // player
}

class DreamsOfIce(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.DreamsOfIce), new AOEShapeCircle(6));
class Epode(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Epode), new AOEShapeRect(70, 6));

class EruptionForteAOE(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.EruptionForteAOE), new AOEShapeCircle(8));

class LeftFiragaForte(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.LeftFiragaForte), new AOEShapeRect(40, 10));
class RightFiragaForte(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.RightFiragaForte), new AOEShapeRect(40, 10));

class ThundagaForte1(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.ThundagaForte1), 15);
class ThundagaForte2(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ThundagaForte2), new AOEShapeCone(20, 22.6f.Degrees()));
class ThundagaForte3(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ThundagaForte3), new AOEShapeCone(20, 22.6f.Degrees()));

class DarkForte(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.DarkForte));
class Entracte(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.Entracte));

class D053AmonStates : StateMachineBuilder
{
    public D053AmonStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<DreamsOfIce>()
            .ActivateOnEnter<Epode>()
            .ActivateOnEnter<EruptionForteAOE>()
            //.ActivateOnEnter<LeftFiragaForte>()
            //.ActivateOnEnter<RightFiragaForte>()
            .ActivateOnEnter<ThundagaForte1>()
            .ActivateOnEnter<ThundagaForte2>()
            .ActivateOnEnter<ThundagaForte3>()
            .ActivateOnEnter<DarkForte>()
            .ActivateOnEnter<Entracte>();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "CombatReborn Team", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 786, NameID = 10293)] // 
public class D053Amon(WorldState ws, Actor primary) : BossModule(ws, primary, new ArenaBoundsCircle(new(11, -490), 20));