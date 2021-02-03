using System;
using System.Collections.Generic;
using System.Text;
//using PostSharp.Aspects;

namespace OOP_star
{
    //[Serializable]
    //public class RangeAttribute : LocationInterceptionAspect
    //{
    //    private int min;
    //    private int max;

    //    public RangeAttribute(int min, int max)
    //    {
    //        this.min = min;
    //        this.max = max;
    //    }

    //    public override void OnSetValue(LocationInterceptionArgs args)
    //    {
    //        int value = (int)args.Value;
    //        if (value < min) value = min;
    //        if (value > max) value = max;
    //        args.SetNewValue(value);
    //    }
    //}

    [Serializable]
    class House : Building
    {
        private int livingSpace;
        private int floors;
        private int apartments;

        public int LivingSpace { get => livingSpace; set => livingSpace = Math.Max(value, 1); }
        public int Floors { get => floors; set => floors = Math.Max(value, 1); }
        public int Apartments { get => apartments; set => apartments = Math.Max(value, 1); }

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
            //ChangeAge();
            try
            {
                Console.Write("Enter properties of a house\nLiving space: ");
                LivingSpace = int.Parse(Console.ReadLine());
                Console.Write("Number of floors: ");
                Floors = int.Parse(Console.ReadLine());
                Console.Write("Number of apartments: ");
                Apartments = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static House ConvertToHouse(Building building)
        {
            House h = new House();
            h.Adress = building.Adress;
            h.Comm_date = building.Comm_date;
            //h.Age = building.Age;
            return h;
        }
    }
}
