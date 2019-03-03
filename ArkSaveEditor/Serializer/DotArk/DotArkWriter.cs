using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    public static class DotArkWriter
    {
        public static void WriteDotArk(IOMemoryStream ms, DotArkFile f)
        {
            //Create instance
            DotArkSerializerInstance inst = new DotArkSerializerInstance();

            //Write the game object bodies into their own temporary stream for later
            IOMemoryStream gameObjectBodyStream = new IOMemoryStream(true);
            long[] gameObjectPropertyOffsets = GameObjectBodyWriter.WriteGameObjectBodies(gameObjectBodyStream, f, inst);

            //Now, write the GameObject heads into their own temporary stream for later.
            IOMemoryStream gameObjectHeadStream = new IOMemoryStream(true);
            GameObjectHeadWriter.WriteGameObjectHeads(gameObjectHeadStream, f, inst, gameObjectPropertyOffsets);
            
        }

        public static void WriteStringArray(IOMemoryStream ms, string[] s)
        {
            //Write the length first
            ms.WriteInt(s.Length);

            //Write each string
            for (int i = 0; i < s.Length; i++)
                ms.WriteUEString(s[i]);
        }
    }
}
