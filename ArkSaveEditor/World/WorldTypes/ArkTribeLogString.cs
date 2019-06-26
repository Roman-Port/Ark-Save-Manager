using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.World.WorldTypes
{
    public class ArkTribeLogString
    {
        public string dateData;
        public string timeData;
        public string content;

        public string raw;

        public float r;
        public float g;
        public float b;
        public float a;

        public static ArkTribeLogString ParseArkML(string s)
        {
            //First, split the day and the content
            string dateData = s.Substring(0, s.IndexOf(','));
            string timeData = s.Substring(dateData.Length + 2, 8);
            string content = s.Substring(dateData.Length + 2 + 8 + 2);

            //Check if this uses Ark ML. If it does, parse. This is a very, very, basic parser.
            float r = 1;
            float g = 1;
            float b = 1;
            float a = 1;
            if (content.StartsWith("<RichColor Color="))
            {
                //Substring to the color data
                string colorData = content.Substring("<RichColor Color=\"".Length);
                colorData = colorData.Substring(0, colorData.IndexOf('"'));

                //Substring the content to skip the ML
                content = content.Substring("<RichColor Color=\"".Length + colorData.Length + 2);

                //Trim off the end
                if (content.EndsWith("</>"))
                    content = content.Substring(0, content.Length - 3);

                //Now, it's time to parse the colors.
                colorData.Replace(" ", "");
                string[] splitColors = colorData.Split(',');
                if (splitColors.Length == 4 || splitColors.Length == 3)
                {
                    //Has an alpha channel
                    r = float.Parse(splitColors[0]);
                    g = float.Parse(splitColors[1]);
                    b = float.Parse(splitColors[2]);
                    if (splitColors.Length == 4)
                        a = float.Parse(splitColors[3]);
                    else
                        a = 1;
                }
                else
                {
                    throw new Exception("Too many or too few channels in Ark ML!");
                }
            }

            return new ArkTribeLogString
            {
                content = content,
                dateData = dateData,
                timeData = timeData,
                r = r,
                g = g,
                b = b,
                a = b,
                raw = s
            };
        }
    }
}
