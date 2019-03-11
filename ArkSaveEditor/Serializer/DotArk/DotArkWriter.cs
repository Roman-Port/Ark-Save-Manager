using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    public static class DotArkWriter
    {
        const long HEADER_SIZE_BYTES = 26;

        public static void WriteDotArk(IOMemoryStream ms, DotArkFile f)
        {
            //Create instance
            DotArkSerializerInstance inst = new DotArkSerializerInstance();

            //Write the game object bodies into their own temporary stream for later
            IOMemoryStream gameObjectBodyStream = new IOMemoryStream(true);
            long[] gameObjectPropertyOffsets = GameObjectBodyWriter.WriteGameObjectBodies(gameObjectBodyStream, f, inst);

            //Now, write the GameObject heads into their own temporary stream for later.
            IOMemoryStream gameObjectHeadStream = new IOMemoryStream(true);
            GameObjectHeadWriter.WriteGameObjectHeads(gameObjectHeadStream, f, inst, gameObjectPropertyOffsets);

            //Create the binary data names, the map parts.
            IOMemoryStream binaryDataNames = SmallArkDataWriter.WriteBinaryDataNames(f, inst);

            //Create the embedded binary data
            IOMemoryStream embeddedBinaryData = SmallArkDataWriter.WriteEmbeddedBinaryDataArray(f, inst);

            //Create flag data
            IOMemoryStream unknownFlagData = SmallArkDataWriter.WriteArkUnknownFlags(f, inst);

            //Finally, generate the name table. THIS STEP MUST COME LAST!
            IOMemoryStream nameTable = SmallArkDataWriter.WriteNameTable(f, inst);

            //Build the file
            BuildArkFile(nameTable, binaryDataNames, embeddedBinaryData, unknownFlagData, gameObjectHeadStream, gameObjectBodyStream, f.meta.unknownData1, f.gameTime, f.meta.saveCount).CopyFromBeginningTo(ms);
        }

        public static IOMemoryStream BuildArkFile(IOMemoryStream nameTable, IOMemoryStream binaryDataNames, IOMemoryStream embeddedBinaryData, IOMemoryStream unknownFlagData, IOMemoryStream gameObjectHeadStream, IOMemoryStream gameObjectBodyStream, int headerUnknownData1, float headerGameTime, int headerSaveCount)
        {
            //Create MemoryStream
            IOMemoryStream ms = new IOMemoryStream(true);
            
            //Now that we have all of that data generated, we need to get offsets.
            long binaryDataNameOffset = HEADER_SIZE_BYTES; //Offset to map names
            long embeddedBinaryDataOffset = binaryDataNameOffset + binaryDataNames.length; //Offset to embedded binary data
            long unknownFlagsOffset = embeddedBinaryDataOffset + embeddedBinaryData.length; //Offset to the unknown flags
            long gameObjectHeadOffset = unknownFlagsOffset + unknownFlagData.length; //Offset to the game object heads
            long binaryNameTableOffset = gameObjectHeadOffset + gameObjectHeadStream.length; //Offset to name table
            long gameObjectPropertiesOffset = binaryNameTableOffset + nameTable.length; //Offset to the game object props

            //Now that we have all of our data, it's time to actually put it into the file. We're going to start generating the header
            //Use version 9, the latest
            ms.WriteShort(9); //0
            ms.WriteInt((int)binaryDataNameOffset); // 2
            ms.WriteInt(headerUnknownData1); //Unknown header data. Appears to be 0 commonly. Index 6
            ms.WriteInt((int)binaryNameTableOffset); //10
            ms.WriteInt((int)gameObjectPropertiesOffset); //14
            ms.WriteFloat(headerGameTime); //18
            ms.WriteInt(headerSaveCount); //22

            //Now, it's time to copy all of the data into the file.
            binaryDataNames.CopyFromBeginningTo(ms);
            embeddedBinaryData.CopyFromBeginningTo(ms);
            unknownFlagData.CopyFromBeginningTo(ms);
            gameObjectHeadStream.CopyFromBeginningTo(ms);
            nameTable.CopyFromBeginningTo(ms);
            gameObjectBodyStream.CopyFromBeginningTo(ms);

            return ms;
        }

        public static void WriteStringArray(IOMemoryStream ms, string[] s)
        {
            //Write the length first
            ms.WriteInt(s.Length);

            //Write each string
            for (int i = 0; i < s.Length; i++)
                ms.WriteUEString(s[i]);
        }
    }
}
