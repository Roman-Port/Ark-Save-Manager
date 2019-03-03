using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties
{
    public class ArkStructUniqueNetId : DotArkStruct
    {
        public int unk;
        public string netId;

        public ArkStructUniqueNetId(IOMemoryStream ms, ArkClassName structType)
        {
            unk = ms.ReadInt();
            netId = ms.ReadUEString();
        }

        public override void WriteStruct(DotArkSerializerInstance s, DotArkGameObject go, DotArkFile f, IOMemoryStream ms)
        {
            ms.WriteInt(unk);
            ms.WriteUEString(netId);
        }
    }
}
