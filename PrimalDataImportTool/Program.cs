using System;
using System.IO;
using ArkSaveEditor.Entities;

namespace PrimalDataImportTool
{
    /// <summary>
    /// A tool for importing Ark game data, like class lists.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            OpenStructurePlacerBlueprintFile();

            Console.ReadLine();
        }

        static IOMemoryStream OpenMemoryStreamFromFile(string path)
        {
            //First, read in the file and put it in a memory stream.
            MemoryStream ms = new MemoryStream();
            using (FileStream fs = new FileStream(path, FileMode.Open))
                fs.CopyTo(ms);
            ms.Position = 0;
            //Open IOMemoryStream
            return new IOMemoryStream(ms, true);
        }

        static void OpenStructurePlacerBlueprintFile(string path = @"C:\Program Files (x86)\Steam\steamapps\common\ARK\ShooterGame\Content\PrimalEarth\Structures\StructurePlacerBlueprint.uasset")
        {
            //Open a Stream on this file and open an IO memory stream.
            IOMemoryStream ms = OpenMemoryStreamFromFile(path);
            //Skip to strings offset.
            ms.position = 171;
            //Begin reading strings until we fail.
            try
            {
                while (true)
                {
                    Console.WriteLine(ms.ReadUEString(256));
                }
            } catch
            {

            }
        }
    }
}
