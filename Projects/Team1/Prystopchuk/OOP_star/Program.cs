using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Text.Json;
using System.IO;

namespace OOP_star
{
    class Program
    {
        public static List<Building> JSONSerializer(List<Building> collection)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
            using (var file = File.CreateText("buildings.json"))
                file.Write(JsonConvert.SerializeObject(collection, settings));

            using (System.IO.StreamReader sr = File.OpenText("buildings.json"))
                return JsonConvert.DeserializeObject<List<Building>>(sr.ReadToEnd(), settings);
        }       
    
    public static void Main()
        {
            var buildings = new List<Building>();
            
            //building #1
            Building building1 = new Building(new AdressInfo("Kyiv, Khreschatik Street"), 
                                            DateTime.Parse("19/02/2000"));
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
            foreach (int _ in Enumerable.Range(0, 10)) { 
                buildings.Add(new Building(adress, new DateTime(new Random().Next(1960, 2020), 9, 15)));                
            }

            //a few more houses
            foreach (int _ in Enumerable.Range(0, 10))
            {
                buildings.Add(new House(adress, new DateTime(new Random().Next(1960, 2020), 9, 15),
                    50, new Random().Next(1, 20), 3));
            }
          
            Console.WriteLine("\n----------Original Collection----------");
            foreach (var it in buildings.Select((x, i) => new { item = x, index = i }))
            {
                Console.Write($"\n{it.item.GetType().Name} #{it.index}");
                it.item.Display();
            } 
            
            Console.WriteLine("\n----------Restored Collection----------");
            foreach (var it in JSONSerializer(buildings).Select((x, i) => new { item = x, index = i }))
            {
                Console.Write($"\n{it.item.GetType().Name} #{it.index}");
                it.item.Display();
            }

            //List of builgings which lifespan are more then 40 years
            var Olderthen40 = new List<Building>(from it in buildings
                                                 where it.Age > 40
                                                 select it);
            Console.WriteLine("\n\n" +
                "----------List of builgings which lifespan are more then 40 years----------\n");

            foreach (var it in Olderthen40.Select((x, i) => new { item = x, index = i }))
            {
                Console.Write($"\n{it.item.GetType().Name} #{it.index}");
                it.item.Display();
            }

            //Houses sorted by number of floors
            var HousesByFloors = buildings.OfType<House>().OrderBy(it => it.Floors).ToList();
            Console.WriteLine("\n\n" +
                "----------Houses sorted by number of floors----------\n");
            foreach (var it in HousesByFloors.Select((x, i) => new { item = x, index = i }))
            {
                Console.Write($"\n{it.item.GetType().Name} #{it.index}");
                it.item.Display();
            }
        }
    }
}