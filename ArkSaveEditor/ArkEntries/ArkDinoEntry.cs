using ArkSaveEditor.World;
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
    }

    public class ArkDinoEntryStatusComponent
    {
        public float baseFoodConsumptionRate { get; set; }
        public float babyDinoConsumingFoodRateMultiplier { get; set; }
        public float extraBabyDinoConsumingFoodRateMultiplier { get; set; }
        public float foodConsumptionMultiplier { get; set; }
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
