using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonPlanta : Pokémon
    {
        //Un constructor para la clase
        public PokemonPlanta(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonPlanta
    public class Venusaur : PokemonPlanta
    {
        //Un constructor para la clase
        public Venusaur() : base("Venusaur", Tipo.Planta, Tipo.Veneno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Fuego);
            this.debilidades.debilidades.Add(Tipo.Volador);
            this.debilidades.debilidades.Add(Tipo.Hielo);
            this.debilidades.debilidades.Add(Tipo.Psiquico);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Hoja Afilada", 55);
            this.ataques.Add("Látigo Cepa", 45);
            this.ataques.Add("Danza Pétalo", 120);
            this.ataques.Add("Planta Feroz", 150);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 80;
            int ataque = 100;
            int defensa = 100;
            int velocidad = 80;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
