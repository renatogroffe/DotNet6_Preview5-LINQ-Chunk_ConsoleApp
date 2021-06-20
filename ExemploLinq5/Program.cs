using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ExemploLinq5
{
    public class Pais
    {
        public string Nome { get; set; }
        public string Continente { get; set; }
    }

    class Program
    {
        static void ExibirResultado(string tipoTeste,
            IEnumerable<Pais> paises)
        {
            Console.WriteLine();
            Console.WriteLine($"*** {tipoTeste} ***");
            Console.WriteLine();
            
            Console.WriteLine($"No. de elementos: {paises.Count()}");
            Console.WriteLine();
            
            Console.WriteLine($"Dados: {JsonSerializer.Serialize(paises)}");
            Console.WriteLine();

            Console.WriteLine("Países:");
            foreach (var pais in paises)
                Console.WriteLine($"  * {pais.Nome} ({pais.Continente})");
            Console.WriteLine();
        }

        static void Main()
        {
            Console.WriteLine("*** Testes com o método Chunk ***");
            var paises = new Pais[]{
                new () { Nome = "Alemanha", Continente = "Europa" },                
                new () { Nome = "Austrália", Continente = "Oceania" },
                new () { Nome = "Brasil", Continente = "América do Sul" },
                new () { Nome = "Canadá", Continente = "América do Norte" },
                new () { Nome = "Chile", Continente = "América do Sul" },
                new () { Nome = "Espanha", Continente = "Europa" },                
                new () { Nome = "Egito", Continente = "África" },
                new () { Nome = "Estados Unidos", Continente = "América do Norte" },
                new () { Nome = "Inglaterra", Continente = "Europa" },                
                new () { Nome = "Itália", Continente = "Europa" },                
                new () { Nome = "Japão", Continente = "Ásia" },                
                new () { Nome = "Rússia", Continente = "Europa" },
            };

            Console.WriteLine($"No. de elementos no array " +
                $"{nameof(paises)} = {paises.Length}");

            var subGrupos = paises.Chunk(5);
            for (int i = 0; i < subGrupos.Count(); i++)
                ExibirResultado($"Sub-grupo = posição {i}", subGrupos.ElementAt(i));
        }
    }
}