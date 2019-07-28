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
        public bool isOfficial; //Is official map that ships with the game
        public bool isStoryArk; //Is a story ark
        public string backgroundColor; //Background color around the map. Null if there is no one complete color, such as Extinction

        public float latLonMultiplier; //To convert the Lat/Long map coordinates to UE coordinates, simply subtract 50 and multiply by the value
        public WorldBounds2D bounds; //Bounds of the map in UE coords

        public Vector2 mapImageOffset; //Offset to move the Ark position by in order for it to fit in the center of the image.
        public int captureSize; //Size of the captured image, in game units

        public ArkMapDisplayData[] maps; //Maps we can display

        /// <summary>
        /// Converts from Ark position to normalized, between (-0.5, 0.5).
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Vector2 ConvertFromGamePositionToNormalized(Vector2 input)
        {
            Vector2 o = input.Clone();

            //Translate by the map image offset
            if (mapImageOffset != null)
            {
                o.x += mapImageOffset.x;
                o.y += mapImageOffset.y;
            }

            //Scale by the size of our image
            o.Divide(captureSize); 

            //Move
            o.Add(0.5f);

            return o;
        }
    }

    /// <summary>
    /// Contains data about maps we can show
    /// </summary>
    public class ArkMapDisplayData
    {
        public string url;
        public string name;
        public string description;
        public int maximumZoom;
    }
}
