using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class StandardArkStructure
    {
        public static bool TryParseClassname(string name, out ArkStructureMaterial material)
        {
            //Split the classname by underscores.
            string[] split = name.Split('_');
            material = ArkStructureMaterial.Adobe;
            return true;
        }
    }

    public enum ArkStructureMaterial
    {
        Thatch,
        Wood,
        Adobe,
        Greenhouse,
        Stone,
        Metal,
        Tek
    }

    public enum ArkStructureType
    {
        Railing,
        Wall,
        WindowWalls, //Check
        Ceiling,
        SlopedCeiling, //CHeck
        Ramp,
        Door,
        ReinforcedDoor,

    }
}
