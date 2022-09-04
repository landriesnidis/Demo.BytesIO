using STTech.BytesIO.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.BytesIO.Modbus
{
    public partial class ModbusForm : Form
    {
        public ModbusForm()
        {
            InitializeComponent();
        }

        private void tsmiCreateTcpClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("ModbusTCP", new ModbusClientPanel(new ModbusTcpClient()));
        }

        private void tsmiCreateSerialClient_Click(object sender, EventArgs e)
        {
            tab.AddPage("ModbusRTU", new ModbusClientPanel(new ModbusRtuClient() { ReceiveBufferSize = 65536, SendBufferSize = 65536 }));
        }
    }
}
