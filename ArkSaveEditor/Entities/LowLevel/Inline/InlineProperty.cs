using ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline
{
    public class InlineProperty
    {
        public long startPos;
        public ArkClassName name;
        public ArkClassName type;
        public int length;
        public int index;

        public static InlineProperty ReadProperty(IOMemoryStream ms)
        {
            //Read type
            long startPos = ms.position;
            ArkClassName name = ms.ReadInlineArkClassname();
            
            if (name.IsNone())
                return null;

            ArkClassName type = ms.ReadInlineArkClassname();

            //Rewind
            ms.position = startPos;

            //Based on the name of the prop, compare.
            InlineProperty p;
            switch(type.classname)
            {
                case "IntProperty":
                    p = new InlineIntProperty(ms);
                    break;
                case "StructProperty":
                    p = new InlineStructProperty(ms);
                    break;
                case "UInt64Property":
                    p = new InlineUInt64Property(ms);
                    break;
                case "StrProperty":
                    p = new InlineStrProperty(ms);
                    break;
                case "BoolProperty":
                    p = new InlineBoolProperty(ms);
                    break;
                case "ArrayProperty":
                    p = new InlineArrayProperty(ms);
                    break;
                case "ByteProperty":
                    p = new InlineByteProperty(ms);
                    break;
                case "UInt16Property":
                    p = new InlineUInt16Property(ms);
                    break;
                case "FloatProperty":
                    p = new InlineFloatProperty(ms);
                    break;
                case "DoubleProperty":
                    p = new InlineDoubleProperty(ms);
                    break;
                case "ObjectProperty":
                    p = new InlineObjectProperty(ms);
                    break;
                case "UInt32Property":
                    p = new InlineUInt32Property(ms);
                    break;
                default:
                    //Default and read a base one, then skip
                    p = new InlineProperty(ms);
                    Console.WriteLine($"Unknown property {p.name.classname} ({p.type.classname}) at {p.startPos}. Attempting to skip; this will probably cause a crash.");
                    ms.position += p.length;
                    break;
            }
            return p;
        }

        public InlineProperty(IOMemoryStream ms)
        {
            startPos = ms.position;
            name = ms.ReadInlineArkClassname();
            type = ms.ReadInlineArkClassname();
            length = ms.ReadInt();
            index = ms.ReadInt();
        }
    }
}
