using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArrayProperty : DotArkProperty
    {
        public ArkClassName arrayType;

        public ArrayProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            //First, read the type of the array.
            arrayType = ms.ReadArkClassname(d);

            //Read through each of the values in the array.
            ms.ms.Position += length;
        }
    }
}
