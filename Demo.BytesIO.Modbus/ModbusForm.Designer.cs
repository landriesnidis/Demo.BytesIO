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
            this.tsmiCreateTcpClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateSerialClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 25);
            this.tab.Name = "tab";
            this.tab.Size = new System.Drawing.Size(784, 536);
            this.tab.TabIndex = 3;
            this.tab.TitleDock = System.Windows.Forms.DockStyle.Top;
            this.tab.TitleLayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreateTcpClient,
            this.tsmiCreateSerialClient});
            this.新建ToolStripMenuItem.Image = global::Demo.BytesIO.Modbus.Properties.Resources.ic_new_client;
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.新建ToolStripMenuItem.Text = "创建客户端";
            // 
            // tsmiCreateTcpClient
            // 
            this.tsmiCreateTcpClient.Name = "tsmiCreateTcpClient";
            this.tsmiCreateTcpClient.Size = new System.Drawing.Size(185, 22);
            this.tsmiCreateTcpClient.Text = "ModbusTCP客户端";
            this.tsmiCreateTcpClient.Click += new System.EventHandler(this.tsmiCreateTcpClient_Click);
            // 
            // tsmiCreateSerialClient
            // 
            this.tsmiCreateSerialClient.Name = "tsmiCreateSerialClient";
            this.tsmiCreateSerialClient.Size = new System.Drawing.Size(185, 22);
            this.tsmiCreateSerialClient.Text = "ModbusRTU客户端";
            this.tsmiCreateSerialClient.Click += new System.EventHandler(this.tsmiCreateSerialClient_Click);
            // 
            // ModbusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateTcpClient;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateSerialClient;
    }
}