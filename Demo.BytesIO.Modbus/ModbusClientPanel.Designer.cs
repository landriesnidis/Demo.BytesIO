namespace Demo.BytesIO.Modbus
{
    partial class ModbusClientPanel
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pgConnectionInfo = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnDisconnect = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelRequest = new System.Windows.Forms.Panel();
            this.pgRequest = new System.Windows.Forms.PropertyGrid();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNewRequest = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEditHex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClean = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelRequest.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pgConnectionInfo);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 509);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备信息";
            // 
            // pgConnectionInfo
            // 
            this.pgConnectionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgConnectionInfo.Location = new System.Drawing.Point(3, 42);
            this.pgConnectionInfo.Name = "pgConnectionInfo";
            this.pgConnectionInfo.Size = new System.Drawing.Size(223, 464);
            this.pgConnectionInfo.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(223, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_connect;
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(52, 22);
            this.btnConnect.Text = "连接";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_disconnect;
            this.btnDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(52, 22);
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbLog);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(229, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 219);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 17);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(527, 199);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelRequest);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(229, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(533, 290);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入区";
            // 
            // panelRequest
            // 
            this.panelRequest.Controls.Add(this.pgRequest);
            this.panelRequest.Controls.Add(this.toolStrip3);
            this.panelRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRequest.Enabled = false;
            this.panelRequest.Location = new System.Drawing.Point(3, 42);
            this.panelRequest.Name = "panelRequest";
            this.panelRequest.Size = new System.Drawing.Size(527, 245);
            this.panelRequest.TabIndex = 0;
            // 
            // pgRequest
            // 
            this.pgRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgRequest.Location = new System.Drawing.Point(0, 0);
            this.pgRequest.Name = "pgRequest";
            this.pgRequest.Size = new System.Drawing.Size(527, 220);
            this.pgRequest.TabIndex = 6;
            this.pgRequest.SelectedObjectsChanged += new System.EventHandler(this.pgRequest_SelectedObjectsChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSend,
            this.toolStripSeparator1});
            this.toolStrip3.Location = new System.Drawing.Point(0, 220);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip3.Size = new System.Drawing.Size(527, 25);
            this.toolStrip3.TabIndex = 7;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnSend
            // 
            this.btnSend.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_send;
            this.btnSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(52, 22);
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewRequest,
            this.btnEditHex,
            this.toolStripSeparator2,
            this.btnClean});
            this.toolStrip2.Location = new System.Drawing.Point(3, 17);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(527, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNewRequest
            // 
            this.btnNewRequest.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_new_packet;
            this.btnNewRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewRequest.Name = "btnNewRequest";
            this.btnNewRequest.Size = new System.Drawing.Size(97, 22);
            this.btnNewRequest.Text = "新建消息包";
            // 
            // btnEditHex
            // 
            this.btnEditHex.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_edit;
            this.btnEditHex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditHex.Name = "btnEditHex";
            this.btnEditHex.Size = new System.Drawing.Size(88, 22);
            this.btnEditHex.Text = "编辑数据段";
            this.btnEditHex.Visible = false;
            this.btnEditHex.Click += new System.EventHandler(this.btnEditHex_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClean
            // 
            this.btnClean.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_clean;
            this.btnClean.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(76, 22);
            this.btnClean.Text = "清空日志";
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // ModbusClientPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModbusClientPanel";
            this.Size = new System.Drawing.Size(762, 509);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelRequest.ResumeLayout(false);
            this.panelRequest.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid pgConnectionInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton btnDisconnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripDropDownButton btnNewRequest;
        private System.Windows.Forms.Panel panelRequest;
        private System.Windows.Forms.PropertyGrid pgRequest;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnSend;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClean;
        private System.Windows.Forms.ToolStripButton btnEditHex;
    }
}

