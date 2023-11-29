using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonNormal : Pokémon
    {
        //Un constructor para la clase
        public PokemonNormal(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonNormal
    public class Tauros : PokemonNormal
    {
        //Un constructor para la clase
        public Tauros() : base("Tauros", Tipo.Normal, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Lucha);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Placaje", 50);
            this.ataques.Add("Cornada", 65);
            this.ataques.Add("Golpe", 120);
            this.ataques.Add("Imagen", 90);
        }

        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 75;
            int ataque = 100;
            int defensa = 95;
            int velocidad = 110;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
