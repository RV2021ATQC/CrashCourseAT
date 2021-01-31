using System;
using System.Linq;
using System.Collections.Generic;

namespace OOP_star
{
    class Program
    {
        static public void Main()
        {
            var buildings = new List<Building>();
            
            //building #1
            Building building1 = new Building(new AdressInfo("Kyiv, Khreschatik Street"), 
                                            DateTime.Parse("02/02/2000"));
            buildings.Add(building1);

            //house #1
            Console.WriteLine("Initializing new house:\n");
            House house1 = new House();
            house1.SetNewInfo();
            buildings.Add(house1);

            var adress = new AdressInfo("New York", "Manhattan");
            var date = DateTime.Parse("02/02/1940");
            
            //building #2
            Building building2 = new Building(adress, date);
            buildings.Add(building2);
            
            //house #2 (from building)
            Console.WriteLine("\nConverting existing building to a house: \n");
            House house2 = House.ConvertToHouse(building1);
            house2.SetNewInfo(false);            
            buildings.Add(house2);

            //a few more buildings 
            int year = 1940;
            while(year != 1980)
            {
                buildings.Add(new Building(adress, new DateTime(year, 9, 15)));
                year += 10;
            }

            Console.WriteLine("\n\n");
            foreach(var it in buildings)
            {
                int i = 0;
                Console.WriteLine($"\n{it.GetType().Name} #{++i}");
                it.Display();
            }
        }
    }
}