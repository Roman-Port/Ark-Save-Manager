using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkPlayer : ArkCharacter
    {
        /// <summary>
        /// The name of the player, shown in game
        /// </summary>
        public string playerName;

        /// <summary>
        /// Name of this person's Steam profile
        /// </summary>
        public string steamName;

        /// <summary>
        /// The ID on Steam, used for verification
        /// </summary>
        public string steamId;

        /// <summary>
        /// Name of the tribe
        /// </summary>
        public string tribeName;

        /// <summary>
        /// The ID of this player on ARK
        /// </summary>
        public ulong arkId;

        /// <summary>
        /// Is this player living?
        /// </summary>
        public bool isAlive;

        /// <summary>
        /// Stats. May be null.
        /// </summary>
        public ArkDinosaurStats currentStats;

        public ArkPlayer(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {
            playerName = GetStringProperty("PlayerName");
            steamName = GetStringProperty("PlatformProfileName");
            arkId = GetUInt64Property("LinkedPlayerDataID");

            //Read the struct containing Steam ID
            StructProperty sprop = (StructProperty)GetSingleProperty("PlatformProfileID");
            ArkStructUniqueNetId nsprop = (ArkStructUniqueNetId)sprop.structData;
            steamId = nsprop.netId;

            //Tribe stuff
            if(HasProperty("TribeName"))
            {
                tribeName = GetStringProperty("TribeName");
                tribeId = GetInt32Property("TargetingTeam");
                isInTribe = true;
            } else
            {
                tribeName = "No Tribe";
                tribeId = -1;
                isInTribe = false;
            }
            
            //Check if alive
            try
            {
                HighLevelArkGameObjectRef statusComponent = GetGameObjectRef("MyCharacterStatusComponent");
                currentStats = ArkDinosaurStats.ReadStats(statusComponent, "CurrentStatusValues", false);
                isAlive = currentStats.health > 0.1f;
            } catch
            {
                isAlive = false;
            }
        }

        /// <summary>
        /// Grabs the player profile for this user
        /// </summary>
        /// <returns></returns>
        public ArkPlayerProfile GetPlayerProfile()
        {
            var matches = world.players.Where(x => x.steamPlayerId == steamId);
            if (matches.Count() == 1)
                return matches.First();
            else
                return null;
        }
    }
}
