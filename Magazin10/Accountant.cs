﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    internal class Accountant : User
    {

        public void Delete()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    con.Remove(acc);
                    Converter.Ser<List<Accounting>>(con, json);
                    break;
                }
            }
        }

        ModelWorkera manager = new ModelWorkera();
        //Записи бухгалтерии системы
        List<Accounting> allBuh = new List<Accounting>();
        internal enum Post
        {
            F1 = ConsoleKey.F1,
            F2 = ConsoleKey.F2,
            F3 = ConsoleKey.F3,
            F4 = ConsoleKey.F4,
            Enter = ConsoleKey.Enter,
            UpArrow = ConsoleKey.UpArrow,
            DownArrow = ConsoleKey.DownArrow,
            Esc = ConsoleKey.Escape
        }
        public Accountant(ModelWorkera worker, List<Accounting> allBuh)
        {
            manager = worker;
            this.allBuh = allBuh;
        }
        public void Interface()
        {
            int pose = 2;
            int max = allBuh.Count() + 1;
            while (true)
            {
                //Усечение строки до файла с юзерами
                string startupPath = Directory.GetCurrentDirectory();
                int len1 = startupPath.Length - 17;
                string json = startupPath.Substring(0, len1) + "\\Accounting.json";
                List<Accounting> con = Converter.Des<List<Accounting>>(json);
                max = con.Count + 1;
                Console.Clear();
                Console.WriteLine(pose);
                Console.SetCursorPosition(0, pose);
                Console.WriteLine("->");

                InterfaceForUsers.PrintInterface(manager);

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == (ConsoleKey)Post.F1)
                {
                    Console.Clear();
                    Create();
                }
                else if (key.Key == (ConsoleKey)Post.F2)
                {
                    Console.Clear();
                    Search();
                }

                else if (key.Key == (ConsoleKey)Post.F3)
                {
                    Console.Clear();
                    Delete();
                }
                else if (key.Key == (ConsoleKey)Post.F4)
                {
                    Console.Clear();
                    Read(pose);
                }
                else if (key.Key == (ConsoleKey)Post.UpArrow)
                {
                    if (pose <= 2)
                    {
                        pose += max - 2;
                    }
                    else
                    {
                        pose--;
                    }

                }
                else if (key.Key == (ConsoleKey)Post.DownArrow)
                {
                    if (pose >= max)
                    {
                        pose -= max - 2;
                    }
                    else
                    {
                        pose++;
                    }

                }
                else if (key.Key == (ConsoleKey)Post.Enter)
                {
                    Console.Clear();
                    Update(pose);
                }
                else if (key.Key == (ConsoleKey)Post.Esc)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public void Create()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();
            Console.WriteLine("Введите сумму покупки");
            int sumPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вычитать или прибавлять (1 или 0)");
            int pribavka = Convert.ToInt32(Console.ReadLine());

            int id = con[con.Count - 1].id + 1;

            Accounting newAcc = new Accounting();
            newAcc.id = id;
            newAcc.name = name;
            newAcc.sumPrice = sumPrice;
            newAcc.pribavka = pribavka;

            con.Add(newAcc);

            Converter.Ser<List<Accounting>>(con, json);
        }

        public void Read(int id)
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    Console.WriteLine(acc.id);
                    Console.WriteLine(acc.name);
                    Console.WriteLine(acc.sumPrice);
                    Console.WriteLine(acc.pribavka);
                    break;
                }
            }
        }

        public void Search()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            Accounting newAcc = new Accounting();
            Console.WriteLine("Введите название товара");
            newAcc.name = Console.ReadLine();
            Console.WriteLine("Введите сумму покупки");
            newAcc.sumPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите вычитать или прибавлять (1 или 0)");
            newAcc.pribavka = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите id записи");
            newAcc.id = Convert.ToInt32(Console.ReadLine());

            foreach (Accounting acc in con)
            {
                if (acc == newAcc)
                {
                    Console.Clear();
                    Console.WriteLine(acc.id);
                    Console.WriteLine(acc.name);
                    Console.WriteLine(acc.sumPrice);
                    Console.WriteLine(acc.pribavka);
                    break;
                }
            }
        }

        public void Update(int id)
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    Console.WriteLine("Введите название товара");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите сумму покупки");
                    int sumPrice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите вычитать или прибавлять (1 или 0)");
                    int pribavka = Convert.ToInt32(Console.ReadLine());

                    Accounting vrem = acc; 
                    con.Remove(acc);
                    vrem.name = name;
                    vrem.sumPrice = sumPrice;
                    vrem.pribavka = pribavka;
                    Converter.Ser<List<Accounting>>(con, json);

                    break;
                }
            }
        }
    }
}
