using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class PokemonTierra : Pokémon
    {
        //Un constructor para la clase
        public PokemonTierra(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonSiniestro
    public class Marowak : PokemonTierra
    {
        //Un constructor para la clase
        public Marowak() : base("Marowak", Tipo.Tierra, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Agua);
            this.debilidades.debilidades.Add(Tipo.Planta);
            this.debilidades.debilidades.Add(Tipo.Hielo);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Terremoto", 100);
            this.ataques.Add("Pataleta", 75);
            this.ataques.Add("Bofetón Lodo", 20);
            this.ataques.Add("Huesomerang", 50);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 60;
            int ataque = 80;
            int defensa = 110;
            int velocidad = 50;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
