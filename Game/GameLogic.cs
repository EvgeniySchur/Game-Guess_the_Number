using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{   
    public static class GameLogic
    {
        public const int MinRange = 10;
        public const int MaxRange = 100;
        public const int MinUsrAnsw = 0;

        public static int inputRange = MinRange;
        public static int inputUserAnswer = MinUsrAnsw;
        public static int cpuAnswer = MinUsrAnsw;
        public static int InputRange { get { if (inputRange < MinRange) return MinRange; if (inputRange > MaxRange) return MaxRange; return inputRange; } }  
        public static int InputUserAnswer { get { if (inputUserAnswer < MinUsrAnsw) return MinUsrAnsw; if (inputUserAnswer > MaxRange) return MaxRange; return inputUserAnswer; } }
        public static Func<int, int, int> Randomize = (c,d) => new Random().Next(c,d);
        public static int setRangeForUser() => new Random().Next(MinRange, MaxRange);
        public static int NumOfAttempts(int inputRange)
        {
            var counter = 0;
            var balance = inputRange;
            for (var i = 0; i < inputRange; i++)
            {
                if (balance < 2)
                    break;
                balance = balance / 2;
                counter++;
               
            }
            return counter;
        }
     }
}
