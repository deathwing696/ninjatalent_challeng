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

                Test_country country = new Test_country(context);

                country.Test();

                Test_flag flag = new Test_flag(context);

                flag.Test();

                Console.ReadKey();
            }
        }
    }
}
