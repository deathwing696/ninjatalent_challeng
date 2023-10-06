using System;

namespace deathwing696
{
    public class Test_country
    {
        #region Variables
        private Bd context;
        #endregion

        #region Constructores
        public Test_country(Bd context)
        {
            this.context = context;
        }
        #endregion

        #region Métodos
        public void Test()
        {
            Console.WriteLine("Prueba de recuperación de un pais");
            Console.WriteLine("-------------------------------------");

            string nombre_pais = "deutschland";
            Country pais = Country.Get_country(nombre_pais);

            if (pais != null)
            {
                pais.Dibuja_consola();
                pais.Insert(context);
            }
            else
                Console.WriteLine($"La búsqueda de {nombre_pais} no ha producido resultados");

            Console.WriteLine("-------------------------------------");
        }
        #endregion
    }
}
