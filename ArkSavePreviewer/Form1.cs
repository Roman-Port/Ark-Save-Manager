using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkSavePreviewer
{
    public partial class MainView : Form
    {
        public ArkSaveEditor.Entities.LowLevel.DotArkFile ark;

        public ArkSaveEditor.Entities.LowLevel.DotArk.DotArkGameObject activeGameObject;

        public MainView()
        {
            InitializeComponent();

            //First, load the Ark file.
            ark = ArkSaveEditor.Deserializer.ArkSaveDeserializer.OpenDotArk();

            //Write all classes to the sidebar.
            foreach(var g in ark.gameObjects)
            {
                string content = g.classname.classname + " - " + g.props.Count + " props ";
                if (g.locationData != null)
                    content += "- X:" + g.locationData.x.ToString() + " y:" + g.locationData.y.ToString() + " z:" + g.locationData.z.ToString();
                gameObjectList.Items.Add(content);
            }
        }

        string ClassnameToString(ArkSaveEditor.Entities.LowLevel.ArkClassName cn)
        {
            return $"{cn.classname}[{cn.index}]";
        }

        private void gameObjectList_SelectedValueChanged(object sender, EventArgs e)
        {
            activeGameObject = ark.gameObjects[gameObjectList.SelectedIndex];
            var pos = activeGameObject.locationData;

            //Set UI elements
            tb_classname.Lines = new string[] { ClassnameToString(activeGameObject.classname) };
            tb_item.Lines = new string[] { activeGameObject.isItem.ToString() };
            if(pos == null)
                tb_pos.Lines = new string[] { "N/A" };
            else
                tb_pos.Lines = new string[] { $"X:{pos.x} Y:{pos.y} Z:{pos.z} Pitch:{pos.pitch} Yaw:{pos.yaw} Roll:{pos.roll}" };
            string names = "";
            for (int i = 0; i < activeGameObject.names.Count; i++)
                names += activeGameObject.names[i].classname + ", ";
            if(names.Length > 2)
                names = names.Substring(names.Length - 2);
            tb_name.Lines = new string[] { names };
            tb_guid.Lines = new string[] { activeGameObject.guid.ToString() };

            gameObjectProps.Items.Clear();
            //Add each property
            foreach (var p in activeGameObject.props)
                gameObjectProps.Items.Add(p.name.classname + " / " + p.type.classname);
        }

        private void gameObjectProps_SelectedIndexChanged(object sender, EventArgs e)
        {
            var prop = activeGameObject.props[gameObjectProps.SelectedIndex];

            //Set JSON data
            object content = prop.data;
            if(prop.type.classname == "ByteProperty")
            {
                var p = (ByteProperty)prop;
                if (p.isNormalByte)
                    content = "0x" + BitConverter.ToString(new byte[] { p.byteValue });
                else
                    content = $"({ClassnameToString(p.enumName)}) {ClassnameToString(p.enumValue)}";
            }

            string json = JsonConvert.SerializeObject(content);
            jsonData.Lines = json.Split('\n');

            //Set UI
            tb_prop_name.Lines = new string[] { ClassnameToString(prop.name) };
            tb_type.Lines = new string[] { ClassnameToString(prop.type) };
            tb_size.Lines = new string[] { prop.size.ToString() };
        }
    }
}
