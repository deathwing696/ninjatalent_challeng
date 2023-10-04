using System;
using System.Collections.Generic;
using deathwing696;

namespace ninja_challenge.tests
{
    public class Test_all_countries
    {
        public void Test()
        {
            Console.WriteLine("Prueba de recuperación de todos los paises");
            Console.WriteLine("-------------------------------------");
            List<Country> lista = Country.Get_all_countries();

            foreach (var country in lista)
                country.Dibuja_consola();

            Console.WriteLine("-------------------------------------");
        }
    }
}
