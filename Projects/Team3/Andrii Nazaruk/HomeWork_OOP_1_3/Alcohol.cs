using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1_2
{
    [Serializable]
    public class Alcohol : Product
    {
        public Alcohol()
        {

        }
        public Alcohol(string _NameOfProduct, DateTime _PurchaseDate, int _StockBalance, double _PurchasePrice)
            : base(_NameOfProduct, _PurchaseDate, _StockBalance, _PurchasePrice)
        {
            this.NameOfProduct = _NameOfProduct;
            this.PurchaseDate = _PurchaseDate;
            this.PurchasePrice = _PurchasePrice;
            this.StockBalance = _StockBalance;
        }

        public override void ConsoleInputAndOutPut()
        {
            base.ConsoleInputAndOutPut();
        }
      
        public void Print(List<Alcohol> alcoholCollection)
        {
            foreach(var a in alcoholCollection)
            {
                Console.WriteLine($"Name Of Product : {a.NameOfProduct}");
                Console.WriteLine($"Purchase Price : {a.PurchasePrice}");
                Console.WriteLine($"Purchase Date : {a.PurchaseDate}");
                Console.WriteLine($"Stock Balance : {a.StockBalance}");
            }
        }
    }
}
