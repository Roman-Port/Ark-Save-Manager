using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineStrProperty : InlineProperty
    {
        public string value;

        public InlineStrProperty(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadUEString();
        }
    }
}
