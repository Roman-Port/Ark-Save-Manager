using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.Inline;
using ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties;
using ArkSaveEditor.World.WorldTypes.ArkTribeLogEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkTribeProfile
    {
        public int tribeId;
        public string tribeName;
        public uint tribeOwnerId;

        public InlineStructProperty.ArkStructInlineProps tribeDataStruct;

        public InlineFile source;
        public ArkWorld linkedWorld;

        public ArkTribeProfile(string pathname, ArkWorld world)
        {
            //Set values
            linkedWorld = world;

            //Open inline file
            var indes = new Deserializer.Inline.InlineFileDeserializer();
            source = indes.ReadInlineFile(pathname);

            //Grab tribe data struct.
            var tribeData = (InlineStructProperty)source.props[0];
            tribeDataStruct = (InlineStructProperty.ArkStructInlineProps)tribeData.data;

            //Grab data
            InlineProperty temp;
            temp = GetPropertyByName("TribeName");
            if (temp != null)
                tribeName = ((InlineStrProperty)temp).value;
            temp = GetPropertyByName("OwnerPlayerDataID");
            if (temp != null)
                tribeOwnerId = ((InlineUInt32Property)temp).value;
            temp = GetPropertyByName("TribeID");
            if (temp != null)
                tribeId = ((InlineIntProperty)temp).value;
        }

        private InlineProperty GetPropertyByName(string name)
        {
            var data = tribeDataStruct.props.Where(x => x.name.CompareNameTo(name)).ToArray();
            if (data.Length == 1)
                return data[0];
            return null;
        }

        public List<ArkTribeLogEntry> GetTribeLog()
        {
            //Open tribe log data.
            InlineProperty tribeLogData = GetPropertyByName("TribeLog");
            if (tribeLogData == null)
                return new List<ArkTribeLogEntry>();
            InlineArrayProperty arr = (InlineArrayProperty)tribeLogData;
            List<ArkTribeLogEntry> output = new List<ArkTribeLogEntry>();
            foreach (string s in arr.data)
            {
                ArkTribeLogString str = ArkTribeLogString.ParseArkML(s);
                ArkTribeLogEntry entry = ArkTribeLogEntry.ParseEntry(str, linkedWorld.players, linkedWorld.dinos, tribeId);
                if (entry != null)
                {
                    output.Add(entry);
                }
            }

            //Reverse this because Ark saves it backwards
            output.Reverse();
            return output;
        }
    }
}
