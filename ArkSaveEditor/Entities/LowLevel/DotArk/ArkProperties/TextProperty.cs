using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class TextProperty : DotArkProperty
    {
        public TextProperty(DotArkDeserializer d, int index, int length)
        {
            var ms = d.ms;
            dataFilePosition = ms.position;
            this.data = Convert.ToBase64String(ms.ReadBytes(length));
        }

        public override void WriteProp(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            base.WriteProp(s, go, f, ms);

            //Convert from Base64 string
            byte[] buf = Convert.FromBase64String((string)data);

            //If this does not match the length, die
            if (size != buf.Length)
                throw new Exception("The size of the TextProperty did not match the real size, in bytes.");

            //Write
            ms.ms.Write(buf, 0, size);
        }
    }
}
