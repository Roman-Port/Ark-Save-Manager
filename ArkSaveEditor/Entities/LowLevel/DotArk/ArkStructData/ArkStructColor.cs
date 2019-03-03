using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructColor : DotArkStruct
    {
        public byte b;
        public byte g;
        public byte r;
        public byte a;

        public ArkStructColor(IOMemoryStream ms, ArkClassName structType)
        {
            b = ms.ReadByte();
            g = ms.ReadByte();
            r = ms.ReadByte();
            a = ms.ReadByte();
        }

        public override void WriteStruct(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            ms.WriteFloat(b);
            ms.WriteFloat(g);
            ms.WriteFloat(r);
            ms.WriteFloat(a);
        }
    }
}
