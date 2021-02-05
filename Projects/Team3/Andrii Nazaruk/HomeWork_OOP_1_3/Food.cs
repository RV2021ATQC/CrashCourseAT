using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1_2
{
    [Serializable]
    public class Food : Product
    {

        public Food()
        {

        }
        public Food(string _NameOfProduct, DateTime _PurchaseDate, int _StockBalance, double _PurchasePrice)
            : base(_NameOfProduct, _PurchaseDate, _StockBalance, _PurchasePrice)
        {
            this.NameOfProduct = _NameOfProduct;
            this.PurchaseDate = _PurchaseDate;
            this.PurchasePrice = _PurchasePrice;
            this.StockBalance = _StockBalance;
        }
        public Food(string _NameOfProduct, DateTime _PurchaseDate, int _StockBalance, double _PurchasePrice,
            string _UnitOfMeasurement, int _ExpirationDate, DateTime _DateOfManufacture)
            : base(_NameOfProduct, _PurchaseDate, _StockBalance, _PurchasePrice)
        {
            this.NameOfProduct = _NameOfProduct;
            this.PurchaseDate = _PurchaseDate;
            this.PurchasePrice = _PurchasePrice;
            this.StockBalance = _StockBalance;
            this.UnitOfMeasurment = _UnitOfMeasurement;
            this.DateOfManufacture = _DateOfManufacture;
            this.ExpirationDate = _ExpirationDate;
        }

        public void Print(List<Food> foodsCollection)
        {
            foreach (var f in foodsCollection)
            {
                Console.WriteLine($"NameOfProduct : {f.NameOfProduct}");
                Console.WriteLine($"PurchaseDate : {f.PurchaseDate}");
                Console.WriteLine($"StockBalance : {f.StockBalance}");
                Console.WriteLine($"UnitOfMeasurment : {f.UnitOfMeasurment}");
                Console.WriteLine($"DateOfManufacture : {f.DateOfManufacture}");
                Console.WriteLine($"ExpirationDate : {f.ExpirationDate}");
            }

        }

        public override void ConsoleInputAndOutPut()
        {
            try
            {
                Console.WriteLine("Enter Product Name (String)");
                NameOfProduct = Console.ReadLine();


                Console.WriteLine("Enter Purchase Price (Double) ");
                string PurchasePrice = Console.ReadLine();
                if (double.TryParse(PurchasePrice, out double _purchasePrice))
                {
                    Console.WriteLine($"Purchase price parsed , Purchase Price = {PurchasePrice}");
                    this.PurchasePrice = _purchasePrice;
                }
                else
                    Console.WriteLine($"You enter a wrong value");


                Console.WriteLine("Enter Purchase Date (DateTime like '2010.1.6') ");
                string PurchaseDate = Console.ReadLine();
                if (DateTime.TryParse(PurchaseDate, out DateTime _purchaseDate))
                {
                    Console.WriteLine($"Purchase Date parsed , Purchase Date : {PurchaseDate}");
                    this.PurchaseDate = _purchaseDate;
                }
                else
                    Console.WriteLine($"You input a wrong format");


                Console.WriteLine("Enter Stock Balance (int)");
                string StockBalance = Console.ReadLine();
                if (int.TryParse(StockBalance, out int _stockbalance))
                {
                    Console.WriteLine($"Stock Balance parsed , Stock Balance = {StockBalance}");
                    this.StockBalance = _stockbalance;
                }

                Console.WriteLine("Enter UnitOfMeasurment : ");
                string UnitOfMeasurment = Console.ReadLine();
                this.UnitOfMeasurment = UnitOfMeasurment;

                Console.WriteLine($"Enter date of manufacture like '2020.20.10'");
                string DateOfManufacture = Console.ReadLine();
                if (DateTime.TryParse(DateOfManufacture, out DateTime _dateofmanufacture))
                {
                    Console.WriteLine($"Date of Manufacture parsed , date of manufacture : {DateOfManufacture}");
                    this.DateOfManufacture = _dateofmanufacture;
                }
                else
                    Console.WriteLine("You input a wrong format");


                Console.WriteLine("Enter expiration date (int)");
                string ExpirationDate = Console.ReadLine();
                if (int.TryParse(ExpirationDate, out int _expirationdate))
                {
                    Console.WriteLine($"Expiration date is parsed , expiration date is {ExpirationDate}");
                    this.ExpirationDate = _expirationdate;
                }
                else
                {
                    Console.WriteLine("You input wrong value");
                }

                Console.WriteLine($"Name Of Product : {this.NameOfProduct}");
                Console.WriteLine($"Purchase Price : {this.PurchasePrice}");
                Console.WriteLine($"Purchase Date : {this.PurchaseDate}");
                Console.WriteLine($"Stock Balance : {this.StockBalance}");
                Console.WriteLine($"UnitOfMeasurment : {this.UnitOfMeasurment}");
                Console.WriteLine($"DateOfManufacture : {this.DateOfManufacture}");
                Console.WriteLine($"ExpirationDate : {this.ExpirationDate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public string UnitOfMeasurment { get; set; }
        public int ExpirationDate { get; set; }
        public DateTime DateOfManufacture { get; set; }
    }
}
