using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructQuat : DotArkStruct
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public ArkStructQuat(DotArkDeserializer d, ArkClassName structType)
        {
            var ms = d.ms;

            x = ms.ReadFloat();
            y = ms.ReadFloat();
            z = ms.ReadFloat();
            w = ms.ReadFloat();
        }
    }
}
