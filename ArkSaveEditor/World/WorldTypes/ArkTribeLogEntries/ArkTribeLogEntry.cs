using ArkSaveEditor.ArkEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ArkSaveEditor.World.WorldTypes.ArkTribeLogEntries
{
    public class ArkTribeLogEntry
    {
        //Regex strings
        public const string REGEX_TAMED = @"([A-z ]*) Tamed an? ([A-z 0-9 !-) \-]*) - Lvl ([0-9]*) \(([A-z ]*)\)";
        public const string REGEX_TARGETKILLEDTARGET = @"(Your )?([A-z 0-9 .!-) \-]*) - Lvl ([0-9 ]*)( \(([A-z 0-9 !-) \-]*)\))?( \(([A-z 0-9 !-) \-]*)\))? was killed by a?n?( )?([A-z 0-9 .!-) \-]*) - Lvl ([0-9 ]*) ?(\| |!| (\(([A-z 0-9 !-) \-]*)\)))";

        //Instance vars
        public ArkTribeLogEntryType type;
        public ArkTribeLogEntryPriority priority;
        public string gameDay;
        public string gameTime;
        public string serverId;
        public string raw;
        public int tribeId;

        //Functions
        public delegate void OnFindSteamProfile(string steamId);
        public static ArkTribeLogEntry ParseEntry(ArkTribeLogString str, List<ArkPlayerProfile> playerProfiles, List<ArkDinosaur> globalDinos, int tribeId, OnFindSteamProfile steamCallback)
        {
            string content = str.content;

            //Determine what type of content this is with a regex. Yuck.
            ArkTribeLogEntry entry = null;
            if (TestRegex(content, REGEX_TAMED))
                entry = new ArkTribeLogEntry_Tamed(content, playerProfiles, globalDinos, tribeId, steamCallback);
            if (TestRegex(content, REGEX_TARGETKILLEDTARGET))
                entry = new ArkTribeLogEntry_TargetKilledTarget(content, playerProfiles, globalDinos, tribeId, steamCallback);

            if(entry == null)
            {
                //If it didn't match, return null for now
                return null;
            }

            //Add date and server information.
            entry.gameDay = str.dateData;
            entry.gameTime = str.timeData;
            entry.tribeId = tribeId;
            entry.raw = str.raw;
            return entry;
        }

        public static bool TestRegex(string content, string regex)
        {
            Regex r = new Regex(regex);
            Match m = r.Match(regex);
            return r.IsMatch(content);
        }

        public static GroupCollection GetRegexGroups(string content, string regex)
        {
            Regex r = new Regex(regex);
            Match m = r.Match(content);
            if (!m.Success)
                throw new Exception("Regex parse was not successful.");
            return m.Groups;
        }

        public static ArkTribeLogPlayerTarget TryFindPlayerProfile(string name, List<ArkPlayerProfile> playerProfiles, int tribeId, bool constrictToTribe, OnFindSteamProfile steamCallback)
        {
            //Find player profiles matching this name. 
            var profiles = playerProfiles.Where(x => x.ingamePlayerName == name && (x.tribeId == tribeId || !constrictToTribe)).ToArray();

            //If results were found, return them. 
            if(profiles.Length >= 1)
            {
                steamCallback(profiles[0].steamPlayerId);
                return new ArkTribeLogPlayerTarget
                {
                    exact = profiles.Length == 1,
                    found = true,
                    name = name,
                    profile = profiles[0]
                };
            } else
            {
                //No results...
                return new ArkTribeLogPlayerTarget
                {
                    profile = null,
                    name = name,
                    found = false,
                    exact = true
                };
            }
        }

        public static ArkTribeLogDinoTarget TryFindDinoProfile(string name, int level, string classname, int tribeId, List<ArkDinosaur> globalDinos, bool constrictToTribe)
        {
            //Find profiles matching this.
            var profiles = globalDinos.Where(x => x.isTamed == true && x.tamedName == name && x.dino_entry != null && x.dino_entry.screen_name == classname.Trim(' ').Trim('(').Trim(')') && (x.tribeId == tribeId || !constrictToTribe)).ToArray();

            //Find dino entries matching this too
            var dinoEntries = ArkImports.dino_entries.Where(x => x.screen_name == classname.Trim(' ').Trim('(').Trim(')')).ToArray();
            ArkDinoEntry dinoEntry = null;
            if (dinoEntries.Length > 0)
                dinoEntry = dinoEntries[0];

            //If results were found, return them
            if(profiles.Length >= 1)
            {
                return new ArkTribeLogDinoTarget
                {
                    name = name,
                    level = level,
                    displayClassname = classname,
                    found = true,
                    exact = profiles.Length == 1,
                    profile = profiles[0],
                    isTamed = true,
                    dinoEntry = dinoEntry
                };
            } else
            {
                return new ArkTribeLogDinoTarget
                {
                    name = name,
                    level = level,
                    displayClassname = classname,
                    found = false,
                    exact = true,
                    profile = null,
                    isTamed = true,
                    dinoEntry = dinoEntry
                };
            }
        }

        public static ArkTribeLogDinoTarget TryFindWildDinoProfile(int level, string classname, List<ArkDinosaur> globalDinos)
        {
            //Find profiles matching this.
            var profiles = globalDinos.Where(x => x.isTamed == false && x.dino_entry != null && x.dino_entry.screen_name == classname.Trim(' ').Trim('(').Trim(')')).ToArray();

            //If results were found, return them
            if (profiles.Length >= 1)
            {
                return new ArkTribeLogDinoTarget
                {
                    level = level,
                    displayClassname = classname,
                    found = true,
                    exact = profiles.Length == 1,
                    profile = profiles[0],
                    isTamed = false
                };
            }
            else
            {
                return new ArkTribeLogDinoTarget
                {
                    level = level,
                    displayClassname = classname,
                    found = false,
                    exact = true,
                    profile = null,
                    isTamed = false
                };
            }
        }

        public static ArkTribeLogPlayerOrDinoTarget TryFindDinoOrPlayerProfile(Group name, Group level, Group classname, List<ArkPlayerProfile> playerProfiles, List<ArkDinosaur> globalDinos, int tribeId, bool isWild, OnFindSteamProfile steamCallback)
        {
            //Try to find a player first, then try a dino.
            try
            {
                string nameString = name.Value;
                if (nameString.StartsWith("Tribemember "))
                    nameString = nameString.Substring("Tribemember ".Length);
                ArkTribeLogPlayerTarget t = TryFindPlayerProfile(nameString, playerProfiles, tribeId, false, steamCallback);
                if(t.found)
                {
                    return new ArkTribeLogPlayerOrDinoTarget
                    {
                        isDino = false,
                        player = t
                    };
                }
            } catch
            {

            }

            //Player check failed. Try a dino now.
            ArkTribeLogDinoTarget dt;
            if(isWild)
                dt = TryFindWildDinoProfile(int.Parse(level.Value), name.Value.Trim(' ').Trim('(').Trim(')').Split(')')[0], globalDinos);
            else
                dt = TryFindDinoProfile(name.Value, int.Parse(level.Value), classname.Value.Trim(' ').Trim('(').Trim(')').Split(')')[0], tribeId, globalDinos, false);
            return new ArkTribeLogPlayerOrDinoTarget
            {
                isDino = true,
                dino = dt
            };
        }
    }

    public enum ArkTribeLogEntryType
    {
        TribeTamedDino,
        TargetKilledTarget
    }

    public enum ArkTribeLogEntryPriority
    {
        High,
        Medium,
        Low
    }

    public class ArkTribeLogPlayerOrDinoTarget
    {
        public bool isDino;
        public ArkTribeLogDinoTarget dino;
        public ArkTribeLogPlayerTarget player;
    }

    public class ArkTribeLogPlayerTarget
    {
        public bool exact; //If this is true, this was the only result.
        public bool found; //If this is not true, use just the playername instead.

        public ArkPlayerProfile profile; //Could be null.
        public string name; //Never null.
    }

    public class ArkTribeLogDinoTarget
    {
        public bool exact; //If this is true, this was the only result.
        public bool found; //If this is not true, use just the playername instead.

        public bool isTamed; //If this is a tamed dino
        public ArkDinosaur profile; //The profile of the dino. Could be null
        public ArkDinoEntry dinoEntry; //The class entry. Could be null.
        public string name; //Never null.
        public int level; //Never null.
        public string displayClassname; //Never null.
    }
}
