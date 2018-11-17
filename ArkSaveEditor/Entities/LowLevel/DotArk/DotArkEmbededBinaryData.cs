using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkEmbededBinaryData
    {
        public string path;
        public byte[][][] data;

        public DotArkEmbededBinaryData(IOMemoryStream ms)
        {
            //First, read the path.
            path = ms.ReadUEString();
            //Now, read the parts. This seems to be split up into part -> blob -> inner blob
            int parts = ms.ReadInt();
            data = new byte[parts][][];
            //Loop through each of the parts 
            for (int i = 0; i < parts; i++)
            {
                int blobs = ms.ReadInt();
                byte[][] partData = new byte[blobs][];

                for (int j = 0; j < blobs; j++)
                {
                    int blobSize = ms.ReadInt() * 4; //Array of 32 bit integers.
                    partData[j] = ms.ReadBytes(blobSize);
                }

                data[i] = partData;
            }
        }
    }
}
