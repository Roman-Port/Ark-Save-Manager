using ArkSaveEditor.Deserializer.DotArk;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel.DotArk
{
    public class DotArkLocationData
    {
        public float x;
        public float y;
        public float z;
        public float pitch;
        public float yaw;
        public float roll;

        public static DotArkLocationData ReadLocationData(DotArkDeserializer da)
        {
            var stream = da.ms;
            DotArkLocationData l = new DotArkLocationData();
            l.x = stream.ReadFloat();
            l.y = stream.ReadFloat();
            l.z = stream.ReadFloat();

            l.pitch = stream.ReadFloat();
            l.yaw = stream.ReadFloat();
            l.roll = stream.ReadFloat();

            return l;
        }

        public void WriteLocationData(IOMemoryStream ms)
        {
            ms.WriteFloat(x);
            ms.WriteFloat(y);
            ms.WriteFloat(z);

            ms.WriteFloat(pitch);
            ms.WriteFloat(yaw);
            ms.WriteFloat(roll);
        }

        public DotArkLocationData()
        {

        }

        public DotArkLocationData(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string ToString
        {
            get
            {
                return $"X:{x} Y:{y} Z:{z} Pitch:{pitch} Yaw:{yaw} Roll:{roll}";
            }
        }
    }
}
