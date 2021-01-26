using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lesson2
{
    class Program
    {

        //перезавантажені overload методи 
        public static string calculate(int a, int b = 2323)
        {
            return (a + b).ToString();
        }

        public static string calculate(string a, string b = "2323")
        {
            return a + b.ToString();
        }

        public static void method2()
        {

            try
            {
                Console.WriteLine("Methot that contains try catch");

                //виклик методу в середниі якого існують свої try catch конструкції
                throw new Exception("Age is not ....");

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Here is the DivideByZeroException!");
            }
        }

        public static void Main(string[] args)
        {
            //виклик перезавантажених методів
            calculate(3);
            calculate(3, 7);
            calculate("text", "text2");

            //створення об'єкту типу Animals
            Animals animal1 = new Animals(12, 7, 30);
            animal1.move(2, 4);

            //створення об'єкту типу Cats двома різними конструкторами, відповідно отримаємо
            //різну ініціалізацію і різні значення для age створених об'єктів
            Cats cat1 = new Cats(2, 4, 5);
            cat1.move(1, 2);

            Console.WriteLine($"cat1.age {cat1.age}");

            Cats cat2 = new Cats();
            Console.WriteLine($"cat2.age {cat2.age}");

            var animalsCollection = new List<Animals>();
            //об'єкти з класів наслідників можуть поводитись як об'єкти батьківських класів
            animalsCollection.Add(cat1);
            animalsCollection.Add(cat2);
            animalsCollection.Add(animal1);
            animalsCollection.Add(new Cats(8,6,3));

            var catsCollection = new List<Cats>();

            foreach (var animal in animalsCollection)
            {
                try
                {
                    //приведення типів
                    catsCollection.Add((Cats)animal);
                    Console.WriteLine($"The cat from List says = {cat1.voise}");

                    //виклик методу всередниі якого існують свої try catch конструкції
                    //компілятор зайде всередину method2() і спробує опрацювати код і 
                    //можливі помилки, якщо знайде помилки, то поверне їх у поточний try блок
                    method2();

                    // Створюємо власне виключення
                    if ( animal.age < 5)  throw new Exception("Age is not ....");

                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Here is the DivideByZeroException!");
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("Here is the SystemException!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Here is the SystemException!");
                }
                finally
                {
                    Console.WriteLine("Here is a finally block");
                }

            }

     
            //обробка виключень при роботі з файлами
            try
            {
                using (System.IO.StreamReader sr = File.OpenText("data.txt"))
                {
                    //читаємо з файлу
                    Console.WriteLine($"The first line of this file is {sr.ReadLine()}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }

            //викликаємо статичний метод класу Animals, який вичитує дані з приватного поля countOfAnimals
            //іншим чином ми не можемо отримати значення цього поля - ІНКАПСУЛЯЦІЯ
            Console.WriteLine($"Animals.GetCountOfAnimals() = {Animals.GetCountOfAnimals()}");

            //LINQ
            Cats catNew = catsCollection.First((x) => x.voise == "Meow!");

            Console.WriteLine($"The cat that have voice  = Meow! is the nex: {catNew.age}, {catNew.speed}, {catNew.voise} \n");


            //коротка форма вибірки з animalsCollection лише об'єктів типу Cats і сортування по віку
            foreach (var cat in animalsCollection.OfType<Cats>().OrderBy(x => x.age).ToList())
            {
                Console.WriteLine($"The sorted cat from List = {cat.age}, {cat.speed}, {cat.voise}");
            }

            var myFavoritFood = new Restaurant();

            myFavoritFood.MadeFood(new Fish());
            myFavoritFood.MadeFood(new Plants());
        }
    }
}
