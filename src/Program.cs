using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ninja_challenge.tests;

namespace ninja_challenge.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_all_countries all_countries = new Test_all_countries();

            all_countries.Test();

            Test_country country = new Test_country();

            country.Test();

            Test_flag flag = new Test_flag();

            flag.Test();

            Console.Read();
        }
    }
}
