using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class UInt32Property : DotArkProperty
    {
        public UInt32Property(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;
            dataFilePosition = ms.position;
            this.data = ms.ReadUInt();
        }
    }
}
