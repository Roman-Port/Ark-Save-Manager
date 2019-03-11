using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkPrimalItem : HighLevelArkGameObjectRef
    {
        /// <summary>
        /// The name of the item, for example PrimalItemResource_Hide_C. Never null
        /// </summary>
        public string classname;

        /// <summary>
        /// Ark item id, maybe for net? Never null
        /// </summary>
        public UInt64 itemId;

        /// <summary>
        /// Number of items in this stack.
        /// </summary>
        public int stackSize;

        /// <summary>
        /// Owner of the object. Never null
        /// </summary>
        [Newtonsoft.Json.JsonIgnoreAttribute]
        public HighLevelArkGameObjectRef owner;

        /// <summary>
        /// Last time the durability was decreased. Never null
        /// </summary>
        public double lastDurabilityDecreaseTime;

        /// <summary>
        /// If this is a in-game Ark blueprint (not to be confused with an UE blueprint)
        /// </summary>
        public bool isBlueprint;

        /// <summary>
        /// If this is an engram. Appears in Argentavis inventory. Not really sure why this is here...
        /// </summary>
        public bool isEngram;

        /// <summary>
        /// Durability of this item, ranging from 0-1
        /// </summary>
        public float savedDurability;

        /// <summary>
        /// Name of the user that crafted this item, if it was crafted
        /// </summary>
        public string crafterName;

        /// <summary>
        /// Name of the tribe that crafted this item, if it was crafted
        /// </summary>
        public string crafterTribe;

        public ArkPrimalItem(ArkWorld world, DotArkGameObject orig) : base(world, orig)
        {
            //Check if this is claimed not to be an item
            if (!isItem)
                throw new Exception("Cannot read ArkPrimalItem when property 'isItem' is false!");
            //Read in values. Start with values that will never be null
            classname = orig.classname.classname;
            stackSize = 1;
            if(orig.PropExistsName("ItemQuantity"))
                stackSize = (int)orig.GetPropByName("ItemQuantity").data;
            owner = new HighLevelArkGameObjectRef(world, (orig.GetPropsByName<ObjectProperty>("OwnerInventory")[0]).gameObjectRef);

            //Convert ItemID
            ArkStructProps itemIdStruct = (ArkStructProps)orig.GetPropsByName<StructProperty>("ItemId")[0].structData;
            byte[] buf = new byte[8];
            BitConverter.GetBytes((UInt32)itemIdStruct.props_string["ItemID1"].data).CopyTo(buf, 0);
            BitConverter.GetBytes((UInt32)itemIdStruct.props_string["ItemID2"].data).CopyTo(buf, 4);
            itemId = BitConverter.ToUInt64(buf, 0);

            //Read booleans
            isBlueprint = GetBooleanProperty("bIsBlueprint");
            isEngram = GetBooleanProperty("bIsEngram");

            //Read props that may not exist
            if (CheckIfValueExists("SavedDurability"))
                savedDurability = GetFloatProperty("SavedDurability");
            else
                savedDurability = 1;

            if (CheckIfValueExists("CrafterCharacterName"))
                crafterName = GetStringProperty("CrafterCharacterName");
            else
                crafterName = null;

            if (CheckIfValueExists("CrafterTribeName"))
                crafterTribe = GetStringProperty("CrafterTribeName");
            else
                crafterTribe = null;

            if (CheckIfValueExists("LastAutoDurabilityDecreaseTime"))
                lastDurabilityDecreaseTime = (double)orig.GetPropsByName<DoubleProperty>("LastAutoDurabilityDecreaseTime")[0].data;
            else
                lastDurabilityDecreaseTime = -1;

        }
    }
}
