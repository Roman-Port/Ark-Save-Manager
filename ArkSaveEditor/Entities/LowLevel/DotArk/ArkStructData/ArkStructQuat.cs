using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
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

        public ArkStructQuat(IOMemoryStream ms, ArkClassName structType)
        {
            x = ms.ReadFloat();
            y = ms.ReadFloat();
            z = ms.ReadFloat();
            w = ms.ReadFloat();
        }

        public override void WriteStruct(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            ms.WriteFloat(x);
            ms.WriteFloat(y);
            ms.WriteFloat(z);
            ms.WriteFloat(w);
        }
    }
}
