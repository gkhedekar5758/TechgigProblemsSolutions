using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodInJunge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> MeetingCanHappenHere = new List<int>();
            var temp = Console.ReadLine().Split(' ');
            int NumberOfTree = Convert.ToInt16(temp[0]);
            decimal Capacity = Convert.ToDecimal(temp[1]);
            int[] xi = new int[NumberOfTree];
            int[] yi = new int[NumberOfTree];
            int[] mi = new int[NumberOfTree];
            int[] ti = new int[NumberOfTree];
            for (int i = 0; i < NumberOfTree; i++)
            {
                var temp1 = Console.ReadLine().Split(' ');
                xi[i] = Convert.ToInt16(temp1[0]);
                yi[i] = Convert.ToInt16(temp1[1]);
                mi[i] = Convert.ToInt16(temp1[2]);
                ti[i] = Convert.ToInt16(temp1[3]);
            }
            var blankIp = Console.ReadLine();

            string result = SearchTree(NumberOfTree, Capacity, xi, yi, mi, ti, MeetingCanHappenHere);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static string SearchTree(int numberOfTree, decimal capacity, int[] xi, int[] yi, int[] mi, int[] ti, List<int> meetingCanHappenHere)
        {
            if (numberOfTree == 1) return numberOfTree.ToString();
            int notPoss = -1;
            int totalMonkey = 0;
            bool searchDone = true;
            List<int> stucktree = new List<int>(); // you can't jump off of this tree
            List<int> FreeTree = new List<int>();
            //FreeTree.Remove);
            List<int> templist = new List<int>();
            for (int i = 0; i < mi.Length; i++)
            {
                templist.Add(i);
                totalMonkey += mi[i]; //get total monekeys in jungle
                if (!canAllJumpFrom(mi[i], ti[i])) stucktree.Add(i);
            }
            if (stucktree.Count == numberOfTree) return notPoss.ToString();
            FreeTree = templist.Except(stucktree).ToList();

            if (mi.ToList().Exists(y => y == totalMonkey))
            {
                meetingCanHappenHere.Add(mi.ToList().FindIndex(p => p == totalMonkey));
                //break;
            }
            var savmi = (int[])mi.Clone();
            var savti = (int[])ti.Clone();
            if (stucktree.Count == 0)
            {
                for (int i = 0; i < FreeTree.Count; i++)
                {
                    int iteration = 0;
                    mi = savmi.ToArray();
                    ti = savti.ToArray();
                    int tot = FreeTree.ElementAt(i);
                    //                    foreach (var x in getSomething(FreeTree))
                    for (int x = 0; x < FreeTree.Count; x++)
                    
                    {
                        
                        if (x == tot) continue;
                        iteration++;
                        if (iteration == FreeTree.Count) break;
                        int frm = x;
                        if (mi[frm] == 0 || !canAllJumpFrom(mi[frm], ti[frm])) continue;
                        if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) <= capacity)
                        {
                            mi[tot] += mi[frm];
                            ti[frm] -= mi[frm];
                            mi[frm] = 0;

                        }
                        if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) > capacity)
                        {
                            int Nfrm = FindNewFrom(ref mi, ref ti, ref xi,ref yi,capacity, FreeTree, tot,frm);
                            if (Nfrm == -1) break;
                            mi[tot] += mi[Nfrm];
                            ti[Nfrm] -= mi[Nfrm];
                            mi[Nfrm] = 0;
                        }
                            if (mi.ToList().Exists(y=>y==totalMonkey))
                        {
                           meetingCanHappenHere.Add( mi.ToList().FindIndex(p => p == totalMonkey));
                            break;
                        }
                    }
                }

            }
            else
            {
                for (int i = 0; i < stucktree.Count; i++)
                {
                    List<int> checkedthis = new List<int>();
                    mi = savmi.ToArray();
                    ti = savti.ToArray();
                    int tot = stucktree.ElementAt(i);
                    //foreach (var frm in getSomething(FreeTree))
                    for (int j = 0; j < FreeTree.Count; j++)
                    {
                        // if (j == i) continue;
                        int frm = FreeTree.ElementAt(j);
                        checkedthis.Add(frm);
                        if (FreeTree.Except(checkedthis).ToList().Count == 0) break;
                        if (frm == tot) continue;
                        if (mi[frm] == 0 || !canAllJumpFrom(mi[frm], ti[frm])) continue;
                        if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) <= capacity)
                        {
                            mi[tot] += mi[frm];
                            ti[frm] -= mi[frm];
                            mi[frm] = 0;

                        }
                        if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) > capacity)
                        {
                            //int Nfrm = FindNewFrom(ref mi, ref ti, ref xi, ref yi, capacity, FreeTree, tot,frm);
                            ////int nTot = FindNewTo(ref mi, ref ti, ref xi, ref yi, capacity, FreeTree, frm,tot);
                            //if (Nfrm == -1) break;
                            //mi[tot] += mi[Nfrm];
                            //ti[Nfrm] -= mi[Nfrm];
                            //mi[Nfrm] = 0;


                            // find new to and jump on it and then come back to do this things
                           int nfrm= FindNewToJump(ref mi, ref ti, ref xi, ref yi, capacity, FreeTree, frm, tot);
                            if(nfrm!=-1)
                            { 
                            mi[tot] += mi[nfrm];
                            ti[nfrm] -= mi[nfrm];
                            mi[nfrm] = 0;
                            }
                        }
                        if (mi.ToList().Exists(y => y == totalMonkey))
                        {
                            meetingCanHappenHere.Add(mi.ToList().FindIndex(p => p == totalMonkey));
                            break;
                        }

                    }
                }

            }
            ////hopping starts
           //if(!ti.ToList().TrueForAll(x=>x==0))
           // {
           //     int tot = mi.ToList().FindIndex(p => p == mi.ToList().Max());
           //     for (int frm = 0; frm < mi.Length; frm++)
           //     {
           //         if ((mi[frm] == 0)|| !canAllJumpFrom(mi[frm],ti[frm])) continue;
           //         if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) <= capacity)
           //         {
           //             mi[tot] += mi[frm];
           //             ti[frm] -= mi[frm];
           //             mi[frm] = 0;

           //         }
           //         if (distance(xi[tot], yi[tot], xi[frm], yi[frm]) > capacity)
           //         {
           //             int nTot = FindNewTo(ref mi, ref ti, ref xi, ref yi, capacity, FreeTree, frm,tot);
           //             if (nTot == -1) break;
           //             mi[nTot] += mi[frm];
           //             ti[frm] -= mi[frm];
           //             mi[frm] = 0;
           //         }


           //     }

            //if(!ti.ToList().TrueForAll(x=>x==0))
            //{

            //    List<int> donetree = new List<int>();
            //    for (int i = 0; i < mi.Length; i++)
            //    {
            //        if (meetingCanHappenHere.Exists(t => t == i)) continue;
            //        if (mi[i] == 0 && ti[i] == 0) donetree.Add(i);
            //        int frm = i;
            //        int tot = -1;
            //        if (mi[i] == 0) continue;
            //        if (canAllJumpFrom(mi[i], ti[i])) continue;
            //        for (int j = 0; j < mi.Length; j++)
            //        {
            //            if (meetingCanHappenHere.Exists(t => t == j)) continue;
            //            if (i == j) continue;
            //            //if (mi[j] == 0) continue;
            //            if (donetree.Exists(l => l == j)) continue;
            //            if (distance(xi[j], yi[j], xi[i], yi[i]) > capacity) continue;
            //            else
            //            {
            //                tot = j;
            //                break;
            //            }
            //        }
            //        mi[tot] += mi[frm];
            //        ti[frm] -= mi[frm];
            //        mi[frm] = 0;
            //        if (mi[frm] == 0 && ti[frm] == 0) donetree.Add(frm);
            //        if (mi.ToList().Exists(y => y == totalMonkey))
            //        {
            //            meetingCanHappenHere.Add(mi.ToList().FindIndex(p => p == totalMonkey));
            //            break;
            //        }

            //    }

            //}

            var temp = string.Empty;
            if (meetingCanHappenHere.Count == 0) return notPoss.ToString();
            else
            {
                meetingCanHappenHere.Sort();

                for (int i = 0; i < meetingCanHappenHere.Count; i++)
                {
                    if (i == 0)
                    {
                        temp = meetingCanHappenHere.ElementAt( i).ToString() + ' ';
                    }
                    else
                    {
                        temp = temp + meetingCanHappenHere.ElementAt(i).ToString()+' ';
                    }
                }
            }
            return temp;
        }
        private static int FindNewToJump(ref int[] mi, ref int[] ti, ref int[] xi, ref int[] yi, decimal capacity, List<int> freeTree, int frm, int tot)
        {
            List<int> localList = new List<int>();
            int retTot = -1;
            //foreach (int LcltTree in getSomething(freeTree))
                for (int LcltTree = 0; LcltTree < freeTree.Count; LcltTree++)
              
            {
                localList.Add(LcltTree);
                
                if ((frm == LcltTree) || (LcltTree == tot)) continue;
               // if (canAllJumpFrom(mi[frm], ti[LcltTree])) continue;
                if (distance(xi[LcltTree], yi[LcltTree], xi[frm], yi[frm]) <= capacity)
                {
                    retTot = LcltTree;
                    break;
                }
                if (freeTree.Except(localList).ToList().Count == 0) break;
            }
            if(retTot!=-1)
            { 
                mi[retTot] += mi[frm];
                ti[frm] -= mi[frm];
                mi[frm] = 0;
            }
            return retTot;
        }

        private static int FindNewTo(ref int[] mi, ref int[] ti, ref int[] xi, ref int[] yi, decimal capacity, List<int> freeTree, int frm,int tot)
        {
            List<int> localList = new List<int>();
            int retTot = -1;
            foreach (int LcltTree in getSomething(freeTree))
            {
                localList.Add(LcltTree);
                if (freeTree.Except(localList).ToList().Count == 0) break;
                if ((frm == LcltTree) || (LcltTree == tot)) continue;
                if (canAllJumpFrom(mi[frm], ti[LcltTree])) continue;
                if (distance(xi[LcltTree], yi[LcltTree], xi[frm], yi[frm]) <= capacity)
                {
                    retTot = LcltTree;
                    break;
                }

            }
            return retTot;
        }

        private static int FindNewFrom(ref int[] mi, ref int[] ti, ref int[] xi, ref int[] yi, decimal capacity, List<int> freeTree, int tot,int frm)
        {
            List<int> localList = new List<int>();
            int retfTree = -1;
            foreach (int ftree in getSomething(freeTree))
            {
                localList.Add(ftree);
                if (freeTree.Except(localList).ToList().Count == 0) break;
                if ((ftree == tot) || (ftree == frm)) continue; //if both are same
                if (mi[ftree] == 0 || !canAllJumpFrom(mi[ftree], ti[ftree])) continue;
                if (distance(xi[tot], yi[tot], xi[ftree], yi[ftree]) < capacity)
                {
                    retfTree = ftree;
                    break;
                }
                //if (localList.Except(freeTree).ToList().Count == 0) break;
            }

            return retfTree;
        }

        

        public static IEnumerable<int> getSomething(List<int> ip)
        {
            int index = 0;

            while (true)
                yield return ip[index++ % ip.Count];
        }
        private static decimal distance(int v1, int v2, int v3, int v4)
        {
            return Convert.ToDecimal (Math.Sqrt(((v1-v3)* (v1 - v3)) + ((v2-v4)* (v2 - v4))));
        }

        private static bool canAllJumpFrom( int mon, int thre)
        {
            return mon <= thre;
            //false if 5>2
        }
    }
}
