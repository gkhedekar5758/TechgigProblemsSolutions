using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class mathsoperation
    {
        public void method()
        {
            int no1 = Convert.ToInt32(Console.ReadLine());
            int no2 = Convert.ToInt32(Console.ReadLine());

            //
            Console.WriteLine(no1+no2);
            Console.WriteLine(no1-no2);
            Console.WriteLine(no1*no2);
            Console.WriteLine(no1/no2);
            if (no1 == no2) Console.WriteLine("equal");
                       
            else                 Console.WriteLine(no1 > no2 ? no1 : no2);
            
        }
    }
}
