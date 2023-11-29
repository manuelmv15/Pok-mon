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
using System.IO;

namespace Pokemon
{
    public partial class Inicio : Form
    {
        List<Pokémon> pokémons = new List<Pokémon>();
        List<Pokémon> pokémons2 = new List<Pokémon>();

        public Entrenador entrenador1 = new Entrenador();
        public Entrenador entrenador2 = new Entrenador();

        bool listo1 = false;
        bool listo2 = false;

        public Inicio()
        {
            InitializeComponent();

            mxb.URL = "Sonidos/Musica_laboratorio.wav"; //asignar la ubicación del archivo de sonido
            mxb.settings.playCount = 99; //establece el número de veces que se reproducirá el archivo de sonido.
            mxb.Ctlcontrols.play(); //inicia la reproducción del archivo de sonido.
            mxb.Visible = false; //se hace invicible

            btnComenzar.Visible = false;

            crearPokemons();

            listBoxJugador1.DisplayMember = "nombre";
            listBoxJugador2.DisplayMember = "nombre";
            foreach (var poke in pokémons)
            {
                listBoxJugador1.Items.Add(poke);
            }
            foreach (var poke in pokémons2)
            {
                listBoxJugador2.Items.Add(poke);
            }
            
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            mxb.Ctlcontrols.pause();
            JugadorN1 jg1 = new JugadorN1();
            foreach (var item in entrenador1.equipo)
            {
                jg1.entrenador1.equipo.Add(item);
            }
            foreach (var item in entrenador2.equipo)
            {
                jg1.entrenador2.equipo.Add(item);
            }
            jg1.lblNombreJugador1.Text = txtJugador1.Text;
            jg1.lblNombreJugador2.Text = txtJugador2.Text;
            this.Hide();
            jg1.ShowDialog();
        }

        private void btnPokemonElejido1_Click(object sender, EventArgs e)
        {
            if (listBoxJugador1.SelectedItem != null)
            {
                var elejirPokemon = listBoxJugador1.SelectedItem;

                Pokémon pokemonElejido = (Pokémon)elejirPokemon;

                lblNombre.Text = null;
                lblTipo1.Text = null;
                lblTipo2.Text = null;
                lblVida.Text = null;
                lblAtaque.Text = null;
                lblDefensa.Text = null;
                lblVelocidad.Text = null;

                listBoxAtaques.Items.Clear();

                if (listBoxEquipo1.Items.Count < 3)
                {
                    if (pokemonElejido.agregado == true)
                    {
                        MessageBox.Show("Este pokemon ya fue elegido");
                    }

                    else
                    {
                        listBoxEquipo1.Items.Add(elejirPokemon);
                        entrenador1.equipo.Add(pokemonElejido);
                        pokemonElejido.agregado = true;
                    }
                }
                else
                {
                    MessageBox.Show("Tu equipo Pokemon ya esta completo");
                }
            }
            else
            {
                MessageBox.Show("Elija un Pokemon!");
            }

            cargarPoke();

            listBoxJugador1.ClearSelected();
            listBoxEquipo1.ClearSelected();
        }

        private void btnPokemonElejido2_Click(object sender, EventArgs e)
        {
            if (listBoxJugador2.SelectedItem != null)
            {
                var elejirPokemon = listBoxJugador2.SelectedItem;

                Pokémon pokemonElejido = (Pokémon)elejirPokemon;

                lblNombre2.Text = null;
                lblTipo12.Text = null;
                lblTipo22.Text = null;
                lblVida2.Text = null;
                lblAtaque2.Text = null;
                lblDefensa2.Text = null;
                lblVelocidad2.Text = null;

                listBoxAtaques2.Items.Clear();

                if (listBoxEquipo2.Items.Count < 3)
                {
                    if (pokemonElejido.agregado == true)
                    {
                        MessageBox.Show("Este pokemon ya fue elegido");
                    }

                    else
                    {
                        listBoxEquipo2.Items.Add(elejirPokemon);
                        entrenador2.equipo.Add(pokemonElejido);
                        pokemonElejido.agregado = true;
                    }
                }
                else
                {
                    MessageBox.Show("Tu equipo Pokemon ya esta completo");
                }
            }
            else
            {
                MessageBox.Show("Elija un Pokemon!");
            }

            cargarPoke();

            listBoxJugador2.ClearSelected();
            listBoxEquipo2.ClearSelected();
        }

        private void listBoxJugador1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxJugador1.SelectedItem != null)
            {
                Pokémon pokémon = (Pokémon)listBoxJugador1.SelectedItem;
                lblNombre.Text = pokémon.nombre;
                lblTipo1.Text = pokémon.tipo.ToString();
                lblTipo2.Text = pokémon.tipo2.ToString();
                lblVida.Text = pokémon.estadisticas.vida.ToString();
                lblAtaque.Text = pokémon.estadisticas.ataque.ToString();
                lblDefensa.Text = pokémon.estadisticas.defensa.ToString();
                lblVelocidad.Text = pokémon.estadisticas.velocidad.ToString();

                listBoxAtaques.Items.Clear();
                foreach (var ataque in pokémon.ataques)
                {
                    listBoxAtaques.Items.Add(ataque.Key + " - " + ataque.Value);
                }
                if (listBoxJugador1.SelectedIndex != -1)
                {
                    string pokemonSeleccionado = listBoxJugador1.SelectedItem.ToString();

                    string nombreImagen = obtenerNombreImagen(pokemonSeleccionado);

                    string ruta = Path.Combine("Imagenes", nombreImagen);
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                    pictureBox1.ImageLocation = rutaCompleta;
                }
                else
                {
                    string ruta = Path.Combine("Imagenes", "default.png");
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                    pictureBox1.ImageLocation = rutaCompleta;
                }
            }
            
        }

        private void listBoxJugador2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxJugador2.SelectedItem != null)
            {
                Pokémon pokémon = (Pokémon)listBoxJugador2.SelectedItem;
                lblNombre2.Text = pokémon.nombre;
                lblTipo12.Text = pokémon.tipo.ToString();
                lblTipo22.Text = pokémon.tipo2.ToString();
                lblVida2.Text = pokémon.estadisticas.vida.ToString();
                lblAtaque2.Text = pokémon.estadisticas.ataque.ToString();
                lblDefensa2.Text = pokémon.estadisticas.defensa.ToString();
                lblVelocidad2.Text = pokémon.estadisticas.velocidad.ToString();

                listBoxAtaques2.Items.Clear();
                foreach (var ataque in pokémon.ataques)
                {
                    listBoxAtaques2.Items.Add(ataque.Key + " - " + ataque.Value);
                }

                if (listBoxJugador2.SelectedIndex != -1)
                {
                    string pokemonSeleccionado = listBoxJugador2.SelectedItem.ToString();

                    string nombreImagen = obtenerNombreImagen(pokemonSeleccionado);

                    string ruta = Path.Combine("Imagenes", nombreImagen);
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                    pictureBox1.ImageLocation = rutaCompleta;
                }
                else
                {
                    string ruta = Path.Combine("Imagenes", "default.png");
                    string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                    pictureBox1.ImageLocation = rutaCompleta;
                }
            }
            
        }

        private void btnListo1_Click(object sender, EventArgs e)
        {
            if (listBoxEquipo1.Items.Count >= 1)
            {
                listo1 = true;

                listBoxEquipo1.Enabled = false;
                listBoxJugador1.Enabled = false;
                txtJugador1.Enabled = false;
                btnPokemonElejido1.Enabled = false;
                this.btnListo1.Enabled = false;

                if ((listBoxEquipo1.Items.Count >= 1) && listo1 == true && listo2 == true)
                {
                    btnComenzar.Visible = true;

                    listBoxJugador1.ClearSelected();
                    listBoxEquipo1.ClearSelected();
                }

            }
            else if (listBoxEquipo1.Items.Count == 0)
            {
                MessageBox.Show("Elige al menos un pokemon");
            }
            cargarPoke();
        }

        private void btnListo2_Click(object sender, EventArgs e)
        {
            if (listBoxEquipo2.Items.Count >= 1)
            {
                listo2 = true;

                listBoxEquipo2.Enabled = false;
                listBoxJugador2.Enabled = false;
                txtJugador2.Enabled = false;
                btnPokemonElejido2.Enabled = false;
                this.btnListo2.Enabled = false;

                if ((listBoxEquipo2.Items.Count >= 1) && listo1 == true && listo2 == true)
                {
                    btnComenzar.Visible = true;

                    listBoxJugador2.ClearSelected();
                }

            }
            else if (listBoxEquipo2.Items.Count == 0)
            {
                MessageBox.Show("Elige al menos un pokemon");
            }
            cargarPoke();
        }
        
        public  string obtenerNombreImagen(string pokemon)
        {

            if (pokemon == "Charizard")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/006.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "006.png";
            }
            else if (pokemon == "Blastoise")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/009.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "009.png";
            }
            else if (pokemon == "Pikachu")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/025.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "025.png";
            }
            else if (pokemon == "Venusaur")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/003.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "003.png";
            }
            else if (pokemon == "Alakazam")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/065.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "065.png";
            }
            else if (pokemon == "Marowak")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/105.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "105.png";
            }
            else if (pokemon == "Tauros")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/128.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "128.png";
            }
            else if (pokemon == "Sudowoodo")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/185.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "185.png";
            }
            else if (pokemon == "Registeel")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/379.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "379.png";
            }
            else if (pokemon == "Darkrai")
            {
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sonidos/491.wav");
                SoundPlayer sonido = new SoundPlayer(rutaCompleta);
                sonido.Play();

                return "491.png";
            }
            return "default.png";
        }
        private void cargarPoke()
        {
            string ruta = Path.Combine("Imagenes", "default.png");
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

            pictureBox1.ImageLocation = rutaCompleta;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void crearPokemons()
        {
            pokémons.Add(new Charizard());
            pokémons.Add(new Blastoise());
            pokémons.Add(new Pikachu());
            pokémons.Add(new Marowak());
            pokémons.Add(new Venusaur());
            pokémons.Add(new Sudowoodo());
            pokémons.Add(new Registeel());
            pokémons.Add(new Darkrai());
            pokémons.Add(new Alakazam());
            pokémons.Add(new Tauros());

            pokémons2.Add(new Charizard());
            pokémons2.Add(new Blastoise());
            pokémons2.Add(new Pikachu());
            pokémons2.Add(new Marowak());
            pokémons2.Add(new Venusaur());
            pokémons2.Add(new Sudowoodo());
            pokémons2.Add(new Registeel());
            pokémons2.Add(new Darkrai());
            pokémons2.Add(new Alakazam());
            pokémons2.Add(new Tauros());
        }
    }
}
