//программа переводит Гривны в Евро, 
//актуальный курс валют берет из сайта НБУ.

using System.Text.Json;
using System;
using System.Linq;
using System.Net;

namespace curency_converter
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the amount of hryvnia: ");
            double uah = double.Parse(Console.ReadLine());
            double cource = GetCourse();
            Console.WriteLine("Euro exchange rate: " + cource);
            Console.WriteLine("{0} UAH. = {1} Euro.", uah,
                Math.Round(uah / cource, 2));
            Console.ReadKey();
        }
        static double GetCourse()
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string data = client.DownloadString("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
            var currencies = JsonSerializer.Deserialize<Root[]>(data); 
            return currencies.Where(c => c.cc.Equals("EUR", StringComparison.InvariantCultureIgnoreCase)).First().rate;
        }
    }

    public class Root
    {
        public int r030 { get; set; }
        public string txt { get; set; }
        public double rate { get; set; }
        public string cc { get; set; }
        public string exchangedate { get; set; }
    }
}


