using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using deathwing696;

namespace ninja_challenge.src
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> lista = Country.Get_all_countries();

            foreach (var country in lista)
                country.Dibuja_consola();

            Console.Read();
        }
    }
}
