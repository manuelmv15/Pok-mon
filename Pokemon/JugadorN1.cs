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
    public partial class JugadorN1 : Form //Iniciar el form Inicio
    {
        public Entrenador entrenador1 = new Entrenador(); //Iniciar ambos entrenadores
        public Entrenador entrenador2 = new Entrenador();

        bool listo1 = false; //Inicia todas las variables 
        bool listo2 = false;
        bool turno1 = false;
        bool turno2 = false;

        bool ganoJugador1 = false;
        bool ganoJugador2 = false;

        int daño1;
        int daño2;
        int daño3;
        int daño4;
        int daño12;
        int daño22;
        int daño32;
        int daño42;

        public JugadorN1()
        {
            InitializeComponent();

            mxb.URL = "Sonidos/mpkm.wav"; //asignar la ubicación del archivo de sonido
            mxb.settings.playCount = 99; //establece el número de veces que se reproducirá el archivo de sonido.
            mxb.Ctlcontrols.play(); //inicia la reproducción del archivo de sonido.
            mxb.Visible = false; //se hace invicible

            btnAtaque1.Visible = false; //Ocultar los botones de ataque hasta que se seleccione un pokemon
            btnAtaque3.Visible = false;
            btnAtaque2.Visible = false;
            btnAtaque4.Visible = false;
            btnAtaque12.Visible = false;
            btnAtaque22.Visible = false;
            btnAtaque32.Visible = false;
            btnAtaque42.Visible = false;
            progressBarVida1.Visible = false;
            progressBarVida2.Visible = false;

        }

        //Inicializar el equipo del jugador 1
        private void btnInicio_Click(object sender, EventArgs e)
        {
            progressBarVida1.Visible = true;//Iniciar la barra de vida del primer pokemon

            Pokémon pokémon = (Pokémon)listBoxEquipo1.SelectedItem; //Pasar todos los datos del pokemon a las etiquetas
            progressBarVida1.Value = barra(pokémon.estadisticas.vidaMax, pokémon.estadisticas.vida);
            lblNombre.Text = pokémon.nombre;
            lblTipo1.Text = pokémon.tipo.ToString();
            lblTipo2.Text = pokémon.tipo2.ToString();
            lblVida.Text = pokémon.estadisticas.vida.ToString();
            lblAtaque.Text = pokémon.estadisticas.ataque.ToString();
            lblDefensa.Text = pokémon.estadisticas.defensa.ToString();
            lblVelocidad.Text = pokémon.estadisticas.velocidad.ToString();

            listBoxAtaque1.Items.Clear();
            foreach (var ataque in pokémon.ataques) //Declarar un bucle para mostrar las estadisticas de ataque
            {
                listBoxAtaque1.Items.Add(ataque.Key + " - " + ataque.Value);
            }

            listo1 = true; //Habilitar el boton de listo del jugador 1
            listos();
            btnSeleccion1.Visible = false;
            listBoxEquipo1.Enabled = false;
        }

        //Inicializar el equipo del jugador 2
        private void button1_Click(object sender, EventArgs e)
        {
            progressBarVida2.Visible = true;//Iniciar la barra de vida del primer pokemon 
            Pokémon pokémon = (Pokémon)listBoxEquipo2.SelectedItem;
            progressBarVida2.Value = barra(pokémon.estadisticas.vidaMax, pokémon.estadisticas.vida);
            lblNombre2.Text = pokémon.nombre;
            lblTipo12.Text = pokémon.tipo.ToString();
            lblTipo22.Text = pokémon.tipo2.ToString();
            lblVida2.Text = pokémon.estadisticas.vida.ToString();
            lblAtaque2.Text = pokémon.estadisticas.ataque.ToString();
            lblDefensa2.Text = pokémon.estadisticas.defensa.ToString();
            lblVelocidad2.Text = pokémon.estadisticas.velocidad.ToString();

            listBoxAtaque2.Items.Clear();
            foreach (var ataque in pokémon.ataques)
            {
                listBoxAtaque2.Items.Add(ataque.Key + " - " + ataque.Value);

            }

            listo2 = true;//Habilitar el boton de listo del jugador 1
            listos();
            listos();
            btnSeleccion2.Visible = false;
            listBoxEquipo2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEquipo1.SelectedItem != null)
            {
                cargarEquipo1(); //Cargar la lista de pokemones del equipo 1

                btnAtaque1.Visible = false; //Mostrar los botones al haber seleccionado un pokemon
                btnAtaque3.Visible = false;
                btnAtaque2.Visible = false;
                btnAtaque4.Visible = false;
            }
            //Colocar la imagen del pokemon segun sea seleccionado en la lista del equipo 1
            if (listBoxEquipo1.SelectedIndex != -1)
            {
                string pokemonSeleccionado = listBoxEquipo1.SelectedItem.ToString();

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

        private void listBoxEquipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEquipo2.SelectedItem != null)
            {
                cargarEquipo2(); //Cargar la lista de pokemones del equipo 2

                btnAtaque12.Visible = false; //Mostrar los botones al haber seleccionado un pokemon
                btnAtaque22.Visible = false;
                btnAtaque32.Visible = false;
                btnAtaque42.Visible = false;
            }
            //Colocar la imagen del pokemon segun sea seleccionado en la lista del equipo 2
            if (listBoxEquipo2.SelectedIndex != -1)
            {
                string pokemonSeleccionado = listBoxEquipo2.SelectedItem.ToString();

                string nombreImagen = obtenerNombreImagen(pokemonSeleccionado);

                string ruta = Path.Combine("Imagenes", nombreImagen);
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                pictureBox2.ImageLocation = rutaCompleta;
            }
            else
            {
                string ruta = Path.Combine("Imagenes", "default.png");
                string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);

                pictureBox2.ImageLocation = rutaCompleta;
            }
        }

        private void btnAtaque1_Click(object sender, EventArgs e)//Metodo del primer ataque del pokemon seleccionado
        {                                                        //del equipo 1
            Pokémon pokémon1 = (Pokémon)listBoxEquipo1.SelectedItem;
            dañoAtaque1(daño1, pokémon1.tipo, pokémon1.tipo2);
        }

        private void btnAtaque12_Click(object sender, EventArgs e)//Metodo del primer ataque del pokemon seleccionado
        {                                                         //del equipo 2
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            dañoAtaque2(daño12, pokémon2.tipo, pokémon2.tipo2);
        }
        private void btnAtaque2_Click(object sender, EventArgs e)//Metodo del primer ataque del pokemon seleccionado
        {                                                        //del equipo 1
            Pokémon pokémon1 = (Pokémon)listBoxEquipo1.SelectedItem;
            dañoAtaque1(daño2, pokémon1.tipo, pokémon1.tipo2);
        }

        private void btnAtaque22_Click(object sender, EventArgs e)//Metodo del primer ataque del pokemon seleccionado
        {                                                         //del equipo 2
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            dañoAtaque2(daño22, pokémon2.tipo, pokémon2.tipo2);
        }

        private void btnAtaque3_Click(object sender, EventArgs e)//Metodo del primer ataque del pokemon seleccionado
        {                                                        //del equipo 1
            Pokémon pokémon1 = (Pokémon)listBoxEquipo1.SelectedItem;
            dañoAtaque1(daño3, pokémon1.tipo, pokémon1.tipo2);
        }

        private void btnAtaque32_Click(object sender, EventArgs e)//Metodo del tercer ataque del pokemon seleccionado
        {                                                         //del equipo 2
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            dañoAtaque2(daño32, pokémon2.tipo, pokémon2.tipo2);
        }

        private void btnAtaque4_Click(object sender, EventArgs e)//Metodo del tercer ataque del pokemon seleccionado
        {                                                        //del equipo 1

            Pokémon pokémon1 = (Pokémon)listBoxEquipo1.SelectedItem;
            dañoAtaque1(daño4, pokémon1.tipo, pokémon1.tipo2);
        }

        private void btnAtaque42_Click(object sender, EventArgs e)//Metodo del tercer ataque del pokemon seleccionado
        {                                                         //del equipo 1
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            dañoAtaque2(daño42, pokémon2.tipo, pokémon2.tipo2);
        }

        private void botonesDes1()//Metodo para indicar el turno del ataque del jugador  1
        {
            btnSeleccion1.Visible = true;//Identificar si el boton de seleccion esta activo
            btnSeleccion2.Visible = false;

            listBoxEquipo1.Enabled = true;
            listBoxEquipo2.Enabled = false;

            if (listBoxEquipo1.Enabled == true)//Evaluar si la lista esta activa
            {
                turnoEquipo2.BackColor = Color.Red;//Si se cumple se mostrara en pantalla una barra verde sino una roja
                turnoEquipo1.BackColor = Color.Green;
            }

            btnAtaque1.Visible = true;//Habilitar los botones segun el turno del jugador 
            btnAtaque3.Visible = true;
            btnAtaque2.Visible = true;
            btnAtaque4.Visible = true;

            btnAtaque12.Visible = false;
            btnAtaque22.Visible = false;
            btnAtaque32.Visible = false;
            btnAtaque42.Visible = false;

            cargarEquipo1();
        }
        private void botonesDes2()
        {
            btnSeleccion1.Visible = false;
            btnSeleccion2.Visible = true;

            listBoxEquipo1.Enabled = false;
            listBoxEquipo2.Enabled = true;

            if (listBoxEquipo2.Enabled == true)
            {
                turnoEquipo2.BackColor = Color.Green;
                turnoEquipo1.BackColor = Color.Red;
            }

            btnAtaque1.Visible = false;
            btnAtaque3.Visible = false;
            btnAtaque2.Visible = false;
            btnAtaque4.Visible = false;

            btnAtaque12.Visible = true;
            btnAtaque22.Visible = true;
            btnAtaque32.Visible = true;
            btnAtaque42.Visible = true;

            cargarEquipo2();
        }
        private void listos()
        {
            if (listo1 == true && listo2 == true)
            {
                Pokémon pokémon1 = (Pokémon)listBoxEquipo1.SelectedItem;
                Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;

                if (pokémon1.estadisticas.velocidad >= pokémon2.estadisticas.velocidad)//Si el pokemon 1 tiene mayor velocidad 
                                                                                       //empezara el jugador 1
                {
                    turno1 = true;
                    turno2 = false;
                }
                else if (pokémon1.estadisticas.velocidad < pokémon2.estadisticas.velocidad)//Sino empezara el jugador 2
                {
                    turno1 = false;
                    turno2 = true;
                }
            }
            turno();//Implementar el metodo de turno para empezar la batalla
        }
        private void cargarEquipo1()//Metodo para mostrar el equipo 1
        {
            if (listBoxEquipo1.SelectedItems != null)
            {
                lblDaño2.Text = "";
                lblDañoTipo2.Text = "";

                Pokémon pokémon = (Pokémon)listBoxEquipo1.SelectedItem;
                lblNombre.Text = pokémon.nombre;
                lblTipo1.Text = pokémon.tipo.ToString();
                lblTipo2.Text = pokémon.tipo2.ToString();
                lblVida.Text = pokémon.estadisticas.vida.ToString();
                lblAtaque.Text = pokémon.estadisticas.ataque.ToString();
                lblDefensa.Text = pokémon.estadisticas.defensa.ToString();
                lblVelocidad.Text = pokémon.estadisticas.velocidad.ToString();

                listBoxAtaque1.Items.Clear();
                foreach (var ataque in pokémon.ataques)
                {
                    listBoxAtaque1.Items.Add(ataque.Key + " - " + ataque.Value);
                }

                int i = 1;
                foreach (var ataque in pokémon.ataques)
                {
                    switch (i)
                    {
                        case 1:
                            btnAtaque1.Text = ataque.Key;
                            daño1 = ataque.Value;
                            break;
                        case 2:
                            btnAtaque2.Text = ataque.Key;
                            daño2 = ataque.Value;
                            break;
                        case 3:
                            btnAtaque3.Text = ataque.Key;
                            daño3 = ataque.Value;
                            break;
                        case 4:
                            btnAtaque4.Text = ataque.Key;
                            daño4 = ataque.Value;
                            break;
                    }
                    i++;
                }
            }
        }
        private void cargarEquipo2()//Metodo para mostrar el equipo 2
        {
            if (listBoxEquipo2.SelectedItems != null)
            {
                lblDaño1.Text = "";
                lblDañoTipo1.Text = "";

                Pokémon pokémon = (Pokémon)listBoxEquipo2.SelectedItem;
                lblNombre2.Text = pokémon.nombre;
                lblTipo12.Text = pokémon.tipo.ToString();
                lblTipo22.Text = pokémon.tipo2.ToString();
                lblVida2.Text = pokémon.estadisticas.vida.ToString();
                lblAtaque2.Text = pokémon.estadisticas.ataque.ToString();
                lblDefensa2.Text = pokémon.estadisticas.defensa.ToString();
                lblVelocidad2.Text = pokémon.estadisticas.velocidad.ToString();

                listBoxAtaque2.Items.Clear();
                foreach (var ataque in pokémon.ataques)
                {
                    listBoxAtaque2.Items.Add(ataque.Key + " - " + ataque.Value);

                }

                int i = 1;
                foreach (var ataque in pokémon.ataques)
                {
                    switch (i)
                    {
                        case 1:
                            btnAtaque12.Text = ataque.Key;
                            daño12 = ataque.Value;
                            break;
                        case 2:
                            btnAtaque22.Text = ataque.Key;
                            daño22 = ataque.Value;
                            break;
                        case 3:
                            btnAtaque32.Text = ataque.Key;
                            daño32 = ataque.Value;
                            break;
                        case 4:
                            btnAtaque42.Text = ataque.Key;
                            daño42 = ataque.Value;
                            break;
                    }
                    i++;
                }

            }
        }
        private void turno()//Metodo para saber de que jugador es el turno
        {
            if (turno1 == true && turno2 == false)//Si el turno del jugador 1 esta activado
                                                  //invocar el metodo botonesDes1() para mostrar en pantalla una barra de color verde
            {
                botonesDes1();
            }
            if (turno1 == false && turno2 == true)//Si el turno del jugador 2 esta activado
                                                  //invocar el metodo botonesDes1() para mostrar en pantalla una barra de color verde
            {
                botonesDes2();
            }
        }
        
        private void dañoAtaque1(int dañoHabilidad, Tipo tipoAtaque, Tipo tipoAtaque2)//Metodo para calcular el ataque critico 1
        {
            lblDaño1.Text = "";
            lblDaño2.Text = "";
            lblDañoTipo1.Text = "";
            lblDañoTipo2.Text = "";

            Pokémon pokémon = (Pokémon)listBoxEquipo1.SelectedItem;
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            Random random = new Random();
            int vida = pokémon2.estadisticas.vidaMax;
            int ataqueRival = pokémon.estadisticas.ataque;
            int defensa = pokémon2.estadisticas.defensa;

            bool esDebilidad = pokémon2.debilidades.debilidades.Contains(tipoAtaque);
            bool esDebilidad2 = pokémon2.debilidades.debilidades.Contains(tipoAtaque2);

            int daño = calcularDaño(vida, defensa, ataqueRival, dañoHabilidad);

            if (esDebilidad)
            {
                daño = (int)(daño * 1.25);
                lblDañoTipo2.Text = "Super efectivo";
            }
            else if (esDebilidad2)
            {
                daño = (int)(daño * 1.25);
                lblDañoTipo2.Text = "Super efectivo";
            }

            int numero = random.Next(1,11); //Definir un numero random para hacer el daño critico del pokemon
            switch (numero)
            {
                case 1:
                    daño = (daño * 2);//Si esta en el rango de 1 a 4 sera golpe critico
                    lblDaño2.Text = "Critico";
                    break;
                case 2:
                    daño = (daño * 2);
                    lblDaño2.Text = "Critico";
                    break;
                case 3:
                    daño = (daño * 2);
                    lblDaño2.Text = "Critico";
                    break;
                case 4:
                    daño = (daño * 2);
                    lblDaño2.Text = "Critico";
                    break;
                default:
                    break;
            }

            if (daño < 0)
            {
                pokémon2.estadisticas.vida -= Math.Abs(daño);
            }
            progressBarVida2.Value = barra(pokémon2.estadisticas.vidaMax, pokémon2.estadisticas.vida);
            botonesDes2();

            if (pokémon2.estadisticas.vida <= 0)
            {
                eliminarPokemon1();
            }

            if (listBoxEquipo2.Items.Count == 0)
            {
                ganoJugador1 = true;
            }

            ganador();
        }
        private void dañoAtaque2(int dañoHabilidad, Tipo tipoAtaque, Tipo tipoAtaque2)//Metodo para calcular el ataque critico 1
        {
            lblDaño1.Text = "";
            lblDaño2.Text = "";
            lblDañoTipo1.Text = "";
            lblDañoTipo2.Text = "";

            Pokémon pokémon = (Pokémon)listBoxEquipo1.SelectedItem;
            Pokémon pokémon2 = (Pokémon)listBoxEquipo2.SelectedItem;
            Random random = new Random();
            int vida = pokémon.estadisticas.vidaMax;
            int ataqueRival = pokémon2.estadisticas.ataque;
            int defensa = pokémon.estadisticas.defensa;

            bool esDebilidad = pokémon.debilidades.debilidades.Contains(tipoAtaque);
            bool esDebilidad2 = pokémon.debilidades.debilidades.Contains(tipoAtaque2);

            int daño = calcularDaño(vida, defensa, ataqueRival, dañoHabilidad);

            if (esDebilidad)
            {
                daño = (int)(daño * 1.25);
                lblDañoTipo1.Text = "Super efectivo";
            }
            else if (esDebilidad2)
            {
                daño = (int)(daño * 1.25);
                lblDañoTipo1.Text = "Super efectivo";
            }

            int numero = random.Next(1, 11);
            switch (numero)
            {
                case 1:
                    daño = (daño * 2);//Si esta en el rango de 1 a 4 sera golpe critico
                    lblDaño1.Text = "Critico";
                    break;
                case 2:
                    daño = (daño * 2);
                    lblDaño1.Text = "Critico";
                    break;
                case 3:
                    daño = (daño * 2);
                    lblDaño1.Text = "Critico";
                    break;
                case 4:
                    daño = (daño * 2);
                    lblDaño1.Text = "Critico";
                    break;
                default:
                    break;
            }

            if (daño < 0)
            {
                pokémon.estadisticas.vida -= Math.Abs(daño);
            }
            progressBarVida1.Value = barra(pokémon.estadisticas.vidaMax, pokémon.estadisticas.vida);
            botonesDes1();

            if (pokémon.estadisticas.vida <= 0)//Evaluar si un pokemon llego a 0 de vida
            {
                eliminarPokemon2(); //Si se cumple el pokemon se elimina
            
            }

            if (listBoxEquipo1.Items.Count == 0)//Evaluar si la lista del equipo 1 esta vacia para validar que el jugador2 gano 
            {
                ganoJugador2 = true;
            }

            ganador();//Invocar el metodo para evaluar un ganador
        }
        private int calcularDaño(int vida, int defensa, int ataqueRival, int ataque)
        {
            // int daño = ((vida) + defensa) - (ataqueRival + ataque); Esta es la formula de daño de antes si quieren se puede reutilizar

           //Este cálculo se encarga de ver la potencia de ataque
            int atq = ataqueRival * ataque;

            //En los juegos hay un random de que tanta potencia tendrá el ataque aquí para no complicarnos le daremos algo predefinido
            int beneficio = Convert.ToInt32(0.01 * 85);

            //En los juegos se le da un bonus de daño por nivel pero aquí los trataremos a todos por igual con una fórmula predefinida
            int bonus = Convert.ToInt32(0.10 * 50 + 1);

            //Un cálculo simple para ver la resistencia del rival para con el daño y un multiplicador algo alto para que no sea eliminado fácil
            int def = 40 * defensa;

            //Este es ya el cálculo de cuanto daño recibirá el pokemon
            int daño = Convert.ToInt32(-0.95 * beneficio * ((((bonus) * atq) / def) + 2));

            return daño;
        }

        private void cargarEquipo(ListBox listBox, List<Pokémon> pokemon)//Agregar los pokemones seleccionados a una listbox
        {
            foreach (var item in pokemon)//Declarar un blucle para agregar todos los pokemones
            {
                listBox.Items.Add(item);
            }
        }

        private void JugadorN1_Load(object sender, EventArgs e)
        {
            cargarEquipo(listBoxEquipo1, entrenador1.equipo);//Cargar ambos equipos
            cargarEquipo(listBoxEquipo2, entrenador2.equipo);
        }

        //Vaciar las etiquetas del equipo2 si el turno del equipo1 esta activo
        private void vacio1()
        {
            lblDaño1.Text = "";
            lblDaño2.Text = "";
            lblDañoTipo1.Text = "";
            lblDañoTipo2.Text = "";

            lblNombre.Text = "";
            lblTipo1.Text = "";
            lblTipo2.Text = "";
            lblVida.Text = "";
            lblAtaque.Text = "";
            lblDefensa.Text = "";
            lblVelocidad.Text = "";

            listBoxAtaque1.Items.Clear();

            btnAtaque1.Visible = false;
            btnAtaque3.Visible = false;
            btnAtaque2.Visible = false;
            btnAtaque4.Visible = false;
            btnAtaque12.Visible = false;
            btnAtaque22.Visible = false;
            btnAtaque32.Visible = false;
            btnAtaque42.Visible = false;

            btnSeleccion1.Visible = true;
            btnSeleccion2.Visible = false;

            listBoxEquipo1.Enabled = true;
            listBoxEquipo2.Enabled = false;

            progressBarVida1.Visible = false;

            if (listBoxEquipo1.Enabled == true)
            {
                turnoEquipo2.BackColor = Color.Red;
                turnoEquipo1.BackColor = Color.Green;
            }
        }

        //Vaciar las etiquetas del equipo1 si el turno del equipo2 esta activo
        private void vacio2()
        {
            lblDaño1.Text = "";
            lblDaño2.Text = "";
            lblDañoTipo1.Text = "";
            lblDañoTipo2.Text = "";

            lblNombre2.Text = "";
            lblTipo12.Text = "";
            lblTipo22.Text = "";
            lblVida2.Text = "";
            lblAtaque2.Text = "";
            lblDefensa2.Text = "";
            lblVelocidad2.Text = "";

            listBoxAtaque2.Items.Clear();

            btnAtaque1.Visible = false;
            btnAtaque3.Visible = false;
            btnAtaque2.Visible = false;
            btnAtaque4.Visible = false;
            btnAtaque12.Visible = false;
            btnAtaque22.Visible = false;
            btnAtaque32.Visible = false;
            btnAtaque42.Visible = false;

            btnSeleccion1.Visible = false;
            btnSeleccion2.Visible = true;

            listBoxEquipo1.Enabled = false;
            listBoxEquipo2.Enabled = true;

            progressBarVida2.Visible = false;

            if (listBoxEquipo2.Enabled == true)
            {
                turnoEquipo2.BackColor = Color.Green;
                turnoEquipo1.BackColor = Color.Red;
            }
        }
        
        private void eliminarPokemon1()//Metodo para eliminar un pokemon del equipo2
        {
            Pokémon pokemonSeleccionado = (Pokémon)listBoxEquipo2.SelectedItem;
            if (pokemonSeleccionado.estadisticas.vida <= 0)//Validar si ha perdido toda la vida
            {
                listBoxEquipo2.Items.Remove(pokemonSeleccionado);
                listo1 = false;
                listo2 = false;
                turno1 = false;
                turno2 = true;
                vacio2();
                listBoxEquipo2.SelectedIndex = -1;
            }
        }
        private void eliminarPokemon2()//Metodo para eliminar un pokemon del equipo2
        {
            Pokémon pokemonSeleccionado = (Pokémon)listBoxEquipo1.SelectedItem;
            if (pokemonSeleccionado.estadisticas.vida <= 0)//Validar si ha perdido toda la vida
            {
                listBoxEquipo1.Items.Remove(pokemonSeleccionado);
                listo1 = false;
                listo2 = false;
                turno1 = true;
                turno2 = false;
                vacio1();
                listBoxEquipo1.SelectedIndex = -1;
            }
        }
        int barra(int vida_maxima, int vida)//Iniciar la barra de vida de los pokemones seleccionados
        {
            int retornar = 0;
            if (vida > 0)//Evaluar si el pokemon tiene vida
            {

                retornar = (vida * 100) / vida_maxima;
            }
            else retornar = 0;

            return retornar;
        }
        private void ganador()//Metodo para definir el ganador
        {
            Ganador ganador = new Ganador();

            if (ganoJugador1 == true)
            {
                ganador.lblGanador.Text = lblNombreJugador1.Text;
                foreach (var item in listBoxEquipo1.Items)
                {
                    ganador.listBox1.Items.Add(item);
                }
                mxb.Ctlcontrols.stop();
                this.Hide();
                ganador.ShowDialog();

            }
            if (ganoJugador2 == true)
            {
                ganador.lblGanador.Text = lblNombreJugador2.Text;
                foreach (var item in listBoxEquipo2.Items)
                {
                    ganador.listBox1.Items.Add(item);
                }
                mxb.Ctlcontrols.stop();
                this.Hide();
                ganador.ShowDialog();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string obtenerNombreImagen(string pokemon)
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
    }
}
