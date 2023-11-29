using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon
{
    public partial class Ganador : Form
    {
        public Ganador()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            mxb.Ctlcontrols.stop();
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Ganador_Load(object sender, EventArgs e)
        {
            mxb.URL = "Sonidos/Musica_Final.wav"; //asignar la ubicación del archivo de sonido
            mxb.settings.playCount = 99; //establece el número de veces que se reproducirá el archivo de sonido.
            mxb.Ctlcontrols.play(); //inicia la reproducción del archivo de sonido.
            mxb.Visible = false; //se hace invicible
        }
    }
}
