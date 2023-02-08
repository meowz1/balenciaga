using Magazine;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace Magazine
{
    public class Program
    {
        static void Main(string[] argrs)
        {
            while (true)
            {
                string startupPath = Directory.GetCurrentDirectory();
                int len = startupPath.Length - 17;


                string jsonUs = startupPath.Substring(0, len) + "\\UserTables.json";
                List<UserTable> convert = Converter.Des<List<UserTable>>(jsonUs);

                string json = startupPath.Substring(0, len) + "\\usersData.json";
                List<ModelWorkera> con = Converter.Des<List<ModelWorkera>>(json);

                List<(string, string)> logins = new List<(string, string)>();
                for (int i = 0; i < con.Count; i++)
                {
                    logins.Add((con[i].name, con[i].password));
                }

                int ind = Autorize.Aut(logins);
                ModelWorkera worker = new ModelWorkera();
                if (ind != -1)
                {
                    worker = con[ind];
                }
                else
                {
                    foreach (ModelWorkera i in con)
                    {
                        if (i.atribute == -1)
                        {
                            worker = i;
                        }
                    }
                }


                switch (worker.atribute)
                {
                    case -1:
                        Console.WriteLine("Попробуй в другой раз");
                        break;
                    case 1:
                        Console.Clear();
                        Admin admin = new Admin(worker, convert);
                        admin.Interface();
                        break;
                    case 2:
                        Console.Clear();
                        Manager manager = new Manager(worker, con);
                        manager.Inteface();
                        break;
                    case 3:
                        Console.Clear();
                        string allPath = Directory.GetCurrentDirectory();
                        int lenProd = startupPath.Length - 17;
                        string jsonProd = startupPath.Substring(0, lenProd) + "\\Product.json";
                        List<Product> products = Converter.Des<List<Product>>(jsonProd);
                        WarehouseManager warehouseManager = new WarehouseManager(worker, products);
                        warehouseManager.Interface();
                        break;
                    case 4:
                        Console.Clear();
                        string allPathForSeller = Directory.GetCurrentDirectory();
                        int lenProdSeller = startupPath.Length - 17;
                        string jsonProdSeller = startupPath.Substring(0, lenProdSeller) + "\\Product.json";
                        List<Product> productsSeller = Converter.Des<List<Product>>(jsonProdSeller);
                        Seller seller = new Seller(worker, productsSeller);
                        seller.Interface();
                        break;
                    case 5:
                        Console.Clear();
                        string allPathForAccountant = Directory.GetCurrentDirectory();
                        int lenAcc = startupPath.Length - 17;
                        string jsonAcc = startupPath.Substring(0, lenAcc) + "\\Accounting.json";
                        List<Accounting> accounting = Converter.Des<List<Accounting>>(jsonAcc);
                        Accountant accountant = new Accountant(worker, accounting);
                        accountant.Interface();
                        break;
                }
            }

        }
    }
}