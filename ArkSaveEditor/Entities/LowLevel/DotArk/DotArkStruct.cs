using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkStruct
    {
        public static DotArkStruct ReadFromFile(DotArkDeserializer d, ArkClassName structType)
        {
            //Based on the type, open it.
            string typeName = structType.classname;

            DotArkStruct st;
            //First, we check known types for the struct property list. There could be other data, but it could fail.
            if (typeName == "ItemNetID" || typeName == "ItemNetInfo" || typeName == "Transform" || typeName == "PrimalPlayerDataStruct" || typeName == "PrimalPlayerCharacterConfigStruct" || typeName == "PrimalPersistentCharacterStatsStruct" || typeName == "TribeData" || typeName == "TribeGovernment" || typeName == "TerrainInfo" || typeName == "ArkInventoryData" || typeName == "DinoOrderGroup" || typeName == "ARKDinoData")
            {
                //Open this as a struct property list.
                st = new ArkStructProps(d, structType);
            } else if (typeName == "Vector" || typeName == "Rotator")
            {
                //3d vector or rotor 
                st = new ArkStructVector3(d, structType);
            } else if (typeName == "Vector2D")
            {
                //2d vector
                st = new ArkStructVector2(d, structType);
            } else if (typeName == "Quat")
            {
                //Quat
                st = new ArkStructQuat(d, structType);
            } else if (typeName == "Color")
            {
                //Color
                st = new ArkStructColor(d, structType);
            } else if (typeName == "LinearColor")
            {
                //Linear color
                st = new ArkStructLinearColor(d, structType);
            } else if (typeName == "UniqueNetIdRepl")
            {
                //Some net stuff
                st = new ArkStructUniqueNetId(d, structType);
            } else
            {
                //Interpet this as a struct property list. Maybe raise a warning later?
                throw new Exception("temp");
            }

            return st;
        }
    }
}
