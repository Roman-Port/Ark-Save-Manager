using ArkSaveEditor.Entities.LowLevel.DotArk;
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
        public string ingamePlayerName;
        public UInt64 arkPlayerId;
        public string steamPlayerId;
        public int tribeId;

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

            //in-game name is read below
            InlineStructProperty playerStats = (InlineStructProperty)(playerData.props.Where(x => x.name.CompareNameTo("MyPlayerCharacterConfig")).ToArray()[0]);
            p.ingamePlayerName = ((InlineStrProperty)(((ArkStructInlineProps)playerStats.data).props.Where(x => x.name.CompareNameTo("PlayerCharacterName")).ToArray()[0])).value;

            //Read Steam ID
            InlineStructProperty steamStruct = (InlineStructProperty)playerData.props.Find(x => x.name.CompareNameTo("UniqueID"));
            ArkStructUniqueNetId steamData = (ArkStructUniqueNetId)steamStruct.data;
            p.steamPlayerId = steamData.netId;

            return p;
        }
    }
}
