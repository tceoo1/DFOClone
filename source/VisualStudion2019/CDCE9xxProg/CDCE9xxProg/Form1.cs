using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CDCE9xxProg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SetCOMMPorts();
            btnSend.Enabled = false;
        }

        Dictionary<string, string> COMMPorts;

        private void SetCOMMPorts()
        {
            COMMPorts = EnumSerialPort.DeviceNames;

            cmbPortSelect.DataSource = new BindingSource(COMMPorts, null);
            cmbPortSelect.DisplayMember = "Value";
            cmbPortSelect.ValueMember = "Key";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var r = openFileDialog1.ShowDialog();

            if (r != DialogResult.OK) return;


            txtFilename.Text = openFileDialog1.FileName;
            dictWriteData.Clear();

            LoadFile(txtFilename.Text);

            byte cap = (byte)((dictWriteData[0x05]) >> 2);
            if (cap > 20) cap = 20;
            cmbLoadCapacitance.Text = cap.ToString();

        }

        private void LoadFile(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                listView1.Items.Clear();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //0 12 3456 78 9ABC
                    //: 01 0000 00 01FE
                    //: 00 0000 01 FF
                    if (line.StartsWith(":") == false) continue;
                    if (line.Length != 13 && line.Length != 11) continue;
                    string strLength = line.Substring(1, 2);
                    byte Length = Convert.ToByte(strLength, 16);
                    if (Length > 1) continue;
                    string strOffset = line.Substring(3, 4);
                    ushort Offset = Convert.ToUInt16(strOffset, 16);
                    string strType = line.Substring(7, 2);
                    byte Type = Convert.ToByte(strType, 16);
                    //List<byte> lstData = new List<byte>();
                    byte Data = 0xFF;
                    string strData = string.Empty;
                    switch (Type)
                    {
                        case 0x00:
                            //data record
                            for (byte i = 0; i < Length; i++)
                            {
                                strData = line.Substring(9 + i * 2, 2);
                                Data = Convert.ToByte(strData, 16);
                            }
                            break;
                        case 0x01:
                            //end record
                            return;
                        default:
                            continue;
                    }
                    //チェックバイトは省略

                    AddListViewItem(Offset, Data);
                    dictWriteData.Add(Offset, Data);
                }
            }

        }


        void AddListViewItem(ushort offset, byte data)
        {
            string strOffset = offset.ToString("X2");
            string strData = data.ToString("X2");
            var itm = listView1.Items.Add(strOffset);
            itm.SubItems.Add(strData);
            switch (offset & 0xF0)
            {
                case 0x00:
                    itm.Group = listView1.Groups["lvgGeneral"];
                    break;
                case 0x10:
                    itm.Group = listView1.Groups["lvgPLL1"];
                    break;
                case 0x20:
                    itm.Group = listView1.Groups["lvgPLL2"];
                    break;
                case 0x30:
                    itm.Group = listView1.Groups["lvgPLL3"];
                    break;
                case 0x40:
                    itm.Group = listView1.Groups["lvgPLL4"];
                    break;
            }
        }

        Dictionary<ushort, byte> dictWriteData = new Dictionary<ushort, byte>();

        private void Write()
        {
            byte addr = Convert.ToByte(cmbI2CAddress.SelectedItem.ToString(), 16);

            if(dictWriteData.Count < 16)
            {
                MessageBox.Show("書き込みデータがありません");
                return;
            }

            //アドレス書き換え
            byte temp = (byte)(dictWriteData[0x01] & 0x03);
            temp |= (byte)(addr & 0x03);
            dictWriteData[0x01] = temp;

            //負荷容量書き換え
            if(chkChangeLoadCapacitance.Checked)
            {
                temp = (byte)(dictWriteData[0x05] & 0x03);
                byte cap = byte.Parse(cmbLoadCapacitance.Text);
                temp |= (byte)(cap << 2);
                dictWriteData[0x05] = temp;
            }

            List<byte> SendData = new List<byte>();
            //'W'
            //devAddress
            //StoreEEPROM
            //nRegisters
            //(data)
            SendData.Add((byte)'W');
            SendData.Add(addr);
            SendData.Add(1);

            SendData.Add((byte)dictWriteData.Values.Count);
            SendData.AddRange(dictWriteData.Values.ToArray());
            try
            {
                serialPort1.DiscardInBuffer();
                serialPort1.Write(SendData.ToArray(), 0, SendData.Count);
                var r = serialPort1.ReadLine();

                if(r.Contains("OK"))
                {
                    MessageBox.Show("正常に書き込みました");
                }
                else
                {
                    MessageBox.Show("書き込み中にエラーが発生しました:\n" + r);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnConnectDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //close
                serialPort1.Close();
                btnSend.Enabled = false;
                btnRead.Enabled = false;
                cmbPortSelect.Enabled = true;
                btnReloadPort.Enabled = true;
                btnConnectDisconnect.Text = "接続";
            }
            else
            {
                //open
                string date = string.Empty, ver = string.Empty;
                try 
                { 
                    serialPort1.PortName = (string)cmbPortSelect.SelectedValue;

                    serialPort1.Open();
                    serialPort1.Write("D");
                    date = serialPort1.ReadLine();
                    txtFWDate.Text = date;
                    serialPort1.Write("V");
                    ver = serialPort1.ReadLine();
                    txtFWVersion.Text = ver;

                    string i2caddr;
                    cmbI2CAddress.Items.Clear();
                    serialPort1.Write("S");
                    do
                    {
                        i2caddr = serialPort1.ReadLine().Trim();
                        if (i2caddr.Contains("OK")) break;
                        if (i2caddr.Contains("ERR")) break;
                        cmbI2CAddress.Items.Add(i2caddr);

                    } while (true);

                    if(cmbI2CAddress.Items.Count == 0)
                    {
                        MessageBox.Show("CDCE9xxが検出されませんでした");
                        serialPort1.Close();
                        return;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    try
                    {
                        if (serialPort1.IsOpen) serialPort1.Close();
                    }
                    catch { }
                    return;
                }
                cmbI2CAddress.SelectedIndex = 0;
                btnSend.Enabled = true;
                btnRead.Enabled = true;
                cmbPortSelect.Enabled = false;
                btnReloadPort.Enabled = false;
                btnConnectDisconnect.Text = "切断";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Write();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            List<byte> send = new List<byte>();

            send.Add((byte)'R');    
            send.Add(I2CAddress);
            send.Add(DataSize);
            serialPort1.DiscardInBuffer();
            serialPort1.Write(send.ToArray(), 0, send.Count);

            List<byte> recv = new List<byte>();
            string r = string.Empty;

            try
            {
                for (int i = 0; i < DataSize; i++)
                {
                    recv.Add((byte)serialPort1.ReadByte());
                }
                r = serialPort1.ReadLine();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(r.Contains("OK"))
            {
                listView1.Items.Clear();
                dictWriteData.Clear();
                for(byte i = 0; i < recv.Count; i++)
                {
                    AddListViewItem(i, recv[i]);
                    dictWriteData.Add(i, recv[i]);
                }

                byte cap = (byte)((dictWriteData[0x05]) >> 2);
                if (cap > 20) cap = 20;
                cmbLoadCapacitance.Text = cap.ToString();

                MessageBox.Show("正常に読み出しました");
            }
            else
            {
                MessageBox.Show("読み出しに失敗しました\n" + r);
            }
        }

        private void cmbI2CAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            I2CAddress = Convert.ToByte(cmbI2CAddress.SelectedItem.ToString(), 16);
            switch(I2CAddress)
            {
                case 0x65:
                    //CDCE913
                    cmbDeviceType.Text = "CDCE(L)913";
                    break;
                case 0x64:
                    //CDCE925
                    cmbDeviceType.Text = "CDCE(L)925";
                    break;
                case 0x6D:
                    //CDCE937
                    cmbDeviceType.Text = "CDCE(L)937";
                    break;
                case 0x6C:
                    //CDCE949
                    cmbDeviceType.Text = "CDCE(L)949";
                    break;
                default:
                    if((I2CAddress & 0x08) == 0)
                    {
                        //CDCE913ということにする
                        cmbDeviceType.Text = "CDCE(L)913";
                    }
                    else
                    {
                        //CDCE937ということにする
                        cmbDeviceType.Text = "CDCE(L)937";
                    }
                    break;
            }
        }

        byte I2CAddress = 0x65;

        private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbDeviceType.SelectedItem.ToString())
            {
                case "CDCE(L)913":
                    DataSize = 32;
                    break;
                case "CDCE(L)925":
                    DataSize = 48;
                    break;
                case "CDCE(L)937":
                    DataSize = 64;
                    break;
                case "CDCE(L)949":
                    DataSize = 80;
                    break;

            }
        }

        byte DataSize = 32;

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLoadCapacitance.Text = "10";
        }

        private void chkChangeLoadCapacitance_CheckedChanged(object sender, EventArgs e)
        {
            cmbLoadCapacitance.Enabled = chkChangeLoadCapacitance.Checked;
        }

        private void btnSaveHex_Click(object sender, EventArgs e)
        {
            if (dictWriteData.Count < 16)
            {
                MessageBox.Show("データがありません");
                return;
            }

            var r = saveFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;

            /*
                    //0 12 3456 78 9ABC
                    //: 01 0000 00 01FE
                    //: 00 0000 01 FF
            */
            using (var sw = new StreamWriter(saveFileDialog1.FileName))
            {
                foreach (var d in dictWriteData)
                {
                    string line = string.Empty;
                    byte sum = 0;
                    line += ":";
                    line += "01"; //length
                    sum += 1;
                    line += d.Key.ToString("X4"); //offset
                    sum += (byte)d.Key;
                    line += "00"; //type
                    sum += 0;
                    line += d.Value.ToString("X2"); //data
                    sum += d.Value;
                    line += ((byte)(~sum)+1).ToString("X2");
                    sw.WriteLine(line);
                }
                sw.WriteLine(":00000001FF");
            }
        }

        private void btnReloadPort_Click(object sender, EventArgs e)
        {
            SetCOMMPorts();
        }
    }
}
    