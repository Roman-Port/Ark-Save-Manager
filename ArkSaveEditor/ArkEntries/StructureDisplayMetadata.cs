using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.ArkEntries
{
    public class StructureDisplayMetadata
    {
        public string[] names;
        public string img; //Top down view
        public string img_thumbnail; //45 degree view
        public StructureDisplayMetadata_DisplayType displayType;
        public float captureSize; //Ortho capture size, in game meters
        public int capturePixels; //The size, in pixels, of the source image
        public float rotationOffset; //Offset to apply to the rotation
        public StructureDisplayMetadata_StructureType type; //Type of structure
    }

    public enum StructureDisplayMetadata_DisplayType
    {
        Standard = 0, //Shows this at the level according to the Z-axis
        AlwaysTop = 1, //Always shows this on top of other structures

    }

    public enum StructureDisplayMetadata_StructureType
    {
        Foundation,
        Ceiling,
        Wall,
        Inventory,
        Tool
    }
}
