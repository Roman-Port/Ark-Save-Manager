using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class ArkConfigSettings
    {
        public bool alwaysNotifyPlayerJoined {get; set;} = false;
        public bool alwaysNotifyPlayerLeft {get; set;} = false;
        public bool allowThirdPersonPlayer {get; set;} = false;
        public bool globalVoiceChat {get; set;} = false;
        public bool ShowMapPlayerLocation {get; set;} = false;
        public bool noTributeDownloads {get; set;} = false;
        public bool proximityChat {get; set;} = false;
        public bool serverPVE {get; set;} = false;
        public bool serverHardcore {get; set;} = false;
        public bool serverForceNoHud {get; set;} = false;
        public bool bDisableStructureDecayPvE {get; set;} = false;
        public bool DisableDinoDecayPvE {get; set;} = false;
        public bool AllowFlyerCarryPvE {get; set;} = false;
        public int TheMaxStructuresInRange {get; set;} = 10500;
        public bool bAllowPlatformSaddleMultiFloors {get; set;} = false;
        public int MaxPlayers {get; set;} = 70;
        public float DifficultyOffset {get; set;} = 0.2f;
        public string ServerPassword {get; set;} = null;
        public string ServerAdminPassword {get; set;} = null;
        public string SpectatorPassword {get; set;} = null;
        public float DayCycleSpeedScale {get; set;} = 1.0f;
        public float NightTimeSpeedScale {get; set;} = 1.0f;
        public float DayTimeSpeedScale {get; set;} = 1.0f;
        public float DinoDamageMultiplier {get; set;} = 1.0f;
        public float PlayerDamageMultiplier {get; set;} = 1.0f;
        public float StructureDamageMultiplier {get; set;} = 1.0f;
        public float PlayerResistanceMultiplier {get; set;} = 1.0f;
        public float DinoResistanceMultiplier {get; set;} = 1.0f;
        public float StructureResistanceMultiplier {get; set;} = 1.0f;
        public float XPMultiplier {get; set;} = 1.0f;
        public float PvEStructureDecayPeriodMultiplier {get; set;} = 1.0f;
        public float PvEStructureDecayDestructionPeriod {get; set;} = 0;
		public float PvEDinoDecayPeriodMultiplier {get; set;} = 1.0f;
        public float TamingSpeedMultiplier {get; set;} = 1.0f;
        public float HarvestAmountMultiplier {get; set;} = 1.0f;
        public float HarvestHealthMultiplier {get; set;} = 1.0f;
        public float PerPlatformMaxStructuresMultiplier {get; set;} = 1.0f;
        public float ResourcesRespawnPeriodMultiplier {get; set;} = 1.0f;
        public float PlayerCharacterWaterDrainMultiplier {get; set;} = 1.0f;
        public float PlayerCharacterFoodDrainMultiplier {get; set;} = 1.0f;
        public float PlayerCharacterStaminaDrainMultiplier {get; set;} = 1.0f;
        public float PlayerCharacterHealthRecoveryMultiplier {get; set;} = 1.0f;
        public float DinoCharacterFoodDrainMultiplier {get; set;} = 1.0f;
        public float DinoCharacterStaminaDrainMultiplier {get; set;} = 1.0f;
        public float DinoCharacterHealthRecoveryMultiplier {get; set;} = 1.0f;
        public float DinoCountMultiplier {get; set;} = 1.0f;
        public bool AllowCaveBuildingPvE {get; set;} = false;
        public string BanListURL {get; set;} = "http://arkdedicated.com/banlist.txt";
        public bool PvPStructureDecay {get; set;} = false;
        public int TributeItemExpirationSeconds {get; set;} = 86400;
        public int TributeDinoExpirationSeconds {get; set;} = 86400;
        public int TributeCharacterExpirationSeconds {get; set;} = 86400;
        public float AutoSavePeriodMinutes {get; set;} = 15.0f;
        public bool bUseCorpseLocator {get; set;} = false;
        public bool CrossARKAllowForeignDinoDownloads {get; set;} = false;
        public bool DisablePvEGamma {get; set;} = false;
        public bool EnablePvPGamma {get; set;} = false;
        public int TribeNameChangeCooldown {get; set;} = 15;
        public bool AllowHideDamageSourceFromLogs {get; set;} = false;
        public bool RandomSupplyCratePoints {get; set;} = false;
        public bool DisableWeatherFog {get; set;} = false;
        public string ActiveMods {get; set;} = null;
        public bool AdminLogging {get; set;} = true;
        public bool ClampResourceHarvestDamage {get; set;} = false;
        public float ItemStackSizeMultiplier {get; set;} = 1.0f;
        public float PlatformSaddleBuildAreaBoundsMultiplier {get; set;} = 1.0f;
        public int MaxTamedDinos {get; set;} = 4000;
        public int NewMaxStructuresInRange {get; set;} = 6000;
        public int MaxStructuresInRange {get; set;} = 1300;

        public bool AllowMultipleTamedUnicorns {get; set;} = false;
        public int UnicornSpawnInterval {get; set;} = 24;
        public float VolcanoIntensity {get; set;} = 1;
        public int VolcanoInterval {get; set;} = 0;
        public bool EnableVolcano {get; set;} = true;

        public bool AlwaysAllowStructurePickup {get; set;} = false;
        public float StructurePickupTimeAfterPlacement {get; set;} = 30.0f;
        public bool AllowIntegratedSPlusStructures {get; set;} = true;
        public float StructurePickupHoldDuration {get; set;} = 0.5f;

        public int DestroyTamesOverLevelClamp﻿ {get; set;} = 449;
        public float GlobalPoweredBatteryDurabilityDecreasePerSecond {get; set;} = 4;
        public float FuelConsumptionIntervalMultiplier {get; set;} = 1;
        public float UseCorpseLifeSpanMultiplier { get; set; }
        public bool bUseTameLimitForStructuresOnly { get; set; }
        public int MaxTribesPerAlliance { get; set; }
        public int MaxAlliancesPerTribe { get; set; }
        public int FastDecayInterval {get; set;} = 43200;
        public float SpecialXPMultiplier {get; set;} = 1;
        public float GenericXPMultiplier {get; set;} = 1;
        public float CraftXPMultiplier {get; set;} = 1;
        public float HarvestXPMultiplier {get; set;} = 1;
        public float KillXPMultiplier {get; set;} = 1;
        public float TamedDinoTorporDrainMultiplier {get; set;} = 1;
        public float PassiveTameIntervalMultiplier {get; set;} = 1;
        public float WildDinoTorporDrainMultiplier {get; set;} = 1;
        public float WildDinoCharacterFoodDrainMultiplier {get; set;} = 1;
        public float TamedDinoCharacterFoodDrainMultiplier {get; set;} = 1;
        public float PreventOfflinePvPConnectionInvincibleInterval {get; set;} = 5;
        public bool bShowCreativeMode {get; set;} = false;
        public bool bHardLimitTurretsInRange {get; set;} = true;
        public bool bAutoUnlockAllEngrams {get; set;} = false;
        public bool bAllowCustomRecipes {get; set;} = false;
        public bool bDisableStructurePlacementCollision {get; set;} = false;
        public bool bDisableDinoTaming {get; set;} = false;
        public bool bDisableDinoRiding {get; set;} = false;
        public float PvPZoneStructureDamageMultiplier {get; set;} = 6;
        public int MaxTribeLogs {get; set;} = 100;
        public float BabyCuddleLoseImprintQualitySpeedMultiplier {get; set;} = 1;
        public float BabyCuddleGracePeriodMultiplier {get; set;} = 1;
        public float BabyCuddleIntervalMultiplier {get; set;} = 1;
        public float BabyImprintingStatScaleMultiplier {get; set;} = 1;
        public float MaxNumberOfPlayersInTribe {get; set;} = 0;
        public float TribeSlotReuseCooldown {get; set;} = 0;
        public int KickIdlePlayersPeriod {get; set;} = 3600;
        public float FishingLootQualityMultiplier {get; set;} = 1;
        public float SupplyCrateLootQualityMultiplier {get; set;} = 1;
        public bool bDisableLootCrates {get; set;} = false;
        public float DinoTurretDamageMultiplier {get; set;} = 1;
        public float PlayerHarvestingDamageMultiplier {get; set;} = 1;
        public float DinoHarvestingDamageMultiplier {get; set;} = 3.2f;
        public float CustomRecipeSkillMultiplier {get; set;} = 1;
        public float CustomRecipeEffectivenessMultiplier {get; set;} = 1;
        public bool bPassiveDefensesDamageRiderlessDinos {get; set;} = false;
        public bool bPvEAllowTribeWarCancel {get; set;} = false;
        public bool bPvEAllowTribeWar {get; set;} = true;
        public int StructureDamageRepairCooldown {get; set;} = 180;
        public float HairGrowthSpeedMultiplier {get; set;} = 1;
        public float CropDecaySpeedMultiplier {get; set;} = 1;
        public float PoopIntervalMultiplier {get; set;} = 1;
        public float LayEggIntervalMultiplier {get; set;} = 1;
        public float CropGrowthSpeedMultiplier {get; set;} = 1;
        public float BabyFoodConsumptionSpeedMultiplier {get; set;} = 1;
        public float BabyMatureSpeedMultiplier {get; set;} = 1;
        public float EggHatchSpeedMultiplier {get; set;} = 1;
        public float MatingSpeedMultiplier {get; set;} = 1;
        public float MatingIntervalMultiplier {get; set;} = 1;
        public bool bFlyerPlatformAllowUnalignedDinoBasing {get; set;} = false;
        public bool bDisableFriendlyFire {get; set;} = false;
        public bool bPvEDisableFriendlyFire {get; set;} = false;
        public float ResourceNoReplenishRadiusPlayers {get; set;} = 1;
        public float ResourceNoReplenishRadiusStructures {get; set;} = 1;
        public string PreventDinoTameClassNames { get; set; }
        public int OverrideMaxExperiencePointsDino { get; set; }
        public int OverrideMaxExperiencePointsPlayer { get; set; }
        public float GlobalCorpseDecompositionTimeMultiplier {get; set;} = 1;
        public float GlobalItemDecompositionTimeMultiplier {get; set;} = 1;
        public float GlobalSpoilingTimeMultiplier {get; set;} = 1;

        public float TamedBaseHealthMultiplier { get; set; } = 1;

        public void ReadFromFile(string[] lines)
        {
            foreach(string s in lines)
            {
                //Check if it is valid
                string[] split = s.Split('=');
                if(split.Length == 2)
                {
                    //This is a line we can import
                    string key = split[0];
                    string value = split[1];

                    //Find the attribute in this file for this.
                    PropertyInfo p;
                    try
                    {
                        p = GetType().GetProperty(key);
                    }
                    catch { continue; }

                    if (p == null)
                        continue;

                    //Now, set it based on the type used
                    try
                    {
                        Type propType = p.PropertyType;
                        if (propType == typeof(float))
                        {
                            p.SetValue(this, float.Parse(value));
                        }
                        else if (propType == typeof(int))
                        {
                            p.SetValue(this, int.Parse(value));
                        }
                        else if (propType == typeof(bool))
                        {
                            bool v = false;
                            if (value.ToLower() == "true" || value.ToLower() == "1")
                                v = true;
                            p.SetValue(this, v);
                        }
                        else if (propType == typeof(string))
                        {
                            p.SetValue(this, value);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    catch { continue; }
                }
            }
        }
    }
}
