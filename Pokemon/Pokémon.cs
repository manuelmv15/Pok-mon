using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public enum Tipo//Declarar un enum para guardar todos los tipos de pokemon
    {
        Ninguno,
        Fuego,
        Agua,
        Electrico,
        Tierra,
        Planta,
        Hielo,
        Veneno,
        Volador,
        Psiquico,
        Lucha,
        Bicho,
        Roca,
        Fantasma,
        Dragón,
        Siniestro,
        Acero,
        Hada,
        Normal
    }
    
    public class Pokémon//Crear una clase padre llamada Pokemon
    {
        public string nombre;
        public bool agregado = false;
        public Tipo tipo;
        public Tipo tipo2;
        public Estadisticas estadisticas;
        public Dictionary<string, int> ataques;
        public Debilidades debilidades;

        //Crear un constructor para la clase 

        public Pokémon(string nombre, Tipo tipo, Tipo tipo2, Estadisticas estadisticas, Dictionary<string, int> ataques, Debilidades debilidades)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.tipo2 = tipo2;
            this.estadisticas = estadisticas;
            this.ataques = ataques;
            this.debilidades = debilidades;
        }

    }
}
