using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameManager
    {
        
        public static string[] textsGM = {
            $"\t{Localization.textsGameManager[0]}",
            Localization.textsGameManager[1],
            Localization.textsGameManager[2],
            Localization.textsGameManager[3],
            Localization.textsGameManager[4],
            $"\t{Localization.textsGameManager[5]}"
        };
        enum Str
        {
            // Имена не дословно передают смысл выводимого сообщения
            Guess_Or_Conceive,
            One,
            One_Plus_Shift,
            Two,
            Two_Plus_Shift,
            Bad_Value
        }
        public static void Dialogue()
        {           
            for (var i = 0; i < int.MaxValue; i++)
            {
                Console.WriteLine(textsGM[(int)Str.Guess_Or_Conceive]);
                string answer = Console.ReadLine();
                if (answer == textsGM[(int)Str.One] || answer == textsGM[(int)Str.One_Plus_Shift])
                {
                    Console.Clear();
                    GuessTheNumber.StartGame();
                    break;
                }
                else if (answer == textsGM[(int)Str.Two] || answer == textsGM[(int)Str.Two_Plus_Shift])
                {
                    Console.Clear();
                    ConceiveTheNumber.StartGame();
                    break;
                }
                else
                {
                    Console.WriteLine(textsGM[(int)Str.Bad_Value]);
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
            }
         }
        public static void GameCycle()
        {
            for (var i = 0; i < int.MaxValue; i++)
            {
                Dialogue();
                if (GuessTheNumber.anotherGame)
                {
                    Console.Clear();
                    GuessTheNumber.anotherGame = false;
                    GuessTheNumber.correctAnswer = false;
                    ConceiveTheNumber.correctAnswer = false;
                    continue;
                }
                else
                    break;
            }
        }
    }
}
