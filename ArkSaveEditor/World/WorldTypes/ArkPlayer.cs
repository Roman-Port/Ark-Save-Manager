using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// The ID of this player on ARK
        /// </summary>
        public ulong arkId;

        /// <summary>
        /// Is in a tribe
        /// </summary>
        public bool isInTribe;

        public ArkPlayer(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {
            playerName = GetStringProperty("PlayerName");
            steamName = GetStringProperty("PlatformProfileName");

            //Read the struct containing Steam ID
            StructProperty sprop = (StructProperty)GetSingleProperty("PlatformProfileID");
            ArkStructUniqueNetId nsprop = (ArkStructUniqueNetId)sprop.structData;
            steamId = nsprop.netId;

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
            arkId = GetUInt64Property("LinkedPlayerDataID");
        }

        /// <summary>
        /// Get the items in this player's inventory.
        /// </summary>
        public List<ArkPrimalItem> GetInventoryItems(bool includeEngrams = false)
        {
            //If we don't have an inventory compnent, return empty list
            if (!HasProperty("MyInventoryComponent"))
                return new List<ArkPrimalItem>();

            //Get the inventory component from our props. This is ref
            var inventoryComponent = ((ObjectProperty)GetPropertiesByName("MyInventoryComponent")[0]).gameObjectRef;

            //Get the items
            if (!inventoryComponent.PropExistsName("InventoryItems"))
                return new List<ArkPrimalItem>();
            var inventoryItems = ((ArrayProperty<ObjectProperty>)inventoryComponent.GetPropsByName("InventoryItems")[0]).items;

            //Get the referenced items
            List<ArkPrimalItem> stacks = new List<ArkPrimalItem>();
            foreach (var o in inventoryItems)
            {
                ArkPrimalItem item = new ArkPrimalItem(world, o.gameObjectRef);
                if (includeEngrams || !item.isEngram)
                    stacks.Add(item);
            }
            return stacks;
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
