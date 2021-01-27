using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NUnit;

namespace StarProject
{
    
    public class Collection
    {
        //folder
        static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        // Filename  
        static string fileName = "Animal_collection.txt";
        //функція запису полів та їх значень у текстовий файл
        static void WriteonFile(string path, string filename, List<Animals> AnimalCollection)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, filename), true))
                {
                    foreach (object obj in AnimalCollection)
                    {
                        outputFile.WriteLine($"Object {AnimalCollection.IndexOf((Animals)obj) + 1}");
                        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                        {
                            string name = descriptor.Name;
                            object value = descriptor.GetValue(obj);
                            outputFile.WriteLine("{0} = {1}.", name, value);
                        }
                    }
                    Console.WriteLine("Successfuly writed!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Some exception: {ex}!");
            }
        }
        //серіалізація
        //static void Serialization(List<Animals> AnimalCollection)
        //{
        //    try
        //    {
        //        XmlSerializer formatter = new XmlSerializer(typeof(Animals));
        //        using (FileStream fs = new FileStream("Animals.xml", FileMode.OpenOrCreate))
        //        {
        //            formatter.Serialize(fs, AnimalCollection[0]);
        //            Console.WriteLine("Collection serialized!");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine($"Some exception: {ex}");
        //    }
            
        //}
        //функція консольного виведення полів і значень
        static void GetValues(List<Animals> AnimalCollection)
        {
            foreach (object obj in AnimalCollection)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    Console.WriteLine("Now {0} = {1}.", name, value);
                }
            }
        }
        //функція серіалізації
        public static void WriteXML(List<Animals> AnimalCollection)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Animals>));

                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, AnimalCollection);
                }
                Console.WriteLine("Serialized!");
                //using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                //{
                //    List<Animals> newanimals = (List<Animals>)formatter.Deserialize(fs);

                //    foreach (Animals p in newanimals)
                //    {
                //        Console.WriteLine($"Year: {p.born_year} --- Color: {p.color}");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some exception: {ex}");
            }
        }
        //функція десеріалізації
        public static void ReadXML(List<Animals> AnimalCollection)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Animals>));

                //using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                //{
                //    formatter.Serialize(fs, AnimalCollection);
                //}
                //Console.WriteLine("Serialized");
                using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
                {
                    List<Animals> newanimals = (List<Animals>)formatter.Deserialize(fs);

                    foreach (Animals p in newanimals)
                    {
                        Console.WriteLine($"Year: {p.born_year} --- Color: {p.color}");
                    }
                }
                Console.WriteLine("Deserialized!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Some exception: {ex}");
            }
        }
        //функція консольного виведення полів і значень тварин старших за n
        static void PrintOlderThen(List<Animals> AnimalCollection, int YearsOld)
        {
            foreach (object obj in AnimalCollection)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    if (name == "born_year" && Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(value) < YearsOld)
                        break;
                    else
                        Console.WriteLine("Now {0} = {1}. obj({2})", name, value, AnimalCollection.IndexOf((Animals)obj) + 1);
                }
            }
        }
        static void Main(string[] args)
        {
            //створення колекції(списку) тварин
            var AnimalCollection = new List<Animals>();
            //попередньо введені дані
            AnimalCollection.Add(new Animals(1234.5, "red"));
            Console.WriteLine(AnimalCollection[0].GetAge());
            AnimalCollection.Add(new Animals(2020, "blue"));
            AnimalCollection.Add(new Animals(4321, "brown"));
            AnimalCollection.Add(new Animals(234, "yellow"));
            //AnimalCollection.Add(new Fish(1234, "black", "river fish", "mutant"));
            //AnimalCollection.Add(new Fish(2015, "white", "sea fish", "normal"));
            //перевірка на пустоту список
            if ((AnimalCollection != null) && (!AnimalCollection.Any()))
            {
                Console.WriteLine("Your collection is empty. Add some animal to collection first");
            }
            Console.WriteLine("Do you want to add more animals? Press \"y\"/\"n\"");
            int n = 0;
            //консольне заповнення списку
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("Choose what type of animal you want to add? Simple animal(1), fish(2)");
                //перевівка на цілочисельне введення
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input format!");
                }
                //меню додавання тварин
                switch (n)
                {
                    case 1:
                        {
                            Console.WriteLine("Write year of born and color");
                            try
                            {
                                int born_year = int.Parse(Console.ReadLine());
                                string color = Console.ReadLine();
                                AnimalCollection.Add(new Animals(born_year, color));
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong input format!");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Write year of born, color, kind of fish(river fish/sea fish), and species");
                            try
                            {
                                int fborn_year = int.Parse(Console.ReadLine());
                                string fcolor = Console.ReadLine();
                                string fkind = Console.ReadLine();
                                string fspecies = Console.ReadLine();
                                AnimalCollection.Add(new Fish(fborn_year, fcolor, fkind, fspecies));
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong input format!");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You have not selected any of the possible animal types!");
                            break;
                        }
                }
                Console.WriteLine("Do you still want to add something? Press \"y\"/\"n\"");
            }
            Console.WriteLine("Do you want to change something? \"y\"/\"n\"");
            int choose = 0;
            //консольна зміна списку
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("What do you want to do? Delete(1), Clear collection(2)");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input format!");
                }
                switch (choose)
                {
                    case 1:
                        Console.WriteLine("Choose number of animal you want to change");
                        try
                        {
                            int k = int.Parse(Console.ReadLine());
                            AnimalCollection.RemoveAt(k - 1);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Wrong input format!");
                        }
                        break;
                    case 2:
                        AnimalCollection.Clear();
                        break;
                    default:
                        Console.WriteLine("You choosed not possible variant!");
                        break;
                }
                Console.WriteLine("Something else to change? \"y\"/\"n\"");
            }
            //GetValues(AnimalCollection);
            //кількість років за які треба бути старше
            int older = 3;
            Console.WriteLine("Animals that older then {0}:", older);
            PrintOlderThen(AnimalCollection, older);
            //створення списку риб для сортування
            var FishCollection = new List<Fish>();
            //витягання "риб" із "тварин" i сортування за ознаками
            foreach (var fish in AnimalCollection.OfType<Fish>().OrderBy(x => x.species).ToList())
            {
                Console.WriteLine($"The sorted fish from collection(by species) : {fish.born_year}, {fish.color}, {fish.kind}, {fish.species}");
            }
            //запис усіх тварин
            WriteonFile(folder, fileName, AnimalCollection);
            //Sort(AnimalCollection);
            //серіалізація
            WriteXML(AnimalCollection);
            //десеріалізація
            ReadXML(AnimalCollection);
            //Serialization(AnimalCollection);
            Console.ReadKey();
        }
    }
}
