using ArkSaveEditor.ArkEntries;
using ArkSaveEditor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Tools
{
    public static class ArkStatsCalculator
    {
        public static double CalculateStat(ArkDinoEntry dino_entry, DinoStatTypeIndex stat, float wildLevelups, float tamingEffectiveness, float tamedLevelups, float imprintingBonus, ArkWorldSettings world)
        {
            //As of 1-19-2018 (https://ark.gamepedia.com/Creature_Stats_Calculation)
            //Calculate wild level
            float B = dino_entry.baseLevel[stat];//Base level for Yutyrannus: 1100.0
            float Lw = wildLevelups; //Blake's levelups: 1
            float Iw = dino_entry.increasePerWildLevel[stat];//Increase per wild level: 0.2
            float IwM = world.increasePerWildLevelModifier; //Server modifier: 1
            double Vw = CalculateVw(B, Lw, Iw, IwM);

            //Calculate wild taming effectiveness (Vpt)
            float TBHM = world.serverConfig_tamedBaseHealthMultiplier; //Server config var TamedBaseHealthMultiplier, 1
            float Ta = dino_entry.additiveTamingBonus[stat]; //For health as a test. This is in UE file TamingMaxStatAdditions
            float TaM = world.additiveTamingBonusModifier[stat]; //Seems to be on a per stat basis. UNKNOWN IN FILE TODO: RIP FROM FILE
            float TE = tamingEffectiveness; //Taming effectiveness percentage. Per creature
            float Tm = dino_entry.multiplicativeTamingBonus[stat]; //Multiplier taming bonus. This in the UE file is TamingMaxStatMultipliers 
            float TmM = world.multiplicativeTamingBonusModifier[stat]; //Seems to be on a per stat basis. UNKNOWN IN FILE TODO: RIP FROM FILE
            float IB = imprintingBonus; //Imprint
            float IBM = world.serverConfig_babyImprintingStatScaleMultiplier;
            double Vpt = CalculateVptWild(Vw, TBHM, Ta, TaM, TE, Tm, TmM);

            //Finally, calculate the final result with the user tamed levelups
            float Ld = tamedLevelups; //Number of player applied upgrades
            float Id = dino_entry.increasePerTamedLevel[stat]; //Increase per wild level
            float IdM = world.increasePerTamedLevelModifier[stat]; //Seems to be on a per stat basis. UNKNOWN IN FILE TODO: RIP FROM FILE
            double V = CalculateV(Vpt, Ld, Id, IdM);
            //V = (B * (1 + Lw * Iw * IwM) * TBHM * (1 + IB * 0.2 * IBM) + Ta * TaM) * (1 + TE * Tm * TmM) * (1 + Ld * Id * IdM);

            //Calculating bonus levels with taming effectiveness (Vpt)
            //Console.WriteLine($"{stat.ToString()} - {V} - {Math.Round(V, 1)} (Base {B}, Vw {Vw}, Vpt {Vpt})");
            return V;
        }

        static double CalculateVw(float B, float Lw, float Iw, float IwM)
        {
            return B * (1 + Lw * Iw * IwM);
        }

        static double CalculateVptWild(double Vw, float TBHM, float Ta, float TaM, float TE, float Tm, float TmM)
        {
            return (Vw * TBHM + Ta * TaM) * (1 + TE * Tm * TmM);
        }

        static double CalculateV(double Vpt, float Ld, float Id, float IdM)
        {
            //Console.WriteLine($"{Vpt} {Ld} {Id} {IdM}");
            return Vpt * (1 + Ld * Id * (1 - IdM));
        }
    }
}
