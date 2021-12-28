using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhopalJailBreak
{
    public class MainLogic
    {
        int TotalAttempts = 0;
        public int MethodOne(int input1, int input2, int[] input3)
        {
            for (int i = 0; i < input3.Length; i++)
            {

                int attemptToCrossThisWall = attempTOCrossThisSingleWall(input1,input2,input3[i]);
                TotalAttempts +=  attemptToCrossThisWall;
            }

            return TotalAttempts;
        }

        public int attempTOCrossThisSingleWall(int abilityToJump,int slipHeight,int HeightOfWall)
        {
            if (abilityToJump >= HeightOfWall) return 1;
            else
            {
                int tempResult = Math.DivRem(HeightOfWall, (abilityToJump - slipHeight), out tempResult);
                //if (HeightOfWall % (abilityToJump - slipHeight) > 1) return ++tempResult;
                return ((HeightOfWall % (abilityToJump - slipHeight) > 1)) ? tempResult : ++tempResult;
                //else return tempResult;
            }
            //return 0;
        }
    }
}

/*

       static int TotalAttempts = 0;
    static int GetJumpCount(int input1,int input2,int[] input3)
    {
    	//Write code here
    	 for (int i = 0; i < input3.Length; i++)
            {

                int attemptToCrossThisWall = attempTOCrossThisSingleWall(input1,input2,input3[i]);
                TotalAttempts +=  attemptToCrossThisWall;
            }

            return TotalAttempts;
    }
     static int attempTOCrossThisSingleWall(int abilityToJump,int slipHeight,int HeightOfWall)
        {
            if (abilityToJump >= HeightOfWall) return 1;
            else
            {
                int tempResult = Math.DivRem(HeightOfWall, (abilityToJump - slipHeight), out tempResult);
                if (HeightOfWall % (abilityToJump - slipHeight) > 1) return ++tempResult;
                else return tempResult;
            }
            //return 0;
        }


 * */
