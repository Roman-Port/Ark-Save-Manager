using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using ArkSaveEditor.World;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ArkSaveEditor.World.WorldTypes;

namespace ArkHttpServer.Entities
{
    /// <summary>
    /// A basic world that won't take up too much bandwidth to send over http.
    /// </summary>
    public class BasicArkWorld
    {
        public float gameTime;
        public BasicArkDino[] dinos;

        public BasicArkWorld(ArkWorld world, string tribeName)
        {
            gameTime = world.gameTime;
            //Narrow down our search by tribe name, if needed.
            ArkDinosaur[] searchDinos = world.dinos.Where(x => x.isTamed == true && x.tamerName == tribeName).ToArray();
            dinos = new BasicArkDino[searchDinos.Length];
            for (int i = 0; i < dinos.Length; i++)
                dinos[i] = new BasicArkDino(searchDinos[i]);
        }
    }

    public class BasicArkDino
    {
        public float x;
        public float y;
        public float z;
        public float pitch;
        public float yaw;
        public float roll;

        public int[] colors;
        public string classname;
        public string imgUrl;
        public string apiUrl;
        public ulong id;
        public bool isFemale;
        public string tamedName;
        public string tamerName;
        public bool isTamed;

        public BasicArkDino(ArkDinosaur dino)
        {
            //Convert this dino to this.
            x = dino.location.x;
            y = dino.location.y;
            z = dino.location.z;
            pitch = dino.location.pitch;
            yaw = dino.location.yaw;
            roll = dino.location.roll;

            classname = dino.classnameString;
            imgUrl = $"classimgs/map/{classname}.png";
            id = dino.dinosaurId;
            apiUrl = "/dino/" + id;
            isFemale = dino.isFemale;
            tamedName = dino.tamedName;
            tamerName = dino.tamerName;
            isTamed = dino.isTamed;
            //Convert the colors to an integer so it is serialized correctly.
            colors = new int[dino.colors.Length];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = dino.colors[i];
        }
    }
}
