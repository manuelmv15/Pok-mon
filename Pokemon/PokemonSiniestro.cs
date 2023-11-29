using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonSiniestro : Pokémon
    {
        //Un constructor para la clase
        public PokemonSiniestro(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonSiniestro
    public class Darkrai : PokemonSiniestro
    {
        //Un constructor para la clase
        public Darkrai() : base("Darkrai", Tipo.Siniestro, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Lucha);
            this.debilidades.debilidades.Add(Tipo.Bicho);
            this.debilidades.debilidades.Add(Tipo.Hada);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Golpe Bajo", 80);
            this.ataques.Add("Alarido", 55);
            this.ataques.Add("Ladrón", 60);
            this.ataques.Add("Juego Sucio", 95);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 70;
            int ataque = 135;
            int defensa = 90;
            int velocidad = 125;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
