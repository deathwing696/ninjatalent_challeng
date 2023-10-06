using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using deathwing696;
using System.Linq;

namespace ninja_challenge.tests
{
    public class Test_all_countries
    {
        #region Variables
        private Bd context;
        #endregion

        #region Constructores
        public Test_all_countries(Bd context)
        {
            this.context = context;
        }
        #endregion
        public void Test()
        {
            Console.WriteLine("Prueba de recuperación de todos los paises");
            Console.WriteLine("-------------------------------------");
            List<Country> lista = Country.Get_all_countries();

            foreach (var country in lista)
            {
                country.Dibuja_consola();
                country.Insert(context);
            }

            Console.WriteLine("-------------------------------------");
        }
    }
}
