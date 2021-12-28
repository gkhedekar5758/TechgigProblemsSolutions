using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace virus_allscripts2021
{
    class Program
    {
        static void Main(string[] args)
        {
            string virusSequence = Console.ReadLine();
            int numberOfTest = Convert.ToInt32(Console.ReadLine());
            List<string> bloodSequences = new List<string>();
            for (int i = 0; i < numberOfTest; i++)
            {
                bloodSequences.Add(Console.ReadLine());
            }

            foreach (var item in bloodSequences)
            {
                if (CheckIfPositiveOrNegative(item, virusSequence, item.Length, virusSequence.Length)) Console.WriteLine("POSITIVE");
                else Console.WriteLine("NEGATIVE");
            }
        }

        private static bool CheckIfPositiveOrNegative(string bloodSequenceOfPatient, string virusSequence,int m,int n)
        {
            if (m == 0)
                return true;
            if (n == 0)
                return false;

            // If last characters of two strings
            // are matching
            if (bloodSequenceOfPatient[m - 1] == virusSequence[n - 1])
                return CheckIfPositiveOrNegative(bloodSequenceOfPatient, virusSequence,
                                        m - 1, n - 1);

            // If last characters are not matching
            return CheckIfPositiveOrNegative(bloodSequenceOfPatient, virusSequence, m, n - 1);
        }
    }
}
