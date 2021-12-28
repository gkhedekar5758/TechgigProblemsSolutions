using System;
using System.Collections.Generic;
using System.Linq;


namespace DesignNecklace_Allscripts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> ListOfNecklace = new List<char>();
            int intBlue; //= 0;
            int intGreen;// = 0;
            int intRed;//= 0;
            int intYellow;// = 0;
            intBlue = Convert.ToInt16(Console.ReadLine());
            intRed = Convert.ToInt16(Console.ReadLine());
            intYellow = Convert.ToInt16(Console.ReadLine());
            intGreen = Convert.ToInt16(Console.ReadLine());

          //int lengthOfNecklace=  DesignNecklace(ref ListOfNecklace, ref intBlue, ref intGreen, ref intRed, ref intYellow);
            Console.WriteLine(DesignNecklace(ref ListOfNecklace, ref intBlue, ref intGreen, ref intRed, ref intYellow));
            Console.ReadLine();
        }

        private static int DesignNecklace(ref List<char> listOfNecklace, ref int intBlue, ref int intGreen, ref int intRed, ref int intYellow)
        {
            //only one pearl is passed from the user so length is only one or the red and yellow
            if ((intBlue == 1 & intGreen == 0 & intRed == 0 & intYellow == 0) ||
               (intBlue == 0 & intGreen == 1 & intRed == 0 & intYellow == 0) ||
               (intBlue == 0 & intGreen == 0 & intRed == 1 & intYellow == 0) ||
               (intBlue == 0 & intGreen == 0 & intRed == 0 & intYellow == 1) ||
               (intBlue == 0 & intGreen == 0 & intRed > 1 & intYellow == 0) ||  //if more red but no other gems
               (intBlue == 0 & intGreen == 0 & intRed == 0 & intYellow > 1))    //if more yellow but no other gems
                return 1;

            if (intBlue > 1 & intGreen == 0 & intRed == 0 & intYellow == 0) return intBlue;  //blue can go behind blue
            if (intBlue == 0  & intGreen > 1 & intRed == 0 & intYellow == 0) return intGreen; //green can go behind green

            List<int> lengthOfPossible = new List<int>();
            int saveBlue = intBlue;
            int saveGreen = intGreen;
            int saveRed = intRed;
            int saveYello = intYellow;

            //combination -1 
            if(saveBlue>0)
            {
                List<char> tempNecklace = new List<char>();
                int intLocalBlue = saveBlue;
                int intLocalGreen = saveGreen;
                int intLocalYellow = saveYello;
                int intLocalRed = saveRed;
                
                //starting from blue jem
                tempNecklace.Add('b');
                intLocalBlue -=  1;
                commonLogic(ref tempNecklace, ref intLocalBlue, ref intLocalGreen, ref intLocalYellow, ref intLocalRed);
                lengthOfPossible.Add(tempNecklace.Count);
            }

            //combination -2
            if(saveRed>0)
            {
                List<char> tempNecklace = new List<char>();
                int intLocalBlue = saveBlue;
                int intLocalGreen = saveGreen;
                int intLocalYellow = saveYello;
                int intLocalRed = saveRed;

                //starting from red jem
                tempNecklace.Add('r');
                intLocalRed -= 1;
                commonLogic(ref tempNecklace, ref intLocalBlue, ref intLocalGreen, ref intLocalYellow, ref intLocalRed);
                lengthOfPossible.Add(tempNecklace.Count);

            }
            if (saveBlue==0 && saveRed==0)
            {
                //in this yellow can't be first as it is getting followed by red and blue and we do not have blue and red so starting with green only
                List<char> tempNecklace = new List<char>();
                int intLocalBlue = saveBlue;
                int intLocalGreen = saveGreen;
                int intLocalYellow = saveYello;
                int intLocalRed = saveRed;

                //starting from green jem
                tempNecklace.Add('g');
                intLocalGreen -= 1;
                commonLogic(ref tempNecklace, ref intLocalBlue, ref intLocalGreen, ref intLocalYellow, ref intLocalRed);
                lengthOfPossible.Add(tempNecklace.Count);
            }

            //Now we are done with all the possible solution.

             lengthOfPossible.Sort();
            return lengthOfPossible.Last();
            //return 0;
            
        }

        private static void commonLogic(ref List<char> tempNecklace, ref int intBlue, ref int intGreen, ref int intYellow, ref int intRed)
        {
            while (true)
            {
                int endNecklace = 0;
                if ((tempNecklace.ElementAt(tempNecklace.Count - 1) == 'b') || (tempNecklace.ElementAt(tempNecklace.Count - 1) == 'y'))
                    addBlueOrRed(ref tempNecklace, ref intBlue, ref intRed, ref endNecklace);

                if (endNecklace == -1) break;
                if ((tempNecklace.ElementAt(tempNecklace.Count - 1) == 'g') || (tempNecklace.ElementAt(tempNecklace.Count - 1) == 'r'))
                    addGreenOrYellow(ref tempNecklace, ref intGreen, ref intYellow, ref endNecklace);

                if (endNecklace == -1) break;

            }
        }

        private static void addGreenOrYellow(ref List<char> tempNecklace1, ref int intGreen, ref int intYellow,ref int endNecklace)
        {
            if(intGreen>0)
            {
                tempNecklace1.Add('g');
                intGreen -= 1;
            }
            else if(intYellow>0)
            {
                tempNecklace1.Add('y');
                intYellow -= 1;
            }
            else
            {
                // return -1;
                endNecklace = -1;
            }
        }

        private static void addBlueOrRed(ref List<char> tempNecklace1, ref int intBlue, ref int intRed, ref int endNecklace)
        {
            if(intBlue>0)
            {
                tempNecklace1.Add('b');
                intBlue -= 1;
            }
            else if(intRed>0)
            {
                tempNecklace1.Add('r');
                intRed -= 1;
            }
            else
            {
                endNecklace = -1;
            }
        }
    }
}
