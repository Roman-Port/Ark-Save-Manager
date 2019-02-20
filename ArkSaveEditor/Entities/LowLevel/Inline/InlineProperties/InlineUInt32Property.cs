using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineUInt32Property : InlineProperty
    {
        public UInt32 value;

        public InlineUInt32Property(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadUInt();
        }
    }
}
