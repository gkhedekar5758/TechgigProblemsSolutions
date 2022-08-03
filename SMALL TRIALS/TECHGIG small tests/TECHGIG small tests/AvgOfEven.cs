using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class AvgOfEven
    {
    
        List<int> a= new List<int>();
        string s;
        int sum = 0;
        int count;
    public int method()
        {
            do
            {
                s = Console.ReadLine();
                a.Add(Convert.ToInt32(s));

            } while (s != null);
            foreach (var item in a)
            {
                if (item % 2 == 0)
                {
                    sum += item;
                    count++;
                }
            }
            if (count == 0) return 0;
            else return sum / count;
        }
    }
}


// main method

//List<int> a = new List<int>();
//            string s=Console.ReadLine();
//            int sum = 0;
//            int count=0;
//            while (s != "") 
//            {
//                a.Add(Convert.ToInt32(s));
//                s = Console.ReadLine();
                

//            } 
//            foreach (var item in a)
//            {
//                if (item % 2 == 0)
//                {
//                    sum += item;
//                    count++;
//                }
//            }
//            Console.WriteLine(count==0?0:sum/count);