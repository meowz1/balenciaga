using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Magazine
{
    internal class Autorize
    {
        public static int user;

        public static (string, string, bool) PasswordInput(string name, List<(string, string)> workers)
        {

            //Ввод пароля, да не обычного, а типа пассворд бокса!
            string inpt = string.Empty;
            while (!workers.Contains((name, inpt)))
            {
                Console.Write("Введите пароль: ");
                inpt = string.Empty;
                while (true)
                {
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter) break;

                    Console.Write("*");
                    inpt += key.KeyChar;
                }
                
                if (!workers.Contains((name, inpt)))
                {
                    Console.WriteLine("Unanswered password");
                    break;
                }
                Console.WriteLine();
            }
            if (!workers.Contains((name, inpt)))
            {
                return (name, inpt, false);
            }
            else if (workers.Contains((name, inpt)))
            {
                return (name, inpt, true);
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Unanswered");
                return (name, inpt, false);
            }
        }

        public static int Aut(List<(string, string)> workers)
        {
            while (true)
            {
                //Ввод логина юзера
                Console.WriteLine("Введите имя");
                string name= Console.ReadLine();

                var password = PasswordInput(name, workers);
                if (password.Item3 == false)
                {
                    return -1;

                }
                else if (password.Item3 == true)
                {
                    foreach (var worker in workers)
                    {
                        Console.WriteLine(worker);
                    }


                    return workers.IndexOf((password.Item1, password.Item2));
                }
            }
            

        }
    }
}
