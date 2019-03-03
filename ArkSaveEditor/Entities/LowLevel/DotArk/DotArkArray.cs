using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkArray
    {
        public static DotArkProperty ReadArray(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;

            //First, read the type of the array.
            ArkClassName arrayType = ms.ReadArkClassname(d);

            //Read through each of the values in the array.
            //ms.ms.Position += length;

            //Switch depending on the type
            DotArkProperty r;
            switch (arrayType.classname)
            {
                case "ObjectProperty": r = ReadObjectProperty(d, index, length, arrayType); break;
                case "StructProperty": r = ReadStructProperty(d, index, length, arrayType); break;
                case "UInt32Property": r = ReadUInt32Property(d, index, length, arrayType); break;
                case "IntProperty": r = ReadIntProperty(d, index, length, arrayType); break;
                case "UInt16Property": r = ReadUInt16Property(d, index, length, arrayType); break;
                case "Int16Property": r = ReadInt16Property(d, index, length, arrayType); break;
                case "ByteProperty": r = ReadByteProperty(d, index, length, arrayType); break;
                case "Int8Property": r = ReadInt8Property(d, index, length, arrayType); break;
                case "StrProperty": r = ReadStrProperty(d, index, length, arrayType); break;
                case "UInt64Property": r = ReadUInt64Property(d, index, length, arrayType); break;
                case "BoolProperty": r = ReadBoolProperty(d, index, length, arrayType); break;
                case "FloatProperty": r = ReadFloatProperty(d, index, length, arrayType); break;
                case "DoubleProperty": r = ReadDoubleProperty(d, index, length, arrayType); break;
                case "NameProperty": r = ReadNameProperty(d, index, length, arrayType); break;
                default:
                    throw new Exception($"Unknown ARK array type '{arrayType.classname}'.");
            }

            return r;
        }

        private static DotArkProperty ReadObjectProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<ObjectProperty> data = new List<ObjectProperty>();

            for(int i = 0; i < arraySize; i++)
            {
                data.Add(new ObjectProperty(d, index, length));
            }

            //Create
            return new ArrayProperty<ObjectProperty>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadStructProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            List<DotArkStruct> data = new List<DotArkStruct>();
            int arraySize = d.ms.ReadInt();

            //Determine the type
            ArkClassName structType;
            if (arraySize * 4 + 4 == length)
                structType = ArkClassName.Create("Color");
            else if (arraySize * 12 + 4 == length)
                structType = ArkClassName.Create("Vector");
            else if (arraySize * 16 + 4 == length)
                structType = ArkClassName.Create("LinearColor");
            else
                structType = null;

            //Read
            if(structType != null)
            {
                for(int i = 0; i<arraySize; i++)
                {
                    data.Add(DotArkStruct.ReadFromFile(d, structType));
                }
            } else
            {
                for (int i = 0; i < arraySize; i++)
                {
                    data.Add(new ArkStructProps(d, structType));
                }
            }

            //Create
            return new ArrayProperty<DotArkStruct>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadUInt32Property(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<UInt32> data = new List<UInt32>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadUInt());

            //Create
            return new ArrayProperty<UInt32>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadIntProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<int> data = new List<int>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadInt());

            //Create
            return new ArrayProperty<int>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadUInt16Property(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<UInt16> data = new List<UInt16>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadUShort());

            //Create
            return new ArrayProperty<UInt16>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadInt16Property(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<Int16> data = new List<Int16>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadShort());

            //Create
            return new ArrayProperty<Int16>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadByteProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<byte> data = new List<byte>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadByte());

            //Create
            return new ArrayProperty<byte>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadInt8Property(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<byte> data = new List<byte>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadByte());

            //Create
            return new ArrayProperty<byte>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadStrProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<string> data = new List<string>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadUEString());

            //Create
            return new ArrayProperty<string>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadUInt64Property(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<UInt64> data = new List<UInt64>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadULong());

            //Create
            return new ArrayProperty<UInt64>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadBoolProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<bool> data = new List<bool>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadByteBool());

            //Create
            return new ArrayProperty<bool>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadFloatProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<float> data = new List<float>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadFloat());

            //Create
            return new ArrayProperty<float>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadDoubleProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<double> data = new List<double>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadDouble());

            //Create
            return new ArrayProperty<double>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

        private static DotArkProperty ReadNameProperty(DotArkDeserializer d, int index, int length, ArkClassName type)
        {
            //Open
            int arraySize = d.ms.ReadInt();

            List<ArkClassName> data = new List<ArkClassName>();

            for (int i = 0; i < arraySize; i++)
                data.Add(d.ms.ReadArkClassname(d));

            //Create
            return new ArrayProperty<ArkClassName>
            {
                arrayType = type,
                index = index,
                items = data,
                size = length
            };
        }

    }
}
