using ArkSaveEditor.ArkEntries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArkSaveEditor
{
    public static class ArkImports
    {
        public static List<ArkDinoEntry> dino_entries;
        public static List<ArkItemEntry> item_entries;
        public static ArkWorldSettings world_settings;

        public static void ImportContent(string worldPath, string dinosPath, string itemsPath)
        {
            //Deserialize all of these assets.
            dino_entries = JsonConvert.DeserializeObject<List<ArkDinoEntry>>(File.ReadAllText(dinosPath));
            item_entries = JsonConvert.DeserializeObject<List<ArkItemEntry>>(File.ReadAllText(itemsPath));
            world_settings = JsonConvert.DeserializeObject<ArkWorldSettings>(File.ReadAllText(worldPath));
        }

        public static ArkDinoEntry GetDinoDataByClassname(string classname)
        {
            foreach (var d in dino_entries)
            {
                if (d.classname+"_C" == classname)
                    return d;
            }
            return null;
        }

        public static ArkItemEntry GetItemDataByClassname(string classname)
        {
            foreach(var d in item_entries)
            {
                if (d.classname == classname)
                    return d;

            }
            return null;
        }
    }
}
