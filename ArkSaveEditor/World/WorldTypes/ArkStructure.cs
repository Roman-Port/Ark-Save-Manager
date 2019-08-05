using ArkSaveEditor.ArkEntries;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkStructure : ArkCharacter
    {
        /// <summary>
        /// Has an inventory or not
        /// </summary>
        public bool hasInventory;

        /// <summary>
        /// If this structure has an inventory, the current number of items inside of it
        /// </summary>
        public int currentItemCount;

        /// <summary>
        /// If this structure has an inventory, the maximum number of items inside of it
        /// </summary>
        public int maxItemCount;

        /// <summary>
        /// How to display this
        /// </summary>
        public StructureDisplayMetadata displayMetadata;

        /// <summary>
        /// The max health of the structure
        /// </summary>
        public float maxHealth;

        /// <summary>
        /// The current health of this structure
        /// </summary>
        public float currentHealth;

        public ArkStructure(ArkWorld world, DotArkGameObject orig, StructureDisplayMetadata displayMetadata) : base(world, orig)
        {
            tribeId = GetInt32Property("TargetingTeam");
            isInTribe = true;
            hasInventory = HasProperty("MyInventoryComponent");
            this.displayMetadata = displayMetadata;

            if (HasProperty("CurrentItemCount"))
                currentItemCount = GetInt32Property("CurrentItemCount");
            if (HasProperty("MaxItemCount"))
                currentItemCount = GetInt32Property("MaxItemCount");
            if (HasProperty("Health"))
                currentHealth = GetFloatProperty("Health");
            if (HasProperty("MaxHealth"))
                maxHealth = GetFloatProperty("MaxHealth");

        }

        public ArkStructure()
        {

        }
    }
}
