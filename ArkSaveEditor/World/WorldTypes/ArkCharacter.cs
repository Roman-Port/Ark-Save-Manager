using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    /// <summary>
    /// Contains some properties that characters have
    /// </summary>
    public class ArkCharacter : HighLevelArkGameObjectRef
    {
        /// <summary>
        /// ID of the tribe
        /// </summary>
        public int tribeId;

        /// <summary>
        /// Is in a tribe
        /// </summary>
        public bool isInTribe;

        /// <summary>
        /// Get the items in this characters's inventory.
        /// </summary>
        public ArkInventory GetInventory()
        {
            //If we don't have an inventory compnent, return empty list
            if (!HasProperty("MyInventoryComponent"))
                return ArkInventory.EMPTY_INVENTORY;

            //Get
            return ArkInventory.LoadFromReference(world, (ObjectProperty)GetPropertiesByName("MyInventoryComponent")[0]);
        }

        /// <summary>
        /// Checks if we have an inventory
        /// </summary>
        public bool HasInventory()
        {
            return HasProperty("MyInventoryComponent");
        }

        public ArkCharacter(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {

        }

        public ArkCharacter()
        {

        }
    }
}
