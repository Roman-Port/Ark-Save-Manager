using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class TextProperty : DotArkProperty
    {
        public TextProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            this.data = Convert.ToBase64String(ms.ReadBytes(length));
        }
    }
}
