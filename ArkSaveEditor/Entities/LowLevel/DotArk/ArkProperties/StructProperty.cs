using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class StructProperty : DotArkProperty
    {
        public ArkClassName structType;
        public DotArkStruct structData;

        public StructProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            //Read the struct type
            structType = ms.ReadArkClassname(d);

            //Read in the struct
            dataFilePosition = ms.position;
            structData = DotArkStruct.ReadFromFile(d, structType);
            data = structData;
        }
    }
}
