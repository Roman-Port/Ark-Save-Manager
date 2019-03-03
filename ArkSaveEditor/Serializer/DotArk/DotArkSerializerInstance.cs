using ArkSaveEditor.Serializer.DotArk.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    public class DotArkSerializerInstance
    {
        public List<string> nameTable; //Name table to write
        public bool isNameTableFinal = false; //If this is true, new entries will not be written to the name table.

        public DotArkSerializerInstance()
        {
            nameTable = new List<string>();
            isNameTableFinal = false;
        }

        public int GetNameTableEntry(string name)
        {
            //Check if the name table already has this name.
            if(nameTable.Contains(name))
            {
                //Write index of this
                return nameTable.IndexOf(name) + 1;
            } else
            {
                //The name table does not contain this name. Check if it is final
                if (isNameTableFinal)
                    throw new NameTableFinalException();

                //Add it and return an index.
                int index;
                lock(nameTable)
                {
                    nameTable.Add(name);
                    index = nameTable.Count - 1;
                }
                return index + 1;
            }
        }
    }
}
