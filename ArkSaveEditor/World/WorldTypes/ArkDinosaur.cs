using ArkSaveEditor.ArkEntries;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using ArkSaveEditor.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkDinosaur : ArkCharacter
    {
        /// <summary>
        /// If this is false, mo values for this dinosaur will be read.
        /// </summary>
        public bool isInit = false;
        
        /// <summary>
        /// True if this dinosaur is tamed.
        /// </summary>
        public bool isTamed;

        /// <summary>
        /// True if this dinosaur is female.
        /// </summary>
        public bool isFemale;

        /// <summary>
        /// The 64 bit dinosaur ID.
        /// </summary>
        public ulong dinosaurId;

        /// <summary>
        /// The colors of this dinosaur. 
        /// </summary>
        public byte[] colors;

        /// <summary>
        /// Colors converted to hex values.
        /// </summary>
        public string[] colors_hex;

        /// <summary>
        /// The current stats of this dinosaur, not the maximum.
        /// </summary>
        public ArkDinosaurStats currentStats;

        /// <summary>
        /// The number of levelups applied AT SPAWN TIME. Does not include user-added levelups.
        /// </summary>
        public ArkDinosaurStats baseLevelupsApplied;

        /// <summary>
        /// The level AT SPAWN TIME
        /// </summary>
        public int baseLevel;

        /// <summary>
        /// The total level of this dinosaur.
        /// </summary>
        public int level;

        /// <summary>
        /// Some global dino data
        /// </summary>
        public ArkDinoEntry dino_entry;

        /* TAMED ONLY */

        /// <summary>
        /// The name of the dinosaur that the tribe set, for example "Delta". Will be null if not tamed.
        /// </summary>
        public string tamedName;

        /// <summary>
        /// The tribe that tamed this dinosaur. Will be null if not tamed.
        /// </summary>
        public string tamerName;

        /// <summary>
        /// The number of levelups applied after spawn time. Does not include base levels.
        /// </summary>
        public ArkDinosaurStats tamedLevelupsApplied;

        /// <summary>
        /// The number of experience this dinosaur has. Only exists on tamed dinosaurs.
        /// </summary>
        public float experience;

        /* Age */
        public float babyAge;
        public bool isBaby;
        public double nextImprintTime;
        public float imprintQuality;

        /// <summary>
        /// Calculates the max stats for a dinosaur. REQUIRES YOU TO RUN ArkSaveEditor.ArkImports.ImportContent() BEFORE THIS!
        /// </summary>
        /// <returns></returns>
        public ArkDinosaurStats GetMaxStats()
        {
            ArkDinoEntry d = dino_entry;
            ArkWorldSettings settings = ArkImports.world_settings;
            float tamingEffectiveness = 0.5f;
            float imprintingBonus = 0f;

            if (d == null)
                return null;

            return new ArkDinosaurStats
            {
                health = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Health, baseLevelupsApplied.health, tamingEffectiveness, tamedLevelupsApplied.health, imprintingBonus, settings, world.configSettings, isTamed),
                stamina = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Stamina, baseLevelupsApplied.stamina, tamingEffectiveness, tamedLevelupsApplied.stamina, imprintingBonus, settings, world.configSettings, isTamed),
                unknown1 = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Torpidity, baseLevelupsApplied.unknown1, tamingEffectiveness, tamedLevelupsApplied.unknown1, imprintingBonus, settings, world.configSettings, isTamed),
                oxygen = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Oxygen, baseLevelupsApplied.oxygen, tamingEffectiveness, tamedLevelupsApplied.oxygen, imprintingBonus, settings, world.configSettings, isTamed),
                food = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Food, baseLevelupsApplied.food, tamingEffectiveness, tamedLevelupsApplied.food, imprintingBonus, settings, world.configSettings, isTamed),
                water = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Water, baseLevelupsApplied.water, tamingEffectiveness, tamedLevelupsApplied.water, imprintingBonus, settings, world.configSettings, isTamed),
                inventoryWeight = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Weight, baseLevelupsApplied.inventoryWeight, tamingEffectiveness, tamedLevelupsApplied.inventoryWeight, imprintingBonus, settings, world.configSettings, isTamed),
                meleeDamageMult = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.MeleeDamage, baseLevelupsApplied.meleeDamageMult, tamingEffectiveness, tamedLevelupsApplied.meleeDamageMult, imprintingBonus, settings, world.configSettings, isTamed),
                movementSpeedMult = (float)ArkStatsCalculator.CalculateStat(d, DinoStatTypeIndex.Speed, baseLevelupsApplied.movementSpeedMult, tamingEffectiveness, tamedLevelupsApplied.movementSpeedMult, imprintingBonus, settings, world.configSettings, isTamed),
            };
        }

        public ArkDinosaur(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {
            //Grab the data and save it here.
            //Get the other components of this dinosaur.
            HighLevelArkGameObjectRef statusComponent = GetGameObjectRef("MyCharacterStatusComponent");
            //Check if this dinosaur is tamed.
            isTamed = CheckIfValueExists("TamedName") && CheckIfValueExists("TribeName") && CheckIfValueExists("TargetingTeam");
            //Grab the values that will exist on both tamed and untamed dinosaurs.
            isFemale = GetBooleanProperty("bIsFemale");
            //Convert the colors into a byte array and hex.
            var colorAttrib = GetPropertiesByName("ColorSetIndices"); //Get all of the color properties from the dinosaur. These are indexes in the color table.
            colors = new byte[colorAttrib.Length]; //Initialize the array for storing the indexes. These will be saved to the file.
            colors_hex = new string[colorAttrib.Length]; //Initialize the array for reading nice HTML color values.
            for (int i = 0; i < colors.Length; i++) //For each color region this dinosaur has. Each "ColorSetIndices" value is a color region.
            {
                colors[i] = ((ByteProperty)colorAttrib[i]).byteValue; //Get the index in the color table by getting the byte value out of the property
                //Validate that the color is in range
                byte color = colors[i];
                if (color <= 0 || color > ArkColorIds.ARK_COLOR_IDS.Length)
                    colors_hex[i] = "#FFF";
                else
                    colors_hex[i] = ArkColorIds.ARK_COLOR_IDS[colors[i] - 1]; //Look this up in the color table to get the nice HTML value.
            }
            //Read the dinosaur ID by combining the the bytes of the two UInt32 values.
            byte[] buf = new byte[8];
            BitConverter.GetBytes(GetUInt32Property("DinoID1")).CopyTo(buf, 0);
            BitConverter.GetBytes(GetUInt32Property("DinoID2")).CopyTo(buf, 4);
            //Convert this to a ulong
            dinosaurId = BitConverter.ToUInt64(buf, 0);
            //Read in levels
            currentStats = ArkDinosaurStats.ReadStats(statusComponent, "CurrentStatusValues", false);
            baseLevelupsApplied = ArkDinosaurStats.ReadStats(statusComponent, "NumberOfLevelUpPointsApplied", true);
            baseLevel = 1;
            if(statusComponent.CheckIfValueExists("BaseCharacterLevel"))
                baseLevel = statusComponent.GetInt32Property("BaseCharacterLevel");
            level = baseLevel;
            //Now, convert attributes that only exist on tamed dinosaurs.
            isInTribe = isTamed;
            if (isTamed)
            {
                tamedName = GetStringProperty("TamedName");
                tribeId = GetInt32Property("TargetingTeam");
                tamerName = GetStringProperty("TribeName");
                tamedLevelupsApplied = ArkDinosaurStats.ReadStats(statusComponent, "NumberOfLevelUpPointsAppliedTamed", true);
                if(statusComponent.CheckIfValueExists("ExtraCharacterLevel"))
                    level += statusComponent.GetUInt16Property("ExtraCharacterLevel");
                if (statusComponent.HasProperty("ExperiencePoints"))
                    experience = statusComponent.GetFloatProperty("ExperiencePoints");
                else
                    experience = 0;

                isBaby = GetBooleanProperty("bIsBaby");
                if (isBaby)
                {
                    babyAge = GetFloatProperty("BabyAge");
                    nextImprintTime = -1;
                    if(HasProperty("BabyNextCuddleTime"))
                        nextImprintTime = GetDoubleProperty("BabyNextCuddleTime");
                    if (statusComponent.HasProperty("DinoImprintingQuality"))
                        imprintQuality = statusComponent.GetFloatProperty("DinoImprintingQuality");
                    else
                        imprintQuality = 0;
                }
                
            }

            //Get the dino entry data
            dino_entry = ArkImports.GetDinoDataByClassname(classname.classname);

            isInit = true;

            
        }
    }
}
