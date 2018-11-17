using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkSaveEditor.Entities.LowLevel
{
    public class DotArkFile
    {
        public float gameTime;

        public List<DotArkGameObject> gameObjects;

        [JsonIgnoreAttribute]
        public DotArkDeserializer meta;
    }
}
