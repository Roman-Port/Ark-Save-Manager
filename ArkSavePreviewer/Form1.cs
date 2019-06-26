using ArkSaveEditor.Entities.LowLevel.DotArk.ArkProperties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkSavePreviewer
{
    public partial class MainView : Form
    {
        public ArkSaveEditor.Entities.LowLevel.DotArkFile ark;

        public List<ArkSaveEditor.Entities.LowLevel.DotArk.DotArkGameObject> searchGameObjects = new List<ArkSaveEditor.Entities.LowLevel.DotArk.DotArkGameObject>();

        public ArkSaveEditor.Entities.LowLevel.DotArk.DotArkGameObject activeGameObject;

        public MainView()
        {
            InitializeComponent();

            //Show loader
            var loader = new LoaderForm();
            loader.Show();
            

            //First, load the Ark file.
            ark = ArkSaveEditor.Deserializer.ArkSaveDeserializer.OpenDotArk(@"C:\Program Files (x86)\Steam\steamapps\common\ARK\ShooterGame\Saved\SavedArksLocal\TheIsland.ark");

            //Write all classes to the sidebar.
            Search("");

            Thread.Sleep(300);
            //Hidel oader
            loader.Hide();
        }

        string ClassnameToString(ArkSaveEditor.Entities.LowLevel.ArkClassName cn)
        {
            return $"{ cn.classname}[{cn.index}]";
        }

        private void gameObjectList_SelectedValueChanged(object sender, EventArgs e)
        {
            activeGameObject = searchGameObjects[gameObjectList.SelectedIndex];
            var pos = activeGameObject.locationData;
            jumpToRefBtn.Enabled = false;
            //Clear prop info
            jsonData.Lines = new string[0];
            tb_prop_name.Lines = new string[0];
            tb_type.Lines = new string[0];
            tb_size.Lines = new string[0];

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
            jumpToRefBtn.Enabled = false;
            //Set JSON data
            object content = prop.data;
            string json = JsonConvert.SerializeObject(content);
            if (prop.type.classname == "ByteProperty")
            {
                var p = (ByteProperty)prop;
                if (p.isNormalByte)
                    json = "0x" + BitConverter.ToString(new byte[] { p.byteValue });
                else
                    json = $"({ClassnameToString(p.enumName)}) {ClassnameToString(p.enumValue)}";
            }
            if(prop.type.classname == "ObjectProperty")
            {
                var p = (ObjectProperty)prop;
                if (p.objectRefType == ObjectPropertyType.TypeID)
                    json = $"(ref to index {p.objectId})";
                else if (p.objectRefType == ObjectPropertyType.TypePath)
                    json = $"(ref to type path)\n{p.className.classname} {p.className.index}";
                //Also enable the jump to btn
                jumpToRefBtn.Enabled = true;
                jumpToRefIndex = p.objectId;
            }
            if(prop.type.classname == "ArrayProperty")
            {
                json = JsonConvert.SerializeObject(prop);
            }

            
            jsonData.Lines = json.Split('\n');

            //Set UI
            tb_prop_name.Lines = new string[] { ClassnameToString(prop.name) };
            tb_type.Lines = new string[] { ClassnameToString(prop.type) };
            tb_size.Lines = new string[] { prop.index.ToString() };
            filePositionEntry.Lines = new string[] { prop.dataFilePosition.ToString() };
        }

        string lastSearch = null;

        void Search(string query)
        {
            if (lastSearch == query)
                return; //Stop
            lastSearch = query;
            //Clear GameObject list and search.
            gameObjectList.Items.Clear();
            searchGameObjects.Clear();
            foreach (var g in ark.gameObjects)
            {
                if(g.classname.classname.ToLower().Contains(query.ToLower()) || query.Length == 0)
                {
                    //Add to list and UI.
                    string content = g.classname.classname + " - " + g.props.Count + " props ";
                    if (g.locationData != null)
                        content += "- X:" + g.locationData.x.ToString() + " y:" + g.locationData.y.ToString() + " z:" + g.locationData.z.ToString();
                    gameObjectList.Items.Add(content);

                    searchGameObjects.Add(g);
                }
            }

            resultsCounter.Text = $"{searchGameObjects.Count} results";
        }

        private void saerchBox_TextChanged(object sender, EventArgs e)
        {
            if(saerchBox.Lines.Length>=1)
            {
                if (saerchBox.Lines[0].Length > 3)
                    Search(saerchBox.Lines[0]);
            }
        }

        private int jumpToRefIndex;

        private void jumpToRefBtn_Click(object sender, EventArgs e)
        {
            //Clear search
            Search("");
            //Jump to index
            gameObjectList.SelectedIndex = jumpToRefIndex;
        }

        private void get_tp_cmd_Click(object sender, EventArgs e)
        {
            string p = $"admincheat setplayerpos {activeGameObject.locationData.x} {activeGameObject.locationData.y} {activeGameObject.locationData.z}";
            Clipboard.SetText(p);
        }
    }
}
