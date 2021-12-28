using System;
using System.Collections.Generic;
using System.Linq;


namespace BenTheGamer
{
    class Program
    {
        static void Main(string[] args)
        {
            int levelsOfGames;
            int numberOfWeapons;
            // List<List<char>> listOfWeapon = new List<List<char>>();
            
            string[] tempIp = new string[3];
            tempIp=   Console.ReadLine().Split(' ');
            levelsOfGames = Convert.ToInt32(tempIp[0]); //level of game
            numberOfWeapons = Convert.ToInt32(tempIp[1]); //number of weapons
            //only array will be able to have a swaping facility without any issue
            object[] arrayOfWeapon = new object[levelsOfGames]; 
            for (int i = 0; i < levelsOfGames; i++)
            {
                arrayOfWeapon[i] = Console.ReadLine().ToList();
            }
            Console.WriteLine(CalculateCost(ref arrayOfWeapon, ref levelsOfGames, ref numberOfWeapons));
            Console.ReadLine();
            
        }

        private static int CalculateCost(ref object[] arrayOfWeapon, ref int levelsOfGames, ref int numberOfWeapons)
        {
            int totalCostToBuyWeapon = 0;
            //now sort the list first to be cost effective
            sortTheList(ref arrayOfWeapon);
            //prepare inventory as we will be carrying all weapon to next level
            char[] typeOfWeapon = new char[numberOfWeapons];

            for (int i = 0; i < arrayOfWeapon.Length; i++)
            {
                List<char> iterationVariable = ((List<char>)arrayOfWeapon[i]);
               FindCostOfThisLevel(ref iterationVariable,ref typeOfWeapon,ref totalCostToBuyWeapon);
            }

            return totalCostToBuyWeapon;
        }

        private static void FindCostOfThisLevel(ref List<char> iterationVariable, ref char[] typeOfWeapon,ref int totalCostToBuyWeapon)
        {
            int totalWeaponBought = 0;
            for (int i = 0; i < iterationVariable.Count; i++)
            {
                if(iterationVariable.ElementAt(i) == '1'&& typeOfWeapon[i] != '1')
                {
                    //add to inventory
                    typeOfWeapon[i] = '1';
                    // add the count
                    totalWeaponBought += 1;
                }
            }
            totalCostToBuyWeapon += (totalWeaponBought * totalWeaponBought);
        }
        private static void sortTheList(ref object[] arrayOfWeapon)
        {
            //now do the sorting as we used to do in college, pass by pass
            for (int i = 0; i < arrayOfWeapon.Length; i++)
            {
                for (int j = i+1; j < arrayOfWeapon.Length; j++)
                {
                   if (((List<char>)arrayOfWeapon[i]).FindAll(x => x == '1').Count > ((List<char>)arrayOfWeapon[j]).FindAll(x => x == '1').Count)
                    {
                        var tempList = arrayOfWeapon[i];
                        arrayOfWeapon[i] = arrayOfWeapon[j];
                        arrayOfWeapon[j] = tempList;
                    }
                }
            }
        }
    }
}
