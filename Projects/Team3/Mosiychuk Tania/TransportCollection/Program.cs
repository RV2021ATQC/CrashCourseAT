using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace TransportCollection
{
    class Program
    {
        /*Створити колекцію транспорту, додати кілька різних видів транспорту та автомобілів до цієї колекції
        *реалізуйте виведення автомобілів старіших ніж 10 років
        *відсортуйте інформацію за брендом та моделлю
        *збережіть колекцію у файл
        *реалізуйте опрацювання виключень(Exceptions)
        *сереалізуйте(Serialize) колекцію в XML файл
        *десереалізуйте колекцію з XML файла
        *напишіть unit тести до реалізованих функцій"*/

        static void Main(string[] args)
        {
            Bicycle bicycle1 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Alcatel", Price = 8000, Speed = 30, YearOfExploatation = 13 };
            Bicycle bicycle2 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Huawei", Price = 12000, Speed = 28, YearOfExploatation = 11 };
            Bicycle bicycle3 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Cannondale", Price = 6000, Speed = 29, YearOfExploatation = 29 };
            Bicycle bicycle4 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Discovery", Price = 17000, Speed = 25, YearOfExploatation = 25 };
            Bicycle bicycle5 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Huawei", Price = 21000, Speed = 12, YearOfExploatation = 22 };
            Bicycle bicycle6 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Kinetic", Price = 9000, Speed = 27, YearOfExploatation = 10 };
            Bicycle bicycle7 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Alcatel", Price = 12000, Speed = 20, YearOfExploatation = 14 };

            List <Bicycle> bicycles = new List<Bicycle>();

            bicycles.Add(bicycle1);
            bicycles.Add(bicycle2);
            bicycles.Add(bicycle3);
            bicycles.Add(bicycle4);
            bicycles.Add(bicycle5);
            bicycles.Add(bicycle6);
            bicycles.Add(bicycle7);

            Ship ship1 = new Ship { TypeOfTransport = "Ship", Mark = "Mangusta", Price = 1000000, Speed = 74, YearOfExploatation = 8 };
            Ship ship2 = new Ship { TypeOfTransport = "Ship", Mark = "Ferretti", Price = 400000, Speed = 90, YearOfExploatation = 25 };
            Ship ship3 = new Ship { TypeOfTransport = "Ship", Mark = "Galeon", Price = 500000, Speed = 80, YearOfExploatation = 10 };
            Ship ship4 = new Ship { TypeOfTransport = "Ship", Mark = "Galia", Price = 750000, Speed = 91, YearOfExploatation = 20 };
            Ship ship5 = new Ship { TypeOfTransport = "Ship", Mark = "SeaLine", Price = 480000, Speed = 82, YearOfExploatation = 7 };
            Ship ship6 = new Ship { TypeOfTransport = "Ship", Mark = "Princess Flybridge", Price = 348857, Speed = 93, YearOfExploatation = 3 };
            Ship ship7 = new Ship { TypeOfTransport = "Ship", Mark = "Sea Ray", Price = 756000, Speed = 76, YearOfExploatation = 16 };

            List<Ship> ships = new List<Ship>();

            ships.Add(ship1);
            ships.Add(ship2);
            ships.Add(ship3);
            ships.Add(ship4);
            ships.Add(ship5);
            ships.Add(ship6);
            ships.Add(ship7);

            Car car1 = new Car { TypeOfTransport = "Car", Mark = "Mercedez", Price = 50000, Speed = 120, YearOfExploatation = 5 };
            Car car2 = new Car { TypeOfTransport = "Car", Mark = "BMW", Price = 60000, Speed = 150, YearOfExploatation = 6 };
            Car car3 = new Car { TypeOfTransport = "Car", Mark = "Toyota", Price = 750000, Speed = 160, YearOfExploatation = 9 };
            Car car4 = new Car { TypeOfTransport = "Car", Mark = "Mazda", Price = 230000, Speed = 120, YearOfExploatation = 3 };
            Car car5 = new Car { TypeOfTransport = "Car", Mark = "Honda", Price = 250000, Speed = 120, YearOfExploatation = 9 };
            Car car6 = new Car { TypeOfTransport = "Car", Mark = "Nissan", Price = 430000, Speed = 110, YearOfExploatation = 10 };
            Car car7 = new Car { TypeOfTransport = "Car", Mark = "BMW", Price = 210000, Speed = 150, YearOfExploatation = 11 };

            List<Car> cars = new List<Car>();

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
            cars.Add(car5);
            cars.Add(car6);
            cars.Add(car7);

            List<Transport> transport = new List<Transport>();

            transport.AddRange(cars);
            transport.AddRange(bicycles);
            transport.AddRange(ships);

            CarsExploatationMoreThen10Years(transport);
            SelectCarsByMark(transport);
            SerializeAndDeserialize(cars);
            WrittenToFile(transport);
        }
        static void CarsExploatationMoreThen10Years(List<Transport> transport)
        {
            var result = transport.
                Where(t => t.TypeOfTransport == "Car").Where(x => x.YearOfExploatation >= 10).ToList();
            try
            {
                foreach (Car car in result)
                {
                    Console.WriteLine($"Transport type: {car.TypeOfTransport}");
                    Console.WriteLine($"Mark: {car.Mark}");
                    Console.WriteLine($"Exploatation: {car.YearOfExploatation}");
                    Console.WriteLine($"Price: {car.Price}");
                    Console.WriteLine($"Speed: {car.Speed}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Select cars from collection which exploatation more than 10 years");
            }
        }
        static void SelectCarsByMark(List<Transport> transports)
        {
            var result = transports.
                Where(x => x.TypeOfTransport == "Car").OrderBy(x => x.Mark).ToList();
            try
            {
                foreach (Car car in result)
                {
                    Console.WriteLine($"{car.Mark}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Collection sorted by mark");
            }

        }
        static void SerializeAndDeserialize(List<Car> cars)
        {
            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

                using (FileStream filestreams = new FileStream("document.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(filestreams, cars);
                }
                using (FileStream filestream = new FileStream("document.xml", FileMode.OpenOrCreate))
                {
                    List<Car> List = (List<Car>)serializer.Deserialize(filestream);
                    foreach (Car car in List)
                    {
                        Console.WriteLine(car.Mark);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("The process is complete!");
            }

        }

        static void WrittenToFile(List<Transport> transport)
        {
            string WritePath = @"D:\Documents\New folder\document.txt";
            try
            {
                using (StreamWriter streamwriter = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
                {
                    foreach (var c in transport)
                    {
                        streamwriter.WriteLine($"Type of transport: {c.TypeOfTransport}\nMark: {c.Mark}" +
                            $"\nYears of exploatation : {c.YearOfExploatation}\nPrice : {c.Price} ");
                        ;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Text file was added on disc D, Documents, New folder.");
            }

        }
    }
}
