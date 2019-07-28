using ArkSaveEditor.ArkEntries;
using ArkSaveEditor.World;
using ArkSaveEditor.World.WorldTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Tools
{
    public static class ArkStatsCalculator
    {
        /*public static double CalculateStat(ArkDinoEntry dino_entry, DinoStatTypeIndex stat, float wildLevelups, float tamingEffectiveness, float tamedLevelups, float imprintingBonus, ArkWorldSettings world, ArkConfigSettings settings)
        {
            //As of 7-24-2018 (https://ark.gamepedia.com/Creature_Stats_Calculation)
            float b = dino_entry.baseLevel[stat];
            float lw = dino_entry.increasePerWildLevel[stat];
            float Id = dino_entry.increasePerTamedLevel[stat];
            float Ta = dino_entry.additiveTamingBonus[stat];
            float Tm = dino_entry.multiplicativeTamingBonus[stat];
            float TE = tamingEffectiveness;
            float IB = imprintingBonus;
            float Ld = tamedLevelups;
            float TBHM = settings.TamedBaseHealthMultiplier;

            float v = (B * (1 + Lw * Iw * IwM) * TBHM * (1 + IB * 0.2 * IBM) + Ta * TaM) * (1 + TE * Tm * TmM) * (1 + Ld * Id * IdM);
        }*/

        private const double roundupDelta = 0.0001;

        public static double CalculateStat(ArkDinoEntry dino_entry, DinoStatTypeIndex stat, float levelWild, float tamingEff, float levelDom, float imprintingBonus, ArkWorldSettings world, ArkConfigSettings settings, bool isTamed)
        {
            // if stat is generally available but level is set to -1 (== unknown), return -1 (== unknown)
            if (levelWild < 0 && dino_entry != null && dino_entry.increasePerWildLevel[stat] != 0)
            {
                return -1;
            }
            if (dino_entry != null)
            {
                Dictionary<DinoStatTypeIndex, ArkBreedingStat> stats = dino_entry.GetBreedingStats(settings);
                double add = 0, domMult = 1, imprintingM = 1, tamedBaseHP = 1;
                if (isTamed)
                {
                    add = stats[stat].AddWhenTamed;
                    double domMultAffinity = stats[stat].MultAffinity;
                    // the multiplicative bonus is only multiplied with the TE if it is positive (i.e. negative boni won't get less bad if the TE is low)
                    if (domMultAffinity >= 0)
                        domMultAffinity *= tamingEff;
                    domMult = (tamingEff >= 0 ? (1 + domMultAffinity) : 1) * (1 + levelDom * stats[stat].IncPerTamedLevel);
                    if (imprintingBonus > 0
                        && stat != DinoStatTypeIndex.Stamina
                        && stat != DinoStatTypeIndex.Oxygen
                        && stat != DinoStatTypeIndex.Temperature
                        && (stat != DinoStatTypeIndex.Speed /*|| species.NoImprintingForSpeed == false*/)
                        && stat != DinoStatTypeIndex.TemperatureFortitude
                        && stat != DinoStatTypeIndex.CraftingSpeed
                        )
                        imprintingM = 1 + 0.2 * imprintingBonus * settings.BabyImprintingStatScaleMultiplier; // TODO 0.2 is not always true
                    if (stat == 0)
                        tamedBaseHP = (float)dino_entry.statusComponent.tamedBaseHealthMultiplier;
                }
                //double result = Math.Round((species.stats[stat].BaseValue * tamedBaseHP * (1 + species.stats[stat].IncPerWildLevel * levelWild) * imprintingM + add) * domMult, Utils.precision(stat), MidpointRounding.AwayFromZero);
                // double is too precise and results in wrong values due to rounding. float results in better values, probably ARK uses float as well.
                // or rounding first to a precision of 7, then use the rounding of the precision
                //double resultt = Math.Round((species.stats[stat].BaseValue * tamedBaseHP * (1 + species.stats[stat].IncPerWildLevel * levelWild) * imprintingM + add) * domMult, 7);
                //resultt = Math.Round(resultt, Utils.precision(stat), MidpointRounding.AwayFromZero);

                // adding an epsilon to handle rounding-errors
                double result = Math.Round((stats[stat].BaseValue * tamedBaseHP *
                        (1 + stats[stat].IncPerWildLevel * levelWild) * imprintingM + add) *
                        domMult + roundupDelta, precision(stat), MidpointRounding.AwayFromZero);

                return result >= 0 ? result : 0;
            }
            return 0;
        }

        public static int precision(DinoStatTypeIndex s)
        {
            // damage and speed are percentagevalues, need more precision
            return (s == DinoStatTypeIndex.Speed || s == DinoStatTypeIndex.MeleeDamage || s == DinoStatTypeIndex.CraftingSpeed) ? 3 : 1;
        }
    }
}
