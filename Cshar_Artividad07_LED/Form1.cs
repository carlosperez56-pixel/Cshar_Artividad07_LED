using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //Libreria de comunicación SERIAL

namespace Cshar_Artividad07_LED
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }

        public Form1()
        {
            InitializeComponent();

            // Configuración de Comunicación SERIAL
            ArduinoPort = new SerialPort();
            ArduinoPort.PortName = "COM9"; // Verificar con la configuración de su equipo
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();
            

            // Manejadores de Eventos
            this.FormClosing += CerrandoForm1;
            this.btnEncender.Click += btnEncender_Click;
            this.btnApagar.Click += btnApagar_Click;
        }

        private void CerrandoForm1(object sender, EventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                ArduinoPort.Close();
            }
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
    }
}
