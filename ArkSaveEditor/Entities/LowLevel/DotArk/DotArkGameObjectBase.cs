using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkGameObject
    {
        public Guid guid;
        public ArkClassName classname;
        public bool isItem;
        public List<ArkClassName> names;
        private bool unknownData1;
        private int unknownData2;
        public DotArkLocationData locationData; //Could be null
        private int propDataOffset;
        private int unknownData3;

        // Prop data
        //public Dictionary<string, DotArkProperty> props;
        public List<DotArkProperty> props;

        public static DotArkGameObject ReadBaseFromFile(DotArkDeserializer ds)
        {
            //Read from the initial ArkGameObject table.
            DotArkGameObject go = new DotArkGameObject();
            var ms = ds.ms;

            go.guid = new Guid(ms.ReadBytes(16));
            go.classname = ms.ReadArkClassname(ds);
            go.isItem = ms.ReadBool();
            //Read the name array. Start by reading the integer length.
            int nameArrayLength = ms.ReadInt();
            go.names = new List<ArkClassName>();
            for (int i = 0; i < nameArrayLength; i++)
                go.names.Add(ms.ReadArkClassname(ds));
            //Read some unknown data
            go.unknownData1 = ms.ReadBool();
            go.unknownData2 = ms.ReadInt();
            //Read location data boolean
            bool locationDataExists = ms.ReadBool();
            if (locationDataExists)
                go.locationData = ms.ReadLocationData(ds);
            //Read the offset to the property data
            go.propDataOffset = ms.ReadInt();
            //Read some last unknown data
            go.unknownData3 = ms.ReadInt();

            return go;
        }

        public void ReadPropsFromFile(DotArkDeserializer ds)
        {
            //First, let's jump to the location of this data.
            long position = (long)propDataOffset + (long)ds.propertiesBlockOffset; //Add the offset we got to the properties block offset
            var ms = ds.ms;
            ms.ms.Position = position;
            //Now, keep reading properties until we run out. For some reason, Wildcard didn't include a count.
            DotArkProperty prop = DotArkProperty.ReadPropertyFromDisk(ds);
            props = new List<DotArkProperty>();
            while(prop != null)
            {
                //Add this to the properties.
                props.Add(prop);
                //Continue and read next property.
                prop = DotArkProperty.ReadPropertyFromDisk(ds);
            }
        }
    }
}
