using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkIntroMysteryFlags
    {
        public int flags;
        public int objectCount;
        public string nameString;

        public static DotArkIntroMysteryFlags ReadFromFile(DotArkDeserializer ds)
        {
            DotArkIntroMysteryFlags mf = new DotArkIntroMysteryFlags();
            mf.flags = ds.ms.ReadInt();
            mf.objectCount = ds.ms.ReadInt();
            mf.nameString = ds.ms.ReadUEString();
            return mf;
        }
    }
}
