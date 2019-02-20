using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineArrayProperty : InlineProperty
    {
        public ArkClassName arrayType;

        public InlineArrayProperty(IOMemoryStream ms) : base(ms)
        {
            //Read type
            arrayType = ms.ReadInlineArkClassname();

            //Skip for now
            ms.position += length;
        }
    }
}
