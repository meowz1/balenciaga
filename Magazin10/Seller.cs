using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    public class Seller
    {
        ModelWorkera seller = new ModelWorkera();
        //Товары на складе
        List<Product> allProd = new List<Product>();
        List<SellerProduct> selledProducts = new List<SellerProduct>();

        public void Save()
        {
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);

            Converter.Ser<List<Product>>(allProd, json);

            Console.WriteLine("Введите название файла сохранения проданных товаров");
            string filenameSelledProd = Console.ReadLine();
            Converter.Ser<List<SellerProduct>>(selledProducts, filenameSelledProd);


            //Усечение строки до файла с юзерами
            string startupPath1 = Directory.GetCurrentDirectory();
            int len1 = startupPath1.Length - 17;
            string json1 = startupPath1.Substring(0, len1) + "\\Accounting.json";
            List<Accounting> con1 = Converter.Des<List<Accounting>>(json1);

            foreach (SellerProduct i in selledProducts)
            {
                Accounting newAcc = new Accounting();
                newAcc.id = i.id;
                newAcc.name = i.name;
                newAcc.sumPrice = i.count * i.price;
                newAcc.pribavka = 1;
                con1.Add(newAcc);
            }

            Converter.Ser<List<Accounting>>(con1, json);

            selledProducts.Clear();

        }

        public Seller(ModelWorkera seller, List<Product> allProducts)
        {
            this.seller = seller;
            this.allProd = allProducts;
        }

        internal enum Post
        {
            S = ConsoleKey.S,
            Plus = ConsoleKey.OemPlus,
            Minus = ConsoleKey.OemMinus,
            Enter = ConsoleKey.Enter,
            UpArrow = ConsoleKey.UpArrow,
            DownArrow = ConsoleKey.DownArrow,
            Esc = ConsoleKey.Escape

        }
        public void Interface()
        {
            int pose = 2;
            int max = allProd.Count() + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pose);
                Console.SetCursorPosition(0, pose);
                Console.WriteLine("->");

                InterfaceForUsers.PrintInterface(seller);
                PrintOrder();

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == (ConsoleKey)Post.UpArrow)
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
                else if (key.Key == (ConsoleKey)Post.Plus)
                {
                    PlusProd(pose);
                }
                else if (key.Key == (ConsoleKey)Post.Minus)
                {
                    MInusProd(pose);
                }
                else if (key.Key == (ConsoleKey)Post.S)
                {
                    Save();
                }

                else if (key.Key == (ConsoleKey)Post.Esc)
                {
                    Console.Clear();
                    break;
                }
            }
        
        }
        public void PlusProd(int id)
        {            
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (Product prod in con)
            {
                ids.Add(prod.id);
            }

            Product product = con[ids.IndexOf(id)];
            if (selledProducts.Count() != 0)
            {
                foreach (SellerProduct i in selledProducts)
                {
                    if (i.id == product.id)
                    {
                        if (product.count >= i.count++)
                        {
                            SellerProduct vrem = i;
                            selledProducts.Remove(i);
                            vrem.count++;
                            selledProducts.Add(vrem);
                        
                            Product vrem2 = product;
                            con.Remove(product);
                            vrem.count--;
                            con.Insert(id, vrem2);

                            allProd = con;
                        }
                        
                    }
                }
                
            }
            else
            {
                SellerProduct newSell = new SellerProduct();
                newSell.name = product.name;
                newSell.id = product.id;
                newSell.price = product.price;
                newSell.count = product.count--;
                newSell.tookCount++;
                selledProducts.Add(newSell);
                        
                Product vrem2 = product;
                con.Remove(product);
                vrem2.count--;
                con.Insert(id, vrem2);

                allProd = con;
            }
        }
        public void MInusProd(int id)
        {
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (Product prod in con)
            {
                ids.Add(prod.id);
            }

            Product product = con[ids.IndexOf(id)];
            if (selledProducts.Count() != 0)
            {
                foreach (SellerProduct i in selledProducts)
                {
                    if (i.id == product.id)
                    {
                        if (i.count-- >= 0)
                        {
                            SellerProduct vrem = i;
                            selledProducts.Remove(i);
                            vrem.count--;
                            selledProducts.Add(vrem);
                        
                            Product vrem2 = product;
                            con.Remove(product);
                            vrem.count++;
                            con.Insert(id, vrem2);

                            allProd = con;
                        }
                        
                    }
                }
                
            }
        }

        public void PrintOrder()
        {
            foreach (Product i in selledProducts)
            {
                Console.WriteLine($"Название: {i.name},  Количество: {i.count}  Цена за шт.: {i.price}");
            }
        }

    }
}
