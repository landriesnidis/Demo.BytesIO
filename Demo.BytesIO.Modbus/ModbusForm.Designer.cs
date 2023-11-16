namespace Demo.BytesIO.Modbus
{
    partial class ModbusForm
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
            this.tab = new ApeFree.ApeForms.Core.Controls.SlideTabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModbusSerialPortRTU = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModbusTcpRTU = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModbusTcpAscii = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModbusSerialPortAscii = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 32);
            this.tab.Margin = new System.Windows.Forms.Padding(6);
            this.tab.Name = "tab";
            this.tab.Rate = 1;
            this.tab.Size = new System.Drawing.Size(1176, 810);
            this.tab.TabIndex = 3;
            this.tab.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.tab.TitleLayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModbusSerialPortAscii,
            this.tsmiModbusSerialPortRTU,
            this.tsmiModbusTcpRTU,
            this.tsmiModbusTcpAscii});
            this.新建ToolStripMenuItem.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_new_client;
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(140, 28);
            this.新建ToolStripMenuItem.Text = "创建客户端";
            // 
            // tsmiCreateTcpClient
            // 
            this.tsmiModbusSerialPortRTU.Name = "tsmiModbusSerialPortRTU";
            this.tsmiModbusSerialPortRTU.Size = new System.Drawing.Size(336, 34);
            this.tsmiModbusSerialPortRTU.Text = "Modbus SerialPort (RTU)";
            this.tsmiModbusSerialPortRTU.Click += new System.EventHandler(this.tsmiModbusSerialPortRTU_Click);
            // 
            // tsmiCreateSerialClient
            // 
            this.tsmiModbusTcpRTU.Name = "tsmiModbusTcpRTU";
            this.tsmiModbusTcpRTU.Size = new System.Drawing.Size(336, 34);
            this.tsmiModbusTcpRTU.Text = "Modbus TCP (RTU)";
            this.tsmiModbusTcpRTU.Click += new System.EventHandler(this.tsmiModbusTcpRTU_Click);
            // 
            // modbusASCII客户端ToolStripMenuItem
            // 
            this.tsmiModbusTcpAscii.Name = "tsmiModbusTcpAscii";
            this.tsmiModbusTcpAscii.Size = new System.Drawing.Size(336, 34);
            this.tsmiModbusTcpAscii.Text = "Modbus TCP (Ascii)";
            this.tsmiModbusTcpAscii.Click += new System.EventHandler(this.tsmiModbusTcpAscii_Click);
            // 
            // toolStripMenuItem1
            // 
            this.tsmiModbusSerialPortAscii.Name = "tsmiModbusSerialPortAscii";
            this.tsmiModbusSerialPortAscii.Size = new System.Drawing.Size(336, 34);
            this.tsmiModbusSerialPortAscii.Text = "Modbus SerialPort (Ascii)";
            this.tsmiModbusSerialPortAscii.Click += new System.EventHandler(this.tsmiModbusSerialPortAscii_Click);
            // 
            // ModbusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 842);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModbusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModbusForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ApeFree.ApeForms.Core.Controls.SlideTabControl tab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiModbusSerialPortRTU;
        private System.Windows.Forms.ToolStripMenuItem tsmiModbusTcpRTU;
        private System.Windows.Forms.ToolStripMenuItem tsmiModbusSerialPortAscii;
        private System.Windows.Forms.ToolStripMenuItem tsmiModbusTcpAscii;
    }
}