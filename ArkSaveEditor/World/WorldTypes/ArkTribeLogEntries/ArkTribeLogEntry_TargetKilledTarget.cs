using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ArkSaveEditor.World.WorldTypes.ArkTribeLogEntries
{
    public class ArkTribeLogEntry_TargetKilledTarget : ArkTribeLogEntry
    {
        public ArkTribeLogPlayerOrDinoTarget killer;
        public ArkTribeLogPlayerOrDinoTarget victim;

        public ArkTribeLogEntry_TargetKilledTarget(string content, List<ArkPlayerProfile> playerProfiles, List<ArkDinosaur> globalDinos, int tribeId, OnFindSteamProfile steamCallback)
        {
            //Use the regex to get groups
            GroupCollection gc = GetRegexGroups(content, ArkTribeLogEntry.REGEX_TARGETKILLEDTARGET);

            //Grab targets
            victim = TryFindDinoOrPlayerProfile(gc[2], gc[3], gc[4], playerProfiles, globalDinos, tribeId, false, steamCallback);
            killer = TryFindDinoOrPlayerProfile(gc[9], gc[10], gc[11], playerProfiles, globalDinos, tribeId, gc[8].Success, steamCallback); //If group 8 is not empty, this is a wild dino

            //Set IDs
            priority = ArkTribeLogEntryPriority.High;
            type = ArkTribeLogEntryType.TargetKilledTarget;
        }
    }
}
