using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructVector3 : DotArkStruct
    {
        public float x;
        public float y;
        public float z;

        public ArkStructVector3(DotArkDeserializer d, ArkClassName structType)
        {
            var ms = d.ms;

            x = ms.ReadFloat();
            y = ms.ReadFloat();
            z = ms.ReadFloat();
        }
    }
}
