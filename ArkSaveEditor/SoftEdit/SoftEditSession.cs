using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArkSaveEditor.SoftEdit
{
    /// <summary>
    /// Soft Edit is used to make small modifications to existing Ark save files. 
    /// </summary>
    public class SoftEditSession
    {
        public IOMemoryStream originalFile;
        readonly DotArkFile underlyingFile;

        //Editable
        public List<string> nameTable;

        public SoftEditSession(IOMemoryStream ms)
        {
            //Load ARK save
            underlyingFile = new DotArkDeserializer().OpenArkFile(ms);

            //Copy name table to here
            nameTable = underlyingFile.meta.binaryNameTable.ToList();
        }

        //Basic API
        public int GetNameTableEntry(string name)
        {
            //Check if the name table already has this name.
            if (nameTable.Contains(name))
            {
                //Write index of this
                return nameTable.IndexOf(name) + 1;
            }
            else
            {
                //Add it and return an index.
                int index;
                lock (nameTable)
                {
                    nameTable.Add(name);
                    index = nameTable.Count - 1;
                }
                return index + 1;
            }
        }

        public MemoryStream Commit()
        {
            //First, we're going to rebuild the name table
            IOMemoryStream nameTableData = new IOMemoryStream(true);
            DotArkWriter.WriteStringArray(nameTableData, nameTable.ToArray());

            return null;
        }
    }
}
