using System;

namespace deathwing696
{
    public class Test_flag
    {
        #region Variables
        private Bd context;
        #endregion

        #region Constructores
        public Test_flag(Bd context)
        {
            this.context = context;
        }
        #endregion

        #region Métodos
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
        #endregion
    }
}
