using System;

namespace ConsoleApp1_QA_
{
    //Створіть клас Date, який буде містити інформацію про дату(день, місяць, рік).
    //За допомогою механізму перевантаження операторів, визначте операцію різниці 
    //двох дат(результат у вигляді кількості днів між датами), а також операцію 
    //збільшення дати на певну кількість днів.
    class Date
    {
        public int day, month, year, days, result,add;
        private bool flag=true;
        public Date()
        {
            day = 0;
            month = 0;
            year = 0;
        }
        public Date(int day,int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            days = day + month * 30 + year * 360;
            flag = check(day, month, year);
        }
        public void print()
        {
            if (flag == true)
            {
                Console.WriteLine($"({day}.{month}.{year})");
            }
            else
            {
                Console.WriteLine("Date is invalid");
                Environment.Exit(0);
            }
        }
        public bool check(int day,int month,int year)
        {
            if (day >= 1 && day <= 31 && month >= 1 && month <= 12 && year >= 0)
            {
                this.day = day;
                this.month = month;
                this.year = year;
                return true;
            }
            return false;
        }
        public void AddDays(int days)
        {
            day += days;
        }
        public static Date operator -(Date date1,Date date2)
        {
            Date abc=new Date();
            abc.result = date1.days - date2.days;
            return abc;
        }
        public static Date operator +(Date date1, int days)
        {
            Date abc = new Date(date1.day+days,date1.month,date1.year);
            return abc;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Date one = new Date(17,01,2021);
            Console.Write("First date is ");
            one.print();
            Date two = new Date(25, 01, 2021);
            Console.Write("Second date is ");
            two.print();
            Date three = two - one;
            Console.WriteLine($"Deeference between dates is {three.result} days");
            Console.Write("First date + 10 days = ");
            Date four = one + 10;
            four.print();
        }
    }
}
