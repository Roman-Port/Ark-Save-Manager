using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities
{
    /// <summary>
    /// Contains info about the actual Ark map, not the save file.
    /// </summary>
    public class ArkMapData
    {
        public string displayName; //The name displayed
        public bool isOfficial; //Is official map. Ragnorok is not considered official.
        public bool isTheCenter; //The Center uses a custom formula for calculating the transformations.

        public float latLonMultiplier; //To convert the Lat/Long map coordinates to UE coordinates, simply subtract 50 and multiply by the value
        public WorldBounds2D bounds; //Bounds of the map in UE coords
        public WorldTransformOffsets transformOffsets; //Used for adjusting the map for the flat world map. These, for the most part, are only estimates.
    }

    /// <summary>
    /// Transfroms applied to make the game data line up with the web world map. Applied when the center is at zero and the range is 0.5 to -0.5
    /// </summary>
    public class WorldTransformOffsets
    {
        public float offsetX;
        public float offsetY;

        public float sizeMult;

        public Vector2 Apply(Vector2 input)
        {
            Vector2 adjusted_map_pos = input.Clone();
            
            //Offset to make transformations easier
            adjusted_map_pos.Subtract(0.5f);

            //Run transformations
            adjusted_map_pos.Multiply(sizeMult);
            adjusted_map_pos.y += offsetY;
            adjusted_map_pos.x += offsetX;

            //Undo the ease of use transform conversions
            adjusted_map_pos.Add(0.5f);

            return adjusted_map_pos;
        }
    }
}
