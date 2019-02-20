using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineStructProperty : InlineProperty
    {
        public ArkClassName type;
        public DotArkStruct data;

        public InlineStructProperty(IOMemoryStream ms) : base(ms)
        {
            //Determine the type.
            type = ms.ReadInlineArkClassname();
            

            //First, we check known types for the struct property list. There could be other data, but it could fail.
            if (type.classname == "ItemNetID" || type.classname == "ItemNetInfo" || type.classname == "Transform" || type.classname == "PrimalPlayerDataStruct" || type.classname == "PrimalPlayerCharacterConfigStruct" || type.classname == "PrimalPersistentCharacterStatsStruct" || type.classname == "TribeData" || type.classname == "TribeGovernment" || type.classname == "TerrainInfo" || type.classname == "ArkInventoryData" || type.classname == "DinoOrderGroup" || type.classname == "ARKDinoData")
            {
                //Open this as a struct property list.
                data = new ArkStructInlineProps(ms);
            }
            else if (type.classname == "Vector" || type.classname == "Rotator")
            {
                //3d vector or rotor 
                data = new ArkStructVector3(ms, type);
            }
            else if (type.classname == "Vector2D")
            {
                //2d vector
                data = new ArkStructVector2(ms, type);
            }
            else if (type.classname == "Quat")
            {
                //Quat
                data = new ArkStructQuat(ms, type);
            }
            else if (type.classname == "Color")
            {
                //Color
                data = new ArkStructColor(ms, type);
            }
            else if (type.classname == "LinearColor")
            {
                //Linear color
                data = new ArkStructLinearColor(ms, type);
            }
            else if (type.classname == "UniqueNetIdRepl")
            {
                //Some net stuff
                data = new ArkStructUniqueNetId(ms, type);
            }
            else
            {
                //Interpet this as a struct property list. Maybe raise a warning later?
                throw new Exception("Unknown struct type.");
            }
        }

        public class ArkStructInlineProps : DotArkStruct
        {
            public List<InlineProperty> props;

            public ArkStructInlineProps(IOMemoryStream ms)
            {
                props = new List<InlineProperty>();
                InlineProperty p = InlineProperty.ReadProperty(ms);
                while (p != null)
                {
                    props.Add(p);
                    //Console.WriteLine($"STRUCT > {p.name.classname} ({p.type.classname})");
                    p = InlineProperty.ReadProperty(ms);
                }
            }
        }
    }
}
