using ArkSaveEditor.World;
using ArkSaveEditor.World.WorldTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class ArkDinoEntry
    {
        public string screen_name { get; set; }
        public float colorizationIntensity { get; set; }
        public float babyGestationSpeed { get; set; }
        public float extraBabyGestationSpeedMultiplier { get; set; }
        public float babyAgeSpeed { get; set; }
        public float extraBabyAgeSpeedMultiplier { get; set; }
        public bool useBabyGestation { get; set; }

        //New in v2
        public ArkDinoEntryStatusComponent statusComponent;

        //New in v3
        public List<ArkDinoFood> adultFoods;
        public List<ArkDinoFood> childFoods;

        public string classname;
        public string blueprintPath;

        public ArkIcon icon;

        public Dictionary<DinoStatTypeIndex, float> baseLevel;
        public Dictionary<DinoStatTypeIndex, float> increasePerWildLevel;
        public Dictionary<DinoStatTypeIndex, float> increasePerTamedLevel;
        public Dictionary<DinoStatTypeIndex, float> additiveTamingBonus; //Taming effectiveness
        public Dictionary<DinoStatTypeIndex, float> multiplicativeTamingBonus; //Taming effectiveness


        /// <summary>
        /// Very, very similar to the ARKBreedingStats stat. Used for interchangability https://github.com/cadon/ARKStatsExtractor/blob/dev/ARKBreedingStats/species/CreatureStat.cs
        /// </summary>
        public Dictionary<DinoStatTypeIndex, ArkBreedingStat> GetBreedingStats(ArkConfigSettings conf)
        {
            Dictionary<DinoStatTypeIndex, ArkBreedingStat> s = new Dictionary<DinoStatTypeIndex, ArkBreedingStat>();
            for(int i = 0; i<11; i+=1)
            {
                DinoStatTypeIndex index = (DinoStatTypeIndex)i;
                ArkBreedingStat stat = ArkBreedingStat.Compute(this, index, conf);
                s.Add(index, stat);
            }
            return s;
        }
    }

    public class ArkDinoEntryStatusComponent
    {
        public float baseFoodConsumptionRate { get; set; }
        public float babyDinoConsumingFoodRateMultiplier { get; set; }
        public float extraBabyDinoConsumingFoodRateMultiplier { get; set; }
        public float foodConsumptionMultiplier { get; set; }
        public float tamedBaseHealthMultiplier { get; set; }
    }

    public class ArkDinoFood
    {
        public string classname;
        public float foodEffectivenessMultiplier;
        public float affinityOverride;
        public float affinityEffectivenessMultiplier;
        public int foodCategory;
        public float priority;
    }
}
