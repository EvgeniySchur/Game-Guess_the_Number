using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Localization
    {
        static string file = @"..\..\lib\localization_game.ru";
        static  List<string> lines = new List<string>();
       
        public static string[] textsGameManager;
        public static string[] textsGuess;
        public static string[] textsConcecive;
        //Разграничители, они указывают, до какой строки считывается информация для каджого модуля (менеджер, угадывание и загадывание)
        static string[] _break = {
            "---break_lines_gm---",
            "---break_lines_guess---",
            "---break_lines_conceive---"
        };
        public static void ReadAll()
        {
            var counter = 0;
            var j = 0;

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file, Encoding.Default))
                {
                    var line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                        counter++;
                    }
                }
            }
            else
            {
                throw new Exception("files of localization is damaged, reinstall the application");
            }
            textsGameManager = new string[counter];
            textsGuess = new string[counter];
            textsConcecive = new string[counter];

            for (var i = 0; i < counter; i++)
            {
                if (lines[i] != _break[0])
                    textsGameManager[i] += lines[i];
                else
                    break;
            }
            for (var i = 0; i < counter; i++)
            {
                if (i > lines.IndexOf(_break[0]))
                {
                    if (lines[i] != _break[1])
                    {
                        textsGuess[j] += lines[i];
                        j++;
                    }
                    else if (lines[i] == _break[1])
                        break;

                }
            }
            j = 0;
            for (var i = 0; i < counter; i++)
            {
                if (i > lines.IndexOf(_break[1]))
                {
                    if (lines[i] != _break[2])
                    {
                        textsConcecive[j] += lines[i];
                        j++;
                    }
                    else if (lines[i] == _break[2])
                        break;

                }
            }
           
        }
           
    }
}
