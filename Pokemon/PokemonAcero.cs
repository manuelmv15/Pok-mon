using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonAcero : Pokémon
    {
        //Un constructor para la clase
        public PokemonAcero(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonAcero
    public class Registeel : PokemonAcero
    {
        //Un constructor para la clase
        public Registeel() : base("Registeel", Tipo.Acero, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Fuego);
            this.debilidades.debilidades.Add(Tipo.Lucha);
            this.debilidades.debilidades.Add(Tipo.Tierra);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Garra Metal", 50);
            this.ataques.Add("Foco Resplandor", 80);
            this.ataques.Add("Cuerpo Pesado", 150);
            this.ataques.Add("Cabeza Hierro", 80);
        }
        public override string ToString()
        {
            return this.nombre;
        }

        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 80;
            int ataque = 75;
            int defensa = 150;
            int velocidad = 50;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
