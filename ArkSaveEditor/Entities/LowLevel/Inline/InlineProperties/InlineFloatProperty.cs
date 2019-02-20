using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineFloatProperty : InlineProperty
    {
        public float value;

        public InlineFloatProperty(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadFloat();
        }
    }
}
