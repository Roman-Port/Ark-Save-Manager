using ArkSaveEditor.Entities;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Serializer.DotArk
{
    public class SmallArkDataWriter
    {
        public static IOMemoryStream WriteBinaryDataNames(DotArkFile f, DotArkSerializerInstance si)
        {
            //Binary data names are showing map parts. Spec is here: https://us-central.assets-static-2.romanport.com/ark/#binary+data+names_header

            //Create stream
            IOMemoryStream ms = new IOMemoryStream(true);

            //Write into it
            DotArkWriter.WriteStringArray(ms, f.meta.binaryDataNames);
            return ms;
        }

        public static IOMemoryStream WriteNameTable(DotArkFile f, DotArkSerializerInstance si)
        {
            //name table for props. Spec is here: https://us-central.assets-static-2.romanport.com/ark/#binary+class+name+table_header

            //Create stream
            IOMemoryStream ms = new IOMemoryStream(true);

            //Write into it
            DotArkWriter.WriteStringArray(ms, si.nameTable.ToArray());
            return ms;
        }

        public static IOMemoryStream WriteArkUnknownFlags(DotArkFile f, DotArkSerializerInstance si)
        {
            //Create stream and get the data
            IOMemoryStream ms = new IOMemoryStream(true);
            var d = f.meta.mysteryFlagData;

            //Write array
            ms.WriteInt(d.Length);

            for(int i = 0; i<d.Length; i++)
            {
                var ds = d[i];
                ms.WriteInt(ds.flags);
                ms.WriteInt(ds.objectCount);
                ms.WriteUEString(ds.nameString);
            }

            //Respond with stream
            return ms;
        }

        public static IOMemoryStream WriteEmbeddedBinaryDataArray(DotArkFile f, DotArkSerializerInstance si)
        {
            //I'm really not sure what this is. Spec: https://us-central.assets-static-2.romanport.com/ark/#embeded+binary+data_header

            //Open straem
            IOMemoryStream ms = new IOMemoryStream(true);

            //Get source data
            var s = f.meta.embededBinaryData;

            //Write number of blobs
            ms.WriteInt(s.Length);

            //Write each
            for(int i = 0; i<s.Length; i++)
            {
                var ss = s[i];

                //Write path
                ms.WriteUEString(ss.path);

                //Write number of parts
                ms.WriteInt(ss.data.Length);

                //Write parts
                for(int j = 0; j<ss.data.Length; j++)
                {
                    var ssb = ss.data[j];

                    //Write number of inner blobs
                    ms.WriteInt(ssb.Length);

                    //Write each inner blob
                    for(int n = 0; n<ssb.Length; n++)
                    {
                        var ssbb = ssb[i];
                        ms.WriteInt(ssbb.Length / 4);
                        ms.WriteBytes(ssbb);
                    }
                }
            }

            //Return stream
            return ms;
        }
    }
}
