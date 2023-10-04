using System;
using deathwing696;

namespace ninja_challenge.tests
{
    public class Test_flag
    {
        public void Test()
        {
            Console.WriteLine("Prueba de recuperación de una bandera");
            Console.WriteLine("-------------------------------------");

            var nombre_pais = "deutschland";
            var buffer = Country.Get_flag(nombre_pais);

            if (buffer != null)
                Console.WriteLine(buffer);
            else
                Console.WriteLine($"La búsqueda de {nombre_pais} no ha producido resultados");

            Console.WriteLine("-------------------------------------");
        }
    }
}
