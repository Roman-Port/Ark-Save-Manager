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

        public string classname;
        public string blueprintPath;

        public string icon_url;
        public string thumb_icon_url;

        public Dictionary<DinoStatTypeIndex, float> baseLevel;
        public Dictionary<DinoStatTypeIndex, float> increasePerWildLevel;
        public Dictionary<DinoStatTypeIndex, float> increasePerTamedLevel;
        public Dictionary<DinoStatTypeIndex, float> additiveTamingBonus; //Taming effectiveness
        public Dictionary<DinoStatTypeIndex, float> multiplicativeTamingBonus; //Taming effectiveness
    }
}
