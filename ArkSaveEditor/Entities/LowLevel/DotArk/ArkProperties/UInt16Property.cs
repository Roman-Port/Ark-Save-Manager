using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class UInt16Property : DotArkProperty
    {
        public UInt16Property(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            this.data = ms.ReadUShort();
        }
    }
}
