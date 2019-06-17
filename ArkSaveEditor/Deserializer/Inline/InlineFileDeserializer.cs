using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.Inline;
using ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArkSaveEditor.Deserializer.Inline
{
    public class InlineFileDeserializer
    {
        public InlineFile ReadInlineFile(string path)
        {
            InlineFile f;
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    fs.CopyTo(ms);
                }
                ms.Position = 0;
                f = ReadInlineFile(ms);
            }
            return f;
        }

        public InlineFile ReadInlineFile(MemoryStream mms)
        {
            //Open IO ms
            IOMemoryStream ms = new IOMemoryStream(mms, true);

            //Skip the unknown header of 24 bytes
            ms.position = 24;

            //Read in the additional header
            ms.ReadUEString(); //PrimalPlayerDataBP_C
            ms.ReadInt();
            ms.ReadInt();
            ms.ReadUEString(); //PrimalPlayerDataBP_C_5
            ms.ReadUEString(); //ArkGameMode
            ms.ReadUEString(); //PersistentLevel
            ms.ReadUEString(); //Extinction (or map name)
            ms.ReadUEString(); //(Game map path)
            ms.ReadInt();
            ms.ReadInt();
            ms.ReadInt();
            ms.ReadInt();
            ms.ReadInt();

            //Start reading props
            List<InlineProperty> props = new List<InlineProperty>();
            InlineProperty p = InlineProperty.ReadProperty(ms);
            while (p != null)
            {
                props.Add(p);
                p = InlineProperty.ReadProperty(ms);
            }

            return new InlineFile
            {
                props = props
            };
        }
    }
}
