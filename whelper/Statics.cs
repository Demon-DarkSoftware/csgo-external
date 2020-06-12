﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    public enum classes : int
    {
        NextBotCombatCharacter = 0,
        CAK47 = 1,
        CBaseAnimating = 2,
        CBaseAnimatingOverlay = 3,
        CBaseAttributableItem = 4,
        CBaseButton = 5,
        CBaseCombatCharacter = 6,
        CBaseCombatWeapon = 7,
        CBaseCSGrenade = 8,
        CBaseCSGrenadeProjectile = 9,
        CBaseDoor = 10,
        CBaseEntity = 11,
        CBaseFlex = 12,
        CBaseGrenade = 13,
        CBaseParticleEntity = 14,
        CBasePlayer = 15,
        CBasePropDoor = 16,
        CBaseTeamObjectiveResource = 17,
        CBaseTempEntity = 18,
        CBaseToggle = 19,
        CBaseTrigger = 20,
        CBaseViewModel = 21,
        CBaseVPhysicsTrigger = 22,
        CBaseWeaponWorldModel = 23,
        CBeam = 24,
        CBeamSpotlight = 25,
        CBoneFollower = 26,
        CBreakableProp = 27,
        CBreakableSurface = 28,
        CC4 = 29,
        CCascadeLight = 30,
        CChicken = 31,
        CColorCorrection = 32,
        CColorCorrectionVolume = 33,
        CCSGameRulesProxy = 34,
        CCSPlayer = 35,
        CCSPlayerResource = 36,
        CCSRagdoll = 37,
        CCSTeam = 38,
        CDEagle = 39,
        CDecoyGrenade = 40,
        CDecoyProjectile = 41,
        CDynamicLight = 42,
        CDynamicProp = 43,
        CEconEntity = 44,
        CEmbers = 45,
        CEntityDissolve = 46,
        CEntityFlame = 47,
        CEntityFreezing = 48,
        CEntityParticleTrail = 49,
        CEnvAmbientLight = 50,
        CEnvDetailController = 51,
        CEnvDOFController = 52,
        CEnvParticleScript = 53,
        CEnvProjectedTexture = 54,
        CEnvQuadraticBeam = 55,
        CEnvScreenEffect = 56,
        CEnvScreenOverlay = 57,
        CEnvTonemapController = 58,
        CEnvWind = 59,
        CFireCrackerBlast = 60,
        CFireSmoke = 61,
        CFireTrail = 62,
        CFish = 63,
        CFlashbang = 64,
        CFogController = 65,
        CFootstepControl = 66,
        CFunc_Dust = 67,
        CFunc_LOD = 68,
        CFuncAreaPortalWindow = 69,
        CFuncBrush = 70,
        CFuncConveyor = 71,
        CFuncLadder = 72,
        CFuncMonitor = 73,
        CFuncMoveLinear = 74,
        CFuncOccluder = 75,
        CFuncReflectiveGlass = 76,
        CFuncRotating = 77,
        CFuncSmokeVolume = 78,
        CFuncTrackTrain = 79,
        CGameRulesProxy = 80,
        CHandleTest = 81,
        CHEGrenade = 82,
        CHostage = 83,
        CHostageCarriableProp = 84,
        CIncendiaryGrenade = 85,
        CInferno = 86,
        CInfoLadderDismount = 87,
        CInfoOverlayAccessor = 88,
        CKnife = 89,
        CKnifeGG = 90,
        CLightGlow = 91,
        CMaterialModifyControl = 92,
        CMolotovGrenade = 93,
        CMolotovProjectile = 94,
        CMovieDisplay = 95,
        CParticleFire = 96,
        CParticlePerformanceMonitor = 97,
        CParticleSystem = 98,
        CPhysBox = 99,
        CPhysBoxMultiplayer = 100,
        CPhysicsProp = 101,
        CPhysicsPropMultiplayer = 102,
        CPhysMagnet = 103,
        CPlantedC4 = 104,
        CPlasma = 105,
        CPlayerResource = 106,
        CPointCamera = 107,
        CPointCommentaryNode = 108,
        CPoseController = 109,
        CPostProcessController = 110,
        CPrecipitation = 111,
        CPrecipitationBlocker = 112,
        CPredictedViewModel = 113,
        CProp_Hallucination = 114,
        CPropDoorRotating = 115,
        CPropJeep = 116,
        CPropVehicleDriveable = 117,
        CRagdollManager = 118,
        CRagdollProp = 119,
        CRagdollPropAttached = 120,
        CRopeKeyframe = 121,
        CSCAR17 = 122,
        CSceneEntity = 123,
        CShadowControl = 124,
        CSlideshowDisplay = 125,
        CSmokeGrenade = 126,
        CSmokeGrenadeProjectile = 127,
        CSmokeStack = 128,
        CSpatialEntity = 129,
        CSpotlightEnd = 130,
        CSprite = 131,
        CSpriteOriented = 132,
        CSpriteTrail = 133,
        CStatueProp = 134,
        CSteamJet = 135,
        CSun = 136,
        CSunlightShadowControl = 137,
        CTeam = 138,
        CTeamplayRoundBasedRulesProxy = 139,
        CTEArmorRicochet = 140,
        CTEBaseBeam = 141,
        CTEBeamEntPoint = 142,
        CTEBeamEnts = 143,
        CTEBeamFollow = 144,
        CTEBeamLaser = 145,
        CTEBeamPoints = 146,
        CTEBeamRing = 147,
        CTEBeamRingPoint = 148,
        CTEBeamSpline = 149,
        CTEBloodSprite = 150,
        CTEBloodStream = 151,
        CTEBreakModel = 152,
        CTEBSPDecal = 153,
        CTEBubbles = 154,
        CTEBubbleTrail = 155,
        CTEClientProjectile = 156,
        CTEDecal = 157,
        CTEDust = 158,
        CTEDynamicLight = 159,
        CTEEffectDispatch = 160,
        CTEEnergySplash = 161,
        CTEExplosion = 162,
        CTEFireBullets = 163,
        CTEFizz = 164,
        CTEFootprintDecal = 165,
        CTEFoundryHelpers = 166,
        CTEGaussExplosion = 167,
        CTEGlowSprite = 168,
        CTEImpact = 169,
        CTEKillPlayerAttachments = 170,
        CTELargeFunnel = 171,
        CTEMetalSparks = 172,
        CTEMuzzleFlash = 173,
        CTEParticleSystem = 174,
        CTEPhysicsProp = 175,
        CTEPlantBomb = 176,
        CTEPlayerAnimEvent = 177,
        CTEPlayerDecal = 178,
        CTEProjectedDecal = 179,
        CTERadioIcon = 180,
        CTEShatterSurface = 181,
        CTEShowLine = 182,
        CTesla = 183,
        CTESmoke = 184,
        CTESparks = 185,
        CTESprite = 186,
        CTESpriteSpray = 187,
        CTest_ProxyToggle_Networkable = 188,
        CTestTraceline = 189,
        CTEWorldDecal = 190,
        CTriggerPlayerMovement = 191,
        CTriggerSoundOperator = 192,
        CVGuiScreen = 193,
        CVoteController = 194,
        CWaterBullet = 195,
        CWaterLODControl = 196,
        CWeaponAug = 197,
        CWeaponAWP = 198,
        CWeaponBizon = 199,
        CWeaponCSBase = 200,
        CWeaponCSBaseGun = 201,
        CWeaponCycler = 202,
        CWeaponElite = 203,
        CWeaponFamas = 204,
        CWeaponFiveSeven = 205,
        CWeaponG3SG1 = 206,
        CWeaponGalil = 207,
        CWeaponGalilAR = 208,
        CWeaponGlock = 209,
        CWeaponHKP2000 = 210,
        CWeaponM249 = 211,
        CWeaponM3 = 212,
        CWeaponM4A1 = 213,
        CWeaponMAC10 = 214,
        CWeaponMag7 = 215,
        CWeaponMP5Navy = 216,
        CWeaponMP7 = 217,
        CWeaponMP9 = 218,
        CWeaponNegev = 219,
        CWeaponNOVA = 220,
        CWeaponP228 = 221,
        CWeaponP250 = 222,
        CWeaponP90 = 223,
        CWeaponSawedoff = 224,
        CWeaponSCAR20 = 225,
        CWeaponScout = 226,
        CWeaponSG550 = 227,
        CWeaponSG552 = 228,
        CWeaponSG556 = 229,
        CWeaponSSG08 = 230,
        CWeaponTaser = 231,
        CWeaponTec9 = 232,
        CWeaponTMP = 233,
        CWeaponUMP45 = 234,
        CWeaponUSP = 235,
        CWeaponXM1014 = 236,
        CWorld = 237,
        DustTrail = 238,
        MovieExplosion = 239,
        ParticleSmokeGrenade = 240,
        RocketTrail = 241,
        SmokeTrail = 242,
        SporeExplosion = 243,
        SporeTrail = 244
    }
    class Statics
    {

        public const Int32 timestamp = 1591880940;
        public static class netvars
        {
            public const Int32 cs_gamerules_data = 0x0;
            public const Int32 m_ArmorValue = 0xB378;
            public const Int32 m_Collision = 0x320;
            public const Int32 m_CollisionGroup = 0x474;
            public const Int32 m_Local = 0x2FBC;
            public const Int32 m_MoveType = 0x25C;
            public const Int32 m_OriginalOwnerXuidHigh = 0x31C4;
            public const Int32 m_OriginalOwnerXuidLow = 0x31C0;
            public const Int32 m_SurvivalGameRuleDecisionTypes = 0x1320;
            public const Int32 m_SurvivalRules = 0xCF8;
            public const Int32 m_aimPunchAngle = 0x302C;
            public const Int32 m_aimPunchAngleVel = 0x3038;
            public const Int32 m_angEyeAnglesX = 0xB37C;
            public const Int32 m_angEyeAnglesY = 0xB380;
            public const Int32 m_bBombPlanted = 0x99D;
            public const Int32 m_bFreezePeriod = 0x20;
            public const Int32 m_bGunGameImmunity = 0x3944;
            public const Int32 m_bHasDefuser = 0xB388;
            public const Int32 m_bHasHelmet = 0xB36C;
            public const Int32 m_bInReload = 0x32A5;
            public const Int32 m_bIsDefusing = 0x3930;
            public const Int32 m_bIsQueuedMatchmaking = 0x74;
            public const Int32 m_bIsScoped = 0x3928;
            public const Int32 m_bIsValveDS = 0x75;
            public const Int32 m_bSpotted = 0x93D;
            public const Int32 m_bSpottedByMask = 0x980;
            public const Int32 m_bStartedArming = 0x33F0;
            public const Int32 m_bUseCustomAutoExposureMax = 0x9D9;
            public const Int32 m_bUseCustomAutoExposureMin = 0x9D8;
            public const Int32 m_bUseCustomBloomScale = 0x9DA;
            public const Int32 m_clrRender = 0x70;
            public const Int32 m_dwBoneMatrix = 0x26A8;
            public const Int32 m_fAccuracyPenalty = 0x3330;
            public const Int32 m_fFlags = 0x104;
            public const Int32 m_flC4Blow = 0x2990;
            public const Int32 m_flCustomAutoExposureMax = 0x9E0;
            public const Int32 m_flCustomAutoExposureMin = 0x9DC;
            public const Int32 m_flCustomBloomScale = 0x9E4;
            public const Int32 m_flDefuseCountDown = 0x29AC;
            public const Int32 m_flDefuseLength = 0x29A8;
            public const Int32 m_flFallbackWear = 0x31D0;
            public const Int32 m_flFlashDuration = 0xA420;
            public const Int32 m_flFlashMaxAlpha = 0xA41C;
            public const Int32 m_flLastBoneSetupTime = 0x2924;
            public const Int32 m_flLowerBodyYawTarget = 0x3A90;
            public const Int32 m_flNextAttack = 0x2D70;
            public const Int32 m_flNextPrimaryAttack = 0x3238;
            public const Int32 m_flSimulationTime = 0x268;
            public const Int32 m_flTimerLength = 0x2994;
            public const Int32 m_hActiveWeapon = 0x2EF8;
            public const Int32 m_hMyWeapons = 0x2DF8;
            public const Int32 m_hObserverTarget = 0x338C;
            public const Int32 m_hOwner = 0x29CC;
            public const Int32 m_hOwnerEntity = 0x14C;
            public const Int32 m_iAccountID = 0x2FC8;
            public const Int32 m_iClip1 = 0x3264;
            public const Int32 m_iCompetitiveRanking = 0x1A84;
            public const Int32 m_iCompetitiveWins = 0x1B88;
            public const Int32 m_iCrosshairId = 0xB3E4;
            public const Int32 m_iEntityQuality = 0x2FAC;
            public const Int32 m_iFOV = 0x31E4;
            public const Int32 m_iFOVStart = 0x31E8;
            public const Int32 m_iGlowIndex = 0xA438;
            public const Int32 m_iHealth = 0x100;
            public const Int32 m_iItemDefinitionIndex = 0x2FAA;
            public const Int32 m_iItemIDHigh = 0x2FC0;
            public const Int32 m_iMostRecentModelBoneCounter = 0x2690;
            public const Int32 m_iObserverMode = 0x3378;
            public const Int32 m_iShotsFired = 0xA390;
            public const Int32 m_iState = 0x3258;
            public const Int32 m_iTeamNum = 0xF4;
            public const Int32 m_lifeState = 0x25F;
            public const Int32 m_nFallbackPaintKit = 0x31C8;
            public const Int32 m_nFallbackSeed = 0x31CC;
            public const Int32 m_nFallbackStatTrak = 0x31D4;
            public const Int32 m_nForceBone = 0x268C;
            public const Int32 m_nTickBase = 0x3430;
            public const Int32 m_rgflCoordinateFrame = 0x444;
            public const Int32 m_szCustomName = 0x303C;
            public const Int32 m_szLastPlaceName = 0x35B4;
            public const Int32 m_thirdPersonViewAngles = 0x31D8;
            public const Int32 m_vecOrigin = 0x138;
            public const Int32 m_vecVelocity = 0x114;
            public const Int32 m_vecViewOffset = 0x108;
            public const Int32 m_viewPunchAngle = 0x3020;
        }
        public static class signatures
        {
            public const Int32 anim_overlays = 0x2980;
            public const Int32 clientstate_choked_commands = 0x4D28;
            public const Int32 clientstate_delta_ticks = 0x174;
            public const Int32 clientstate_last_outgoing_command = 0x4D24;
            public const Int32 clientstate_net_channel = 0x9C;
            public const Int32 convar_name_hash_table = 0x2F0F8;
            public const Int32 dwClientState = 0x58ADD4;
            public const Int32 dwClientState_GetLocalPlayer = 0x180;
            public const Int32 dwClientState_IsHLTV = 0x4D40;
            public const Int32 dwClientState_Map = 0x28C;
            public const Int32 dwClientState_MapDirectory = 0x188;
            public const Int32 dwClientState_MaxPlayer = 0x388;
            public const Int32 dwClientState_PlayerInfo = 0x52B8;
            public const Int32 dwClientState_State = 0x108;
            public const Int32 dwClientState_ViewAngles = 0x4D88;
            public const Int32 dwEntityList = 0x4D4B1A4;
            public const Int32 dwForceAttack = 0x317C744;
            public const Int32 dwForceAttack2 = 0x317C750;
            public const Int32 dwForceBackward = 0x317C798;
            public const Int32 dwForceForward = 0x317C7A4;
            public const Int32 dwForceJump = 0x51F4E28;
            public const Int32 dwForceLeft = 0x317C7BC;
            public const Int32 dwForceRight = 0x317C7B0;
            public const Int32 dwGameDir = 0x629678;
            public const Int32 dwGameRulesProxy = 0x526811C;
            public const Int32 dwGetAllClasses = 0xD5CFF4;
            public const Int32 dwGlobalVars = 0x58AAD8;
            public const Int32 dwGlowObjectManager = 0x5292FA0;
            public const Int32 dwInput = 0x519C738;
            public const Int32 dwInterfaceLinkList = 0x901734;
            public const Int32 dwLocalPlayer = 0xD36BA4;
            public const Int32 dwMouseEnable = 0xD3C748;
            public const Int32 dwMouseEnablePtr = 0xD3C718;
            public const Int32 dwPlayerResource = 0x317AADC;
            public const Int32 dwRadarBase = 0x517FEFC;
            public const Int32 dwSensitivity = 0xD4D9A4;
            public const Int32 dwSensitivityPtr = 0xD4D978;
            public const Int32 dwSetClanTag = 0x89FB0;
            public const Int32 dwViewMatrix = 0x4D3CAD4;
            public const Int32 dwWeaponTable = 0x519D1FC;
            public const Int32 dwWeaponTableIndex = 0x325C;
            public const Int32 dwYawPtr = 0xD3C3A8;
            public const Int32 dwZoomSensitivityRatioPtr = 0xD415F0;
            public const Int32 dwbSendPackets = 0xD409A;
            public const Int32 dwppDirect3DDevice9 = 0xA7030;
            public const Int32 find_hud_element = 0x2D50FF00;
            public const Int32 force_update_spectator_glow = 0x39D992;
            public const Int32 interface_engine_cvar = 0x3E9EC;
            public const Int32 is_c4_owner = 0x3AA430;
            public const Int32 m_bDormant = 0xED;
            public const Int32 m_flSpawnTime = 0xA370;
            public const Int32 m_pStudioHdr = 0x294C;
            public const Int32 m_pitchClassPtr = 0x51801A0;
            public const Int32 m_yawClassPtr = 0xD3C3A8;
            public const Int32 model_ambient_min = 0x58DE4C;
            public const Int32 set_abs_angles = 0x1D2CF0;
            public const Int32 set_abs_origin = 0x1D2B30;
        }
    }
}