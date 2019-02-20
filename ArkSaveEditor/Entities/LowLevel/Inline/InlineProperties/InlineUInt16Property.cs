using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineUInt16Property : InlineProperty
    {
        public UInt16 value;

        public InlineUInt16Property(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadUShort();
        }
    }
}
