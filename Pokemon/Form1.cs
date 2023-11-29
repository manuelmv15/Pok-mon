using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            mxb.URL = "Sonidos/Intro_el_mejor.wav"; //asignar la ubicación del archivo de sonido
            mxb.settings.playCount = 99; //establece el número de veces que se reproducirá el archivo de sonido.
            mxb.Ctlcontrols.play(); //inicia la reproducción del archivo de sonido.
            mxb.Visible = false; //se hace invicible
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            mxb.Ctlcontrols.stop();
            Inicio inicio = new Inicio();
            this.Hide();
            inicio.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
