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
            :base(_NameOfProduct,_PurchaseDate,_StockBalance,_PurchasePrice)
        {
            this.NameOfProduct = _NameOfProduct;
            this.PurchaseDate = _PurchaseDate;
            this.PurchasePrice = _PurchasePrice;
            this.StockBalance = _StockBalance;
        }
        public Food(string _NameOfProduct, DateTime _PurchaseDate, int _StockBalance, double _PurchasePrice,
            string _UnitOfMeasurement,int _ExpirationDate,DateTime _DateOfManufacture)
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
            foreach(var f in foodsCollection)
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
                PurchasePrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Purchase Date (DateTime like '2010.1.6') ");
                PurchaseDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Stock Balance (int) ");
                StockBalance = Convert.ToInt32(Console.ReadLine());                
                Console.WriteLine("Enter Unit Of Measurment (String)");
                UnitOfMeasurment = Console.ReadLine();
                Console.WriteLine("Enter Date of Manufacture (DateTime) ");
                DateOfManufacture = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Expiration Date (int) ");
                ExpirationDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Name Of Product : {this.NameOfProduct}");
                Console.WriteLine($"Purchase Price : {this.PurchasePrice}");
                Console.WriteLine($"Purchase Date : {this.PurchaseDate}");
                Console.WriteLine($"Stock Balance : {this.StockBalance}");
                Console.WriteLine($"Unit Of Measurment : {this.UnitOfMeasurment}");
                Console.WriteLine($"Date of Manufacture : {this.DateOfManufacture}");
                Console.WriteLine($"Expiration Date is : {this.ExpirationDate}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                       
        }
        public string UnitOfMeasurment { get; set; }
        public int ExpirationDate { get; set; }
        public DateTime DateOfManufacture { get; set; }
    }
}
