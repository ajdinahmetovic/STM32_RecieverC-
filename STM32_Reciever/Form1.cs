using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace STM32_Reciever
{
    public partial class Form1 : Form
    {
        string msg;
            
        public Form1()
        {
            InitializeComponent();
            

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                label3.Text = comboBox1.GetItemText(comboBox1.SelectedItem);
                serialPort1.PortName = comboBox1.GetItemText(comboBox1.SelectedItem);
                serialPort1.BaudRate = 2400;
                serialPort1.Open();

            } catch (Exception ex)
            {
                MessageBox.Show("Izaberite COM port", "Greska");
            }

            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            msg = serialPort1.ReadLine();
            this.Invoke(new EventHandler(dsiplayTXT));
        }

        private void dsiplayTXT(object sender, EventArgs e)
        {
            label1.Text = msg;
        }

    
    }
}
