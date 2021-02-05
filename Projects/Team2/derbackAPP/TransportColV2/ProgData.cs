using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace TransportCollection
{
    public class TransportData
    {
        internal static int GetAge(int v)
        {
            return DateTime.Now.Year - v;
        }

        public static void TransportListSet()
        {
                Car car1 = new Car(200, "X5", "BMW", "Car", 10, true, 22.277);
                Car car2 = new Car(220, "A8", "Audi", "Car", 8, true, 35.12);
                Car car3 = new Car(210, "A200", "Mercedes-Benz", "Car", 13, true, 24.434);
                Car car4 = new Car(200, "Skyline", "Nissan", "Car", 11, false, 27.13);
                Car car5 = new Car(240, "X6", "BMW", "Car", 6, true, 21.44);
                Car car6 = new Car(200, "Omega", "Opel", "Car", 20, false, 5.4);
                Car car7 = new Car(230, "Fusion", "Ford", "Car", 12, true, 12.3);
                Car car8 = new Car(320, "Huricane", "Lamborgini", "Car", 3, true, 223.5);
                Car car9 = new Car(260, "Phantom", "Rols-Royse", "Car", 5, true, 157.4);

            List<Car> cars = new List<Car>()
            {
                car1,car2,car3,car4,car5,car6,car7,car8,car9
            };
                Bicycle bicycle1 = new Bicycle(25, "SKD-78-65", "Cannondale Trail 7", "Bicycle", 1, true, 5.2);
                Bicycle bicycle2 = new Bicycle(25, "S800 HAMMER", "Shimano", "Bicycle", 4, true, 2.2);
                Bicycle bicycle3 = new Bicycle(25, "Giant Trinity", "Advanced Pro", "Bicycle", 2, true, 3.2);
                Bicycle bicycle4 = new Bicycle(25, "KMC Z33", "TopRider", "Bicycle", 3, false, 1.2);

            List<Bicycle> bicycles = new List<Bicycle>()
            {
                bicycle1,bicycle2,bicycle3,bicycle4
            };
                var transportsCollection = new List<Transport>();
                transportsCollection.AddRange(cars);
                transportsCollection.AddRange(bicycles);
                Console.WriteLine("=====Sorting=====");
                try
                {
                    foreach (Car c in transportsCollection.OfType<Car>().OrderBy(x => x.YearOfExploatation).ToList())
                    {
                        Console.WriteLine($"Model is : {c.Model}, Marks if {c.Mark}, Price is {c.Price}, Speed  is {c.Speed}, Type is {c.TransportType}, YearOfExploatation is {c.YearOfExploatation}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));

                using (FileStream fs = new FileStream("transportCol.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, cars);

                    Console.WriteLine("List was Serialize!");
                }
                using (FileStream fs = new FileStream("transportCol.xml", FileMode.OpenOrCreate))
                {
                    List<Car> newCarsList = (List<Car>)formatter.Deserialize(fs);
                    Console.WriteLine("List was Deserialized!");
                    foreach (Car car in newCarsList)
                    {
                        Console.WriteLine(car.Mark);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
