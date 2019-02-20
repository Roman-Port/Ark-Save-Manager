using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ArkSaveEditor.Entities.LowLevel.Inline.InlineProperties.InlineStructProperty;

namespace ArkSaveEditor.World.WorldTypes
{
    /// <summary>
    /// Player profile from .arkprofile files.
    /// </summary>
    public class ArkPlayerProfile
    {
        public string playerName;
        public UInt64 arkPlayerId;
        public string steamPlayerId;
        public int tribeId;
        public double loginTime;
        public double lastLoginTime;

        public static ArkPlayerProfile ReadFromFile(string filePath)
        {
            //Load the file and deserialize it.
            var deserializer = new ArkSaveEditor.Deserializer.Inline.InlineFileDeserializer();
            var file = deserializer.ReadInlineFile(filePath);

            //Grab the player struct
            InlineStructProperty playerDataStruct = (InlineStructProperty)file.props.Find(x => x.name.CompareNameTo("MyData"));
            ArkStructInlineProps playerData = (ArkStructInlineProps)playerDataStruct.data;

            //Start reading data
            ArkPlayerProfile p = new ArkPlayerProfile();
            p.playerName = ((InlineStrProperty)playerData.props.Find(x => x.name.CompareNameTo("PlayerName"))).value;
            p.arkPlayerId = ((InlineUInt64Property)playerData.props.Find(x => x.name.CompareNameTo("PlayerDataID"))).value;
            //Steam ID is read below
            p.tribeId = ((InlineIntProperty)playerData.props.Find(x => x.name.CompareNameTo("TribeID"))).value;
            p.loginTime = ((InlineDoubleProperty)playerData.props.Find(x => x.name.CompareNameTo("LoginTime"))).value;
            p.lastLoginTime = ((InlineDoubleProperty)playerData.props.Find(x => x.name.CompareNameTo("LastLoginTime"))).value;

            //Read Steam ID
            InlineStructProperty steamStruct = (InlineStructProperty)playerData.props.Find(x => x.name.CompareNameTo("UniqueID"));
            ArkStructUniqueNetId steamData = (ArkStructUniqueNetId)steamStruct.data;
            p.steamPlayerId = steamData.netId;

            return p;
        }
    }
}
