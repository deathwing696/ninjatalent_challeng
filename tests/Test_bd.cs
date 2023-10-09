using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deathwing696
{
        class Test_bd
    {
        #region Propiedades
        private Bd context;
        #endregion

        #region Constructores
        public Test_bd(Bd context)
        {
            this.context = context;
        }
        #endregion

        #region Métodos
        public void Test_read(string alpha2Code)
        {
            Country country = Country.Read(context, alpha2Code);

            Console.WriteLine("Prueba de recuperación de un país desde la base de datos");
            Console.WriteLine("-------------------------------------");

            if (country == null)
            {
                Console.WriteLine("El país no ha sido encontrado en la base ded atos, asegúrate de que el alpha2Code sea correcto");
            }
            else
            {
                country.Dibuja_consola();
            }

            Console.WriteLine("-------------------------------------");
        }
        public void Test_update(Country country)
        {
            Console.WriteLine("Prueba de actualización de datos de un país de la base de datos");
            Console.WriteLine("-------------------------------------");

            if (!country.Update(context))
            {
                Console.WriteLine("El país no ha sido encontrado en la base ded atos, asegúrate de que el alpha2Code sea correcto");
            }
            else
            {
                Console.WriteLine("El país ha sido actualizado correctamente");
                country.Dibuja_consola();
            }

            Console.WriteLine("-------------------------------------");
        }
        public void Test_delete(string alpha2Code)
        {
            Console.WriteLine("Prueba de borrado de un país de la base de datos");
            Console.WriteLine("-------------------------------------");

            Country country = Country.Read(context, alpha2Code);

            if (Country.Delete(context, alpha2Code))
            {
                if (country != null)
                {
                    country.Dibuja_consola();
                    Console.WriteLine("El país ha sido borrado correctamente");
                }
            }
            else
            {
                Console.WriteLine("El país no ha sido encontrado en la base ded atos, asegúrate de que el alpha2Code sea correcto");
            }
        }
        #endregion
    }
}
