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
            this.SuspendLayout();
            // 
            // gameObjectList
            // 
            this.gameObjectList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gameObjectList.FormattingEnabled = true;
            this.gameObjectList.Location = new System.Drawing.Point(12, 38);
            this.gameObjectList.Name = "gameObjectList";
            this.gameObjectList.Size = new System.Drawing.Size(451, 498);
            this.gameObjectList.TabIndex = 0;
            this.gameObjectList.SelectedValueChanged += new System.EventHandler(this.gameObjectList_SelectedValueChanged);
            // 
            // gameObjectProps
            // 
            this.gameObjectProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameObjectProps.FormattingEnabled = true;
            this.gameObjectProps.Location = new System.Drawing.Point(469, 246);
            this.gameObjectProps.Name = "gameObjectProps";
            this.gameObjectProps.Size = new System.Drawing.Size(362, 290);
            this.gameObjectProps.TabIndex = 1;
            this.gameObjectProps.SelectedIndexChanged += new System.EventHandler(this.gameObjectProps_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 38);
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
            this.tb_classname.Location = new System.Drawing.Point(469, 54);
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
            this.tb_item.Location = new System.Drawing.Point(469, 92);
            this.tb_item.Name = "tb_item";
            this.tb_item.ReadOnly = true;
            this.tb_item.Size = new System.Drawing.Size(362, 20);
            this.tb_item.TabIndex = 5;
            this.tb_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 76);
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
            this.tb_pos.Location = new System.Drawing.Point(469, 131);
            this.tb_pos.Name = "tb_pos";
            this.tb_pos.ReadOnly = true;
            this.tb_pos.Size = new System.Drawing.Size(362, 20);
            this.tb_pos.TabIndex = 7;
            this.tb_pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 115);
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
            this.tb_name.Location = new System.Drawing.Point(469, 171);
            this.tb_name.Name = "tb_name";
            this.tb_name.ReadOnly = true;
            this.tb_name.Size = new System.Drawing.Size(362, 20);
            this.tb_name.TabIndex = 9;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 155);
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
            this.tb_guid.Location = new System.Drawing.Point(469, 216);
            this.tb_guid.Name = "tb_guid";
            this.tb_guid.ReadOnly = true;
            this.tb_guid.Size = new System.Drawing.Size(362, 20);
            this.tb_guid.TabIndex = 11;
            this.tb_guid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "GUID";
            // 
            // jsonData
            // 
            this.jsonData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonData.Location = new System.Drawing.Point(837, 157);
            this.jsonData.Multiline = true;
            this.jsonData.Name = "jsonData";
            this.jsonData.Size = new System.Drawing.Size(429, 379);
            this.jsonData.TabIndex = 12;
            // 
            // tb_prop_name
            // 
            this.tb_prop_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_prop_name.Location = new System.Drawing.Point(837, 54);
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
            this.label6.Location = new System.Drawing.Point(838, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Name";
            // 
            // tb_type
            // 
            this.tb_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_type.Location = new System.Drawing.Point(837, 92);
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
            this.label7.Location = new System.Drawing.Point(838, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Type";
            // 
            // tb_size
            // 
            this.tb_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_size.Location = new System.Drawing.Point(837, 131);
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
            this.label8.Location = new System.Drawing.Point(838, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Size";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 563);
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
            this.Name = "MainView";
            this.Text = "Form1";
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
    }
}

