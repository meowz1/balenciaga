﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    public class InterfaceForUsers
    {
        public static string[] roles = new string[] { "Admin", "Manager", "Warehouse Manager", "Seller", "Accountant"};


        public static void UsersForAdmin()
        {

            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\UserTables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            //Вывод юзеров этой говёной системы
            for (int i = 2; i < con.Count + 2; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].login}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].password}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].role}");
            }

        }
        public static void UsersForManager()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\userData.json";
            List<ModelWorkera> con = Converter.Des<List<ModelWorkera>>(json);
            //Вывод юзеров этой говёной системы
            for (int i = 2; i < con.Count + 2; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].password}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].atribute}");
            }
        }
        public static void ProductsForWarehouseManager()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);
            //Вывод товаров этой говёной системы
            for (int i = 2; i < con.Count + 2; i++)
            {

                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].price}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].count}");
            }
        }

        public static void AccountingPrint()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);
            //Вывод бухгалтерии этой говёной системы
            int allSum = 0;
            for (int i = 2; i < con.Count + 2; i++)
            {

                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"Name {con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"Price {con[i - 2].sumPrice}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].pribavka}");

                if (con[i - 2].pribavka == 1)
                {
                    allSum += con[i - 2].sumPrice;
                }
                else if (con[i - 2].pribavka == 0)
                {
                    allSum -= con[i - 2].sumPrice;
                }
            }

            Console.WriteLine($"Общая сумма выручки: {allSum}");

        }
        public static void PrintInterface(ModelWorkera user)
        {
            //Здесь делается интерфейс для админа
            Console.WriteLine(user.atribute);
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Добро пожаловать, {user.name}");
            Console.SetCursorPosition(85, 0);
            Console.WriteLine($"Роль: {roles[user.atribute - 1]}");
            Console.WriteLine("______________________________________________________________________________________________________________________________________________");
            if (user.atribute == 1)
            {
                UsersForAdmin();
            }
            else if (user.atribute == 2)
            {
                UsersForManager();
            }
            else if (user.atribute == 3)
            {
                ProductsForWarehouseManager();
            }
            else if (user.atribute == 4)
            {
                ProductsForWarehouseManager();
            }


            for (int i = 2; i < 12; i++)
            {
                Console.SetCursorPosition(85, i);
                Console.WriteLine("|");
            }
            if (user.atribute != 4)
            {
                Console.SetCursorPosition(95, 2);
                Console.WriteLine("F1 - добавить запись");
                Console.SetCursorPosition(95, 3);
                Console.WriteLine("F2 - найти запись");
                Console.SetCursorPosition(95, 4);
                Console.WriteLine("F3 - удалить запись");
                Console.SetCursorPosition(95, 5);
                Console.WriteLine("F4 - прочитать запись");
            }
            
        }
    }
}
