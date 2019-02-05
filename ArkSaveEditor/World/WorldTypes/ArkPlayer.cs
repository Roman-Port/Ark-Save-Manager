using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkPlayer : HighLevelArkGameObjectRef
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
        /// ID of the tribe
        /// </summary>
        public int tribeId;

        public ArkPlayer(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {
            playerName = GetStringProperty("PlayerName");
            steamName = GetStringProperty("PlatformProfileName");

            //Read the struct containing Steam ID
            StructProperty sprop = (StructProperty)GetSingleProperty("PlatformProfileID");
            ArkStructUniqueNetId nsprop = (ArkStructUniqueNetId)sprop.structData;
            steamId = nsprop.netId;

            tribeName = GetStringProperty("TribeName");
            tribeId = GetInt32Property("TargetingTeam");
        }
    }
}
