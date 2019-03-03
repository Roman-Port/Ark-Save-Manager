using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel
{
    public class ArkClassName
    {
        public string classname;
        public int index;

        public static ArkClassName Create(string name, int index = 0)
        {
            return new ArkClassName
            {
                classname = name,
                index = index
            };
        }

        public static ArkClassName ReadFromFile(DotArkDeserializer ark)
        {
            ArkClassName cn = new ArkClassName();
            //Before a certain version, this is just a string. If we've read ark.binaryNameTable, use the index method.
            if(ark.binaryNameTable == null)
            {
                //Read classname from the file.
                cn.classname = ark.ms.ReadUEString();
            } else
            {
                //Read the index here and jump to it.
                int index = ark.ms.ReadInt()-1; //Subtract one because Ark uses a base-one method
                if (index < 0 || index > ark.binaryNameTable.Length)
                    throw new Exception($"Failed to read Ark class name; {index} is out of range.");
                cn.classname = ark.binaryNameTable[index];
            }
            //Read the unique index
            cn.index = ark.ms.ReadInt();
            return cn;
        }

        public void WriteToDotArkFile(DotArkSerializerInstance ark, IOMemoryStream ms)
        {
            //Get name table index.
            int nameTableIndex = ark.GetNameTableEntry(classname);

            //Write nameTableIndex and the index
            ms.WriteInt(nameTableIndex);
            ms.WriteInt(index);
        }

        public static ArkClassName ReadFromFileInline(IOMemoryStream ms)
        {
            ArkClassName cn = new ArkClassName();
            //Read classname from the file.
            cn.classname = ms.ReadUEString();
            return cn;
        }

        public bool CompareNameTo(string n)
        {
            return n == classname;
        }

        public bool IsNone()
        {
            return classname == "None";
        }
    }
}
