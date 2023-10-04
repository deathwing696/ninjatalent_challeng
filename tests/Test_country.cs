using System;
using deathwing696;

namespace ninja_challenge.tests
{
    public class Test_country
    {
        public void Test()
        {
            Console.WriteLine("Prueba de recuperación de un pais");
            Console.WriteLine("-------------------------------------");

            string nombre_pais = "deutschland";
            Country pais = Country.Get_country(nombre_pais);

            if (pais != null)
                pais.Dibuja_consola();
            else
                Console.WriteLine($"La búsqueda de {nombre_pais} no ha producido resultados");

            Console.WriteLine("-------------------------------------");
        }
    }
}
