using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using NUnit.Framework;


namespace Animals
{
	[TestFixture]
	class Program
	{
		/* Опишіть клас Тварини, який містить 
         поля: РікНародження, Колір
         конструктор з параметрами
         функції консольного введення та виведення полів
         Getteres Setters
         Метод GetAge() що виводить повні роки
         overridden ToString() метод, який викликає метод Voice()
         Реалізуйте клас наслідник Fish, який має додаткові поля Kind (морська\річкова), Species. Конструктор з параметрами, додаткові getters та setters. Overridden input() та output()
         Створіть колекцію тварин, додати кілька різних тварин та риб до цієї колекції
         реалізуйте виведення риб старіших ніж 3 роки
         відсортуйте інформацію за видом (Species)
         збережіть колекцію у файл
         реалізуйте опрацювання виключень (Exceptions)
         сереалізуйте (Serialize) колекцію в XML файл
         десереалізуйте колекцію з XML файла
         напишіть unit тести до реалізованих функцій*/
		public static List<Animals> animals = new List<Animals>();
		static void Main(string[] args)
		{
			animals.Add(new Animals(2001, "red"));
			animals.Add(new Animals(2002, "green"));
			animals.Add(new Animals(2003, "red"));
			animals.Add(new Fish(2001, "red", "sea", "Amberjack"));
			animals.Add(new Fish(2016, "White", "Mackerel", "Barracuda"));
			animals.Add(new Fish(2014, "White", "Mackerel", "Barracuda"));
			animals.Add(new Fish(2019, "White", "Mackerel", "Barracuda"));
			animals.Add(new Fish(2008, "Black", "Perch", "Bass"));
			animals.Add(new Fish(2014, "Black", "Perch", "Bass"));
			animals.Add(new Fish(2020, "Black", "Perch", "Bass"));
			mods();
		}

		public static void mods()
		{
			Console.WriteLine("Select mode:\n0 - Add new animal\n1 - Add new Fish\n2 - Show all animals\n3 - Show all Fish\n4 - Fish older than 3 years and sorted by species" +
				"\n5 - Write to file 'Animals.txt'\n6 - Serialize and Deserialize list cars to 'Animals.xml'");
			int mode = Int32.Parse(Console.ReadLine());
			switch (mode)
			{
				case 0:
					GettersAnimal();
					mods();
					break;
				case 1:
					GettersFish();
					mods();
					break;
				case 2:
					SettersAllAnimals();
					mods();
					break;
				case 3:
					SettersAllFish();
					mods();
					break;
				case 4:
					fishOld();
					mods();
					break;
				case 5:
					WrittenToFile(animals);
					mods();
					break;
				case 6:
					SerializeAndDeserialize(animals);
					mods();
					break;

			}

		}
		//Add new Animal
		public static void GettersAnimal()
		{
			try
			{
				Console.WriteLine("Write the year of birth your animal: ");
				int YearOfBirth = Int32.Parse(Console.ReadLine());
				Console.WriteLine("Write the color your animal: ");
				string Color = Console.ReadLine();
				animals.Add(new Animals(YearOfBirth, Color));
			}
			catch
			{
				Console.WriteLine("The string had the wrong format, please try again");
				Console.ReadKey();
				GettersAnimal();
			}
		}
		//Add new Fish
		public static void GettersFish()
		{
			try
			{
				Console.WriteLine("Write the year of birth fish: ");
				int YearOfBirth = Int32.Parse(Console.ReadLine());
				Console.WriteLine("Write the color fish: ");
				string Color = Console.ReadLine();
				Console.WriteLine("Write the kind fish: ");
				string Kind = Console.ReadLine();
				Console.WriteLine("Write the species your fish: ");
				string Species = Console.ReadLine();
				animals.Add(new Fish(YearOfBirth, Color, Kind, Species));
			}
			catch
			{
				Console.WriteLine("The string had the wrong format, please try again");
				Console.ReadKey();
				GettersFish();
			}
		}
		//Get full years
		public static int GetAge(int age)
		{
			return DateTime.Now.Year - age;
		}
		//Display all animals
		public static void SettersAllAnimals()
		{
			Console.WriteLine("All animals and their parameters:");
			foreach (var animal in animals.OfType<Animals>().OrderBy(x => x.yearOfBirth).ToList())
			{
				Console.WriteLine($"\nYear of birth:{animal.yearOfBirth}\nColor:{animal.color}\nYears at the moment:{GetAge(animal.yearOfBirth)}");
			}
			Console.ReadKey();
		}
		//Display all Fish
		public static void SettersAllFish()
		{
			Console.WriteLine("All fish and their parameters:");
			foreach (var fish in animals.OfType<Fish>().OrderBy(x => x.yearOfBirth).ToList())
			{
				Console.WriteLine($"\nYear of birth:{fish.yearOfBirth}\nColor:{fish.color}\nKind:{fish.kind}\nSpecies:{fish.species}\nYears at the moment:{GetAge(fish.yearOfBirth)}");
			}
			Console.ReadKey();
		}
		//Search for fish older than 3 years and sort by species
		public static void fishOld()
		{
			Console.WriteLine("All fish and their parameters:");
			foreach (var fish in animals.OfType<Fish>().Where(x => GetAge(x.yearOfBirth) >= 3).OrderBy(x => x.species).ToList())
			{
				Console.WriteLine($"\nYear of birth:{fish.yearOfBirth}\nColor:{fish.color}\nKind:{fish.kind}\nSpecies:{fish.species}\nYears at the moment:{GetAge(fish.yearOfBirth)}");

			}
			Console.ReadKey();
		}
		//Write list to file
		static void WrittenToFile(List<Animals> animalsCollection)
		{
			string WritePath = @"F:\Animals.txt";
			try
			{
				using (StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
				{
					foreach (var a in animalsCollection)
					{
						sw.WriteLine($"\nYear of birth:{a.yearOfBirth}\nColor:{a.color}" +
							$"\nYears at the moment:{GetAge(a.yearOfBirth)}");
						;
					}

				}

				Console.WriteLine("Add text-file on disk F");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}
		//Serialize and Deserialize list cars to "Animals.xml"
		public static void SerializeAndDeserialize(List<Animals> animals)
		{

			XmlSerializer sr = new XmlSerializer(typeof(List<Animals>), new[] { typeof(List<Fish>) });
			Stream fileStream = new FileStream(@"D:\Animals.xml", FileMode.OpenOrCreate);
			try
			{
				sr.Serialize(fileStream, animals);
				fileStream.Close();
				Console.WriteLine("Serialization completed");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("Serealized XML file successfully");
			Console.ReadLine();
			try
			{
				using (FileStream fs = new FileStream(@"D:\Animals.xml", FileMode.OpenOrCreate))
				{
					//Census of the available class
					animals = (List<Animals>)sr.Deserialize(fs);
					Console.WriteLine("List was Deserialized!");
					foreach (Animals an in animals)
					{
						Console.WriteLine($"\nYear of birth:{an.yearOfBirth}\nColor:{an.color}\nYears at the moment:{GetAge(an.yearOfBirth)}");
						
					}
					Console.ReadKey();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
