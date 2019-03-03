using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
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

        public override void WriteProp(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            base.WriteProp(s, go, f, ms);

            //Write the struct type
            ms.WriteArkClassname(structType, s);

            //Write the struct data.
            structData.WriteStruct(s, go, f, ms);
        }
    }
}
