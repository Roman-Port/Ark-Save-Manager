using ArkSaveEditor.ArkEntries;
using ArkSaveEditor.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace ArkSaveEditor
{
    public delegate bool VerifyPackageMetadata(PrimalDataPackageMetadata metadata);

    public static class ArkImports
    {
        public static List<ArkDinoEntry> dino_entries;
        public static List<ArkItemEntry> item_entries;
        public static ArkWorldSettings world_settings;
        public static ImportedClassHierarchyFile classHierachy;
        public static List<StructureDisplayMetadata> structureDisplayMetadata;

        public static PrimalDataPackageMetadata packageMetadata;

        public static void ImportContent(string path)
        {
            //Deserialize all of these assets.
            packageMetadata = JsonConvert.DeserializeObject<PrimalDataPackageMetadata>(File.ReadAllText(path + "metadata.json"));
            dino_entries = JsonConvert.DeserializeObject<List<ArkDinoEntry>>(File.ReadAllText(path + "dinos.json"));
            item_entries = JsonConvert.DeserializeObject<List<ArkItemEntry>>(File.ReadAllText(path + "items.json"));
            world_settings = JsonConvert.DeserializeObject<ArkWorldSettings>(File.ReadAllText(path + "world_settings.json"));
            classHierachy = JsonConvert.DeserializeObject<ImportedClassHierarchyFile>(File.ReadAllText(path + "classes.json"));
            structureDisplayMetadata = JsonConvert.DeserializeObject<List<StructureDisplayMetadata>>(File.ReadAllText(path + "structure_metadata.json"));
        }

        public static bool ImportContentFromPackage(Stream package, VerifyPackageMetadata verify = null)
        {
            //Open package as ZIP
            using(ZipArchive zip = new ZipArchive(package, ZipArchiveMode.Read, true))
            {
                //Read package metadata first
                PrimalDataPackageMetadata metadata = PackageReaderHelper<PrimalDataPackageMetadata>(zip, "metadata.json");

                //If requested, verify that we can read this
                if (verify != null)
                {
                    if (!verify(metadata))
                        return false;
                }

                //Now, read other parts
                packageMetadata = metadata;
                dino_entries = PackageReaderHelper<List<ArkDinoEntry>>(zip, "dinos.json");
                item_entries = PackageReaderHelper<List<ArkItemEntry>>(zip, "items.json");
                world_settings = PackageReaderHelper<ArkWorldSettings>(zip, "world_settings.json");
                classHierachy = PackageReaderHelper<ImportedClassHierarchyFile>(zip, "classes.json");
                structureDisplayMetadata = PackageReaderHelper<List<StructureDisplayMetadata>>(zip, "structure_metadata.json");
            }

            return true;
        }

        private static T PackageReaderHelper<T>(ZipArchive zip, string name)
        {
            //Get the entry
            var entry = zip.GetEntry(name);
            if (entry == null)
                throw new Exception($"Primal Data content package is corrupt! Missing '{name}'.");

            //Open stream
            string raw;
            using (Stream s = entry.Open()) {
                byte[] buf = new byte[entry.Length];
                s.Read(buf, 0, buf.Length);
                raw = Encoding.UTF8.GetString(buf);
            }

            //Read as JSON
            T output;
            try
            {
                output = JsonConvert.DeserializeObject<T>(raw);
            } catch
            {
                throw new Exception($"Primal Data content package is corrupt! Failed to decode '{name}'.");
            }
            return output;
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
