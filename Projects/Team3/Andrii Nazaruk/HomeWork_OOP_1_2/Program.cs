using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HomeWork_OOP_1_2
{
   
    class Program
    {
        //"* Створити колекцію транспорту, додати кілька різних видів транспорту та автомобілів до цієї колекції
        //реалізуйте виведення автомобілів старіших ніж 10 років
        //відсортуйте інформацію за брендом та моделлю
        //збережіть колекцію у файл
        //реалізуйте опрацювання виключень(Exceptions)
        //сереалізуйте(Serialize) колекцію в XML файл
        //десереалізуйте колекцію з XML файла
        //напишіть unit тести до реалізованих функцій"
        static void Main(string[] args)
        {   
            //Create a list of cars
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

            //Create a list of motorcycles

            Motorcycle motorcycle1 = new Motorcycle(250, "GSX-S1000F", "Loncin", "Motorcycle", 3, true, 13.2);
            Motorcycle motorcycle2 = new Motorcycle(280, "GSX-R750", "Suzuki", "Motorcycle", 6, true, 7.8);
            Motorcycle motorcycle3 = new Motorcycle(200, "RTD-E34", "Harley-Davidson", "Motorcycle", 8, true, 19.4);
            Motorcycle motorcycle4 = new Motorcycle(300, "CBR 1000RR", "Honda", "Motorcycle", 2, true, 10.5);

            List<Motorcycle> motorcycles = new List<Motorcycle>();
            motorcycles.Add(motorcycle1);
            motorcycles.Add(motorcycle2);
            motorcycles.Add(motorcycle3);
            motorcycles.Add(motorcycle4);

            //Create a list of Bicycles
            Bicycle bicycle1 = new Bicycle(25, "SKD-78-65", "Cannondale Trail 7", "Bicycle", 1, true, 5.2);
            Bicycle bicycle2 = new Bicycle(25, "S800 HAMMER", "Shimano", "Bicycle", 4, true, 2.2);
            Bicycle bicycle3 = new Bicycle(25, "Giant Trinity", "Advanced Pro", "Bicycle", 2, true, 3.2);
            Bicycle bicycle4 = new Bicycle(25, "KMC Z33", "TopRider", "Bicycle", 3, false, 1.2);

            List<Bicycle> bicycles = new List<Bicycle>();
            bicycles.Add(bicycle4);
            bicycles.Add(bicycle3);
            bicycles.Add(bicycle2);
            bicycles.Add(bicycle1);

            //Create a list of Transport

            var transportsCollection = new List<Transport>();
            transportsCollection.AddRange(cars);
            transportsCollection.AddRange(motorcycles);
            transportsCollection.AddRange(bicycles);

            //Function sorted by Model
            static void OrderByModel(List<Transport> transportsCollection)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Function Sorted By Model");
                var result = transportsCollection.
                    Where(x => x.TransportType == "Car").
                    Where(x=>x.YearOfExploatation>=10).
                    OrderBy(x => x.Model).
                    ToList();
                try
                {
                    foreach (Car c in result)
                    {
                        Console.WriteLine($"Car Model is : {c.Model}");
                    }
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //Function Sorted By Mark
            static void OrderByMark(List<Transport> transportsCollection)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Function Sorted by Marks");
                var result = transportsCollection.
                    Where(x => x.TransportType == "Car").
                    Where(x=>x.YearOfExploatation>=10).
                    OrderBy(x => x.Mark).
                    ToList();
                try
                {
                    foreach (Car c in result)
                    {
                        Console.WriteLine($"Car Mark is : {c.Mark}");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            //Function Select cars more then 10 years exploatation
            static void SelectCarsMoreThen_10Years(List<Transport> transportsCollection)
            {
                var result = transportsCollection.
                    Where(x => x.TransportType == "Car").
                    Where(x => x.YearOfExploatation > 10).ToList();
                Console.WriteLine("Function Select cars from collection wich years of exploatation more then 10 years");
                try
                {
                    foreach (Car car in result)
                    {
                        Console.WriteLine($"Transport type is : {car.TransportType}");
                        Console.WriteLine($"Car Model is : {car.Model}");
                        Console.WriteLine($"Car Mark is : {car.Mark}");
                        Console.WriteLine($"Car Speed : {car.Speed}");
                        Console.WriteLine($"Year of exploatation : {car.YearOfExploatation}");
                    }
                    
                }
                catch(Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }                
            }          
            //Function Write all fields in data.txt on D:\
            static void WrittenToFile(List<Transport> transportsCollection)
            {
                string WritePath = @"D:\data.txt";
                try
                {
                    using (StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
                    {
                        foreach(var c in transportsCollection)
                        {
                            sw.WriteLine($"Transport type : {c.TransportType} | Model : {c.Model}" +
                                $" | Mark : {c.Mark} | Year : {c.YearOfExploatation} | Price : {c.Price} | IsWorking? : {c.IsWorking}");                           
                          ;
                        }
                       
                    }
                    
                    Console.WriteLine("Text file was added on disc D");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //Function Serialize and Deserialize list cars to "transport.xml"
            static void SerializeAndDeserialize(List<Car> cars)
            {
                try
                {

                    XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));
                  
                    using (FileStream fs = new FileStream("transport.xml", FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, cars);

                        Console.WriteLine("List was Serialize!");
                    }
                    using (FileStream fs=new FileStream("transport.xml", FileMode.OpenOrCreate))
                    {
                        List<Car> newCarsList = (List<Car>)formatter.Deserialize(fs);
                        Console.WriteLine("List was Deserialized!");
                        foreach(Car car in newCarsList)
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

            SelectCarsMoreThen_10Years(transportsCollection);
            OrderByModel(transportsCollection);
            OrderByMark(transportsCollection);
            WrittenToFile(transportsCollection);
            SerializeAndDeserialize(cars);
        }
    }
}
