using ArkSaveEditor.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class ArkItemEntry
    {
        public ArkImageAsset icon;
        public ArkImageAsset broken_icon;

        public string classname;
        public string blueprintPath;

        public bool hideFromInventoryDisplay { get; set; }

        public bool useItemDurability { get; set; }

        public bool isTekItem { get; set; }

        public bool allowUseWhileRiding { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public float spoilingTime { get; set; } //0 if not spoiling

        public float baseItemWeight { get; set; }

        public float useCooldownTime { get; set; }

        public float baseCraftingXP { get; set; }

        public float baseRepairingXP { get; set; }

        public int maxItemQuantity { get; set; }

        //CONSUMABLES
        public float increasePerQuanity_Weight { get; set; }

        public float increasePerQuanity_Food { get; set; }

        public float increasePerQuanity_Health { get; set; }

        public float increasePerQuanity_Water { get; set; }

        public float increasePerQuanity_Stamina { get; set; }
    }
}
