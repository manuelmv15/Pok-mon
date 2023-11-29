using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class PokémonFuego : Pokémon
    {
        public PokémonFuego(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades) : base(nombre, tipo, tipo2, estadisticas, ataques, debilidades)
        {
        }
    }
    public class Charizard : PokémonFuego
    {

        public Charizard() : base("Charizard", Tipo.Fuego, Tipo.Volador, estadisticas(), new Dictionary<string, int>(), new Debilidades())
        {
            this.debilidades.debilidades.Add(Tipo.Agua);
            this.debilidades.debilidades.Add(Tipo.Tierra);
            this.debilidades.debilidades.Add(Tipo.Roca);

            this.ataques.Add("Llamarada", 80);
            this.ataques.Add("Furia Ígnea", 100);
            this.ataques.Add("Inferno Ardiente", 150);
            this.ataques.Add("Ala Cortante", 90);
        }
        public override string ToString()
        {
            return this.nombre;
        }
        private static Estadisticas estadisticas()
        {
            int vida = 78;
            int ataque = 84;
            int defensa = 78;
            int velocidad = 100;

            return new Estadisticas { vida = vida, vidaMax = vida, ataque = ataque, defensa = defensa, velocidad = velocidad };
        }
    }
}
