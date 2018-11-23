using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkDinosaurStats
    {
        /// <summary>
        /// Health points
        /// </summary>
        public float health = 0;
        /// <summary>
        /// Stamina
        /// </summary>
        public float stamina = 0;
        /// <summary>
        /// Unknown ARK data
        /// </summary>
        public float unknown1 = 0;
        /// <summary>
        /// Oxygen
        /// </summary>
        public float oxygen = 0;
        /// <summary>
        /// Food
        /// </summary>
        public float food = 0;
        /// <summary>
        /// Water level
        /// </summary>
        public float water = 0;
        /// <summary>
        /// Unknown ARK data
        /// </summary>
        private float unknown2 = 0;
        /// <summary>
        /// Inventory weight units.
        /// </summary>
        public float inventoryWeight = 0;
        /// <summary>
        /// Melee damage multiplier
        /// </summary>
        public float meleeDamageMult = 0;
        /// <summary>
        /// Movement damage multiplier
        /// </summary>
        public float movementSpeedMult = 0;
        /// <summary>
        /// Unknown ARK data
        /// </summary>
        private float unknown3 = 0;
        /// <summary>
        /// Unknown ARK data
        /// </summary>
        private float unknown4 = 0;

        /// <summary>
        /// Generate this data from a GameObject's properties.
        /// </summary>
        /// <param name="gameobject"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static ArkDinosaurStats ReadStats(HighLevelArkGameObjectRef gameobject, string propertyName, bool isByteProp)
        {
            ArkDinosaurStats s = new ArkDinosaurStats();
            //Read each property name and loop through them.
            var props = gameobject.GetPropertiesByName(propertyName);
            foreach(var p in props)
            { 
                int index = p.index;
                float data;
                if(isByteProp)
                    data = (float)(((ByteProperty)p).byteValue);
                else
                    data = (float)p.data;

                switch (index)
                {
                    case 0:
                        s.health = data;
                        break;
                    case 1:
                        s.stamina = data;
                        break;
                    case 2:
                        s.unknown1 = data;
                        break;
                    case 3:
                        s.oxygen = data;
                        break;
                    case 4:
                        s.food = data;
                        break;
                    case 5:
                        s.water = data;
                        break;
                    case 6:
                        s.unknown2 = data;
                        break;
                    case 7:
                        s.inventoryWeight = data;
                        break;
                    case 8:
                        s.meleeDamageMult = data;
                        break;
                    case 9:
                        s.movementSpeedMult = data;
                        break;
                    case 10:
                        s.unknown2 = data;
                        break;
                    case 11:
                        s.unknown4 = data;
                        break;
                    default:
                        //We shouldn't be here...
                        throw new Exception($"Unknown index ID while reading Dinosaur stats {index}!");
                }
            }

            return s;
        }
    }
}
