/*Create a Date class that will contain date information (day, month, year).
 Using the operator overload mechanism, determine the operation of the difference of two dates 
(the result in the form of the number of days between dates), 
as well as the operation of increasing the date by a certain number of days.*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace OOP_2_3_Date
{
    public class Date
    {
        private DateTime date;
        private string day;
        private string month;
        private string year;

        public static DateTime WaitDate(int nom)
        {
            Console.WriteLine("\r\nInput date{0}: ", nom);
            string inputString = Console.ReadLine();
            DateTime fromDateValue;
            while (!DateTime.TryParse(inputString, out fromDateValue))
            {
                Console.WriteLine("Could not convert '{0}' to a datetime. Input date again: ", inputString);
                inputString = Console.ReadLine();
            }
            return fromDateValue;
        }

        public Date(DateTime date)
        {
            this.date = date;
            this.day = date.ToString("dd");
            this.month = date.ToString("MM");
            this.year = date.ToString("yyyy");
        }

        public static int operator -(Date d1, Date d2)
        {   
            return (Math.Abs(d2.date.Subtract(d1.date).Days));
        }

        public static string operator +(Date d1, int razn)
        {
            return (d1.date.AddDays(razn).ToShortDateString());
        }


        public void Print(int nom)
        {
            Console.WriteLine("\r\ndate{0}:\r\nDay: {1}\r\nMonth: {2}\r\nYear: {3}", nom, day, month, year);
        }
    }

    class OOP_2_3_Date
    {
        static void Main(string[] args)
        {
          //  Date date1 = new Date(new DateTime(2020, 05, 06));
             Date date1 = new Date(Date.WaitDate(1));                      // new object
            date1.Print(1);

           // Date date2 = new Date(new DateTime(2021, 05, 01));
             Date date2 = new Date(Date.WaitDate(2));                      // new object
            date2.Print(2);
   
            Console.WriteLine("\r\nDifference of two dates is {0} days.",(date1-date2));

            Console.WriteLine("\r\nIncreasing the date1 by {0} days is {1}", 6, (date1 + 6));

            Console.ReadKey();
        }
    }
}