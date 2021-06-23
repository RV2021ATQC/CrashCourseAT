using System;
using System.Globalization;

namespace Star_3_Figure
{
    [Serializable]
    public class Figure
    {
        //перевіряю, чи дата коректна 
        public static void Correct_Parse_DateTime(string inputString)
        {
            if (!DateTime.TryParse(inputString, out DateTime _1))
                throw new ArgumentException();
            else if ((DateTime.TryParse(inputString, out DateTime _2))&(_2 >DateTime.Today.Date))
                throw new ArgumentOutOfRangeException();
        }

        //зчитуємо дані, поки дата не буде коректною
        public static DateTime Correct_Date(string inputString)
        {
            try
            {
                Correct_Parse_DateTime(inputString);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Create date {inputString} can not be more then today date {DateTime.Today.ToShortDateString()}! \nInput date again:");
                inputString = Console.ReadLine();
                return Correct_Date(inputString);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Could not convert '{inputString}' to a datetime! \nInput date again: ");
                inputString = Console.ReadLine();
                return Correct_Date(inputString);
            }
            DateTime.TryParse(inputString, out DateTime _3);
            return _3;
        }
        public static double Correct_Double(string inputString)
        {
            double _2;
            while ((!Double.TryParse(inputString, out _2)) | ((Double.TryParse(inputString, out _2)) & (_2 < 0)))
            {
                if (!Double.TryParse(inputString, out _2))
                    Console.WriteLine("Could not convert '{0}' to a double. Input double again: ", inputString);
                else if ((Double.TryParse(inputString, out _2)) & (_2 < 0))
                    Console.WriteLine($"!Double {_2} must by more then 0 and less then 100! \nInput double again:");

                inputString = Console.ReadLine();
            }
            return _2;
        }


        private string name;
        private DateTime create_date;
        private string color;
        private double area;
        public string Name { get; set; }
        public string Create_date
        {
            get => create_date.ToShortDateString();
            set
            {
                create_date = Correct_Date(value);
                GetCreatedDate(DateTime.Today);
            }
        }
        public string Color { get; set; }

        public string Area { get => area.ToString(); set => area = Correct_Double(value); }

        public Figure(string name, DateTime create_date, string color, double area)

        {
            try
            {
                this.name = name;
                this.create_date = create_date;
                this.color = color;
                this.area = area;
                Create_date = Correct_Date(create_date.ToShortDateString()).ToShortDateString();
                Area = Correct_Double(area.ToString()).ToString();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message} {create_date}");
            }
            finally
            {
                Name = name;
                Color = color;
                GetCreatedDate(DateTime.Today);
            }
        }
        public Figure(string name, DateTime create_date) : this(name, create_date, "red", 100) { }

        public Figure() : this("Default name", DateTime.Parse("01/01/2021")) { }
        public int GetCreatedDate(DateTime date1)
        {
            if (Correct_Date(Create_date) < date1)
                return date1.Subtract(Correct_Date(Create_date)).Days;
            else if (Correct_Date(Create_date) > date1)
                return -Correct_Date(Create_date).Subtract(date1).Days;
            else return 0;

        }
        public override string ToString() => string.Join("", "\nShape: ", GetShape(), "\nName: ", Name,
                                                             "\nCreation date: ", Create_date, "\nDays from creations: ", GetCreatedDate(DateTime.Today),
                                                             "\nColor: ", Color, "\nArea: ", Area, " sm.kv.");
        public virtual void Display() => Console.WriteLine(this);

        public virtual string GetShape() => "figure";

        public virtual void SetNewInfo(bool brand_new = true)
        {
            Console.Write("Enter name of a figure: ");
            this.Name = new string(Console.ReadLine());
            Console.Write("Enter figure creation date (dd/mm/yyyy): ");
            this.Create_date = (Correct_Date(Console.ReadLine()).ToShortDateString());
        }
    }
}