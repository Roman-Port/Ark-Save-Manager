using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class StructureDisplayMetadata
    {
        public string[] names;
        public string img;
        public StructureDisplayMetadata_DisplayType displayType;
        public float pixelsPerMeter;
        public StructureDisplayMetadata_Priority priority;
        public StructureDisplayMetadata_Type type;
    }

    public enum StructureDisplayMetadata_DisplayType
    {
        Standard = 0
    }

    public enum StructureDisplayMetadata_Type
    {
        SquareCeiling = 0,
        TriCeiling = 1,
        SquareFoundation = 2,
        TriFoundation = 3,
        Ramp = 4,
        Wall = 5
    }

    public enum StructureDisplayMetadata_Priority
    {
        Ramp = 10,
        Ceiling = 9,

        Wall = 3,
        Foundation = 1
    }
}
