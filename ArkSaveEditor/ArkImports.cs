using ArkSaveEditor.ArkEntries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArkSaveEditor
{
    public static class ArkImports
    {
        public static List<ArkDinoEntry> dino_entries;
        public static List<ArkItemEntry> item_entries;
        public static ArkWorldSettings world_settings;
        public static ImportedClassHierarchyFile classHierachy;
        public static List<StructureDisplayMetadata> structureDisplayMetadata;

        public static void ImportContent(string path)
        {
            //Deserialize all of these assets.
            dino_entries = JsonConvert.DeserializeObject<List<ArkDinoEntry>>(File.ReadAllText(path + "dinos.json"));
            item_entries = JsonConvert.DeserializeObject<List<ArkItemEntry>>(File.ReadAllText(path + "items.json"));
            world_settings = JsonConvert.DeserializeObject<ArkWorldSettings>(File.ReadAllText(path + "world.json"));
            classHierachy = JsonConvert.DeserializeObject<ImportedClassHierarchyFile>(File.ReadAllText(path + "classes.json"));
            structureDisplayMetadata = JsonConvert.DeserializeObject<List<StructureDisplayMetadata>>(File.ReadAllText(path + "structureMetadata.json"));
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

        public static StructureDisplayMetadata GetStructureDisplayMetadataByClassname(string classname)
        {
            if (classname.EndsWith("_C"))
                classname = classname.Substring(0, classname.Length - 2);
            var results = structureDisplayMetadata.Where(x => x.names.Contains(classname));
            if (results.Count() >= 1)
                return results.First();
            return null;
        }
    }
}
