using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineObjectProperty : InlineProperty
    {
        public InlineObjectProperty(IOMemoryStream ms) : base(ms)
        {
            //Skip for now;
            ms.position += length;
        }
    }
}
