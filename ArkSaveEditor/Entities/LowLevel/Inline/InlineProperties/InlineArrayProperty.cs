using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineArrayProperty : InlineProperty
    {
        public ArkClassName arrayType;
        public string[] data;

        public InlineArrayProperty(IOMemoryStream ms) : base(ms)
        {
            //Read type
            arrayType = ms.ReadInlineArkClassname();

            if(arrayType.classname == "StrProperty")
            {
                //Read string array
                int count = ms.ReadInt();
                data = new string[count];
                for (int i = 0; i < count; i += 1)
                    data[i] = ms.ReadUEString();
            } else
            {
                //Skip
                ms.position += length;
            }
            
        }
    }
}
