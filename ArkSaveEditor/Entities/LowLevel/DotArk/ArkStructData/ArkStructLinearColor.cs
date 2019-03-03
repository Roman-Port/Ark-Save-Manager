using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructLinearColor : DotArkStruct
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public ArkStructLinearColor(IOMemoryStream ms, ArkClassName structType)
        {
            r = ms.ReadFloat();
            g = ms.ReadFloat();
            b = ms.ReadFloat();
            a = ms.ReadFloat();
        }

        public override void WriteStruct(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            ms.WriteFloat(r);
            ms.WriteFloat(g);
            ms.WriteFloat(b);
            ms.WriteFloat(a);
        }
    }
}
