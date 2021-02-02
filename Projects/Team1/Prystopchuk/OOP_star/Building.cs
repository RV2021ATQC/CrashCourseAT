using System;

namespace OOP_star
{   
    [Serializable]
    public class Building
    {
        public AdressInfo Adress { get; set; }
        public Nullable<DateTime> Comm_date { get; set; }
        public int Age { get; set; }

       public Building() { }
        public Building(AdressInfo adrs) : this(adrs, default) { }
        public Building(AdressInfo adrs, DateTime comm_date)
        {
            try
            {
                if (comm_date > DateTime.Today)
                    throw new ArgumentException("Invalid date provided");
                Comm_date = comm_date/*.GetValueOrDefault()*/;
            }
            catch (ArgumentException ex)
            {
                Comm_date = null;
                Console.WriteLine($"{ex.Message} {comm_date}");
            }
            finally
            {
                Adress = adrs;
                ChangeAge();
            }
        }

        protected void ChangeAge()
        {
            Age = Comm_date == default ? 0 : (int)((DateTime.Today - Comm_date).Value.TotalDays / 365.2422);
        }
        public override string ToString() => string.Join("", "\nAdress: ", Adress,
                "\nCommission date: ", Comm_date.HasValue? Comm_date.Value.ToShortDateString() : Comm_date,
                "\nYears from comissioning: ", Age);
        public virtual void Display() => Console.WriteLine(this);

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
            ChangeAge();
        }
    }    
}