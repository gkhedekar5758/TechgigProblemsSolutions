using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHGIG_small_tests
{
    class NegativeNumberInArray

    {
        public int method(){
int numberOfElement;
            int noOfNElements = 0;


            numberOfElement = Convert.ToInt32(Console.ReadLine());

            string text = Console.ReadLine();
            string[] nos = text.Split(' ');
           // int a = 0;
           int[] array = new int[numberOfElement];
            for (int i = 0; i < nos.Length; i++)
            {
                array[i] = Convert.ToInt32(nos[i]);   
            }

            foreach (var item in array)
            {
                if (item < 0) noOfNElements += 1;
                
            }

            Console.WriteLine( noOfNElements);
            return noOfNElements;
        }}
    }

