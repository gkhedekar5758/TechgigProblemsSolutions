using System;

namespace PowerPuffGirls
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the inputs

            int numbeOfIngredients = Convert.ToInt32(Console.ReadLine());
            Int64[] Qp = new Int64[numbeOfIngredients];
            Int64[] Qt = new Int64[numbeOfIngredients];
            //char[] a = new char[] { ' ' }; 
            string[] tempQp = Console.ReadLine().Trim().Split(' ');
            string[] tempQt = Console.ReadLine().Trim().Split(' ');
            for (int i = 0; i < tempQp.Length; i++)
            {
                Int64.TryParse(tempQp[i], out Qp[i]);
                Int64.TryParse(tempQt[i], out Qt[i]);
            }

            Console.WriteLine(DecideTheNumberOfGirls(numbeOfIngredients,Qp,Qt));
            Console.ReadLine();
        }

        private static Int64 DecideTheNumberOfGirls(int numbeOfIngredients, Int64[] Qp, Int64[] Qt)
        {
            Int64 previosMin = int.MaxValue;
            for (int i = 0; i < Qp.Length; i++)
            {
                if (Qp[i] == 0) continue;
                Int64 minNow = -1;
                minNow = Qt[i] / Qp[i];
                if (minNow < previosMin) previosMin = minNow;
            }
            return previosMin;
        }
    }
}
