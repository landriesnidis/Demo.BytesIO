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

        private void tsmiModbusSerialPortRTU_Click(object sender, EventArgs e)
        {
            tab.AddPage((sender as ToolStripItem).Text, new ModbusClientPanel(new ModbusSerialClient(ModbusProtocolFormat.RTU)));
        }

        private void tsmiModbusTcpRTU_Click(object sender, EventArgs e)
        {
            tab.AddPage((sender as ToolStripItem).Text, new ModbusClientPanel(new ModbusTcpClient(ModbusProtocolFormat.RTU) { ReceiveBufferSize = 65536, SendBufferSize = 65536, ProtocolFormat = ModbusProtocolFormat.RTU }));
        }

        private void tsmiModbusTcpAscii_Click(object sender, EventArgs e)
        {
            tab.AddPage((sender as ToolStripItem).Text, new ModbusClientPanel(new ModbusTcpClient(ModbusProtocolFormat.ASCII) { ReceiveBufferSize = 65536, SendBufferSize = 65536, ProtocolFormat = ModbusProtocolFormat.ASCII }));
        }

        private void tsmiModbusSerialPortAscii_Click(object sender, EventArgs e)
        {
            tab.AddPage((sender as ToolStripItem).Text, new ModbusClientPanel(new ModbusSerialClient(ModbusProtocolFormat.ASCII)));
        }
    }
}
