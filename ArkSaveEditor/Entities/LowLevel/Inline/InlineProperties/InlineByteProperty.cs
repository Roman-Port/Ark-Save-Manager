using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineByteProperty : InlineProperty
    {
        public ArkClassName enumName;

        public bool isNormalByte; //If this is true, this is just a normal byte. If it is not true, use the ClassName instead

        //=== VALUES ===
        public ArkClassName enumValue; //Use ONLY if the above boolean is false
        public byte byteValue; //Use ONLY if the above boolean is true

        public InlineByteProperty(IOMemoryStream ms) : base(ms)
        {          
            //Read in the enum name
            enumName = ms.ReadInlineArkClassname();

            //That can be None, but cannot be null.
            if (enumName == null)
                throw new Exception("Tried to read enum type, but got null!");

            isNormalByte = enumName.IsNone();

            //If that type is a None, this is not an enum. If it is, this is an enum. Read the name.
            if (isNormalByte)
                byteValue = ms.ReadByte();
            else
                enumValue = ms.ReadInlineArkClassname();
        }
    }
}
