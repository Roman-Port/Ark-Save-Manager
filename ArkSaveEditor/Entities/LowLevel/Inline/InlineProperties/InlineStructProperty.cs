using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties
{
    public class InlineStructProperty : InlineProperty
    {
        public ArkClassName structType;
        public DotArkStruct data;

        public InlineStructProperty(IOMemoryStream ms) : base(ms)
        {
            //Determine the type.
            structType = ms.ReadInlineArkClassname();
            

            //First, we check known types for the struct property list. There could be other data, but it could fail.
            if (structType.classname == "ItemNetID" || structType.classname == "ItemNetInfo" || structType.classname == "Transform" || structType.classname == "PrimalPlayerDataStruct" || structType.classname == "PrimalPlayerCharacterConfigStruct" || structType.classname == "PrimalPersistentCharacterStatsStruct" || structType.classname == "TribeData" || structType.classname == "TribeGovernment" || structType.classname == "TerrainInfo" || structType.classname == "ArkInventoryData" || structType.classname == "DinoOrderGroup" || structType.classname == "ARKDinoData")
            {
                //Open this as a struct property list.
                data = new ArkStructInlineProps(ms);
            }
            else if (structType.classname == "Vector" || structType.classname == "Rotator")
            {
                //3d vector or rotor 
                data = new ArkStructVector3(ms, structType);
            }
            else if (structType.classname == "Vector2D")
            {
                //2d vector
                data = new ArkStructVector2(ms, structType);
            }
            else if (structType.classname == "Quat")
            {
                //Quat
                data = new ArkStructQuat(ms, structType);
            }
            else if (structType.classname == "Color")
            {
                //Color
                data = new ArkStructColor(ms, structType);
            }
            else if (structType.classname == "LinearColor")
            {
                //Linear color
                data = new ArkStructLinearColor(ms, structType);
            }
            else if (structType.classname == "UniqueNetIdRepl")
            {
                //Some net stuff
                data = new ArkStructUniqueNetId(ms, structType);
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
