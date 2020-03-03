namespace COMStockTest
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openport = new System.Windows.Forms.Button();
            this.cbport = new System.Windows.Forms.ComboBox();
            this.cbrate = new System.Windows.Forms.ComboBox();
            this.cbparity = new System.Windows.Forms.ComboBox();
            this.cbstop = new System.Windows.Forms.ComboBox();
            this.cbdata = new System.Windows.Forms.ComboBox();
            this.tblog = new System.Windows.Forms.TextBox();
            this.cbport1 = new System.Windows.Forms.ComboBox();
            this.tblog2 = new System.Windows.Forms.TextBox();
            this.tb_palletqty = new System.Windows.Forms.TextBox();
            this.Palletqty = new System.Windows.Forms.Label();
            this.lb_pos = new System.Windows.Forms.Label();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.OrderNo});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(399, 469);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "Serial Number";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Width = 205;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "OrderNo";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Width = 150;
            // 
            // openport
            // 
            this.openport.Location = new System.Drawing.Point(440, 217);
            this.openport.Name = "openport";
            this.openport.Size = new System.Drawing.Size(121, 23);
            this.openport.TabIndex = 2;
            this.openport.Text = "Открыть порт";
            this.openport.UseVisualStyleBackColor = true;
            this.openport.Click += new System.EventHandler(this.openport_Click);
            // 
            // cbport
            // 
            this.cbport.FormattingEnabled = true;
            this.cbport.Location = new System.Drawing.Point(440, 13);
            this.cbport.Name = "cbport";
            this.cbport.Size = new System.Drawing.Size(121, 21);
            this.cbport.TabIndex = 3;
            // 
            // cbrate
            // 
            this.cbrate.FormattingEnabled = true;
            this.cbrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cbrate.Location = new System.Drawing.Point(440, 50);
            this.cbrate.Name = "cbrate";
            this.cbrate.Size = new System.Drawing.Size(121, 21);
            this.cbrate.TabIndex = 4;
            // 
            // cbparity
            // 
            this.cbparity.FormattingEnabled = true;
            this.cbparity.Location = new System.Drawing.Point(440, 92);
            this.cbparity.Name = "cbparity";
            this.cbparity.Size = new System.Drawing.Size(121, 21);
            this.cbparity.TabIndex = 5;
            // 
            // cbstop
            // 
            this.cbstop.FormattingEnabled = true;
            this.cbstop.Location = new System.Drawing.Point(440, 129);
            this.cbstop.Name = "cbstop";
            this.cbstop.Size = new System.Drawing.Size(121, 21);
            this.cbstop.TabIndex = 6;
            // 
            // cbdata
            // 
            this.cbdata.FormattingEnabled = true;
            this.cbdata.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cbdata.Location = new System.Drawing.Point(440, 172);
            this.cbdata.Name = "cbdata";
            this.cbdata.Size = new System.Drawing.Size(121, 21);
            this.cbdata.TabIndex = 7;
            // 
            // tblog
            // 
            this.tblog.Location = new System.Drawing.Point(440, 506);
            this.tblog.Name = "tblog";
            this.tblog.ReadOnly = true;
            this.tblog.Size = new System.Drawing.Size(248, 21);
            this.tblog.TabIndex = 14;
            // 
            // cbport1
            // 
            this.cbport1.FormattingEnabled = true;
            this.cbport1.Location = new System.Drawing.Point(567, 13);
            this.cbport1.Name = "cbport1";
            this.cbport1.Size = new System.Drawing.Size(121, 21);
            this.cbport1.TabIndex = 15;
            // 
            // tblog2
            // 
            this.tblog2.Location = new System.Drawing.Point(12, 506);
            this.tblog2.Name = "tblog2";
            this.tblog2.ReadOnly = true;
            this.tblog2.Size = new System.Drawing.Size(399, 21);
            this.tblog2.TabIndex = 16;
            // 
            // tb_palletqty
            // 
            this.tb_palletqty.Location = new System.Drawing.Point(630, 289);
            this.tb_palletqty.Name = "tb_palletqty";
            this.tb_palletqty.ReadOnly = true;
            this.tb_palletqty.Size = new System.Drawing.Size(58, 21);
            this.tb_palletqty.TabIndex = 17;
            // 
            // Palletqty
            // 
            this.Palletqty.AutoSize = true;
            this.Palletqty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Palletqty.Location = new System.Drawing.Point(437, 294);
            this.Palletqty.Name = "Palletqty";
            this.Palletqty.Size = new System.Drawing.Size(177, 16);
            this.Palletqty.TabIndex = 18;
            this.Palletqty.Text = "Recommended pallet quantity";
            // 
            // lb_pos
            // 
            this.lb_pos.AutoSize = true;
            this.lb_pos.Location = new System.Drawing.Point(372, 490);
            this.lb_pos.Name = "lb_pos";
            this.lb_pos.Size = new System.Drawing.Size(46, 13);
            this.lb_pos.TabIndex = 19;
            this.lb_pos.Text = "Кол-во:";
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(440, 258);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(121, 23);
            this.bt_refresh.TabIndex = 20;
            this.bt_refresh.Text = "Обновить порты";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 538);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.lb_pos);
            this.Controls.Add(this.Palletqty);
            this.Controls.Add(this.tb_palletqty);
            this.Controls.Add(this.tblog2);
            this.Controls.Add(this.cbport1);
            this.Controls.Add(this.tblog);
            this.Controls.Add(this.cbdata);
            this.Controls.Add(this.cbstop);
            this.Controls.Add(this.cbparity);
            this.Controls.Add(this.cbrate);
            this.Controls.Add(this.cbport);
            this.Controls.Add(this.openport);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button openport;
        private System.Windows.Forms.ComboBox cbport;
        private System.Windows.Forms.ComboBox cbrate;
        private System.Windows.Forms.ComboBox cbparity;
        private System.Windows.Forms.ComboBox cbstop;
        private System.Windows.Forms.ComboBox cbdata;
        private System.Windows.Forms.ComboBox cbport1;
        public System.Windows.Forms.TextBox tblog;
        private System.Windows.Forms.TextBox tblog2;
        private System.Windows.Forms.TextBox tb_palletqty;
        private System.Windows.Forms.Label Palletqty;
        private System.Windows.Forms.Label lb_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.Button bt_refresh;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

