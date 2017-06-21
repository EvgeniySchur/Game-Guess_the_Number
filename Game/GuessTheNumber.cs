using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GuessTheNumber
    {        
        public static string[] texts =
        {
            $"\t{Localization.textsGuess[0]} {GameLogic.MinRange} {Localization.textsGuess[1]} {GameLogic.MaxRange}\n",
            $"\t{Localization.textsGuess[2]}",
            $"\t{Localization.textsGuess[3]} {GameLogic.MinUsrAnsw} {Localization.textsGuess[4]}",
            $"\t{Localization.textsGuess[5]}\n",
            $"{Localization.textsGuess[6]}",
            $"\t{Localization.textsGuess[7]}",//5
            $"\t{Localization.textsGuess[8]}",//6
            $"\t{Localization.textsGuess[9]}\n",//7
            $"\t{Localization.textsGuess[10]}\n",
            $"\t{Localization.textsGuess[11]}\n",
            $"\t{Localization.textsGuess[12]}\n",
            $"{Localization.textsGuess[13]}",
            $"{Localization.textsGuess[14]}",
            $"{Localization.textsGuess[15]}",
            $"\t{Localization.textsGuess[16]}",
            $"\t{Localization.textsGuess[17]}",
            $"\t{Localization.textsGuess[18]}"

        };
        enum Str
        {
            User_Set_Max_Range,
            CPU_Conceive_The_Number,
            Input_The_Nunmber,
            Play_Again_Question,
            Yes,
            Too_Small_Number,
            Too_Big_Number,
            My_Number_is_Greater,
            My_Number_is_Smaller,
            You_Win,
            You_Lose,
            Yes_Tranliteration_1,
            Yes_Tranliteration_2,
            Yes_Lower,
            Out_Of_Range,
            Out_of_Range_CPU_Set_Range,
            One_Attempt_is_Spent

        }
        public static bool anotherGame;
        public static bool correctAnswer;
        public static string Error(int input)
        {
            Func<int, string> Range = c => c <GameLogic.MinRange || c > GameLogic.MaxRange || c > GameLogic.InputRange ? texts[(int)Str.Out_of_Range_CPU_Set_Range] : string.Empty;

            Func<int, string> Answer = c => c < GameLogic.MinUsrAnsw || c > GameLogic.MaxRange || c > GameLogic.InputRange ? texts[(int)Str.Out_Of_Range] : string.Empty;

            return input == GameLogic.inputRange ? Range(input) : Answer(input);
        }

        public static void Attempts(int numOfAttempts, int numIHadInMind)
        {           
            for (var i = 0; i < numOfAttempts; i++)
            {                
                GameLogic.inputUserAnswer = Convert.ToInt32(Console.ReadLine());
                Print(Error(GameLogic.inputUserAnswer));
                if (Error(GameLogic.inputUserAnswer) != string.Empty)
                    Print(texts[(int)Str.One_Attempt_is_Spent]);

                if (GameLogic.InputUserAnswer < numIHadInMind)
                {
                    Print(texts[(int)Str.My_Number_is_Greater]);
                    continue;
                }
                if (GameLogic.InputUserAnswer > numIHadInMind)
                {
                    Print(texts[(int)Str.My_Number_is_Smaller]);
                    continue;
                }
                if (GameLogic.InputUserAnswer == numIHadInMind)
                {
                    correctAnswer = true;
                    break;
                }
             }
         }
        public static void StartGame()
        {
            Print(texts[(int)Str.User_Set_Max_Range]);
            GameLogic.inputRange = Convert.ToInt32(Console.ReadLine());
            Print(Error(GameLogic.inputRange));
            if (Error(GameLogic.inputRange) != string.Empty)
                Print($"{GameLogic.InputRange}");

            GameInProgress();
        }
        public static void GameInProgress()
        {
            var numIHadInMind = GameLogic.Randomize(0,GameLogic.InputRange);
            var numOfAttempts = GameLogic.NumOfAttempts(numIHadInMind);

            Print(texts[(int)Str.CPU_Conceive_The_Number]);
            Print($"{texts[(int)Str.Input_The_Nunmber]} {numOfAttempts}");
            Attempts(numOfAttempts, numIHadInMind);

            if (correctAnswer)
                Print(texts[(int)Str.You_Win]);

            if (!correctAnswer)
                Print(texts[(int)Str.You_Lose]);

            EndGame();
        }
        public static void EndGame()
        {
            Print(texts[(int)Str.Play_Again_Question]);
            var anotherGameAnswer = Console.ReadLine();
            var anotherGameTrue = anotherGameAnswer == texts[(int)Str.Yes] || anotherGameAnswer == texts[(int)Str.Yes_Tranliteration_1] || anotherGameAnswer == texts[(int)Str.Yes_Tranliteration_2] || anotherGameAnswer == texts[(int)Str.Yes_Lower];
            if (anotherGameTrue)
                anotherGame = true;
            else
                anotherGame = false;

        }
       static void Print(string s) => Console.WriteLine(s);

    }
}
