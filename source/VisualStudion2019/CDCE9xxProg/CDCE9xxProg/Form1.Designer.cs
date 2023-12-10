
namespace CDCE9xxProg
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("General", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("PLL 1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("PLL 2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("PLL 3", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("PLL 4", System.Windows.Forms.HorizontalAlignment.Left);
            this.cmbPortSelect = new System.Windows.Forms.ComboBox();
            this.btnConnectDisconnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFWVersion = new System.Windows.Forms.TextBox();
            this.txtFWDate = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.cmbI2CAddress = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeviceType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLoadCapacitance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkChangeLoadCapacitance = new System.Windows.Forms.CheckBox();
            this.btnSaveHex = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnReloadPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPortSelect
            // 
            this.cmbPortSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortSelect.FormattingEnabled = true;
            this.cmbPortSelect.Location = new System.Drawing.Point(14, 35);
            this.cmbPortSelect.Name = "cmbPortSelect";
            this.cmbPortSelect.Size = new System.Drawing.Size(295, 20);
            this.cmbPortSelect.TabIndex = 0;
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Location = new System.Drawing.Point(315, 32);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(75, 24);
            this.btnConnectDisconnect.TabIndex = 1;
            this.btnConnectDisconnect.Text = "接続";
            this.btnConnectDisconnect.UseVisualStyleBackColor = true;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.btnConnectDisconnect_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.ReadTimeout = 3000;
            this.serialPort1.WriteTimeout = 3000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "FWバージョン";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "FW日付";
            // 
            // txtFWVersion
            // 
            this.txtFWVersion.Location = new System.Drawing.Point(84, 67);
            this.txtFWVersion.Name = "txtFWVersion";
            this.txtFWVersion.ReadOnly = true;
            this.txtFWVersion.Size = new System.Drawing.Size(85, 19);
            this.txtFWVersion.TabIndex = 3;
            // 
            // txtFWDate
            // 
            this.txtFWDate.Location = new System.Drawing.Point(226, 67);
            this.txtFWDate.Name = "txtFWDate";
            this.txtFWDate.ReadOnly = true;
            this.txtFWDate.Size = new System.Drawing.Size(85, 19);
            this.txtFWDate.TabIndex = 3;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(12, 113);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(313, 19);
            this.txtFilename.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "HEXファイルパス";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(331, 105);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(54, 34);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "参照";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "HEXファイル|*.hex|すべてのファイル|*.*";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            listViewGroup6.Header = "General";
            listViewGroup6.Name = "lvgGeneral";
            listViewGroup7.Header = "PLL 1";
            listViewGroup7.Name = "lvgPLL1";
            listViewGroup8.Header = "PLL 2";
            listViewGroup8.Name = "lvgPLL2";
            listViewGroup9.Header = "PLL 3";
            listViewGroup9.Name = "lvgPLL3";
            listViewGroup10.Header = "PLL 4";
            listViewGroup10.Name = "lvgPLL4";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(378, 276);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "オフセット";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "値";
            this.columnHeader2.Width = 120;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 200);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 24);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "書き込み";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRead
            // 
            this.btnRead.Enabled = false;
            this.btnRead.Location = new System.Drawing.Point(129, 200);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(90, 24);
            this.btnRead.TabIndex = 9;
            this.btnRead.Text = "読み出し";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // cmbI2CAddress
            // 
            this.cmbI2CAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbI2CAddress.FormattingEnabled = true;
            this.cmbI2CAddress.Location = new System.Drawing.Point(171, 145);
            this.cmbI2CAddress.Name = "cmbI2CAddress";
            this.cmbI2CAddress.Size = new System.Drawing.Size(64, 20);
            this.cmbI2CAddress.TabIndex = 10;
            this.cmbI2CAddress.SelectedIndexChanged += new System.EventHandler(this.cmbI2CAddress_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "ポート選択";
            // 
            // cmbDeviceType
            // 
            this.cmbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceType.FormattingEnabled = true;
            this.cmbDeviceType.Items.AddRange(new object[] {
            "CDCE(L)913",
            "CDCE(L)925",
            "CDCE(L)937",
            "CDCE(L)949"});
            this.cmbDeviceType.Location = new System.Drawing.Point(12, 145);
            this.cmbDeviceType.Name = "cmbDeviceType";
            this.cmbDeviceType.Size = new System.Drawing.Size(106, 20);
            this.cmbDeviceType.TabIndex = 11;
            this.cmbDeviceType.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "アドレス";
            // 
            // cmbLoadCapacitance
            // 
            this.cmbLoadCapacitance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoadCapacitance.Enabled = false;
            this.cmbLoadCapacitance.FormattingEnabled = true;
            this.cmbLoadCapacitance.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbLoadCapacitance.Location = new System.Drawing.Point(300, 145);
            this.cmbLoadCapacitance.Name = "cmbLoadCapacitance";
            this.cmbLoadCapacitance.Size = new System.Drawing.Size(61, 20);
            this.cmbLoadCapacitance.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "負荷容量";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(367, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "pF";
            // 
            // chkChangeLoadCapacitance
            // 
            this.chkChangeLoadCapacitance.AutoSize = true;
            this.chkChangeLoadCapacitance.Location = new System.Drawing.Point(243, 171);
            this.chkChangeLoadCapacitance.Name = "chkChangeLoadCapacitance";
            this.chkChangeLoadCapacitance.Size = new System.Drawing.Size(124, 16);
            this.chkChangeLoadCapacitance.TabIndex = 14;
            this.chkChangeLoadCapacitance.Text = "負荷容量を変更する";
            this.chkChangeLoadCapacitance.UseVisualStyleBackColor = true;
            this.chkChangeLoadCapacitance.CheckedChanged += new System.EventHandler(this.chkChangeLoadCapacitance_CheckedChanged);
            // 
            // btnSaveHex
            // 
            this.btnSaveHex.Location = new System.Drawing.Point(300, 200);
            this.btnSaveHex.Name = "btnSaveHex";
            this.btnSaveHex.Size = new System.Drawing.Size(90, 24);
            this.btnSaveHex.TabIndex = 9;
            this.btnSaveHex.Text = "HEX保存";
            this.btnSaveHex.UseVisualStyleBackColor = true;
            this.btnSaveHex.Click += new System.EventHandler(this.btnSaveHex_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "HEXファイル|*.hex|すべてのファイル|*.*";
            // 
            // btnReloadPort
            // 
            this.btnReloadPort.Location = new System.Drawing.Point(315, 6);
            this.btnReloadPort.Name = "btnReloadPort";
            this.btnReloadPort.Size = new System.Drawing.Size(75, 23);
            this.btnReloadPort.TabIndex = 15;
            this.btnReloadPort.Text = "ポート更新";
            this.btnReloadPort.UseVisualStyleBackColor = true;
            this.btnReloadPort.Click += new System.EventHandler(this.btnReloadPort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 518);
            this.Controls.Add(this.btnReloadPort);
            this.Controls.Add(this.chkChangeLoadCapacitance);
            this.Controls.Add(this.cmbLoadCapacitance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDeviceType);
            this.Controls.Add(this.cmbI2CAddress);
            this.Controls.Add(this.btnSaveHex);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.txtFWDate);
            this.Controls.Add(this.txtFWVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnectDisconnect);
            this.Controls.Add(this.cmbPortSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CDCE9XX Programmer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPortSelect;
        private System.Windows.Forms.Button btnConnectDisconnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFWVersion;
        private System.Windows.Forms.TextBox txtFWDate;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ComboBox cmbI2CAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeviceType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLoadCapacitance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkChangeLoadCapacitance;
        private System.Windows.Forms.Button btnSaveHex;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnReloadPort;
    }
}

