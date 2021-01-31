using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_star
{
    class House : Building
    {
        public int LivingSpace { get; set; }
        public int Floors { get; set; }
        public int Apartments { get; set; }

        public House() : base() => LivingSpace = Apartments = Floors = 1;
        public House(AdressInfo adress, DateTime comm_date, int LS, int floors, int AN) : base(adress, comm_date)
        {
            LivingSpace = LS;
            Floors = floors;
            Apartments = AN;
        }



        public override string ToString() => string.Join("", base.ToString(),
                "\nBuilding Type: ", typeof(House).Name,
                "\nLiving space: ", LivingSpace, "sq.m",
                "\nNumber of floors: ", Floors,
                "\nNumber of apartments: ", Apartments);

        public override void Display() => Console.WriteLine(this);

        public override void SetNewInfo(bool brand_new = true)
        {
            if (brand_new == true)
                base.SetNewInfo();
            Console.Write("Enter properties of a house\nLiving space: ");
            LivingSpace = int.Parse(Console.ReadLine());
            Console.Write("Number of floors: ");
            Floors = int.Parse(Console.ReadLine());
            Console.Write("Number of apartments: ");
            Apartments = int.Parse(Console.ReadLine());
        }

        public static House ConvertToHouse(Building building)
        {
            House h = new House();
            h.Adress = building.Adress;
            h.Comm_date = building.Comm_date;
            return h;            
        }
    }
}
