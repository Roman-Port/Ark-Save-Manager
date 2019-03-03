using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkProperty
    {
        public ArkClassName name;
        public ArkClassName type;

        public int index;
        public int size;

        /// <summary>
        /// Beginning of the content, not the prop
        /// </summary>
        public long dataFilePosition;

        public object data;

        public static DotArkProperty ReadPropertyFromDisk(DotArkDeserializer d)
        {
            var ms = d.ms;

            //First, read a name and open it.
            ArkClassName name = ms.ReadArkClassname(d);

            //If this name is null, we've done something wrong.
            if (name == null)
                throw new Exception("A property reading error occurred and got an unexpected NULL value; do not save");

            //If the name is None, we've read to the final property and we can stop.
            if (name.IsNone())
                return null;

            //Now, read the type
            ArkClassName type = ms.ReadArkClassname(d);

            //If the type is None or unreadable, something has gone wrong.
            if (type == null)
                throw new Exception($"A property name was identified as {name.classname}, but the type failed to read.");

            //Read in the index and size 
            int size = ms.ReadInt();
            int index = ms.ReadInt();

            //Based on the type, deserialize this.
            DotArkProperty prop;
            switch(type.classname)
            {
                case "IntProperty":
                    prop = new IntProperty(d, index, size);
                    break;
                case "UInt32Property":
                    prop = new UInt32Property(d, index, size);
                    break;
                case "Int8Property":
                    prop = new Int8Property(d, index, size);
                    break;
                case "Int16Property":
                    prop = new Int16Property(d, index, size);
                    break;
                case "UInt16Property":
                    prop = new UInt16Property(d, index, size);
                    break;
                case "UInt64Property":
                    prop = new UInt64Property(d, index, size);
                    break;
                case "BoolProperty":
                    prop = new BoolProperty(d, index, size);
                    break;
                case "ByteProperty":
                    prop = new ByteProperty(d, index, size);
                    break;
                case "FloatProperty":
                    prop = new FloatProperty(d, index, size);
                    break;
                case "DoubleProperty":
                    prop = new DoubleProperty(d, index, size);
                    break;
                case "NameProperty":
                    prop = new NameProperty(d, index, size);
                    break;
                case "ObjectProperty":
                    prop = new ObjectProperty(d, index, size);
                    break;
                case "StrProperty":
                    prop = new StrProperty(d, index, size);
                    break;
                case "StructProperty":
                    prop = new StructProperty(d, index, size); 
                    break;
                case "ArrayProperty":
                    prop = DotArkArray.ReadArray(d, index, size); //UNFINISHED
                    break;
                case "TextProperty":
                    prop = new TextProperty(d, index, size);
                    break;
                default:
                    //Unknown
                    throw new Exception($"Type {type.classname} was not a valid property type. Something failed to read.");
            }
            //Set additional values in the property and return it.
            prop.type = type;
            prop.name = name;
            prop.index = index;
            prop.size = size;

            return prop;
        }

        /// <summary>
        /// When overwritten, this function will write the prop
        /// </summary>
        /// <param name="s"></param>
        /// <param name="go"></param>
        /// <param name="f"></param>
        /// <param name="ms"></param>
        public virtual void WriteProp(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            //Write the header data
            ms.WriteArkClassname(name, s);
            ms.WriteArkClassname(type, s);
            ms.WriteInt(size);
            ms.WriteInt(index);

            //Now, the overwritten function will run.
        }
    }
}
