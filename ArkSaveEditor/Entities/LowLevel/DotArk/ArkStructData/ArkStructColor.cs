using ArkSaveEditor.Deserializer.DotArk;
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

        public ArkStructColor(DotArkDeserializer d, ArkClassName structType)
        {
            var ms = d.ms;

            b = ms.ReadByte();
            g = ms.ReadByte();
            r = ms.ReadByte();
            a = ms.ReadByte();
        }
    }
}
