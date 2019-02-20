using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineBoolProperty : InlineProperty
    {
        public bool value;

        public InlineBoolProperty(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadByte() != 0;
        }
    }
}
