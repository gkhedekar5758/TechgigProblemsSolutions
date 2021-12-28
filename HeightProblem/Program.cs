using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeightProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the height Array in form {N#NN,N#NN} format ");
            string HeightArray = Console.ReadLine();
            
            Console.Write("Enter the total No of Person :");
            int noOfPerson = Convert.ToInt16(Console.ReadLine());
            Height objHeight = new Height();
            Console.WriteLine("Result is : "+objHeight.CalculateTheIChangeblePerson(HeightArray,noOfPerson));

            Console.WriteLine("Press any Key to Continue...");
            Console.ReadLine();

        }
    }
    class Height
    {

        public int CalculateTheIChangeblePerson(string a,int b)
        {
            
            int finalIChangeblePersons=0;
            string[] personArray=a.Split(',');
           personArray[0]=personArray[0].Replace("{","");
           personArray[personArray.Length-1] = personArray[personArray.Length-1].Replace("}", "");
          
            if (personArray.Length != b) return -1;
            for (int k = 0; k < personArray.Length; k++)
            {

                if (!verifyNumber(personArray[k])) return -1;
            }
            double[] personHeightArray = new double[personArray.Length];
            for (int i = 0; i < personArray.Length; i++)
            {
                personHeightArray[i] = Convert.ToDouble(personArray[i].Replace('#','.'));
                
            }
            for (int i = 0; i < personHeightArray.Length; i++)
            {
                for (int j = i+1; j < personHeightArray.Length; j++)
                {
                    if (personHeightArray[i] > personHeightArray[j]) finalIChangeblePersons = finalIChangeblePersons + 1;
                }
            }

            return finalIChangeblePersons;
        }
        public bool verifyNumber(string a)
        {
            string[] sep = { "#" };
            var val = a.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (!((Convert.ToInt16(val[0]) > 4) & (Convert.ToInt16(val[0]) < 7))) return false;
            if (!((Convert.ToInt16(val[1]) > 0) & (Convert.ToInt16(val[1]) < 11))) return false;
            return true;

        }
    }
}
