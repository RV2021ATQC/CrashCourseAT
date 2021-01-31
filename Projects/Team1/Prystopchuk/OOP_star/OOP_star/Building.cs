using System;

namespace OOP_star
{

    public class Building
    {
        public AdressInfo Adress { get; set; }
        public DateTime Comm_date { get; set; }
        public int Age { get; set; }

       public Building() { }
        public Building(AdressInfo adrs) : this(adrs, null) { }

        public Building(AdressInfo adrs, DateTime? comm_date)
        {
            Adress = adrs;
            Comm_date = comm_date.GetValueOrDefault();
            Age = Comm_date == default ? 0 : (int)((DateTime.Today - Comm_date).TotalDays / 365.2422);
        }
        public override string ToString() => string.Join("", "Adress: ", Adress,
                "\nCommission date: ", Comm_date.Date.ToShortDateString(),
                "\nYears from comissioning: ", Age);
        public virtual void Display() => Console.WriteLine(this);
        //static public Building NewBuilding() {

        //    Console.Write("Enter adress of a building\nCity: ");
        //    string city = Console.ReadLine();
        //    Console.Write("Street: ");
        //    string street = Console.ReadLine();
        //    AdressInfo a = new AdressInfo(city, street);
        //    Console.Write("Enter comissioning date of a building (dd/mm/yyyy): ");
        //    DateTime d = new DateTime();
        //    try { d = DateTime.Parse(Console.ReadLine()); }
        //    catch (Exception) { d = default; }
        //    return new Building(a, d);
        //}

        public virtual void SetNewInfo(bool brand_new = true)
        {
            Console.Write("Enter adress of a building\nCity: ");
            string city = Console.ReadLine();
            Console.Write("Street: ");
            string street = Console.ReadLine();
            AdressInfo a = new AdressInfo(city, street);
            Console.Write("Enter comissioning date of a building (dd/mm/yyyy): ");
            DateTime d = new DateTime();
            try { d = DateTime.Parse(Console.ReadLine()); }
            catch (Exception) { d = default; }
            this.Adress = a;
            this.Comm_date = d;            
        }
    }

    
}

