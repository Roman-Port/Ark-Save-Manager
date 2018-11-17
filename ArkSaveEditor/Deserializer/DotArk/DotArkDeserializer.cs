using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArkSaveEditor.Deserializer.DotArk
{
    /// <summary>
    /// Opens .Ark file
    /// </summary>
    public class DotArkDeserializer
    {
        public IOMemoryStream ms;
        public DotArkFile ark;

        public short saveVersion;
        public int nameTableOffset;
        public int propertiesBlockOffset;
        public int binaryDataTableOffset;

        public long gameObjectBlockStartOffset;

        public int unknownData1; //Unknown data in version 7+ header
        public int unknownData2; //Unknown data in version 9 header

        public string[] binaryDataNames; //Map parts, such as "Extinction", "C1_Far", "C2_Far"
        public DotArkEmbededBinaryData[] embededBinaryData;
        public string[] binaryNameTable;
        public DotArkIntroMysteryFlags[] mysteryFlagData;
        public List<DotArkGameObject> gameObjects;

        public DotArkFile OpenArkFile(MemoryStream mms)
        {
            //Convert this to our IO Memory Stream
            ms = new IOMemoryStream(mms, true);
            //Initialize our variables
            ark = new DotArkFile();
            //Open the header data.
            ReadHeader();
            //Read in the binary data names, such as "Extinction", "C1_Far", "C2_Far"
            binaryDataNames = ReadStringArray();
            //Read the embeded binary data.
            ReadArkEmbededBinaryData();
            //Finally, read the mystery flags
            ReadMysteryFlags();
            //Save our position and read the class name block.
            gameObjectBlockStartOffset = ms.ms.Position; //Save location
            ms.ms.Position = nameTableOffset; //Jump to the table
            binaryNameTable = ReadStringArray(); //Read in the data
            ms.ms.Position = gameObjectBlockStartOffset; //Jump back to continue reading the file.
            //Read the GameObject table. 
            ReadGameObjectTable();
            //Get the property data
            ReadPropertiesForGameObjects();
            //Finish by setting values
            ark.gameObjects = gameObjects;
            ark.meta = this;

            return ark;
        }

        void ReadPropertiesForGameObjects()
        {
            //Loop through each GameObject and read their information.
            foreach (var g in gameObjects)
                g.ReadPropsFromFile(this);
        }

        void ReadMysteryFlags()
        {
            //Read length
            int length = ms.ReadInt();
            //Initialize the array
            mysteryFlagData = new DotArkIntroMysteryFlags[length];
            //Read in
            for (int i = 0; i < length; i++)
                mysteryFlagData[i] = DotArkIntroMysteryFlags.ReadFromFile(this);
        }

        void ReadGameObjectTable()
        {
            int gameObjectCount = ms.ReadInt();
            gameObjects = new List<DotArkGameObject>();
            for (int i = 0; i < gameObjectCount; i++)
                gameObjects.Add(DotArkGameObject.ReadBaseFromFile(this));
        }

        string[] ReadStringArray()
        {
            //Read a standard array. First, read the Int32 of the length
            int length = ms.ReadInt();
            //Create an array and read in strings
            string[] array = new string[length];
            for(int i = 0; i < length; i++)
            {
                array[i] = ms.ReadUEString();
            }
            return array;
        }

        void ReadArkEmbededBinaryData()
        {
            //This is the Ark embeded binary data. I don't know what this is.
            int arraySize = ms.ReadInt();
            //Read the embeded binary data
            DotArkEmbededBinaryData[] data = new DotArkEmbededBinaryData[arraySize];
            for(int i = 0; i<arraySize; i++)
            {
                data[i] = new DotArkEmbededBinaryData(ms);
            }
            embededBinaryData = data;
        }

        void ReadHeader()
        {
            saveVersion = ms.ReadShort(); //Game version. Important for later.
            //Depending on the version, read this in
            switch(saveVersion)
            {
                case 5:
                    ark.gameTime = ms.ReadFloat();
                    break;
                case 6:
                    nameTableOffset = ms.ReadInt();
                    propertiesBlockOffset = ms.ReadInt();
                    ark.gameTime = ms.ReadFloat();
                    break;
                case 7:
                case 8:
                    binaryDataTableOffset = ms.ReadInt();
                    unknownData1 = ms.ReadInt();
                    nameTableOffset = ms.ReadInt();
                    propertiesBlockOffset = ms.ReadInt();
                    ark.gameTime = ms.ReadFloat();
                    break;
                case 9:
                    binaryDataTableOffset = ms.ReadInt();
                    unknownData1 = ms.ReadInt();
                    nameTableOffset = ms.ReadInt();
                    propertiesBlockOffset = ms.ReadInt();
                    ark.gameTime = ms.ReadFloat();
                    unknownData2 = ms.ReadInt();
                    break;
                default:
                    throw new Exception($"Unknown game version {saveVersion.ToString()}, expected 5-9.");
            }
        }
    }
}
