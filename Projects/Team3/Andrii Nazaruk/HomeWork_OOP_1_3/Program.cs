using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_OOP_1_2
{
    class Program
    {
        //"* Опишіть клас Товари, який містить 
        // поля: назва, ціна закупки, дата закупки, залишок на складі
        //конструктор з параметрами
        //функції консольного введення та виведення полів
        //Getteres Setters
        //overridden ToString() метод, який виводить усі поля об'єкту
        //Реалізуйте клас наслідник Харчові Товари, який має додаткові поля: одиниця виміру, строк придатності, дата виготовлення
        //Конструктор з параметрами, додаткові getters та setters.Overridden input() та output(). 
        // Метод GetExpirationDays() що виводить кількість днів до завершення придатності

        //Створіть колекцію Товарів, додати кілька різних товарів та харчових товарів до цієї колекції
        //реалізуйте виведення товарів виготовлених у минулому році, відсорувавши їх за ціною
        //виведііть харчові товари відсортовані за терміном придатності
        //збережіть колекцію у файл
        //реалізуйте опрацювання виключень (Exceptions)
        //сереалізуйте (Serialize) колекцію в JSON файл
        //десереалізуйте колекцію з JSON файла
        //напишіть unit тести до реалізованих функцій"
        static void Main(string[] args)
        {
            //add list of products
            Product product = new Product();
            List<Product> products = new List<Product>();
            products.Add(new Product("Water", DateTime.Parse("2020.7.15"), 6, 12.4));
            products.Add(new Product("Beer", DateTime.Parse("2021.1.16"), 7, 30.4));
            products.Add(new Product("Cigaretes", DateTime.Parse("2020.5.2"), 8, 55.5));
            products.Add(new Product("Meat", DateTime.Parse("2029.11.5"), 50, 20.4));
            products.Add(new Product("Shampoo", DateTime.Parse("2019.12.17"), 57, 80.5));
            products.Add(new Product("Meat", DateTime.Parse("2021.1.5"), 66, 20.4));


            //add alcohol collection
            Alcohol alcohol = new Alcohol();
            List<Alcohol> alcoholCollection = new List<Alcohol>();
            alcoholCollection.Add(new Alcohol("Vodka", DateTime.Parse("2020.11.19"), 150, 101.5));
            alcoholCollection.Add(new Alcohol("Bear", DateTime.Parse("2019.6.21"), 456, 23.5));
            alcoholCollection.Add(new Alcohol("Wine", DateTime.Parse("2015.5.20"), 40, 101.5));
            alcoholCollection.Add(new Alcohol("Whiskey", DateTime.Parse("1999.2.10"), 4, 755.4));



            //add list of food product 
            Food food = new Food();
            var foodsCollection = new List<Food>();
            foodsCollection.Add(new Food("Potato", DateTime.Parse("2021.1.30"), 185, 23.5, "Kg", 343, DateTime.Parse("2021.1.1")));
            foodsCollection.Add(new Food("Bread", DateTime.Parse("2021.1.4"), 136, 10.3, "Kg", 123, DateTime.Parse("2021.1.8")));
            foodsCollection.Add(new Food("Oil", DateTime.Parse("2021.1.20"), 40, 47.2, "Litre", 433, DateTime.Parse("2020.4.6")));
            foodsCollection.Add(new Food("Apple", DateTime.Parse("2021.5.6"), 169, 40.3, "Kg", 5, DateTime.Parse("2021.1.10")));
            foodsCollection.Add(new Food("Sugar", DateTime.Parse("2020.6.3"), 77, 37.9, "Kg", 640, DateTime.Parse("2019.7.6")));
            foodsCollection.Add(new Food("Orange", DateTime.Parse("2021.1.8"), 32, 66.5, "Litre", 3, DateTime.Parse("2021.1.2")));
            foodsCollection.Add(new Food("Cherry", DateTime.Parse("2021.1.10"), 55, 82.1, "Kg", 3, DateTime.Parse("2021.1.3")));
            foodsCollection.Add(new Food("Juice", DateTime.Parse("2021.1.12"), 43, 47.5, "Litre", 3, DateTime.Parse("2021.1.5")));
            foodsCollection.Add(new Food("IceCream", DateTime.Parse("2021.1.2"), 32, 40.9, "Kg", 3, DateTime.Parse("2021.1.4")));

            products.AddRange(foodsCollection);
            products.AddRange(alcoholCollection);


            //this function select all food product from products at last year and sorted by price
            static void OrderByLastYear(List<Product> products)
            {
                try
                {
                    var result = products.
                        Where(x => x.PurchaseDate.Year == DateTime.Now.Year - 1).
                        OrderBy(x => x.PurchasePrice);
                    foreach (var f in result)
                    {

                        Console.WriteLine($"Product Name :{f.NameOfProduct}");
                        Console.WriteLine($"Product Purchase Price is : {f.PurchasePrice}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine(ex.Message);
                }

            }
            //this function get experiations days from food collection
            static void GetExpirationDays(List<Food> foodsCollection)
            {
                try
                {
                    foreach (var f in foodsCollection)
                    {
                        int days = DateTime.Now.Subtract(f.DateOfManufacture).Days;
                        int sub = days - f.ExpirationDate;
                        if (sub <= 0)
                        {
                            Console.WriteLine($"{f.NameOfProduct} have {Math.Abs(sub)} days left");
                        }
                        else
                        {
                            Console.WriteLine($"{f.NameOfProduct} Is Bad!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine(ex.Message);
                }
            }
            //this function sorted product by expiration date
            static void OrderByExpirationDate(List<Product> products)
            {
                var result = products.OfType<Food>().
                    OrderBy(x => x.ExpirationDate).
                    ToList();
                foreach (var f in result)
                {
                    Console.WriteLine(f.NameOfProduct);
                }
            }
            //this function write collection on disc D to dataProduct.txt
            static void WriteCollectionToFile(List<Product> products)
            {
                string path = @"D:\dataProduct.txt";
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        foreach (var p in products)
                        {
                            sw.WriteLine($"Product Name : {p.NameOfProduct} | Purchase Price : {p.PurchasePrice} | " +
                                $"Purchase Date : {p.PurchaseDate} | Stock Balance : {p.StockBalance}");
                        }
                    }
                    Console.WriteLine($"Data was written on Disc D:");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine(ex.Message);
                }
            }
            //this functtion serialize and deserialize product collection
            static void JSONSerializationAndDeserialization(List<Product> products)
            {
                try
                {
                    Console.WriteLine("Json Serialize");
                    using (var fileStream = new FileStream("productsCollection.json", FileMode.OpenOrCreate))
                    {
                        string jsonString = JsonConvert.SerializeObject(products);
                        byte[] array = System.Text.Encoding.Default.GetBytes(jsonString);
                        fileStream.Write(array, 0, array.Length);
                        Console.WriteLine("Data has been serialize to productCollection.json !");
                    }
                    Console.WriteLine("----------------------------------");

                    using (StreamReader sr = File.OpenText("productsCollection.json"))
                    {
                        var collection = JsonConvert.DeserializeObject<List<Product>>(sr.ReadLine());
                        Console.WriteLine("Collection from Json");

                        foreach (var p in collection)
                        {
                            Console.WriteLine($"Product Name : {p.NameOfProduct}");
                            Console.WriteLine($"Purchase Date : {p.PurchaseDate}");
                            Console.WriteLine($"Purchase Price : {p.PurchasePrice}");
                            Console.WriteLine($"Stock Balance : {p.StockBalance}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                    Console.WriteLine(ex.Message);
                }

            }


            JSONSerializationAndDeserialization(products);
            WriteCollectionToFile(products);
            OrderByExpirationDate(products);
            OrderByLastYear(products);
            GetExpirationDays(foodsCollection);

            //this methods print info from collections
            //product.Print(products);
            //alcohol.Print(alcoholCollection);
            //food.Print(foodsCollection);

            //this methods are input and output info to(from) console
            //product.ConsoleInputAndOutPut();
            //food.ConsoleInputAndOutPut();

        }
    }
}


