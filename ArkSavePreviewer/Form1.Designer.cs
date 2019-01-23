namespace ArkSavePreviewer
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.gameObjectList = new System.Windows.Forms.ListBox();
            this.gameObjectProps = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_classname = new System.Windows.Forms.TextBox();
            this.tb_item = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_pos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_guid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.jsonData = new System.Windows.Forms.TextBox();
            this.tb_prop_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_type = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_size = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.saerchBox = new System.Windows.Forms.TextBox();
            this.resultsCounter = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.jumpToRefBtn = new System.Windows.Forms.Button();
            this.get_tp_cmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameObjectList
            // 
            this.gameObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gameObjectList.FormattingEnabled = true;
            this.gameObjectList.Location = new System.Drawing.Point(12, 92);
            this.gameObjectList.Name = "gameObjectList";
            this.gameObjectList.Size = new System.Drawing.Size(451, 459);
            this.gameObjectList.TabIndex = 0;
            this.gameObjectList.SelectedValueChanged += new System.EventHandler(this.gameObjectList_SelectedValueChanged);
            // 
            // gameObjectProps
            // 
            this.gameObjectProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameObjectProps.FormattingEnabled = true;
            this.gameObjectProps.Location = new System.Drawing.Point(469, 287);
            this.gameObjectProps.Name = "gameObjectProps";
            this.gameObjectProps.Size = new System.Drawing.Size(362, 264);
            this.gameObjectProps.TabIndex = 1;
            this.gameObjectProps.SelectedIndexChanged += new System.EventHandler(this.gameObjectProps_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Classname";
            // 
            // tb_classname
            // 
            this.tb_classname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_classname.Location = new System.Drawing.Point(469, 69);
            this.tb_classname.Name = "tb_classname";
            this.tb_classname.ReadOnly = true;
            this.tb_classname.Size = new System.Drawing.Size(362, 20);
            this.tb_classname.TabIndex = 3;
            this.tb_classname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_item
            // 
            this.tb_item.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_item.Location = new System.Drawing.Point(469, 107);
            this.tb_item.Name = "tb_item";
            this.tb_item.ReadOnly = true;
            this.tb_item.Size = new System.Drawing.Size(362, 20);
            this.tb_item.TabIndex = 5;
            this.tb_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Is Item?";
            // 
            // tb_pos
            // 
            this.tb_pos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pos.Location = new System.Drawing.Point(469, 146);
            this.tb_pos.Name = "tb_pos";
            this.tb_pos.ReadOnly = true;
            this.tb_pos.Size = new System.Drawing.Size(362, 20);
            this.tb_pos.TabIndex = 7;
            this.tb_pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Position Data";
            // 
            // tb_name
            // 
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.Location = new System.Drawing.Point(469, 186);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(362, 20);
            this.tb_name.TabIndex = 9;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Names";
            // 
            // tb_guid
            // 
            this.tb_guid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_guid.Location = new System.Drawing.Point(469, 228);
            this.tb_guid.Name = "tb_guid";
            this.tb_guid.ReadOnly = true;
            this.tb_guid.Size = new System.Drawing.Size(362, 20);
            this.tb_guid.TabIndex = 11;
            this.tb_guid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "GUID";
            // 
            // jsonData
            // 
            this.jsonData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonData.Location = new System.Drawing.Point(837, 201);
            this.jsonData.Multiline = true;
            this.jsonData.Name = "jsonData";
            this.jsonData.Size = new System.Drawing.Size(429, 350);
            this.jsonData.TabIndex = 12;
            // 
            // tb_prop_name
            // 
            this.tb_prop_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_prop_name.Location = new System.Drawing.Point(837, 69);
            this.tb_prop_name.Name = "tb_prop_name";
            this.tb_prop_name.ReadOnly = true;
            this.tb_prop_name.Size = new System.Drawing.Size(429, 20);
            this.tb_prop_name.TabIndex = 14;
            this.tb_prop_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(838, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Name";
            // 
            // tb_type
            // 
            this.tb_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_type.Location = new System.Drawing.Point(837, 107);
            this.tb_type.Name = "tb_type";
            this.tb_type.ReadOnly = true;
            this.tb_type.Size = new System.Drawing.Size(429, 20);
            this.tb_type.TabIndex = 16;
            this.tb_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(838, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Type";
            // 
            // tb_size
            // 
            this.tb_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_size.Location = new System.Drawing.Point(837, 146);
            this.tb_size.Name = "tb_size";
            this.tb_size.ReadOnly = true;
            this.tb_size.Size = new System.Drawing.Size(429, 20);
            this.tb_size.TabIndex = 18;
            this.tb_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(838, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Index";
            // 
            // saerchBox
            // 
            this.saerchBox.Location = new System.Drawing.Point(12, 69);
            this.saerchBox.Name = "saerchBox";
            this.saerchBox.Size = new System.Drawing.Size(330, 20);
            this.saerchBox.TabIndex = 19;
            this.saerchBox.TextChanged += new System.EventHandler(this.saerchBox_TextChanged);
            // 
            // resultsCounter
            // 
            this.resultsCounter.AutoSize = true;
            this.resultsCounter.Location = new System.Drawing.Point(348, 76);
            this.resultsCounter.Name = "resultsCounter";
            this.resultsCounter.Size = new System.Drawing.Size(46, 13);
            this.resultsCounter.TabIndex = 20;
            this.resultsCounter.Text = "0 results";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1191, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1110, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Reload";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(982, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "GitHub";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(324, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Ark Save Preview - A basic demo of Ark Save Editor by RomanPort";
            // 
            // jumpToRefBtn
            // 
            this.jumpToRefBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jumpToRefBtn.Enabled = false;
            this.jumpToRefBtn.Location = new System.Drawing.Point(1142, 172);
            this.jumpToRefBtn.Name = "jumpToRefBtn";
            this.jumpToRefBtn.Size = new System.Drawing.Size(124, 23);
            this.jumpToRefBtn.TabIndex = 25;
            this.jumpToRefBtn.Text = "Jump to Reference";
            this.jumpToRefBtn.UseVisualStyleBackColor = true;
            this.jumpToRefBtn.Click += new System.EventHandler(this.jumpToRefBtn_Click);
            // 
            // get_tp_cmd
            // 
            this.get_tp_cmd.Location = new System.Drawing.Point(686, 258);
            this.get_tp_cmd.Name = "get_tp_cmd";
            this.get_tp_cmd.Size = new System.Drawing.Size(145, 23);
            this.get_tp_cmd.TabIndex = 26;
            this.get_tp_cmd.Text = "Get TP Command";
            this.get_tp_cmd.UseVisualStyleBackColor = true;
            this.get_tp_cmd.Click += new System.EventHandler(this.get_tp_cmd_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 563);
            this.Controls.Add(this.get_tp_cmd);
            this.Controls.Add(this.jumpToRefBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultsCounter);
            this.Controls.Add(this.saerchBox);
            this.Controls.Add(this.tb_size);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_prop_name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jsonData);
            this.Controls.Add(this.tb_guid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_pos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_item);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_classname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameObjectProps);
            this.Controls.Add(this.gameObjectList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "Ark Save Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox gameObjectList;
        private System.Windows.Forms.ListBox gameObjectProps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_classname;
        private System.Windows.Forms.TextBox tb_item;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_pos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_guid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox jsonData;
        private System.Windows.Forms.TextBox tb_prop_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_size;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox saerchBox;
        private System.Windows.Forms.Label resultsCounter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button jumpToRefBtn;
        private System.Windows.Forms.Button get_tp_cmd;
    }
}

