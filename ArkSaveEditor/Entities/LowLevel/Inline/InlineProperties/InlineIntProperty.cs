using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineIntProperty : InlineProperty
    {
        public int value;

        public InlineIntProperty(IOMemoryStream ms) : base(ms)
        {
            value = ms.ReadInt();
        }
    }
}
