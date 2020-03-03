using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.OleDb;
using DevExpress.XtraGrid;
using System.Drawing.Printing;
using System.Linq;

namespace COMStockTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {//поменять, чтобы в программе выбирались номера портов сканеров и их открывать

      
       //public SerialPort Port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        //public SerialPort Port1 = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
        private const string connectionString =
            "Provider=OraOLEDB.Oracle.1;Password=adminmanager;Persist Security Info=True;User ID=sfis;Data Source=SFIS_TEST";
        private const string connectionStringStock =
            "Provider=SQLOLEDB.1;Password=5tgbnji9;Persist Security Info=True;User ID=sa;Data Source=172.18.0.8;Connect Timeout = 3;Initial Catalog=tpvstock";
        public OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
        public OleDbCommand myOleDbCommand;
        public OleDbConnection myOleDbConnectionStock = new OleDbConnection(connectionStringStock);
        public OleDbCommand myOleDbCommandStock;
     
        public string _msg, _msg1, SN;
        public int x;
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            myOleDbConnection.Open();
            myOleDbConnectionStock.Open();
        }
        private void Form1_load(object sender, EventArgs e)
        {

            //SetDefaults();
            SetPortNameValues(cbport);
            SetPortNameValues(cbport1);


        }
        public void SetPortNameValues(object obj)
        {
           

            foreach (string str in SerialPort.GetPortNames())
            {
             
                string com = cbport.Items.ToString();
                //if (str != com)
                ((ComboBox)obj).Items.Add(str);
            }
        }
        //private void SetDefaults()
        //{

        //    cbport.SelectedIndex = 0;
        //    cbrate.SelectedText = "9600";
        //    cbparity.SelectedIndex = 0;
        //    cbstop.SelectedIndex = 1;
        //    cbdata.SelectedIndex = 1;
        //}
        public void comportmanager()
        {
            try
            {
                SerialPort Port = new SerialPort(cbport.Text, 9600, Parity.None, 8, StopBits.One);
                SerialPort Port1 = new SerialPort(cbport1.Text, 9600, Parity.None, 8, StopBits.One);
                if (Port.IsOpen == true) Port.Close();
                if (Port1.IsOpen == true) Port1.Close();
                //Port.BaudRate = int.Parse(cbrate.Text);    //BaudRate
                //Port.DataBits = int.Parse(cbdata.Text);    //DataBits
                //Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbstop.Text);    //StopBits
                //Port.Parity = (Parity)Enum.Parse(typeof(Parity), cbparity.Text);    //Parity
                //Port.PortName = cbport.Text;   //PortName
                //                                //now open the port
                
                Port.Open();
                Port1.Open();
                tblog.Text = "Порты открыты";
                Port.DataReceived += new SerialDataReceivedEventHandler(comDataReceived);
                Port1.DataReceived += new SerialDataReceivedEventHandler(comDataReceived1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
         
            Input_Data((sender as SerialPort).ReadExisting());

        }
        private void comDataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
           
            //msg = Port1.ReadExisting(); 
            Input_Data((sender as SerialPort).ReadExisting());

        }
        private void Input_Data(string _inval)
        {
          
            //string indata = _inval.TrimEnd();
            string sn = _inval.Replace(Environment.NewLine, "");
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            //OleDbCommand query = myOleDbConnection.CreateCommand();
            OleDbCommand query_stock = myOleDbConnectionStock.CreateCommand();
            //myOleDbConnection.Open();
            myOleDbCommand.CommandText = "select out_line_time, mo_number, model_name from sfism4.r_wip_tracking_t where serial_number = '" + sn + "'";
           // query.CommandText = "select serial_number, mo_number, model_name from sfism4.r_wip_tracking_t where serial_number = '" + sn + "'";
            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            if (myOleDbDataReader.HasRows)
            {
                myOleDbDataReader.Read();
                var model_mame = myOleDbDataReader["model_name"] + string.Empty;
                var out_line_time = myOleDbDataReader["out_line_time"] + string.Empty;
                //myOleDbConnectionStock.Open();
                query_stock.CommandText = "select PalletQty, CustomerNo, ProductName, ProductCode from tpvstock.dbo.products where SKDPartNo = '" + model_mame + "'";
                OleDbDataReader myOleDbDataReaderStock = query_stock.ExecuteReader();
                myOleDbDataReaderStock.Read();
                var pallet_qty = myOleDbDataReaderStock["PalletQty"] + string.Empty;
                var CustomerNo = myOleDbDataReaderStock["CustomerNo"] + string.Empty;
                var ProductName = myOleDbDataReaderStock["ProductName"] + string.Empty;
                var ProductCode = myOleDbDataReaderStock["ProductCode"] + string.Empty;
                myOleDbDataReaderStock.Close();
                //myOleDbConnectionStock.Close();
               
                SetText1(pallet_qty.ToString());
                if (out_line_time == "")
                {
                    dataGridView1.Rows[x].Cells["SerialNumber"].Value = "";
                 
                    _msg = "SN: " + sn + " is not Route End";
                    SetText(_msg.ToString());
                    myOleDbDataReader.Close();
                    //myOleDbConnection.Close();
                }
                else
                {
                    var mo_number = myOleDbDataReader["mo_number"] + string.Empty;
                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            x = dataGridView1.Rows.Add(sn);
                            dataGridView1.Rows[x].Cells["OrderNo"].Value = mo_number;
                            //OleDbDataAdapter da = new OleDbDataAdapter();
                            //da = new OleDbDataAdapter(query);
                            //DataTable dt = new DataTable();
                            //da.Fill(dt);
                            //GridControl DG = new GridControl();
                            //DG = this.gridControl1;
                            //DG.DataSource = dt;
                            _msg = "SN: " + sn + " OK";
                            SetText(_msg.ToString());
                            myOleDbDataReader.Close();
                            //myOleDbConnection.Close();
                            lb_pos.Text = "Кол-во:" + Convert.ToString (x + 1);
                            if (x + 1 == Convert.ToInt64 (pallet_qty))
                            {

                            }

                        }));
                        return;
                    }
                }
            }
            else
            {
                dataGridView1.Rows[x].Cells["SerialNumber"].Value = "";
            
                _msg = "NO SN";
                SetText(_msg.ToString());
                myOleDbDataReader.Close();
                //myOleDbConnection.Close();
            }


        }

        private void Input_Data_enter(string _inval, int x)
        {
           
            //string indata = _inval.TrimEnd();
            string sn = _inval.Replace(Environment.NewLine, "");
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            //OleDbCommand query = myOleDbConnection.CreateCommand();
            OleDbCommand query_stock = myOleDbConnectionStock.CreateCommand();
            //myOleDbConnection.Open();
            myOleDbCommand.CommandText = "select out_line_time, mo_number, model_name from sfism4.r_wip_tracking_t where serial_number = '" + sn + "'";
            // query.CommandText = "select serial_number, mo_number, model_name from sfism4.r_wip_tracking_t where serial_number = '" + sn + "'";
            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            if (myOleDbDataReader.HasRows)
            {
                myOleDbDataReader.Read();
                var model_mame = myOleDbDataReader["model_name"] + string.Empty;
                var out_line_time = myOleDbDataReader["out_line_time"] + string.Empty;
                //myOleDbConnectionStock.Open();
                query_stock.CommandText = "select PalletQty, CustomerNo, ProductName, ProductCode from tpvstock.dbo.products where SKDPartNo = '" + model_mame + "'";
                OleDbDataReader myOleDbDataReaderStock = query_stock.ExecuteReader();
                myOleDbDataReaderStock.Read();
                var pallet_qty = myOleDbDataReaderStock["PalletQty"] + string.Empty;
                var CustomerNo = myOleDbDataReaderStock["CustomerNo"] + string.Empty;
                var ProductName = myOleDbDataReaderStock["ProductName"] + string.Empty;
                var ProductCode = myOleDbDataReaderStock["ProductCode"] + string.Empty;
                myOleDbDataReaderStock.Close();
                //myOleDbConnectionStock.Close();
                tb_palletqty.Text = pallet_qty;
                //SetText1(pallet_qty.ToString());
                if (out_line_time == "")
                {
                    dataGridView1.Rows[x].Cells["SerialNumber"].Value = "";
                  
                    _msg = "SN: " + sn + " is not Route End";
                    tblog2.Text = _msg;
                   
                    myOleDbDataReader.Close();
                    //myOleDbConnection.Close();
                }
                else
                {
                    var mo_number = myOleDbDataReader["mo_number"] + string.Empty;

                    //int x = dataGridView1.Rows.Add(sn);
                    dataGridView1.Rows[x].Cells["OrderNo"].Value = mo_number;
                    //OleDbDataAdapter da = new OleDbDataAdapter();
                    //da = new OleDbDataAdapter(query);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //GridControl DG = new GridControl();
                    //DG = this.gridControl1;
                    //DG.DataSource = dt;
                    _msg = "SN: " + sn + " OK";
                    tblog2.Text = _msg;
                    //SetText(_msg.ToString());
                    myOleDbDataReader.Close();
                    //myOleDbConnection.Close();
                    lb_pos.Text = "Кол-во:" + Convert.ToString(x + 1);
                    if (x + 1 == Convert.ToInt64(pallet_qty))
                    {

                    }

                  
                }
            }
            else
            {
                dataGridView1.Rows[x].Cells["SerialNumber"].Value = "";
         
                _msg = "NO SN";
                tblog2.Text = _msg;
              
                myOleDbDataReader.Close();
                //myOleDbConnection.Close();
            }


        }

        private void openport_Click(object sender, EventArgs e)
        {
            comportmanager();

        }
        private void SetText(string text)
        {
           
          
                if (this.tblog2.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.tblog2.Text = text;
                }
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    x = e.RowIndex;
                    SN = Convert.ToString (dataGridView1.CurrentCell.Value);

                    Input_Data_enter(SN, x);
                }

            }
            catch (Exception ex)
            {
                //myOleDbConnection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_conn_Click(object sender, EventArgs e)
        {

        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            
            SetPortNameValues(cbport);
            SetPortNameValues(cbport1);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //int x = dataGridView1.Rows.Add("12");
                    dataGridView1.CurrentCell.Value = SN;
                    Input_Data(SN);
                }

            }
            catch (Exception ex)
            {
                //myOleDbConnection.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void SetText1(string text1)
        {
        
            {
                if (this.tb_palletqty.InvokeRequired)
                {
                    SetTextCallback st = new SetTextCallback(SetText1);
                    this.Invoke(st, new object[] { text1 });
                }
                else
                {
                    this.tb_palletqty.Text = text1;
                }
            }
        }
    }
}
