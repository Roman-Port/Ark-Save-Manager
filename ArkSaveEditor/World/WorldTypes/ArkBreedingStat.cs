using ArkSaveEditor.ArkEntries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    /// <summary>
    /// Very, very similar to the ARKBreedingStats stat. Used for interchangability https://github.com/cadon/ARKStatsExtractor/blob/dev/ARKBreedingStats/species/CreatureStat.cs
    /// </summary>
    public class ArkBreedingStat
    {
        public float BaseValue;
        public float IncPerWildLevel;
        public float IncPerTamedLevel;
        public float AddWhenTamed;
        public float MultAffinity;

        /*
        0: MaxStatusValues 				- baseLevel
        1: AmountMaxGainedPerLevelUpValue		- increasePerWildLevel
        2: AmountMaxGainedPerLevelUpValueTamed		- increasePerTamedLevel
        3: TamingMaxStatAdditions			- additiveTamingBonus
        4: TamingMaxStatMultipliers			- multiplicativeTamingBonus
        */

        public static ArkBreedingStat Compute(ArkDinoEntry e, DinoStatTypeIndex index, ArkConfigSettings settings)
        {
            double[] statMultipliers = new double[] { 1, 1, 1, 1 };
            return new ArkBreedingStat
            {
                BaseValue = e.baseLevel[index],
                AddWhenTamed = (float)e.additiveTamingBonus[index] * (e.additiveTamingBonus[index] > 0 ? (float)statMultipliers[0] : 1),
                MultAffinity = (float)e.multiplicativeTamingBonus[index] * (e.multiplicativeTamingBonus[index] > 0 ? (float)statMultipliers[1] : 1),
                IncPerTamedLevel = (float)e.increasePerTamedLevel[index] * (float)statMultipliers[2],
                IncPerWildLevel = (float)e.increasePerWildLevel[index] * (float)statMultipliers[3],
            };
        }
    }
}
