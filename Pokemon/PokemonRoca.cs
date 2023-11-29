using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonRoca : Pokémon
    {
        //Un constructor para la clase
        public PokemonRoca(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonRoca
    public class Sudowoodo : PokemonRoca
    {
        //Un constructor para la clase
        public Sudowoodo() : base("Sudowoodo", Tipo.Roca, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Agua);
            this.debilidades.debilidades.Add(Tipo.Planta);
            this.debilidades.debilidades.Add(Tipo.Acero);
            this.debilidades.debilidades.Add(Tipo.Lucha);
            this.debilidades.debilidades.Add(Tipo.Tierra);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Roca Afilada", 100);
            this.ataques.Add("Lanza Rocas", 50);
            this.ataques.Add("Testarazo", 150);
            this.ataques.Add("Avalancha", 75);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 70;
            int ataque = 100;
            int defensa = 115;
            int velocidad = 50;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
