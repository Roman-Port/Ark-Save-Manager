using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ByteProperty : DotArkProperty
    {
        public ArkClassName enumName;

        public bool isNormalByte; //If this is true, this is just a normal byte. If it is not true, use the ClassName instead

        //=== VALUES ===
        public ArkClassName enumValue; //Use ONLY if the above boolean is false
        public byte byteValue; //Use ONLY if the above boolean is true

        public ByteProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            //Read in the enum name
            enumName = ms.ReadArkClassname(d);

            //That can be None, but cannot be null.
            if (enumName == null)
                throw new Exception("Tried to read enum type, but got null!");

            isNormalByte = enumName.IsNone();

            //If that type is a None, this is not an enum. If it is, this is an enum. Read the name.
            dataFilePosition = ms.position;
            if (isNormalByte)
                byteValue = ms.ReadByte();
            else
                enumValue = ms.ReadArkClassname(d);
        }

        public override void WriteProp(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            base.WriteProp(s, go, f, ms);

            //Write enum name
            ms.WriteArkClassname(enumName, s);

            //If this is a normal byte, write the byte value. Else, write the classname
            if (isNormalByte)
                ms.ms.WriteByte(byteValue);
            else
                ms.WriteArkClassname(enumValue, s);
        }
    }
}
