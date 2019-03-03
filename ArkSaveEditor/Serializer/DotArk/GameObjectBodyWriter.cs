using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    static class GameObjectBodyWriter
    {
        public static long[] WriteGameObjectBodies(IOMemoryStream ms, DotArkFile f, DotArkSerializerInstance si)
        {
            //Start writing properties at the current location.
            long startPos = ms.position;

            //Allocate an array for storing the offsets to each
            long[] offsets = new long[f.gameObjects.Count];

            //Loop through all GameObjects
            for(int i = 0; i<f.gameObjects.Count; i++)
            {
                offsets[i] = ms.position - startPos;
                WriteSingleGameObjectBody(ms, f, f.gameObjects[i], si);
            }

            //Return offsets
            return offsets;
        }

        static void WriteSingleGameObjectBody(IOMemoryStream ms, DotArkFile f, DotArkGameObject o, DotArkSerializerInstance si)
        {
            //Just start writing properties
            foreach(var prop in o.props)
            {
                prop.WriteProp(si, o, f, ms);
            }

            //Finally, write a None name to tell Ark that this is the end of the list of props.
            ms.WriteArkClassname(new ArkClassName
            {
                classname = "None",
                index = 0
            }, si);
        }
    }
}
