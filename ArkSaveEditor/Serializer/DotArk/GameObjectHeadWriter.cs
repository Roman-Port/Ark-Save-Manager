using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    public class GameObjectHeadWriter
    {
        public static void WriteGameObjectHeads(IOMemoryStream ms, DotArkFile f, DotArkSerializerInstance si, long[] propertyOffsets)
        {
            //Write all of the GameObject headers
            //First, write the number of GameObjects
            ms.WriteInt(f.gameObjects.Count);

            //Loop through gameObjects and write their heads
            for(int i = 0; i<f.gameObjects.Count; i++)
            {
                WriteHead(ms, f, si, f.gameObjects[i], propertyOffsets[i]);
            } 
        }

        static void WriteHead(IOMemoryStream ms, DotArkFile f, DotArkSerializerInstance si, DotArkGameObject go, long propertyOffset)
        {
            //Write data according to https://us-central.assets-static-2.romanport.com/ark/#gameobject+base_header
            ms.WriteBytes(go.guid.ToByteArray()); //Write the GUID
            ms.WriteArkClassname(go.classname, si); //Write classname 
            ms.WriteIntBool(go.isItem);

            //Write classname array
            ms.WriteInt(go.names.Count);
            foreach (var n in go.names)
                ms.WriteArkClassname(n, si);

            //Write unknowns
            ms.WriteIntBool(go.unknownData1);
            ms.WriteInt(go.unknownData2);

            //Write position data if it exists.
            ms.WriteIntBool(go.locationData != null);
            if (go.locationData != null)
                ms.WriteLocationData(go.locationData);

            //Write the offset to the properties data
            ms.WriteInt((int)propertyOffset);

            //Write last unknown data
            ms.WriteInt(go.unknownData3);
        }
    }
}
