using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructProps : DotArkStruct
    {
        public Dictionary<ArkClassName, DotArkProperty> props;
        public Dictionary<string, DotArkProperty> props_string;

        public ArkStructProps(DotArkDeserializer d, ArkClassName structType)
        {
            var ms = d.ms;
            //This file has more custom data.
            //Create the dictoanry where we will store data.
            props = new Dictionary<ArkClassName, DotArkProperty>();
            props_string = new Dictionary<string, DotArkProperty>();
            //Read through all of the properties in a similar matter to the standard way.
            DotArkProperty prop = DotArkProperty.ReadPropertyFromDisk(d);
            while (prop != null)
            {
                //Add this to the properties.
                props.Add(prop.name, prop);
                if(!props_string.ContainsKey(prop.name.classname))
                    props_string.Add(prop.name.classname, prop);
                //Continue and read next property.
                prop = DotArkProperty.ReadPropertyFromDisk(d);
            }
        }
    }
}
