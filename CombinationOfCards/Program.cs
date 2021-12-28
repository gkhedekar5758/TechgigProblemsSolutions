using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;
            int ip1;
            ip1 = Convert.ToInt32(Console.ReadLine());
            int ip2;
            ip2 = Convert.ToInt32(Console.ReadLine());
            string ip3;
            ip3 = Console.ReadLine();
            string ip4;
            ip4 = Console.ReadLine();
            output = combinationOfCards(ip1, ip2, ip3, ip4);
            Console.WriteLine(output);
            Console.ReadLine();

        }

        #region MyCode
        //static string finalOutput = null;
        //static string combinationOfCards(int input1, int input2, string input3, string input4)
        //{
        //    var finalQuitFlag = false;
        //    string[] cardDeck = new string[input1];
        //   // string[] combination = null;
        //    List<string> combination = new List<string>();
        //    for (int i = 0; i < cardDeck.Length; i++) cardDeck[i] = "1";  //initialize all to 1=white
        //    bool noWhiteRestriction = false;
        //    bool noBlackRestriction = false;
        //    int[] WhiteCards=null;
        //    int[] BlackCards=null;
        //    if (input3 == "-1") noWhiteRestriction = true;
        //    else WhiteCards = convertWhiteBlack(input3);
        //    if (input4 == "-1") noBlackRestriction = true;
        //    else BlackCards = convertWhiteBlack(input4);
        //    int[] threeKArray = get3KPlusOne(input1);
        //    while (!finalQuitFlag)
        //    {
        //        if (!noWhiteRestriction) cardDeck=FlipWhiteCards(cardDeck, WhiteCards,"White");
        //        if (!noBlackRestriction) cardDeck = FlipWhiteCards(cardDeck, BlackCards, "Black");
        //        if (!noWhiteRestriction && !noBlackRestriction) { combination.Add(addIt(cardDeck)); }
               
        //        if (noWhiteRestriction&&noBlackRestriction)  //performing first action- flip all to different side
        //        {
        //            for (int i = 0; i < cardDeck.Length; i++) cardDeck[i] = "0";
        //            combination.Add(addIt(cardDeck));
        //        }
        //        if((!noWhiteRestriction&&!noBlackRestriction)&&canPerformAction(cardDeck,WhiteCards,BlackCards,"ODD"))  //flip all ODD cards
        //        { }


        //    }


        //    return finalOutput;
        //}

        //static bool canPerformAction(string[] ip1,int[] ip2,int[] ip3,string ip4)
        //{
        //    if(ip4=="ODD")
        //    {

        //    }
        //    return false;
        //}
        //static string[] FlipWhiteCards(string[] ip1, int[] ip2,string ip3) //flip the cards to white and black side
        //{
        //    if(ip3=="White")
        //    { 
        //        foreach (var item in ip2)
        //        {
        //        ip1[item] = "1";
        //        }
        //    }
        //    else if(ip3=="Black")
        //    {
        //        foreach (var item in ip2)
        //        {
        //            ip1[item] = "0";
        //        }
        //    }
        //    return ip1;
        //}

        //static int[] convertWhiteBlack(string pm1)  // array which holds which cards are black and white
        //{
        //    string[] temp = pm1.Split(',');
        //    int[] WhiteCards = new int[temp.Length];
        //    for (int i = 0; i < temp.Length; i++) WhiteCards[i] = Convert.ToInt32(temp[i]);
        //    return WhiteCards;
        //}
        //static int[] get3KPlusOne(int ip)  //array which holds 3K+1 type of card numbers
        //{
        //    List<int> temp = new List<int>();
        //    bool quit = true;
        //   // tempArr[0] = 1;
        //    for (int i = 0; quit; i++)
        //    {
        //        int no;
        //        no = (3*(i)) + 1;
        //        if (no >= ip) quit = false;
        //        temp.Add( no);

        //    }
            
        //    return temp.ToArray();
        //}
        //static string addIt(string[] ip1)  //add the deck in final array
        //{
        //    StringBuilder sbr = null;
        //    foreach (var item in ip1)
        //    {
        //        sbr.Append(item);

        //    }
        //    return sbr.ToString();
        //}
        #endregion
            // I was not able to resolve this as I was not able to understand it at all
        #region Ram'sCode

        private static string combinationOfCards(int input1, int input2, string input3, string input4)
        {
            //intialize the size of array of cards.
            //black is false and true is white
            bool[] myboolArray = Enumerable.Repeat(true, input1).ToArray(); //Enumerable.Repeat(1, ip1).ToArray();

            List<bool[]> myboollist = new List<bool[]>();
            List<bool[]> mytempboollist = new List<bool[]>();

            mytempboollist.Add(myboolArray);
            string[] finalsequence = new string[4 * input2];

            for (int k = 0; k < input2; k++)
            {

                foreach (var boolarr in mytempboollist)
                {

                    //First Chance
                    bool[] tempboolarrayfirst = new bool[input1];
                    boolarr.CopyTo(tempboolarrayfirst, 0);
                    for (int i = 0; i < input1; i++)
                    {
                        tempboolarrayfirst[i] = !tempboolarrayfirst[i];
                    }

                    myboollist.Add(tempboolarrayfirst);

                    //Second Chance
                    bool[] tempboolarraysecond = new bool[input1];
                    boolarr.CopyTo(tempboolarraysecond, 0);
                    for (int i = 1; i <= input1; i++)
                    {
                        if (i % 2 != 0)
                        {
                            tempboolarraysecond[i - 1] = !tempboolarraysecond[i - 1];
                        }
                    }
                    myboollist.Add(tempboolarraysecond);


                    //Third Chance
                    bool[] tempboolarraythird = new bool[input1];
                    boolarr.CopyTo(tempboolarraythird, 0);
                    for (int i = 1; i <= input1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            tempboolarraythird[i - 1] = !tempboolarraythird[i - 1];
                        }
                    }
                    myboollist.Add(tempboolarraythird);


                    //Fourth Chance
                    bool[] tempboolarrayfourth = new bool[input1];
                    boolarr.CopyTo(tempboolarrayfourth, 0);
                    for (int i = 0; i < input1; i++)
                    {
                        int j = 3 * i;
                        if (j <= input1)
                        {
                            tempboolarrayfourth[j] = !tempboolarrayfourth[j];
                        }
                        else
                            break;
                    }
                    myboollist.Add(tempboolarrayfourth);

                }
                mytempboollist.Clear();
                //Adding the four into this.
                mytempboollist.AddRange(myboollist);
                myboollist.Clear();



            }


            //Remove the ones which arent fit for the values coming in ip1 and ip2
            List<bool[]> myfinalboollist = new List<bool[]>();
            string[] whitearray = new string[0];
            string[] blackarray = new string[0];
            if (input3 != "-1")
            { whitearray = input3.Split(','); }
            if (input4 != "-1")
            { blackarray = input4.Split(','); }

            //We need this one.

            foreach (var boolarr in mytempboollist)
            {
                bool keep = true;
                if (whitearray.Length > 0)
                {
                    foreach (string s in whitearray)
                    {
                        if (boolarr[Int32.Parse(s) - 1] != true)
                        {
                            keep = false;
                            break;
                        }
                    }
                }

                if (blackarray.Length > 0)
                {
                    foreach (string s in blackarray)
                    {
                        if (boolarr[Int32.Parse(s) - 1] != false)
                        {
                            keep = false;
                            break;
                        }
                    }
                }

                if (keep == true)
                {
                    myfinalboollist.Add(boolarr);
                }

            }

            //We need this one.


            //Converting to string array.

            string[] a = new string[myfinalboollist.Count];
            for (int i = 0; i < myfinalboollist.Count; i++)
            {
                string s = "";
                foreach (bool b in myfinalboollist[i])
                {
                    s = s + Convert.ToInt32(b).ToString();
                }

                a[i] = s;
            }


            a = a.Distinct().ToArray();
            Array.Sort(a);

            string final = "";
            foreach (string s in a)
            {
                final = string.Join("#", a);
            }

            return final;
        }

    }

    #endregion
}

