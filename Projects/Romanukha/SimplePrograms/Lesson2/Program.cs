using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson2
{
    class Program
    {
        #region Functions
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
            catch (Exception ex)
            {
                Console.WriteLine("Here is the DivideByZeroException!");
            }
        }


        //серіалізація у XML
        public static async void XmlSerializationExample(List<Animal> animalsCollection)
        {
            Console.WriteLine($"---------------XMLSerializationExample----------------");

 
            //створюємо об'єкт XmlSerializer що приймає типи List<Animal> і List<Cat> 
            //оскільки List, який ми будемо серіалізувати містить об'єкти обох класів
            XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>), new[] { typeof(List<Cat>) });
            Stream fileStream = new FileStream("animalsCollection.xml", FileMode.Create);
            try
            {
                serializer.Serialize(fileStream, animalsCollection);
                fileStream.Close();
                Console.WriteLine("Serialization completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("You can check serealized XML file.  Press ENTER to continue...");
            Console.ReadLine();
        }

        //серіалізація у JSON
        public static async Task JSONSerializationExample(List<Animal> animalsCollection)
        {
            Console.WriteLine($"---------------JSONSerializationExample----------------");

            // збереження данных
            using (var fileStream = new FileStream("animalsCollection.json", FileMode.OpenOrCreate))
            {
                //серіалізація в Json
                string jsonString = JsonConvert.SerializeObject(animalsCollection);
                Console.WriteLine(jsonString);

                // конвертуємо в байти і записуємо в файл
                byte[] array = System.Text.Encoding.Default.GetBytes(jsonString);

                fileStream.Write(array, 0, array.Length);
                Console.WriteLine("Data has been saved to file");
            }

            Console.WriteLine("You can check serealized JSON file.  Press ENTER to continue...");
            Console.ReadLine();

            // зчитування данных
            using (System.IO.StreamReader sr = File.OpenText("animalsCollection.json"))
            {       
                var restoredCollection = JsonConvert.DeserializeObject<List<Animal>>(sr.ReadLine());
                Console.WriteLine("Restored Collection");

                foreach (var animal in restoredCollection)
                    Console.WriteLine($"Name: {animal.age}  Speed: {animal.speed} Weight: {animal.GetWeight()}");
            }
        }
        #endregion Functions
        public static async Task Main(string[] args)
        {
            //виклик перезавантажених методів
            calculate(3);
            calculate(3, 7);
            calculate("text", "text2");

            //створення об'єкту типу Animals
            Animal animal1 = new Animal(12, 7, 30);
            animal1.move(2, 4);

            //створення об'єкту типу Cats двома різними конструкторами, відповідно отримаємо
            //різну ініціалізацію і різні значення для age створених об'єктів
            Cat cat1 = new Cat(2, 4, 5);
            cat1.move(1, 2);

            Console.WriteLine($"cat1.age {cat1.age}");

            Cat cat2 = new Cat();
            Console.WriteLine($"cat2.age {cat2.age}");

            var animalsCollection = new List<Animal>();
            //об'єкти з класів наслідників можуть поводитись як об'єкти батьківських класів
            animalsCollection.Add(cat1);
            animalsCollection.Add(cat2);
            animalsCollection.Add(animal1);
            animalsCollection.Add(new Cat(8,6,3));

            var catsCollection = new List<Cat>();

            //!!!ВИБІРКА з Animals лище котів - є коротша форма через LINQ -дивіться нижче
            foreach (var animal in animalsCollection)
            {
                try
                {
                    //приведення типів
                    catsCollection.Add((Cat)animal);
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
                    Console.WriteLine(ex.Message);
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
          

            //-------------------LINQ---------------------------------
            //Вибірка об'єкту за параметром
            Cat catNew = catsCollection.First((x) => x.voise == "Meow!");
            Console.WriteLine($"The cat that have voice  = Meow! is the nex: {catNew.age}, {catNew.speed}, {catNew.voise} \n");


            //!!!ВИБІРКА LINQ коротка форма вибірки з animalsCollection лише об'єктів типу Cats і сортування по віку
            foreach (var cat in animalsCollection.OfType<Cat>().OrderBy(x => x.age).ToList())
            {
                Console.WriteLine($"The sorted cat from List = {cat.age}, {cat.speed}, {cat.voise}");
            }

            var myFavoritFood = new Restaurant();

            //об'єкт класу Restauranr приймає як параметр об'єкт будь-якого класу який реалізував інтерфейс ICook 
            myFavoritFood.MadeFood(new Fish());
            myFavoritFood.MadeFood(new Plants());


            //викликаємо СТАТИЧНИЙ метод класу Animals, який вичитує дані з приватного поля countOfAnimals
            //іншим чином ми не можемо отримати значення цього поля - ІНКАПСУЛЯЦІЯ + робота зі стат полями і методами
            Console.WriteLine($"Animals.GetCountOfAnimals() = {Animal.GetCountOfAnimals()}");

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


            XmlSerializationExample(animalsCollection);


            catsCollection.Add(new Cat(1, 2, 3));
            catsCollection.Add(new Cat(2, 3, 4));

            await JSONSerializationExample(animalsCollection);

        }
    }
}