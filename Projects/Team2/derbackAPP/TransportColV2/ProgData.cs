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

        public static void TransportVoid()
        {
            string keyWord = "Car";
                Car car1 = new Car(200, "X5", "BMW", "Car", 10, true, 22.277);
                Car car2 = new Car(220, "A8", "Audi", "Car", 8, true, 35.12);
                Car car3 = new Car(210, "A200", "Mercedes-Benz", "Car", 13, true, 24.434);
                Car car4 = new Car(200, "Skyline", "Nissan", "Car", 11, false, 27.13);
                Car car5 = new Car(240, "X6", "BMW", "Car", 6, true, 21.44);
                Car car6 = new Car(200, "Omega", "Opel", "Car", 20, false, 5.4);
                Car car7 = new Car(230, "Fusion", "Ford", "Car", 12, true, 12.3);
                Car car8 = new Car(320, "Huricane", "Lamborgini", "Car", 3, true, 223.5);
                Car car9 = new Car(260, "Phantom", "Rols-Royse", "Car", 5, true, 157.4);

                List<Car> cars = new List<Car>();
                cars.Add(car9);
                cars.Add(car8);
                cars.Add(car7);
                cars.Add(car6);
                cars.Add(car5);
                cars.Add(car4);
                cars.Add(car3);
                cars.Add(car2);
                cars.Add(car1);
                Bicycle bicycle1 = new Bicycle(25, "SKD-78-65", "Cannondale Trail 7", "Bicycle", 1, true, 5.2);
                Bicycle bicycle2 = new Bicycle(25, "S800 HAMMER", "Shimano", "Bicycle", 4, true, 2.2);
                Bicycle bicycle3 = new Bicycle(25, "Giant Trinity", "Advanced Pro", "Bicycle", 2, true, 3.2);
                Bicycle bicycle4 = new Bicycle(25, "KMC Z33", "TopRider", "Bicycle", 3, false, 1.2);

                List<Bicycle> bicycles = new List<Bicycle>();
                bicycles.Add(bicycle4);
                bicycles.Add(bicycle3);
                bicycles.Add(bicycle2);
                bicycles.Add(bicycle1);

                var transportsCollection = new List<Transport>();
                transportsCollection.AddRange(cars);
                Console.WriteLine("=====Sorting=====");
                var result = transportsCollection.
                    Where(x => x.TransportType == keyWord).
                    Where(x => x.YearOfExploatation <= 10).
                    OrderBy(x => x.Model).
                    ToList();
                try
                {
                    foreach (Car c in result)
                    {
                        Console.WriteLine($"{keyWord} Model is : {c.Model}, Marks if {c.Mark}, Price is{c.Price}, Speed  is {c.Speed}, Type is {c.TransportType}, YearOfExploatation is {c.YearOfExploatation}");
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
