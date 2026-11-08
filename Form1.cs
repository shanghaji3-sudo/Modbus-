using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NModbus;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient;
        private IModbusMaster master;

        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            string ip=textBox1.Text;
            int port = int.Parse(textBox1.Text);    

            tcpClient = new TcpClient();
            tcpClient.Connect(ip, port);

            ModbusFactory modbusFactory = new ModbusFactory();
            master = modbusFactory.CreateMaster(tcpClient);

            ushort[] registers = await Task.Run(() => {
                return master.ReadHoldingRegisters(1, 0, 1);
            });

        }
    }
}
