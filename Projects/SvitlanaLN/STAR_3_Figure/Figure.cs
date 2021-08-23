using System;
using System.Globalization;
namespace Star_3_Figure
{
    [Serializable]
    public class Figure
    {
        private DateTime create_date;
        private double area;
        public string Name { get; set; }
        public string Create_date
        {
            get => create_date.ToShortDateString();
            set
            {
                create_date = Convert_Date(value);
                GetCreatedDays(DateTime.Today);
            }
        }

        public string Color { get; set; }

        public string Area { get => area.ToString(); set => area = Convert_Double(value); }

        public static void Check_Valid_Date(string inputString)
        {
            if (!DateTime.TryParse(inputString, out DateTime Convert_Date_1))
                throw new ArgumentException();
            else if ((DateTime.TryParse(inputString, out DateTime big_date_2))&(big_date_2 > DateTime.Today.Date))
                throw new ArgumentOutOfRangeException();
        }

        public static DateTime Convert_Date(string inputString)
        {
            try
            {
                Check_Valid_Date(inputString);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Create date {inputString} can not be more then today date {DateTime.Today.ToShortDateString()}! \nInput date again:");
                inputString = Console.ReadLine();
                return Convert_Date(inputString);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Could not convert '{inputString}' to a datetime! \nInput date again: ");
                inputString = Console.ReadLine();
                return Convert_Date(inputString);
            }
            DateTime.TryParse(inputString, out DateTime out_datetime);
            return out_datetime;
        }

        public static double Convert_Double(string inputString)
        {
            double out_double;
            while ((!Double.TryParse(inputString, out out_double)) | ((Double.TryParse(inputString, out out_double)) & (out_double < 0)))
            {
                if (!Double.TryParse(inputString, out out_double))
                    Console.WriteLine("Could not convert '{0}' to a double. Input double again: ", inputString);
                else if ((Double.TryParse(inputString, out out_double)) & (out_double < 0))
                    Console.WriteLine($"!Double {out_double} must by more then 0 and less then 100! \nInput double again:");

                inputString = Console.ReadLine();
            }
            return out_double;
        }
        
        public Figure(string name, DateTime create_date, string color, double area)
        {
            try
            {
                Name = name;
                this.create_date = create_date;
                Color = color;
                this.area = area;
                Create_date = Convert_Date(create_date.ToShortDateString()).ToShortDateString();
                Area = Convert_Double(area.ToString()).ToString();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message} {create_date}");
            }
            finally
            {
                GetCreatedDays(DateTime.Today);
            }
        }

        public Figure(string name, DateTime create_date) : this(name, create_date, "red", 100) { }

        public Figure() : this("Default name", DateTime.Parse("01/01/2021")) { }

        public int GetCreatedDays(DateTime date1)
        {
            if (Convert_Date(Create_date) < date1)
                return date1.Subtract(Convert_Date(Create_date)).Days;
            else if (Convert_Date(Create_date) > date1)
                return -Convert_Date(Create_date).Subtract(date1).Days;
            else return 0;

        }

        public override string ToString() => string.Join("", "\nShape: ", GetShape(), "\nName: ", Name,
                                                             "\nCreation date: ", Create_date, "\nDays from creations: ", GetCreatedDays(DateTime.Today),
                                                             "\nColor: ", Color, "\nArea: ", Area, " sm.kv.");
        
        public virtual void Display() => Console.WriteLine(this);

        public virtual string GetShape() => "figure";

        public virtual void SetNewInfo(bool brand_new = true)
        {
            Console.Write("Enter name of a figure: ");
            this.Name = new string(Console.ReadLine());
            Console.Write("Enter figure creation date (dd/mm/yyyy): ");
            this.Create_date = (Convert_Date(Console.ReadLine()).ToShortDateString());
        }

    }
}