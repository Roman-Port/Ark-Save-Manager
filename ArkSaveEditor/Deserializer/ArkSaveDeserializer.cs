using ArkSaveEditor.Entities.LowLevel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArkSaveEditor.Deserializer
{
    /// <summary>
    /// This is the main class for deserializing the Ark save enviornment
    /// </summary>
    public static class ArkSaveDeserializer
    {
        public static DotArkFile OpenDotArk()
        {
            //First, read in the Ark file
            DotArk.DotArkDeserializer dotArkDs;
            using (MemoryStream ms = new MemoryStream())
            {
                //Copy from disk
                using (FileStream fs = new FileStream(@"C:\Program Files (x86)\Steam\steamapps\common\ARK\ShooterGame\Saved\SavedArks\Extinction.ark", FileMode.Open))
                    fs.CopyTo(ms);
                //Rewind
                ms.Position = 0;
                //Create
                dotArkDs = new DotArk.DotArkDeserializer();
                dotArkDs.OpenArkFile(ms);
            }
            return dotArkDs.ark;
        }
    }
}
