using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineDoubleProperty : InlineProperty
    {
        public double value;

        public InlineDoubleProperty(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadDouble();
        }
    }
}
