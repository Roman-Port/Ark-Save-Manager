using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineIntProperty : InlineProperty
    {
        public int data;

        public InlineIntProperty(IOMemoryStream ms) : base(ms)
        {
            data = ms.ReadInt();
        }
    }
}
