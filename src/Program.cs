using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ninja_challenge.tests;

namespace deathwing696
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Bd())
            {
                Test_all_countries all_countries = new Test_all_countries(context);

                all_countries.Test();

                Test_country test_country = new Test_country(context);

                test_country.Test();

                Test_flag flag = new Test_flag(context);

                flag.Test();

                var test_bd = new Test_bd(context);

                test_bd.Test_read("DE");

                Country country = Country.Read(context, "DE");

                if (country != null)
                {
                    country.Name = "Alemaña";
                    test_bd.Test_update(country);
                }

                test_bd.Test_delete("DE");

                Console.ReadKey();
            }
        }
    }
}
