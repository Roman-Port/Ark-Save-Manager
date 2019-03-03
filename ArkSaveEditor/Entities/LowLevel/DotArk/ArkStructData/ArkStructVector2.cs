using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructVector2 : DotArkStruct
    {
        public float x;
        public float y;

        public ArkStructVector2(IOMemoryStream ms, ArkClassName structType)
        {
            x = ms.ReadFloat();
            y = ms.ReadFloat();
        }

        public override void WriteStruct(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            ms.WriteFloat(x);
            ms.WriteFloat(y);
        }
    }
}
