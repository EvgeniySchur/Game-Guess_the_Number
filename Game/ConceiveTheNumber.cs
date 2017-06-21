using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game
{
    class ConceiveTheNumber
    {
        public static string[] texts =
        {
            $"\t {Localization.textsConcecive[0]} {GameLogic.MinRange} {Localization.textsConcecive[1]} {GameLogic.MaxRange} {Localization.textsConcecive[2]} ",
            $"\t{Localization.textsConcecive[3]} {GameLogic.MinUsrAnsw} {Localization.textsConcecive[4]}\n ",
            $"\t{Localization.textsConcecive[5]}",
            $"\t{Localization.textsConcecive[6]}\n\t {Localization.textsConcecive[7]}\n\t{Localization.textsConcecive[8]}\n\t{Localization.textsConcecive[9]}\n\t{Localization.textsConcecive[10]}",
            $"\t{Localization.textsConcecive[11]}",
            $"\t{Localization.textsConcecive[12]}",
            $"{Localization.textsConcecive[13]}",
            $"{Localization.textsConcecive[14]}",
            $"{Localization.textsConcecive[15]}",
            $"\t{Localization.textsConcecive[16]}",
            $"\t{Localization.textsConcecive[17]}",
            $"\t{Localization.textsConcecive[18]}"
        };
        enum Str
        {
            // Имена не дословно передают смысл выводимого сообщения
            CPU_Give_The_Max_Range,
            Conceive_The_Number,
            Print_Number,
            Explanations,
            Num_of_attempts,
            I_Think_Num_Is,
            More_Than,
            Less_Than,
            Equals,
            CPU_Win,
            User_Win,
            Bad_Help
        }
        public static bool correctAnswer;
        public static void StartGame()
        {
            Print(texts[(int)Str.CPU_Give_The_Max_Range]);

            int cpuRange = GameLogic.setRangeForUser();
            Print($"{cpuRange}");
            Print($"{texts[(int)Str.Conceive_The_Number]} {texts[(int)Str.Print_Number]}");

            string userNum = Console.ReadLine();
            Print(texts[(int)Str.Explanations]);
            GameInProgress(cpuRange);
        }
        public static void GameInProgress(int cpuRange)
        {
            int cpuAttempts = GameLogic.NumOfAttempts(cpuRange);
            Print($"{texts[(int)Str.Num_of_attempts]} {cpuAttempts}");
            Attempts(cpuRange, cpuAttempts);

            if (correctAnswer)
                Print(texts[(int)Str.CPU_Win]);

            if (!correctAnswer)
                Print(texts[(int)Str.User_Win]);

            GuessTheNumber.EndGame();
        }
        public static void Attempts(int cpuRange,int cpuAttempts)
        {            
            string[] answer = new string[cpuAttempts];
            var minRange = GameLogic.MinUsrAnsw;
            for (var i = 0; i < cpuAttempts; i++)
            {                
                var cpuAnswerNum = GameLogic.Randomize(minRange, cpuRange);
                Print($"{texts[(int)Str.I_Think_Num_Is]} {cpuAnswerNum}" );
                answer[i] = Console.ReadLine();
                bool errorInputAnswer = answer[i] != texts[(int)Str.More_Than] && answer[i] != texts[(int)Str.Less_Than] && answer[i] != texts[(int)Str.Equals];
                if (answer[i] == texts[(int)Str.More_Than])
                {
                    minRange = cpuAnswerNum+1;
                    continue;
                }
                if (answer[i] == texts[(int)Str.Less_Than])
                {
                    cpuRange = cpuAnswerNum-1;
                    continue;
                }
                if (answer[i] == texts[(int)Str.Equals])
                {
                    correctAnswer = true;
                    break;
                }
                if (errorInputAnswer)
                {
                    Print(texts[(int)Str.Bad_Help]);
                    i--;
                }
            }
        }
        static void Print(string s) => Console.WriteLine(s);
    }
}
