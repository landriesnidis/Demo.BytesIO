namespace Demo.BytesIO.EchoClient
{
    partial class EchoForm
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
            this.tbarDelay = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labDelay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudBaudRate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cbPortName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbarDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaudRate)).BeginInit();
            this.SuspendLayout();
            // 
            // tbarDelay
            // 
            this.tbarDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbarDelay.Location = new System.Drawing.Point(3, 94);
            this.tbarDelay.Name = "tbarDelay";
            this.tbarDelay.Size = new System.Drawing.Size(212, 45);
            this.tbarDelay.TabIndex = 0;
            this.tbarDelay.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbarDelay.Value = 1;
            this.tbarDelay.ValueChanged += new System.EventHandler(this.tbarDelay_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labDelay);
            this.groupBox1.Controls.Add(this.tbarDelay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudBaudRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.cbPortName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 216);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // labDelay
            // 
            this.labDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.labDelay.ForeColor = System.Drawing.Color.Gray;
            this.labDelay.Location = new System.Drawing.Point(3, 139);
            this.labDelay.Name = "labDelay";
            this.labDelay.Size = new System.Drawing.Size(212, 12);
            this.labDelay.TabIndex = 7;
            this.labDelay.Text = "0 ms";
            this.labDelay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "延迟时间";
            // 
            // nudBaudRate
            // 
            this.nudBaudRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudBaudRate.Location = new System.Drawing.Point(3, 61);
            this.nudBaudRate.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudBaudRate.Name = "nudBaudRate";
            this.nudBaudRate.Size = new System.Drawing.Size(212, 21);
            this.nudBaudRate.TabIndex = 6;
            this.nudBaudRate.Value = new decimal(new int[] {
            9600,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "波特率";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(137, 187);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cbPortName
            // 
            this.cbPortName.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPortName.FormattingEnabled = true;
            this.cbPortName.Location = new System.Drawing.Point(3, 29);
            this.cbPortName.Name = "cbPortName";
            this.cbPortName.Size = new System.Drawing.Size(212, 20);
            this.cbPortName.TabIndex = 3;
            this.cbPortName.DropDown += new System.EventHandler(this.cbPortName_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口";
            // 
            // EchoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 384);
            this.Controls.Add(this.groupBox1);
            this.Name = "EchoForm";
            this.Text = "Echo Client";
            ((System.ComponentModel.ISupportInitialize)(this.tbarDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBaudRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tbarDelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.NumericUpDown nudBaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labDelay;
    }
}

