using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class playwithNumbers
    {
        int no = Convert.ToInt32(Console.ReadLine());
        public void method()
        {
           

            if(no>0)
            {
                int[] resultArray = divideandCount(no);
                int finalResult = Results(resultArray);
            }
            else if(no<0)
            {
                int[] resultArray = divideandCount(no);
                int finalResult = Results(resultArray);

            }
            else
            {
                //return no;
            }
        }

         int[]  divideandCount(int no)
        {
            int[] array = null;
            int i = 0;
            while (no != 0) { 
            array[i] = no % 10;
            no = no / 10;
            i++;
            }
            return array;

        }
         int Results(int[] a)
         {
             if (no > 0)
             {
                 int k = 0;
                 foreach (var item in a)
                 {
                     k += item;

                 }
                 return k;

             }
             else
             {
                 int k = 1;
                 foreach (var item in a)
                 {
                     k *= item;

                 }
                 return k;
             }
             
            
         }
    }
}



/*   //// main code as
 * class Program
    {
        static void Main(string[] args)
        {
            //1)
            //NegativeNumberInArray obj = new NegativeNumberInArray();
            //Console.WriteLine("total -ve no is :"+obj.returnNegativeElementsNo());

            //2)
            //mathsoperation ob = new mathsoperation();
            //ob.method();
            
           int no = Convert.ToInt32(Console.ReadLine());
           int absnumber = Math.Abs(no);
           int length = absnumber.ToString().Length;
            if (no > 0)
            {
                int[] resultArray = divideandCount(absnumber,length);
                int finalResult = Results(resultArray,no);
                Console.WriteLine(finalResult);
            }
            else if (no < 0)
            {
                int[] resultArray = divideandCount(no,length);
                int finalResult = Results(resultArray,no);
                Console.WriteLine(finalResult);

            }
            else
            {
                Console.WriteLine(no);
            }
            Console.ReadLine();
        }
       static int[] divideandCount(int no,int a)
        {
            int[] array = new int[a];
            int i = 0;
            while (no != 0)
            {
                array[i] = no % 10;
                no = no / 10;
                i++;
            }
            return array;

        }
       static int Results(int[] a,int no)
       {
           if (no > 0)
           {
               int k = 0;
               foreach (var item in a)
               {
                   k += item;

               }
               return k;

           }
           else
           {
               int k = 1;
               foreach (var item in a)
               {
                   k *= item;

               }
               return Math.Abs(k);
           }


       }
    }
}

*/