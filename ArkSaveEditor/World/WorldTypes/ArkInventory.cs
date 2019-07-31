using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkInventory
    {
        /// <summary>
        /// Items in the inventory
        /// </summary>
        public List<ArkPrimalItem> items;

        /// <summary>
        /// Loads from a GameObject
        /// </summary>
        /// <returns></returns>
        public static ArkInventory LoadFromAsset(ArkWorld world, DotArkGameObject r)
        {
            //Get a list of all items
            List<ObjectProperty> inventoryItems;
            if (!r.PropExistsName("InventoryItems"))
                inventoryItems = new List<ObjectProperty>();
            else
                inventoryItems = ((ArrayProperty<ObjectProperty>)r.GetPropsByName("InventoryItems")[0]).items;

            //Now, loop through and create items
            ArkInventory inventory = new ArkInventory();
            inventory.items = new List<ArkPrimalItem>();
            foreach (var o in inventoryItems)
            {
                ArkPrimalItem item = new ArkPrimalItem(world, o.gameObjectRef);
                if (item.isEngram)
                    continue;

                inventory.items.Add(item);
            }

            //Return
            return inventory;
        }

        /// <summary>
        /// Loads from a reference
        /// </summary>
        /// <returns></returns>
        public static ArkInventory LoadFromReference(ArkWorld world, ObjectProperty r)
        {
            return LoadFromAsset(world, r.gameObjectRef);
        }

        /// <summary>
        /// Use if there is no inventory
        /// </summary>
        public static readonly ArkInventory EMPTY_INVENTORY = new ArkInventory
        {
            items = new List<ArkPrimalItem>()
        };
    }
}
