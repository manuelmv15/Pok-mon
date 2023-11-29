using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    //Se crea una clase pública para un nuevo tipo y que herede de la clase Pokémon
    public class PokemonPsíquico : Pokémon
    {
        //Un constructor para la clase
        public PokemonPsíquico(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    //Se crea una nueva clase para el pokemon nuevo, este hereda de la clase PokemonPsíquico
    public class Alakazam : PokemonPsíquico
    {
        //Un constructor para la clase
        public Alakazam() : base("Alakazam", Tipo.Psiquico, Tipo.Ninguno, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            //Aquí se definen las debilidades del pokemon
            this.debilidades.debilidades.Add(Tipo.Siniestro);
            this.debilidades.debilidades.Add(Tipo.Fantasma);
            this.debilidades.debilidades.Add(Tipo.Bicho);

            //Aquí se definen los 4 ataques que tiene el pokemon
            this.ataques.Add("Psíquico", 90);
            this.ataques.Add("Psicorrayo", 65);
            this.ataques.Add("Confusión", 50);
            this.ataques.Add("Psicocorte", 70);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            //Aquí se definen las estadísticas que posee el pokemon
            int vida = 55;
            int ataque = 135;
            int defensa = 95;
            int velocidad = 120;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
