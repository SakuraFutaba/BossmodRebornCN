using FFXIVClientStructs.FFXIV.Client.System.String;

namespace BossMod.Network.ServerIPC;

// taken from Machina, FFXIVPacketDissector, XIVAlexander, FFXIVOpcodes and custom research
// alternative names:
// StatusEffectListBozja: machina = StatusEffectList2
// StatusEffectListPlayer: machina = StatusEffectList3
// StatusEffectListDouble: machina = BossStatusEffectList
// ActionEffectN: machina = AbilityN
// SpawnObject: FFXIVOpcodes = ObjectSpawn
// SystemLogMessage1: FFXIVOpcodes = SomeDirectorUnk4
// WaymarkPreset: FFXIVOpcodes = PlaceFieldMarkerPreset, machina = PresetWaymark
// Waymark: FFXIVOpcodes = PlaceFieldMarker
// ActorCustomizeData: PlayerUpdateLook
// actor control examples: normal = toggle weapon, self = cooldown, target = target change
public enum PacketID
{
    QuestRecomplete = 0,
    SetCylinderMeshVertexMaterial = 1,
    Pong = 2,
    Init = 3,
    SwitchZone = 5, // trigger when switching zone
    RemainingPlayTime = 6,
    UIModuleLogout = 7,
    SetPenaltyTimestamp = 8,
    CFQueueInfo9 = 9, // payload[1]: 0 2 3 4 5 6
    CFCancel = 10,
    CFRegist = 11,
    CFQueueInfo = 12, // payload[0] payload[4] ShowLogMessage(902) A party member has withdrawn from the duty.
    CFReady = 13, // Client::Game::InstanceContent::PublicContentDirector_HandleEnterContentInfoPacket
    CFNotify = 14,
    CFSetting = 15,
    CloseLogoutDialog = 16, // https://github.com/aers/FFXIVClientStructs/blob/5bbd270516ae92701b9be2e7996eede446e6f1cb/FFXIVClientStructs/FFXIV/Client/UI/UIModuleInterface.cs#L179
    CFPreferredRole = 17,
    SetGlobalByte = 18, // Vf770
    UpdateAgentContentsFinder = 19, // [g_Client::Game::UI::InstanceContent_Instance + 0x6C] = payload[5], [AgentContentsFinder + 0x23E9] = 257
    PFRecruitStart20 = 20, // Party status now cross-world. Invites canceled. Agent: LookingForGroup
    PFRecruitCancel = 21,
    PF22 = 22,
    PF23 = 23,
    PF24 = 24,
    PF25 = 25,
    PFList = 26,
    PFInfo = 27,
    PF28 = 28,
    PF29 = 29,
    PFRecruitStart30 = 30, // 没有搜到任何结果。当前条件没有搜到任何招募信息。开始招募队员 确认招募内容
    ReadyCheck = 33,
    PFUpdateRecruitNum = 34,
    PF32 = 32,
    PF35 = 35,
    PF36 = 36,
    ShowLogMessageCharaCard = 37,
    PvpTeamResult = 38, // GetInfoProxyById(26)
    PFRecruitAllianceStart = 39,
    PF40 = 40,
    PF41 = 41,
    OnlineStatusFriend = 43,
    PFInfoAlliance = 44,
    PF45 = 45,
    PFRecruitAllianceCancel = 46,
    PF47 = 47,
    PF48 = 48,
    Framework49 = 49,
    ShowLogMessage50 = 50,
    InfoProxyUnk51 = 51,
    InfoProxyPvpTeamMember52 = 52,
    InfoProxyPvpTeamMember53 = 53,
    InfoProxyPvpTeamMember54 = 54,
    InfoProxyPvpTeamMember55 = 55,
    InfoProxyPvpTeamMember56 = 56,
    InfoProxyPvpTeamMember57 = 57,
    InfoProxyPvpTeamMember58 = 58,
    InfoProxyPvpTeamMember59 = 59,
    InfoProxyPvpTeamMember60 = 60,
    InfoProxyPvpTeamMember61 = 61,
    InfoProxyPvpTeamMember62 = 62,
    InfoProxyPvpTeamMember63 = 63,
    InfoProxyPvpTeamMember64 = 64,
    InfoProxyPvpTeamMember65 = 65,
    InfoProxyPvpTeamMember66 = 66,
    InfoProxyPvpTeamMember67 = 67,
    InfoProxyPvpTeamMember68 = 68,
    UIModule70 = 70,
    InfoProxyPvpTeamMember71 = 71,
    InfoProxyPvpTeamMember72 = 72,
    CWLS73 = 73,
    CWLS74 = 74,
    CWLS75 = 75,
    CWLS76 = 76,
    CWLS77 = 77,
    CWLS78 = 78,
    CWLS79 = 79,
    CWLS80 = 80,
    CWLSList = 81,
    CWLS82 = 82,
    CWLS83 = 83,
    OnlineStatusFriendList = 86,
    UnableToInvite = 88, // UIModule + 0x118 无法发送组队邀请。
    UIModuleHelpers89 = 89,
    UIModuleHelpers90 = 90,
    UIModuleHelpers92 = 92,
    UIModule93 = 93,
    UIModuleCircleList94 = 94,
    UIModule95 = 95,
    UIModuleCircleList96 = 96,
    UIModule97 = 97,
    UIModuleCircleList98 = 98,
    FellowshipList = 99, // FellowshipList = CircleList
    UIModuleCircle100 = 100,
    UIModuleCircle101 = 101,
    UIModuleCircleList102 = 102,
    UIModuleCircleList103 = 103,
    FellowshipFinder = 104, // UIModule 1C CircleFinder
    FellowshipFinder105 = 105, // UIModule 1C CircleFinder
    UIModuleCircle106 = 106,
    UIModuleCircle107 = 107,
    UIModuleCircle108 = 108,
    UIModuleCircle109 = 109,
    UIModuleCircle110 = 110,
    Playtime = 111,
    CFRegistered = 112,
    UIModuleCircle113 = 113,
    CFUpdateRecruitNum = 114,
    UIModuleStartLogoutCountdown = 115, // https://github.com/aers/FFXIVClientStructs/blob/5bbd270516ae92701b9be2e7996eede446e6f1cb/FFXIVClientStructs/FFXIV/Client/UI/UIModuleInterface.cs#L180
    UIModulePrintPlayTime = 116, // https://github.com/aers/FFXIVClientStructs/blob/5bbd270516ae92701b9be2e7996eede446e6f1cb/FFXIVClientStructs/FFXIV/Client/UI/UIModuleInterface.cs#L181
    ShowPublicInstanceSelection = 117,
    ShowLogMessage118 = 118, // Client::UI::Misc::RaptureLogModule_ShowLogMessage(UIModule + 0x678, ServerIPCHeader->payload[0]);
    ShowLogMessage120 = 120, // Client::UI::Misc::RaptureLogModule_ShowLogMessage(UIModule + 0x88, ServerIPCHeader->payload[0]);
    ChatRecv = 121,
    ShowLogMessage122 = 122,
    ShowLogMessage123 = 123,
    AgentWorldTravel124 = 124, // Housing
    WorldsInfo = 125, // WorldTravel
    WorldsInfo2 = 126, // WorldTravel
    RSVData = 127, // Client::LayoutEngine::LayoutWorld_AddRsvString(payload + 1, payload + 13, *payload);
    RSFData = 128, // Client::LayoutEngine::LayoutWorld_AddRsfEntry(*payload, payload + 1);
    SocialMessage = 129,
    SocialMessage2 = 130,
    Invite = 131, // payload[30] switch { 1 9 14 party / 6 fc / 8 Beginner ...}
    SocialList = 132,
    SocialRequestResponse = 133,
    ExamineSearchInfo = 134,
    UpdateSearchInfo = 135,
    InitSearchInfo = 136,
    ExamineSearchComment = 137,
    NoviceFCLinkShell = 139,
    ServerNoticeShort = 140,
    ServerNotice = 141,
    SetOnlineStatus = 142,
    MarketBoardItemSearchLogMessage = 143, // GetInfoProxyById(11) GetAgentByInternalId(75)
    ReadyCheck144 = 144,
    PerformanceReadyCheck145 = 145,
    PerformanceReadyCheck146 = 146,
    Countdown = 147,
    CountdownCancel = 148,
    PerformanceReadyCheck149 = 149,
    PerformanceReadyCheck150 = 150,
    FreeCompany151 = 151,
    UIModulePartyMember = 152,
    PartyMessage = 153,
    PartyInvite = 154,
    PlayerAddedToBlacklist = 155,
    PlayerRemovedFromBlacklist = 156,
    BlackList = 157,
    Housing158 = 158, // null
    ScheduledEstateDemolition = 159, // null
    BlackList160 = 160, // vf11
    TeleportHousingFriend = 161,
    PlayerSearchUpdateResults = 162, // GetInfoProxyById(9); ShowLogMessage(81);
    LinkshellList = 163,
    MailDeleteRequest = 164, // GetInfoProxyById(3) Linkshell
    MailTakeGil = 165, // ShowLogMessage(675 | 673 | 26 | 28) GetInfoProxyById(8)
    MailTakeItem = 166, // GetInfoProxyById(8) GetSheetByIndex(10)
    MailSetValueCheckPermission = 167, // GetInfoProxyById(8) GetSheetByIndex(10)
    MailSupportDeskQueryAnswered = 168, // ShowLogMessage(687)
    MarketBoardItemListingCount = 169, // FFCS: MarketBoardItemRequestStart
    MarketBoardItemListing = 170,
    PlayerRetainerInfo = 171,
    MarketBoardPurchase = 172,
    MarketBoardSale = 173, // ShowLogMessage(384)
    MarketBoardItemListingHistory = 174,
    RetainerSaleHistory = 175,
    RetainerState = 176,
    MarketBoardSearchResult = 177,
    FreeCompanyActionUpdate = 178,
    FreeCompanyInfo = 179,
    FreeCompany = 180, // GetInfoProxyById(18) GetInfoProxyById(13) payload[264] is a string and is set to InfoProxyFreeCompany
    FreeCompanyInfoExamine = 181,
    FreeCompanyDialog = 182,
    FreeCompanyTopic = 183,
    FreeCompanyAddRank184 = 184,
    FreeCompanyActivity = 185,
    FreeCompanyAddRank186 = 186,
    FreeCompanyApplicationResult = 187,
    FreeCompanyCreditShop = 188,
    FreeCompanyAction = 189,
    FreeCompanyMember = 190,
    NoviceNetwork = 191, // 和151类似
    NoviceNetworkBeginnerChatKick = 192, // FormatAddonText2<int>(7864) icon
    NoviceNetworkLeave = 193,
    PrintMessage194 = 194, // RaptureLogModule_PrintMessage(57, ...) invite blacklist?
    Null196 = 196,
    Null197 = 197,
    Null198 = 198,
    Null199 = 199,
    Null201 = 201,
    Null202 = 202,
    Null203 = 203,
    Null204 = 204,
    Null205 = 205,
    Null206 = 206,
    StatusEffectList = 207,
    StatusEffectListEureka = 208,
    StatusEffectListBozja = 209,
    StatusEffectListForay3 = 210,
    StatusEffectListDouble = 211,
    EffectResult1 = 213,
    EffectResult4 = 214,
    EffectResult8 = 215,
    EffectResult16 = 216,
    EffectResultBasic1 = 218,
    EffectResultBasic4 = 219,
    EffectResultBasic8 = 220,
    EffectResultBasic16 = 221,
    EffectResultBasic32 = 222,
    EffectResultBasic64 = 223,
    ActorControl = 224,
    ActorControlSelf = 225,
    ActorControlTarget = 226,
    UpdateHpMpTp = 227,
    ActionEffect1 = 228,
    ActionEffect8 = 231,
    ActionEffect16 = 232,
    ActionEffect24 = 233,
    ActionEffect32 = 234,
    StatusEffectListPlayer = 237,
    StatusEffectListPlayerDouble = 238,
    FreeCompanyCrestDataAndHousingData = 239,
    UpdateRecastTimes = 240,
    UpdateDutyRecastTimes = 241,
    UpdateDutyRecastTimes5 = 242,
    UpdateAllianceNormal = 243,
    UpdateAllianceSmall = 244,
    UpdatePartyMemberPositions = 245,
    UpdateAllianceNormalMemberPositions = 246,
    UpdateAllianceSmallMemberPositions = 247,
    UpdateUIStateMemberPositions = 248,
    AgentBuddyFinalizer = 249,
    QuestManagerSetGatheringSuccessfulChainCount = 250,	// GCAffiliation in bossmod
    QuestManagerSetUnkBitmask2 = 251,
    QuestManagerSetUnkBitmask2Bit = 252,
    QuestManagerSetUnkBitmask3 = 253,
    QuestManagerSetUnkBitmask2Bit2 = 254,
    QuestManagerSetSeenNotebookDivisionLevelRangeBitmask = 255,
    QuestManagerSetGatheredGatheringItemBitmask = 256,
    QuestManagerSetGatheredGatheringItemBitmaskBit = 257,
    QuestManagerSetSeenCraftingNotebookDivisionLevelRangeBitmask = 258,
    QuestManagerSetCompletedRecipesBitmask = 259,
    QuestManager260 = 260,
    UseCraftAction = 261, // GetAgentByInternalId(375) CraftActionSimulator
    QuestManager262 = 262,
    QuestManager263 = 263,
    GatheringSubCategory264 = 264, // GetRowBySheetIndexAndRowId(442) GatheringSubCategory
    LovmParty = 265, // 萌宠之王
    LovmResult = 266,
    GoldSaucer267 = 267,
    SpawnPlayer = 268,
    SpawnNPC = 269,
    SpawnBoss = 270,
    DespawnCharacter = 271,
    ActorMove = 272,
    ActorEmote = 273, // [CharacterManager + 496] + 88
    Transfer = 274,
    ActorSetPos = 275,
    LovmRankingInit = 276, // 萌宠之王
    ActorCast = 277,
    ActorCustomizeData = 278, // PlayerUpdateLook
    UpdateParty = 279,
    InitZone = 280,
    ApplyIDScramble = 281,
    UpdateHate = 282, // HateRank
    UpdateHater = 283, // HateList
    SpawnObject = 284,
    DespawnObject = 285,
    UpdateClassInfo = 286,
    UpdateClassInfoEureka = 287,
    UpdateClassInfoBozja = 288,
    UpdateClassInfoForay3 = 289,
    PlayerSetup = 290,
    PlayerStats = 291,
    FirstAttack = 292, // CombatTagType [BattleChara + 0x1C5] = payload[0], CombatTaggerId[BattleChara + 0x1C8] = payload[8]
    PlayerStateFlags = 293,
    PlayerClassInfo = 294,
    PlayerBlueMageActions = 295,
    PlayerGearsetData = 296, // ModelEquip
    Examine = 297,
    Examine298 = 298,
    Examine299 = 299,
    Examine300_CharaNameReq = 300,
    SetNameForContentId = 301,
    MateriaAttach = 302,
    RepairRequest = 303,
    RetainerSummary = 304,
    RetainerInfo = 305,
    RetainerMarketPriceSummary = 306,
    RetainerMarketPriceInfo = 307,
    ItemInfo = 309,
    ContainerInfo = 310,
    InventoryTransactionFinish = 311,
    InventoryTransaction = 312,
    CurrencyCrystalInfo = 313,
    Trade = 314,
    InventoryActionAck = 315,
    UpdateInventorySlot = 316,
    CurrencyUnkInfo = 317, // shares same func with ItemInfo = 309, ContainerInfo = 310, CurrencyCrystalInfo = 313,
    OpenTreasure = 318,
    Loot319 = 319,
    Loot320 = 320,
    LootMessage = 321,
    Loot322 = 322,
    Loot323 = 323,
    Loot324 = 324,
    SpawnTreasure = 325,
    TreasureFadeOut = 326,
    HuntingLogEntry = 327,
    EventPlay = 329,
    EventPlay4 = 330,
    EventPlay8 = 331,
    EventPlay16 = 332,
    EventPlay32 = 333,
    EventPlay64 = 334,
    EventPlay128 = 335,
    EventPlay255 = 336,
    EventStart = 338,
    EventFinish = 339,
    EventHandler341 = 341,
    EventHandler342 = 342,
    EventHandler343 = 343,
    EventHandler344 = 344,
    EventHandler345 = 345,
    EventHandler346 = 346,
    EventHandler347 = 347,
    EventHandler348 = 348,
    EventContinue = 350,
    Event351 = 351,
    ResultDialog = 352,
    DesynthResult = 353,
    Event354 = 354, // off_320
    Event355 = 355,
    Event356 = 356,
    Event357 = 357,
    QuestActiveList = 358,
    QuestUpdate = 359,
    QuestCompleteList = 360,
    QuestFinish = 361,
    FREE_WORK_INFO = 362,
    QuestRedo = 363, // also calls QuestCompleteList
    QuestComplete = 364, // ScenarioTree
    QuestUIModule = 365,
    QuestTracker = 366,
    Quest367 = 367,
    QuestSetCompletedLeveBitmask = 368,
    QuestDirectorVars = 369,
    ContentDirectorSync = 370,
    Event371 = 371, // off_336
    Event372 = 372, // off_336
    Event373 = 373, // off_336
    Event374 = 374, // off_336
    Event375 = 375, // off_336
    QuestMapEvent = 376, // off_336
    ServerRequestCallbackResponse1 = 378,
    ServerRequestCallbackResponse2 = 379,
    ServerRequestCallbackResponse3 = 380,
    AgentUpdateFlagsRetainer = 381,
    QuestManagerSetUnkBitmask1 = 382,
    Event384 = 384, // off_312
    RaptureLogModulePrintString = 385,
    Event396 = 396, // off_304
    Mount = 397,
    Event398 = 398, // off_304
    Event399 = 399,
    Event400 = 400, // off_344
    Event401 = 401, // off_344
    EnvControl = 402,
    EnvControl4 = 403,
    EnvControl8 = 404,
    EnvControl12 = 405,
    SystemLogMessage1 = 408,
    SystemLogMessage2 = 409,
    SystemLogMessage4 = 410,
    SystemLogMessage8 = 411,
    SystemLogMessage16 = 412,
    BattleTalk2 = 414,
    BattleTalk4 = 415,
    BattleTalk8 = 416,
    TooFarAway = 417,
    MapUpdate = 418,
    MapUpdate4 = 419,
    MapUpdate8 = 420,
    MapUpdate16 = 421,
    MapUpdate32 = 422,
    MapUpdate64 = 423,
    MapUpdate128 = 424,
    BalloonTalk2 = 426,
    BalloonTalk4 = 427,
    BalloonTalk8 = 428,
    WeatherChange = 430,
    PlayerTitleList = 431,
    Discovery = 432,
    CheckBitMask = 433,
    EorzeaTimeOffset = 434,
    ChocoboTaxiStart = 436,
    FestivalQuestWork437 = 437,
    FestivalQuestWork438 = 438,
    FestivalQuestWork439 = 439,
    FestivalQuestWork440 = 440,
    FestivalQuestWork441 = 441,
    CharaCard442 = 442,
    QuestRecomplete443 = 443, // Accepted quest is nothing
    Leve444 = 444, // Accepted leve is nothing
    DebugPrintStringNameReward = 445,
    DebugPrintEntity = 446,
    EquipDisplayFlags = 447,
    NpcYell = 448,
    CharaUnk449 = 449,
    FateUpdate = 450,
    Loot451 = 451,
    Fate452 = 452,
    FateInfo = 453,
    FateProgress = 455,
    FateSetFloat = 456,
    Cabinet = 457,
    AchievementList = 458,
    AchievementNearCompletion = 459,
    ColosseumRecord460 = 460,
    ColosseumRecord461 = 461,
    ColosseumRecord462 = 462,
    CompanionSetName = 463,
    SetPetCrossHotbarSlot = 464,
    InventoryCharaMake = 465,
    Fate466 = 466,
    AchievementMergeBitmask = 467, // LandSetInitialize
    LandUpdate = 468,
    YardObjectSpawn = 469,
    HousingIndoorInitialize = 470,
    LandAvailability = 471,
    Housing472 = 472,
    LandPriceUpdate = 473,
    LandInfoSign = 474,
    LandRename = 475,
    HousingEstateGreeting = 476,
    HousingUpdateLandFlagsSlot = 477,
    HousingLandFlags = 478, // LandSetInitialize
    HousingShowEstateGuestAccess = 479,
    HousingGuestAccessSetting = 480,
    HousingObjectInitialize = 481,
    HousingInternalObjectSpawn = 482,
    Housing483 = 483,
    HousingWardInfo = 484,
    HousingObjectMove = 485,
    HousingObjectDye = 486,
    Housing487 = 487,
    Housing488 = 488,
    Housing489 = 489,
    Housing490 = 490,
    Housing491 = 491,
    Housing492 = 492,
    Housing493 = 493,
    Unk494 = 494,
    Unk495 = 495,
    Unk496 = 496,
    Unk497 = 497,
    SharedEstateSettingsResponse = 498,
    HousingPersonalRoomMansionRoom = 499,
    HousingBuddyList = 500,
    Housing501 = 501,
    Housing502 = 502,
    Housing503 = 503,
    Unk504 = 504,
    Telepo = 505,
    GcArmyExpeditionMemberUpdate = 506,
    GcArmyMember = 507,
    GcArmyExpeditionEnlistment = 508,
    GcArmyData = 509,
    GcArmyExpeditionMissionResult = 510,
    GcArmy511 = 511,
    GcArmyExpeditionDailyQuestRepeatFlags = 512, // GetSheetByIndex(97); ENpcBase
    PlaylistEdit = 513,
    LandUpdateHouseName = 514,
    QuestManager515 = 515,
    QuestManager516 = 516,
    QuestManager517 = 517,
    Housing518 = 518,
    Housing519 = 519,
    Loot520 = 520,
    Housing521 = 521,
    Housing522 = 522,
    Housing523 = 523,
    Housing524 = 524,
    AirshipTimers = 525,
    Housing526 = 526,
    Housing527 = 527,
    Housing528 = 528,
    Housing529 = 529,
    Housing530 = 530,
    Housing531 = 531,
    Housing532 = 532,
    PlaceMarker = 533,
    WaymarkPreset = 534,
    Waymark = 535,
    DismountFindChairInfo = 536,
    Unk537 = 537, // same instance with 494-497
    UnMount = 538,
    SetDirectorData = 539, // GetDirectorByEventId(0x80040001)
    LotteryWeekly = 540,
    CeremonySetActorAppearance = 541,
    GoldSaucer544 = 544,
    Housing545 = 545,
    HousingWorkshop546 = 546,
    AirshipStatusList = 547,
    AirshipStatus = 548,
    AirshipExplorationResult = 549,
    SubmarineStatusList = 550,
    SubmarineProgressionStatus = 551,
    SubmarineExplorationResult = 552,
    RollDice = 553,
    SubmarineTimers = 554,
    Submarine555 = 555,
    Submarine556 = 556,
    ContentsNote557 = 557,
    Null558 = 558,
    Null559 = 559,
    Shop560 = 560, // GetEventHandlerById(Instance, 0x310001)
    Shop561 = 561,
    Shop562 = 562,
    Shop563 = 563,
    Shop564 = 564,
    Shop565 = 565,
    DeepDungeonInspect = 566,
    Shop567 = 567, // [InstanceContentDirector + 3622] == 9
    RaceChocobo568 = 568,
    RaceChocobo569 = 569,
    RaceChocobo570 = 570,
    RaceChocobo571 = 571,
    RaceChocobo572 = 572,
    CrystallineConflict573 = 573,
    CrystallineConflict574 = 574,
    CrystallineConflict575 = 575,
    TripleTriad576 = 576,
    TripleTriad577 = 577,
    TripleTriad578 = 578,
    PvPDuelRequest = 579,
    WeeklyBingo = 580, // Wondrous Tails
    Housing581 = 581,
    SetInstanceContentUI = 582,
    CharaSetPos = 583,
    PrepareZoning = 584, // ShowLogMessage
    ActorGauge = 585,
    ActorGaugeCharaVisualEffect = 586,
    LandSetMap = 587,
    Fall = 588,
    MissionStart = 589, // ContentDirector + 0x700
    Mission590 = 590, // ContentDirector + 0x700
    Mission591 = 591, // ContentDirector + 0x700
    RivalWing592 = 592,
    RivalWing593 = 593,
    RivalWing594 = 594,
    RivalWing595 = 595,
    RivalWing596 = 596,
    RivalWing597 = 597,
    RivalWing598 = 598,
    Performance = 599,
    Performance600 = 600,
    PvpProfile = 601,
    MiragePrismPrismBox = 602,
    Mirage603 = 603,
    Mirage604 = 604,
    EurekaElementalEdit = 605,
    PublicContent606 = 606, // UIModule + 0x340 GetPublicContentDirector GetRowBySheetIndexAndRowId(166)
    PublicContent607 = 607, // UIModule + 0x348
    PublicContent608 = 608, // UIModule + 0x340
    PublicContent609 = 609, // UIModule + 0x350
    PublicContent610 = 610, // UIModule + 0x340
    FashionCheck611 = 611,
    FashionCheck612 = 612,
    FashionCheck613 = 613,
    FashionCheck614 = 614,
    Housing615 = 615,
    Housing616 = 616,
    SatisfactionSupply = 617,
    DomanEnclave = 618,
    MerchantSetting619 = 619, // Mannequins 服装模特
    MerchantSetting620 = 620, // Mannequins 服装模特
    PublicContent621 = 621, // UIModule + 0x340
    TreasureHuntDungeonDirector = 622, // UIModule + 0x340
    Mahjong623 = 623,
    Mahjong624 = 624,
    Mahjong625 = 625,
    Mahjong626 = 626,
    Mahjong627 = 627,
    Mahjong628 = 628,
    Mahjong629 = 629,
    TimersAozContentBriefing = 630,
    InstanceContentDirector631 = 631, // InstanceContentDirector + 0xE26
    AozNotebook = 632,
    MahjongAgent633 = 633,
    MahjongAgent634 = 634,
    MahjongAgent635 = 635,
    ContentDirector636 = 636,
    Dawn637 = 637,
    Dawn638 = 638,
    Dawn639 = 639,
    PlayMotionSync = 640,
    HWD641 = 641,
    HWD642 = 642,
    Fate643 = 643,
    IKDFishingLog644 = 644,
    IKDFishingLog645 = 645,
    CEDirector = 646, // [InstanceContentDirector + 0xE26] == 16   InstanceContentDirector + 0x2240
    IKDMission647 = 647,
    SetDesynthesisLevels = 648,
    Tomestone649 = 649,
    Tomestone650 = 650,
    Bozja651 = 651,
    Bozja652 = 652,
    Bozja653 = 653,
    BozjaLostFindsHolster = 654, // 失传技能库的内容已变更。
    QuestEffect655 = 655,
    QuestEffect656 = 656,
    QuestEffect657 = 657,
    AgentMap658 = 658,
    MJI659 = 659,
    MJISchedule = 660,
    MJICraftUpdateScheduleData = 661,
    MJI662 = 662,
    MJI663 = 663,
    MJILoadDemandResearch664 = 664,
    MJIWorkshopDemandResearch = 665,
    MJI666 = 666,
    MJI667 = 667,
    MJIWorkshopSupplyDemand = 668,
    MJI669 = 669,
    MJI670 = 670,
    MJI671 = 671,
    MJI672 = 672,
    MJI674 = 674,
    MJI675 = 675,
    MJI676 = 676,
    MJI677 = 677,
    MJI678 = 678,
    MJI679 = 679,
    MJI680 = 680,
    MJI681 = 681,
    MJI682 = 682,
    MJI683 = 683,
    MJIWorkshopFavors = 684,
    TripleTriad688 = 688,
    TripleTriad689 = 689,
    TripleTriad690 = 690,
    TripleTriad691 = 691,
    CutsceneReplay = 692,
    FittingShopUpdate = 693,
    InputTimer = 694, // Client::UI::Misc::InputTimerModule
    MJI695 = 695, // Confirmed in game
    CharaCardBanner = 696,
    CharaCardData = 697,
    ContentDirector698 = 698,
    EventHandler699 = 699,
    ContentDirector702 = 702,
    BozjaMaybe703 = 703,
    BozjaMaybe704 = 704,
    BozjaMaybe708 = 708,
    Bozja715 = 715,
    MassivePcContentDirector716 = 716, // MassivePcContentDirector
    MassivePcContentDirector717 = 717, // MassivePcContentDirector

    Null685 = 685,
    Null686 = 686,
    Null687 = 687,
    Null705 = 705,
    Null706 = 706,
    Null707 = 707,
    Null709 = 709,
    Null710 = 710,
    Null711 = 711,
    Null712 = 712,
    Null713 = 713,
    Null714 = 714,
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IPCHeader
{
    public ushort Magic; // 0x0014
    public ushort MessageType;
    public uint Unknown1;
    public uint Epoch;
    public uint Unknown2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RSVData
{
    public int ValueLength;
    public fixed byte Key[48];
    public fixed byte Value[1]; // variable-length
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct Countdown
{
    public uint SenderID;
    public ushort u4;
    public ushort Time;
    public byte FailedInCombat;
    public byte u9;
    public byte u10;
    public fixed byte Text[37];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct CountdownCancel
{
    public uint SenderID;
    public ushort u4;
    public ushort u6;
    public fixed byte Text[32];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct MarketBoardItemListingCount
{
    public uint Error;
    public byte NumItems;
    public fixed byte Padding[3];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct MarketBoardItemListingEntry
{
    public ulong ListingId;
    public ulong SellingRetainerContentId;
    public ulong SellingPlayerContentId;
    public ulong ArtisanId;
    public uint UnitPrice;
    public uint TotalTax;
    public uint Quantity;
    public uint ItemId;
    public ushort ContainerId;
    public ushort Durability;
    public ushort Spiritbond;
    public fixed ushort Materia[5];
    public uint Unk40;
    public ushort Unk44;
    public fixed byte RetainerName[32];
    public fixed byte Unk66[32];
    public byte IsHQ;
    public byte MateriaCount;
    public byte Unk88;
    public byte TownId;
    public byte Stain0Id;
    public byte Stain1Id;
    public uint Unk8C;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct MarketBoardItemListing
{
    public fixed byte EntriesRaw[10 * 0x90];
    public byte NextPageIndex;
    public byte FirstPageIndex;
    public byte RequestId;
    public fixed byte Padding[5];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct MarketBoardPurchase
{
    public uint ItemId;
    public uint ErrorLogId;
    public uint Quantity;
    public byte Stackable;
    public fixed byte Padding[3];
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct MarketBoardSale
{
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public uint Quantity;
    [FieldOffset(0x08)] public uint UnitPrice;
    [FieldOffset(0x0C)] public uint TotalTax;
    [FieldOffset(0x10)] public byte SaleType; // 1 = normal sale, 2 = everything sold, 3 = mannequin
    [FieldOffset(0x11)] public byte TownId;
}

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct MarketBoardItemListingHistoryEntry
{
    [FieldOffset(0x00)] public uint UnitPrice;
    [FieldOffset(0x04)] public uint SaleUnixTimestamp;
    [FieldOffset(0x08)] public uint Quantity;
    [FieldOffset(0x0C)] public byte IsHQ;
    [FieldOffset(0x0D)] public byte UnkD;
    [FieldOffset(0x0E)] public fixed byte RetainerName[32];
}

[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe struct MarketBoardItemListingHistory
{
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public fixed byte RawEntries[20 * 0x30];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RetainerState
{
    public ulong RetainerId;
    public ulong Flags; // high byte & 0xF is town, highest bit is whether retainer is now selling
    public uint CustomMessageId;
    public byte StateChange; // % 10 is type (1 for rename?, 3 for start sell, 4 for stop sell)
    public fixed byte Name[32];
    public fixed byte Padding[3];

    public readonly byte Town => (byte)((Flags >> 56) & 0xF);
    public readonly bool IsSelling => (Flags >> 63) != 0;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Status
{
    public ushort ID;
    public ushort Extra;
    public float RemainingTime;
    public uint SourceID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct StatusEffectList
{
    public Class ClassID;
    public byte Level;
    public byte u2;
    public byte u3; // != 0 => set alliance member flag 8
    public int CurHP;
    public int MaxHP;
    public ushort CurMP;
    public ushort MaxMP;
    public ushort ShieldValue;
    public ushort u12;
    public fixed byte Statuses[30 * 12]; // Status[30]
    public uint u17C;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StatusEffectListEureka
{
    public byte Rank;
    public byte Element;
    public byte u2;
    public byte pad3;
    public StatusEffectList Data;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StatusEffectListBozja
{
    public byte Rank;
    public byte pad1;
    public ushort pad2;
    public StatusEffectList Data;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct StatusEffectListDouble
{
    public fixed byte SecondSet[30 * 12]; // Status[30]
    public StatusEffectList Data;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EffectResultEffect
{
    public byte EffectIndex;
    public byte pad1;
    public ushort StatusID;
    public ushort Extra;
    public ushort pad2;
    public float Duration;
    public uint SourceID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct EffectResultEntry
{
    public uint RelatedActionSequence;
    public uint ActorID;
    public uint CurHP;
    public uint MaxHP;
    public ushort CurMP;
    public byte RelatedTargetIndex;
    public Class ClassID;
    public byte ShieldValue;
    public byte EffectCount;
    public ushort u16;
    public fixed byte Effects[4 * 16]; // EffectResultEffect[4]
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct EffectResultN
{
    public byte NumEntries;
    public byte pad1;
    public ushort pad2;
    public fixed byte Entries[1 * 0x58]; // N=1/4/8/16
    // followed by 1 dword padding
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct EffectResultBasicEntry
{
    public uint RelatedActionSequence;
    public uint ActorID;
    public uint CurHP;
    public byte RelatedTargetIndex;
    public byte uD;
    public ushort uE;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct EffectResultBasicN
{
    public byte NumEntries;
    public byte pad1;
    public ushort pad2;
    public fixed byte Entries[1 * 16]; // N=1/4/8/16/32/64
    // followed by 1 dword padding
}

public enum ActorControlCategory : ushort
{
    ToggleWeapon = 0, // from dissector
    AutoAttack = 1, // from dissector
    SetStatus = 2, // from dissector
    CastStart = 3, // from dissector
    ToggleAggro = 4, // from dissector
    ClassJobChange = 5, // from dissector
    Death = 6, // dissector calls it DefeatMsg
    GainExpMsg = 7, // from dissector
    LevelUpEffect = 10, // from dissector
    ExpChainMsg = 12, // from dissector
    HpSetStat = 13, // from dissector
    DeathAnimation = 14, // from dissector
    CancelCast = 15, // dissector calls it CastInterrupt (ActorControl), machina calls it CancelAbility
    RecastDetails = 16, // p1=group id, p2=elapsed, p3=total
    Cooldown = 17, // dissector calls it ActionStart (ActorControlSelf)
    GainEffect = 20, // note: this packet only causes log message and hit vfx to appear, it does not actually update statuses
    LoseEffect = 21,
    UpdateEffect = 22,
    HotDot = 23, // dissector calls it HPFloatingText
    UpdateRestedExp = 24, // from dissector
    Flee = 27, // from dissector
    UnkVisControl = 30, // visibility control ??? (ActorControl, params=delay-after-spawn, visible, id, 0)
    TargetIcon = 34, // dissector calls it CombatIndicationShow, this is for boss-related markers, param1 = marker id, param2=param3=param4=0
    Tether = 35,
    SpawnEffect = 37, // from dissector
    ToggleInvisible = 38, // from dissector
    ToggleActionUnlock = 41, // from dissector
    UpdateUiExp = 43, // from dissector
    DmgTakenMsg = 45, // from dissector
    TetherCancel = 47,
    SetTarget = 50, // from dissector
    Targetable = 54, // dissector calls it ToggleNameHidden
    SetAnimationState = 62, // example - ASSN beacon activation; param1 = animation set index (0 or 1), param2 = animation index (0-7)
    SetModelState = 63, // example - TEA liquid hand (open/closed); param1=ModelState row index, rest unused
    LimitBreakStart = 71, // from dissector
    LimitBreakPartyStart = 72, // from dissector
    BubbleText = 73, // from dissector
    DamageEffect = 80, // from dissector
    RaiseAnimation = 81, // from dissector
    TreasureScreenMsg = 87, // from dissector
    SetOwnerId = 89, // from dissector
    ItemRepairMsg = 92, // from dissector
    SetName = 98,
    BluActionLearn = 99, // from dissector
    DirectorInit = 100, // from dissector
    DirectorClear = 101, // from dissector
    LeveStartAnim = 102, // from dissector
    LeveStartError = 103, // from dissector
    DirectorEObjMod = 106, // from dissector
    DirectorUpdate = 109,
    ItemObtainMsg = 117, // from dissector
    DutyQuestScreenMsg = 123, // from dissector
    FatePosition = 125, // from dissector
    ItemObtainIcon = 132, // from dissector
    FateItemFailMsg = 133, // from dissector
    FateFailMsg = 134, // from dissector
    ActionLearnMsg1 = 135, // from dissector
    FreeEventPos = 138, // from dissector
    FateSync = 139, // from dissector
    DailyQuestSeed = 144, // from dissector
    SetBGM = 161, // from dissector
    UnlockAetherCurrentMsg = 164, // from dissector
    RemoveName = 168, // from dissector
    ScreenFadeOut = 170, // from dissector
    ZoneIn = 200, // from dissector
    ZoneInDefaultPos = 201, // from dissector
    TeleportStart = 203, // from dissector
    TeleportDone = 205, // from dissector
    TeleportDoneFadeOut = 206, // from dissector
    DespawnZoneScreenMsg = 207, // from dissector
    InstanceSelectDlg = 210, // from dissector
    ActorDespawnEffect = 212, // from dissector
    ForcedMovement = 226,
    CompanionUnlock = 253, // from dissector
    ObtainBarding = 254, // from dissector
    EquipBarding = 255, // from dissector
    CompanionMsg1 = 258, // from dissector
    CompanionMsg2 = 259, // from dissector
    ShowPetHotbar = 260, // from dissector
    ActionLearnMsg = 265, // from dissector
    ActorFadeOut = 266, // from dissector
    ActorFadeIn = 267, // from dissector
    WithdrawMsg = 268, // from dissector
    OrderCompanion = 269, // from dissector
    ToggleCompanion = 270, // from dissector
    LearnCompanion = 271, // from dissector
    ActorFateOut1 = 272, // from dissector
    Emote = 290, // from dissector
    EmoteInterrupt = 291, // from dissector
    SetPose = 295, // from dissector
    FishingLightChange = 300, // from dissector
    GatheringSenseMsg = 304, // from dissector
    PartyMsg = 305, // from dissector
    GatheringSenseMsg1 = 306, // from dissector
    GatheringSenseMsg2 = 312, // from dissector
    FishingMsg = 320, // from dissector
    FishingTotalFishCaught = 322, // from dissector
    FishingBaitMsg = 325, // from dissector
    FishingReachMsg = 327, // from dissector
    FishingFailMsg = 328, // from dissector
    WeeklyIntervalUpdateTime = 336, // from dissector
    MateriaConvertMsg = 350, // from dissector
    MeldSuccessMsg = 351, // from dissector
    MeldFailMsg = 352, // from dissector
    MeldModeToggle = 353, // from dissector
    AetherRestoreMsg = 355, // from dissector
    DyeMsg = 360, // from dissector
    ToggleCrestMsg = 362, // from dissector
    ToggleBulkCrestMsg = 363, // from dissector
    MateriaRemoveMsg = 364, // from dissector
    GlamourCastMsg = 365, // from dissector
    GlamourRemoveMsg = 366, // from dissector
    RelicInfuseMsg = 377, // from dissector
    PlayerCurrency = 378, // from dissector
    AetherReductionDlg = 381, // from dissector
    PlayActionTimeline = 407, // seems to be equivalent to 412?..
    EObjSetState = 409, // from dissector
    Unk6 = 412, // from dissector
    EObjAnimation = 413, // from dissector
    SetCompanionOwnerId = 417,
    SetTitle = 500, // from dissector
    SetTargetSign = 502,
    SetStatusIcon = 504, // from dissector
    LimitBreakGauge = 505, // name from dissector
    SetHomepoint = 507, // from dissector
    SetFavorite = 508, // from dissector
    LearnTeleport = 509, // from dissector
    OpenRecommendationGuide = 512, // from dissector
    ArmoryErrorMsg = 513, // from dissector
    AchievementProgress = 514,
    AchievementPopup = 515, // from dissector
    LogMsg = 517, // from dissector
    AchievementMsg = 518, // from dissector
    SetCutsceneFlags = 519,
    SetItemLevel = 521, // from dissector
    ChallengeEntryCompleteMsg = 523, // from dissector
    ChallengeEntryUnlockMsg = 524, // from dissector
    DesynthOrReductionResult = 527, // from dissector
    GilTrailMsg = 529, // from dissector
    HuntingLogRankUnlock = 541, // from dissector
    HuntingLogEntryUpdate = 542, // from dissector
    HuntingLogSectionFinish = 543, // from dissector
    HuntingLogRankFinish = 544, // from dissector
    SetMaxGearSets = 560, // from dissector
    SetCharaGearParamUI = 608, // from dissector
    ToggleWireframeRendering = 609, // from dissector
    ActionRejected = 700, // from XivAlexander (ActorControlSelf)
    ExamineError = 703, // from dissector
    GearSetEquipMsg = 801, // from dissector
    SetFestival = 902, // from dissector
    ToggleOrchestrionUnlock = 918, // from dissector
    ServerRequestCallbackResponse = 925,
    SetMountSpeed = 927, // from dissector
    Dismount = 929, // from dissector
    BeginReplayAck = 930, // from dissector
    EndReplayAck = 931, // from dissector
    ShowBuildPresetUI = 1001, // from dissector
    ShowEstateExternalAppearanceUI = 1002, // from dissector
    ShowEstateInternalAppearanceUI = 1003, // from dissector
    BuildPresetResponse = 1005, // from dissector
    RemoveExteriorHousingItem = 1007, // from dissector
    RemoveInteriorHousingItem = 1009, // from dissector
    ShowHousingItemUI = 1015, // from dissector
    HousingItemMoveConfirm = 1017, // from dissector
    OpenEstateSettingsUI = 1023, // from dissector
    HideAdditionalChambersDoor = 1024, // from dissector
    HousingStoreroomStatus = 1049, // from dissector
    TripleTriadCard = 1204, // from dissector
    TripleTriadUnknown = 1205, // from dissector
    FateNpc = 2351, // from dissector
    FateInit = 2353, // from dissector
    FateAssignID = 2356, // p1 = fate id, assigned to main obj
    FateStart = 2357, // from dissector
    FateEnd = 2358, // from dissector
    FateProgress = 2364, // from dissector
    SetPvPState = 1504, // from dissector
    EndDuelSession = 1505, // from dissector
    StartDuelCountdown = 1506, // from dissector
    StartDuel = 1507, // from dissector
    DuelResultScreen = 1508, // from dissector
    SetDutyActionSet = 1512,
    SetDutyActionDetails = 1513,
    SetDutyActionPresent = 1514,
    SetDutyActionActive = 1515,
    SetDutyActionCharges = 1516,
    IncrementRecast = 1536, // p1=cooldown group, p2=delta time quantized to 100ms; example is brd mage ballad proc
    EurekaStep = 1850, // from dissector
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorControl
{
    public ActorControlCategory category;
    public ushort padding0;
    public uint param1;
    public uint param2;
    public uint param3;
    public uint param4;
    public uint padding1;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorControlSelf
{
    public ActorControlCategory category;
    public ushort padding0;
    public uint param1;
    public uint param2;
    public uint param3;
    public uint param4;
    public uint param5;
    public uint param6;
    public uint padding1;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorControlTarget
{
    public ActorControlCategory category;
    public ushort padding0;
    public uint param1;
    public uint param2;
    public uint param3;
    public uint param4;
    public uint padding1;
    public ulong TargetID;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UpdateHpMpTp
{
    public uint HP;
    public ushort MP;
    public ushort GP;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActionEffect
{
    public ActionEffectType Type;
    public byte Param0;
    public byte Param1;
    public byte Param2;
    public byte Param3;
    public byte Param4;
    public ushort Value;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffectHeader
{
    public ulong animationTargetId;  // who the animation targets
    public uint actionId; // what the casting player casts, shown in battle log / ui
    public uint globalEffectCounter;
    public float animationLockTime;
    public uint BallistaEntityId; // for 'artillery' actions - entity id of ballista source
    public ushort SourceSequence; // 0 = initiated by server, otherwise corresponds to client request sequence id
    public ushort rotation;
    public ushort actionAnimationId;
    public byte variation; // animation
    public ActionType actionType;
    public byte Flags;
    public byte NumTargets; // machina calls it 'effectCount', but it is misleading imo
    public ushort padding21;
    public ushort padding22;
    public ushort padding23;
    public ushort padding24;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffect1
{
    public ActionEffectHeader Header;
    public fixed ulong Effects[8]; // ActionEffect[8]
    public ushort padding3;
    public uint padding4;
    public fixed ulong TargetID[1];
    public uint padding5;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffect8
{
    public ActionEffectHeader Header;
    public fixed ulong Effects[8 * 8]; // ActionEffect[8 * 8]
    public ushort padding3;
    public uint padding4;
    public fixed ulong TargetID[8];
    public ushort TargetX; // floatCoord = ((intCoord * 3.0518043) * 0.0099999998) - 1000.0 (0 => -1000, 65535 => +1000)
    public ushort TargetY;
    public ushort TargetZ;
    public ushort padding5;
    public uint padding6;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffect16
{
    public ActionEffectHeader Header;
    public fixed ulong Effects[8 * 16]; // ActionEffect[8 * 16]
    public ushort padding3;
    public uint padding4;
    public fixed ulong TargetID[16];
    public ushort TargetX;
    public ushort TargetY;
    public ushort TargetZ;
    public ushort padding5;
    public uint padding6;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffect24
{
    public ActionEffectHeader Header;
    public fixed ulong Effects[8 * 24]; // ActionEffect[8 * 24]
    public ushort padding3;
    public uint padding4;
    public fixed ulong TargetID[24];
    public ushort TargetX;
    public ushort TargetY;
    public ushort TargetZ;
    public ushort padding5;
    public uint padding6;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ActionEffect32
{
    public ActionEffectHeader Header;
    public fixed ulong Effects[8 * 32]; // ActionEffect[8 * 32]
    public ushort padding3;
    public uint padding4;
    public fixed ulong TargetID[32];
    public ushort TargetX;
    public ushort TargetY;
    public ushort TargetZ;
    public ushort padding5;
    public uint padding6;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct StatusEffectListPlayer
{
    public fixed byte Statuses[30 * 12]; // Status[30]
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct UpdateRecastTimes
{
    public fixed float Elapsed[80];
    public fixed float Total[80];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct UpdateDutyRecastTimes
{
    public fixed float Elapsed[2];
    public fixed float Total[2];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorMove
{
    public ushort Rotation;
    public ushort AnimationFlags;
    public byte AnimationSpeed;
    public byte UnknownRotation;
    public ushort X;
    public ushort Y;
    public ushort Z;
    public uint Unknown;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorSetPos
{
    public ushort Rotation;
    public byte u2;
    public byte u3;
    public uint u4;
    public float X;
    public float Y;
    public float Z;
    public uint u14;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorCast
{
    public ushort SpellID;
    public ActionType ActionType;
    public byte BaseCastTime100ms;
    public uint ActionID; // also action ID; dissector calls it ItemId - matches actionId of ActionEffectHeader - e.g. when using KeyItem, action is generic 'KeyItem 1', Unknown1 is actual item id, probably similar for stuff like mounts etc.
    public float CastTime;
    public uint TargetID;
    public ushort Rotation;
    public byte Interruptible;
    public byte u1;
    public uint BallistaEntityId; // for 'artillery' actions - entity id of ballista source
    public ushort PosX;
    public ushort PosY;
    public ushort PosZ;
    public ushort u3;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UpdateHateEntry
{
    public uint ObjectID;
    public byte Enmity;
    public byte pad5;
    public ushort pad6;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct UpdateHate
{
    public byte NumEntries;
    public byte pad1;
    public ushort pad2;
    public fixed ulong Entries[8]; // UpdateHateEntry[8]
    public uint pad3;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct UpdateHater
{
    public byte NumEntries;
    public byte pad1;
    public ushort pad2;
    public fixed ulong Entries[32]; // UpdateHateEntry[32]
    public uint pad3;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct SpawnObject
{
    public byte Index;
    public byte Kind;
    public byte u2_state;
    public byte u3;
    public uint DataID;
    public uint InstanceID;
    public uint u_levelID;
    public uint DutyID;
    public uint OwnerID;
    public uint u_gimmickID;
    public float Scale;
    public ushort u20;
    public ushort Rotation;
    public ushort FateID;
    public ushort EventState; // for common gameobject field
    public uint EventObjectState; // for eventobject-specific field
    public uint u_modelID;
    public Vector3 Position;
    public ushort u3C;
    public ushort u3E;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct UpdateClassInfo
{
    public Class ClassID;
    public byte pad1;
    public ushort CurLevel;
    public ushort ClassLevel;
    public ushort SyncedLevel;
    public uint CurExp;
    public uint RestedExp;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UpdateClassInfoEureka
{
    public byte Rank;
    public byte Element;
    public byte u2;
    public byte pad3;
    public UpdateClassInfo Data;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct UpdateClassInfoBozja
{
    public byte Rank;
    public byte pad1;
    public ushort pad2;
    public UpdateClassInfo Data;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RetainerSummary
{
    public uint SequenceId;
    public byte NumInformationPackets;
    public byte MaxRetainerEntitlement;
    public byte IsResponseToServerCallbackRequest;
    public byte Pad1;
    public uint ServerCallbackListenerIndex;
    public fixed byte DisplayOrder[10];
    public fixed byte Pad2[2];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RetainerInfo
{
    public uint SequenceId;
    public uint Pad1;
    public ulong RetainerId;
    public byte Index;
    public byte NumItemsInInventory;
    public ushort Pad2;
    public uint Gil;
    public byte NumItemsOnMarket;
    public byte Town;
    public byte ClassJob;
    public byte Level;
    public uint MarketExpire;
    public ushort VentureId;
    public ushort Pad3;
    public uint VentureComplete;
    public byte Available;
    public byte Pad4;
    public ushort Unk2A;
    public byte Unk2C;
    public fixed byte Name[32];
    public fixed byte Pad5[3];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RetainerMarketPriceSummary
{
    public uint SequenceId;
    public uint NumItemPackets;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct RetainerMarketPriceInfo
{
    public uint SequenceId;
    public uint InventoryType;
    public ushort Slot;
    public fixed byte Pad1[6];
    public ulong Unk10;
    public uint Unk18;
    public uint Pad2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct EventPlayN
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct PayloadCrafting // for EventHandler == 0x000A0001
    {
        public enum OperationId
        {
            StartPrepare = 1,
            StartInfo = 2,
            StartReady = 3,
            Finish = 4,
            Abort = 6,
            ReturnedReagents = 8,
            AdvanceCraftAction = 9,
            AdvanceNormalAction = 10,
            QuickSynthStart = 12,
            QuickSynthProgress = 13,
        }

        [Flags]
        public enum StepFlags : uint
        {
            u1 = 0x00000002, // always set?
            CompleteSuccess = 0x00000004, // set even if craft fails due to durability
            CompleteFail = 0x00000008,
            LastActionSucceeded = 0x00000010,
            ComboBasicTouch = 0x08000000,
            ComboStandardTouch = 0x10000000,
            ComboObserve = 0x20000000,
            NoCarefulsLeft = 0x40000000,
            NoHSLeft = 0x80000000,
        }

        [StructLayout(LayoutKind.Explicit, Size = 12)]
        public struct StartInfo // op id == StartInfo
        {
            [FieldOffset(0)] public ushort RecipeId;
            [FieldOffset(4)] public int StartingQuality;
            [FieldOffset(8)] public byte u8;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ReturnedReagents // op id == ReturnedReagents
        {
            public int u0;
            public int u4;
            public int u8;
            public fixed uint ItemIds[8];
            public fixed int NumNQ[8];
            public fixed int NumHQ[8];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct AdvanceStep // op id == Advance*Action
        {
            public int u0;
            public int u4;
            public int u8;
            public int LastActionId;
            public int DeltaCP;
            public int StepIndex;
            public int CurProgress;
            public int DeltaProgress;
            public int CurQuality;
            public int DeltaQuality;
            public int HQChance;
            public int CurDurability;
            public int DeltaDurability;
            public int Condition; // 1 = normal, ...
            public int u38; // usually 1, sometimes 2? related to quality
            public int ConditionParam; // used for good, related to splendorous?
            public StepFlags Flags;
            public int u44;
            public fixed int RemoveStatusIds[7];
            public fixed int RemoveStatusParams[7];
        }

        [StructLayout(LayoutKind.Explicit, Size = 12)]
        public struct QuickSynthStart // op id == QuickSynthStart
        {
            [FieldOffset(0)] public ushort RecipeId;
            [FieldOffset(4)] public byte MaxCount;
        }

        [FieldOffset(0)] public OperationId OpId;
        [FieldOffset(4)] public StartInfo OpStartInfo;
        [FieldOffset(4)] public ReturnedReagents OpReturnedReagents;
        [FieldOffset(4)] public AdvanceStep OpAdvanceStep;
        [FieldOffset(4)] public QuickSynthStart OpQuickSynthStart;
    }

    public ulong TargetID;
    public uint EventHandler;
    public ushort uC;
    public ushort pad1;
    public ulong u10;
    public byte PayloadLength; // in dwords
    public byte pad2;
    public ushort pad3;
    public fixed uint Payload[1]; // N = 1/4/8/16/32/64/128/255
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct DecodeServerRequestCallbackResponse
{
    public uint ListenerIndex;
    public uint ListenerRequestType;
    public byte DataCount;
    public fixed byte Padding[3];
    public fixed uint Data[1]; // variable length
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EnvControl
{
    public uint DirectorID;
    public ushort State1; // typically has 1 bit set
    public ushort State2; // typically has 1 bit set
    public byte Index;
    public byte pad9;
    public ushort padA;
    public uint padC;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NpcYell
{
    public ulong SourceID; //0x0
    public int u8;
    public ushort Message; //0xC
    public ushort uE;
    public ulong u10;
    public ulong u18;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct WaymarkPreset
{
    public byte Mask;
    public byte pad1;
    public ushort pad2;
    public fixed int PosX[8];// Xints[0] has X of waymark A, Xints[1] X of B, etc.
    public fixed int PosY[8];// To calculate 'float' coords from these you cast them to float and then divide by 1000.0
    public fixed int PosZ[8];
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct Waymark
{
    public BossMod.Waymark ID;
    public byte Active; // 0=off, 1=on
    public ushort pad2;
    public int PosX;
    public int PosY;// To calculate 'float' coords from these you cast them to float and then divide by 1000.0
    public int PosZ;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ActorGauge
{
    public Class ClassJobID;
    public ulong Payload;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CFPreferredRole
{
    public byte Unknown;
    public CFRole Leveling;
    public CFRole Highlevel;
    public CFRole MainScenario;
    public CFRole Guildhests;
    public CFRole Expert;
    public CFRole Trials;
    public CFRole LevelCapDungeons;
    public CFRole Mentor;
    public CFRole AllianceRaids;
    public CFRole NormalRaids;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PFUpdateRecruitNum
{
    public ushort All;
    public ushort All2;
    public ushort InWorld;
    public ushort Private;
    public ushort Other;
    public ushort DutyRoulette;
    public ushort Dungeons;
    public ushort Guildhests;
    public ushort Trials;
    public ushort Raids;
    public ushort HighEndDuty;
    public ushort PvP;
    public ushort GoldSaucer;
    public ushort FATE;
    public ushort TreasureHunt;
    public ushort Hunt;
    public ushort Gathering;
    public ushort DeepDungeon;
    public ushort FieldOperations;
    public ushort VCDungeons;
    public ushort Unknown21;
    public ushort Unknown22;
    public ushort Unknown23;
    public ushort Unknown24;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Mount
{
    public ushort MountID;
    public ushort StainID;
    public int ModelTop;
    public int ModelBody;
    public int ModelLegs;
}

[StructLayout(LayoutKind.Explicit, Size = 648, Pack = 1)]
public unsafe struct SpawnNPC // Client::Game::Character::CharacterSetupContainer_InitNPCCommon
{
    [FieldOffset(0)] public uint U0; // Chara+0x7C == Chara.LayoutId + 4
    [FieldOffset(4)] public uint U4; // Chara+0x1B40
    [FieldOffset(8)] public byte U8_01_03; // 01 03 Chara+0x1A0 == Chara.ModelScale - 8   if == 4 set flag at Chara+0x34
    [FieldOffset(9)] public byte U9_00_02; // 00 02 Chara+0x1CC == Chara.Level + 1
    [FieldOffset(10)] public byte U10; // Chara+0x1E8 = Chara+0x1E8 & 0b11111101 | payload[10] != 0 ? 2 : 0
    [FieldOffset(11)] public byte U11; // Chara+0x1E1
    [FieldOffset(12)] public byte U12; // Chara+0x1E2
    [FieldOffset(13)] public byte U13_Always14; // Chara+0x1E4
    [FieldOffset(14)] public byte U14; // Chara+0x1E3
    [FieldOffset(15)] public byte U15; // Chara+0x1E8 = Chara+0x1E8 & 0b11111110 | payload[15] != 0
    [FieldOffset(16)] public uint EntityId16;
    [FieldOffset(24)] public ulong FreeCompanyCrestData;
    [FieldOffset(32)] public ulong WeaponId0;
    [FieldOffset(36)] public ushort U36;
    [FieldOffset(40)] public ulong WeaponId1;
    [FieldOffset(48)] public ulong WeaponId2;
    [FieldOffset(56)] public uint CombatTaggerId;
    [FieldOffset(60)] public uint U60_U63;
    [FieldOffset(64)] public uint BNpcBaseId; // if BNpcBaseId == 952 && Chara+6F == 2  then 30178 else payload[110]
    [FieldOffset(68)] public uint BNpcNameId; // if BNpcNameId != 0 FormatName() else payload[NPCName]
    [FieldOffset(72)] public uint UnkId72;
    [FieldOffset(76)] public uint CompanionOwnerId; // Chara+0x22C4 == Chara.CompanionOwnerId + 4 == Chara.AccountId - 4
    [FieldOffset(80)] public ushort EventId; // Chara+0x97) |= 0xC; Chara.EventId = payload[80];
    [FieldOffset(84)] public uint OwnerId; // payload[128] != 2 | 7.21 no change | EntityIdCheckIsEqualToLocalPlayer
    [FieldOffset(88)] public uint EntityTeatherTargetMaybe;
    [FieldOffset(92)] public uint HP;
    [FieldOffset(96)] public uint maxHP;
    [FieldOffset(100)] public uint U100_08020400_08000600; // 08020400 08000600 Chara+0x1F0  if CharaMod != RidingPillion then bool v = payload[100] & 0x8000) != 0
    [FieldOffset(104)] public ushort FateId; // Chara+0x97) |= 0xC; Chara.FateId = payload[104];
    [FieldOffset(106)] public ushort MP; // sometimes 2800 sometimes 10000
    [FieldOffset(108)] public ushort maxMP;
    [FieldOffset(110)] public ushort BehaviorId; // if BNpcBaseId == 952 && Chara+6F == 2  then 30178 else payload[110] GetSheetByIndex(7) Behavior
    [FieldOffset(112)] public ushort ModelCharaId;
    [FieldOffset(114)] public short Rotation; // 32767 * 0.0095875263 * 0.0099999998 - 3.1415927 == 0
    [FieldOffset(116)] public ushort MountId;
    [FieldOffset(118)] public ushort CompanionData118;
    [FieldOffset(120)] public ushort CompanionData120;
    // [FieldOffset(122)] public ushort Ornament; // 7.21 new
    [FieldOffset(122)] public ushort Tether1;
    [FieldOffset(124)] public byte CharacterManagerIndex; // 7.21 124->126
    [FieldOffset(125)] public byte CharacterModes; // 01
    [FieldOffset(126)] public byte CharacterModesParam;
    [FieldOffset(127)] public byte ObjectKind; // 02
    [FieldOffset(128)] public byte SubKind; // payload[128] != 2 | 7.21 128->130 | if != 1 Chara+0x1AE2~0x1AE7 = payload[640~645] else Chara+0x1AE2 = payload[640]
    [FieldOffset(129)] public byte VfxVoiceId; // 04
    [FieldOffset(130)] public byte FreeCompanyCrestBitfield; // 04
    [FieldOffset(131)] public byte Battalion; // 04
    [FieldOffset(132)] public byte Level;
    [FieldOffset(133)] public byte ClassJobId;
    [FieldOffset(134)] public byte EventState; // 7.21 off + 2
    [FieldOffset(135)] public byte U135; // Chara+0x93 == Chara.YalmDistanceFromPlayerZ + 1
    [FieldOffset(136)] public byte CombatTagType;
    [FieldOffset(137)] public byte BuddyModelTop;
    [FieldOffset(138)] public byte BuddyModelBody;
    [FieldOffset(139)] public byte BuddyModelLegs;
    [FieldOffset(140)] public byte BuddyStain;
    [FieldOffset(141)] public byte U141; // Chara+0x1A0 == Chara.ModelScale - 8
    [FieldOffset(142)] public byte EurekaRank; // Chara+0x2A0
    [FieldOffset(143)] public byte EurekaElement; // Chara+0x2A0
    [FieldOffset(144)] public byte U144; // 0x1AC9 = ModelContainer.UnscaledRadius - 3 = ModelContainer.ModelSkeletonId_2 + 5
    [FieldOffset(145)] public byte TimelineModelState; // 0xC70 = Chara.TimelineContainer.ModelState
    [FieldOffset(146)] public byte U146; // 0x1ACA = ModelContainer.UnscaledRadius - 2
    [FieldOffset(147)] public byte TimelineAnimationState; // 0xC71 0xC72
    [FieldOffset(148)] public uint StatusId; // 7.21 148->152 150->154 156->160
    [FieldOffset(150)] public uint ParamOnGainStatus;
    [FieldOffset(156)] public uint SourceId; // BuddyInstance.BuddyMember.StatusManager.SetStatus(statusIndex, statusId = payload[148], remaining, param = payload[150], sourceId = payload[156], refreshFlags = 1)
    [FieldOffset(508)] public Vector3 Pos;
    [FieldOffset(520)] public int U520;
    [FieldOffset(560)] public fixed byte EquipmentId[10];
    [FieldOffset(570)] public ushort GlassId;
    [FieldOffset(574)] public fixed byte NPCName[74];
    [FieldOffset(606)] public fixed byte CustomizeData[26]; // Chara.DrawDataContainer.CustomizeData
    [FieldOffset(607)] public byte Sex;
    [FieldOffset(632)] public uint U632; // Chara+0x2280 == Chara.CompanionObject + 8 == Chara.TargetId - 8
    [FieldOffset(636)] public ushort U636; // Chara+0x2284
    [FieldOffset(638)] public byte U638; // Chara+0x2286
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FirstAttack
{
    public uint Type;
    public uint U1;
    public uint ID;
    public uint U2;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RemainingPlayTime
{
    public uint Minutes;
    public uint Days;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ServerNotice
{
    public byte Unk;
    public fixed byte Message[700]; // 776 - 1
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct ChatRecv
{
    public uint Unk1;
    public uint Unk2;
    public uint Unk3;
    public uint Unk4;
    public uint EntityId;
    public ushort WorldId;
    public ushort MessageType;
    public fixed byte Name[32]; // 56 - 24 = 32
    public fixed byte Message[1024]; // 1080 - 56 = 1024
}

// [StructLayout(LayoutKind.Explicit, Size = 1080, Pack = 1)]
// public struct Chat2
// {
//     [FieldOffset(0)]public uint Unk1;
//     [FieldOffset(4)]public uint Unk2;
//     [FieldOffset(8)]public uint Unk3;
//     [FieldOffset(12)]public uint Unk4;
//     [FieldOffset(16)]public uint EntityId;
//     [FieldOffset(20)]public ushort WorldId;
//     [FieldOffset(22)]public ushort MessageType;
//     [FieldOffset(24)]public Utf8String Name; // 56 - 24 = 32
//     [FieldOffset(56)]public Utf8String Message; // 1080 - 56 = 1024
// }
