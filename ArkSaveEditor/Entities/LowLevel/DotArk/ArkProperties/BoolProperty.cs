using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class BoolProperty : DotArkProperty
    {
        public BoolProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            this.data = ms.ReadByte() != 0;
        }
    }
}
