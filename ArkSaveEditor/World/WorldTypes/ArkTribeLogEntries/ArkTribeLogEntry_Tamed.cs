using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArkSaveEditor.World.WorldTypes.ArkTribeLogEntries
{
    public class ArkTribeLogEntry_Tamed : ArkTribeLogEntry
    {
        public ArkTribeLogDinoTarget tamedTarget; //The dino tamed
        public ArkTribeLogPlayerTarget tribePlayerTarget; //Who did it

        public ArkTribeLogEntry_Tamed(string content, List<ArkPlayerProfile> playerProfiles, List<ArkDinosaur> globalDinos, int tribeId, OnFindSteamProfile steamCallback)
        {
            //Grab the groups with the regex
            GroupCollection gc = GetRegexGroups(content, ArkTribeLogEntry.REGEX_TAMED);

            //Resolve targets
            tribePlayerTarget = TryFindPlayerProfile(gc[1].Value, playerProfiles, tribeId, true, steamCallback);
            tamedTarget = TryFindDinoProfile(gc[2].Value, int.Parse(gc[3].Value), gc[4].Value, tribeId, globalDinos, true); 

            //Set vars
            priority = ArkTribeLogEntryPriority.Low;
            type = ArkTribeLogEntryType.TribeTamedDino;
        }
    }
}
