using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities
{
    public class WorldBounds2D
    {
        public int minX;
        public int minY;

        public int maxX;
        public int maxY;

        public int width
        {
            get
            {
                return maxX - minX;
            }
        }

        public int height
        {
            get
            {
                return maxY - minY;
            }
        }
    }
}
