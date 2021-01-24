using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;

namespace StarProject
{

    class Collection
    {
        //folder
        static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        // Filename  
        static string fileName = "Animal_collection.txt";
        //функція запису полів та їх значень у текстовий файл
        static void WriteonFile(string path, string filename, List<Animals> AnimalCollection)
        {
            int i = 0;
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, filename), true))
                {
                    foreach (object obj in AnimalCollection)
                    {
                        i++;
                        outputFile.WriteLine($"Object {i}");
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
        //функція консольного виведення полів і значень тварин старших за n
        static void PrintOlderThen(List<Animals> AnimalCollection, int n)
        {
            foreach (object obj in AnimalCollection)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    if (name == "born_year" && Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(value) < n)
                        break;
                    else
                        Console.WriteLine("Now {0} = {1}.", name, value);
                }
            }
        }
        static void Main(string[] args)
        {
            //створення колекції(списку) тварин
            var AnimalCollection = new List<Animals>();
            //попередньо введені дані
            AnimalCollection.Add(new Animals(1234.5,"red"));
            Console.WriteLine(AnimalCollection[0].GetAge());
            AnimalCollection.Add(new Animals(2020, "blue"));
            AnimalCollection.Add(new Animals(4321, "brown"));
            AnimalCollection.Add(new Animals(234, "yellow"));
            AnimalCollection.Add(new Fish(1234, "black","river fish","mutant"));
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
                   n  = int.Parse(Console.ReadLine());
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
                        catch(FormatException ex)
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
            Console.WriteLine("Animals that older then {0}", older);
            PrintOlderThen(AnimalCollection, older);
            //створення списку риб для сортування
            var FishCollection = new List<Fish>();
            //витягання "риб" із "тварин"
            foreach (var animal in AnimalCollection)
            {
                try
                {
                    FishCollection.Add((Fish)animal);
                }
                catch(Exception ex)
                {
                    //Console.WriteLine($"Exeption {ex}");
                }
            }
            //сортування за ознаками
            var result = FishCollection.OrderBy(u => u.species);
            foreach (Fish u in result)
                Console.WriteLine(u);
            //запис усіх тварин
            WriteonFile(folder, fileName, AnimalCollection);
            //Sort(AnimalCollection);
            Console.ReadKey();
        }
    }
}
