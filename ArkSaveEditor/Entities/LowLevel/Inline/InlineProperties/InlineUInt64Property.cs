using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineUInt64Property : InlineProperty
    {
        public UInt64 value;

        public InlineUInt64Property(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadULong();
        }
    }
}
