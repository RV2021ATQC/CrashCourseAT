using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
	class Passport
	{
		public string name { get; set; }

		public string lastName { get; set; }

		public int age { get; set; }

		public string sex { get; set; } 

		public string placeOfResidence { get; set; }

		public Passport(string name, string lastName, int age, string sex, string placeOfResidence)
		{
			this.name = name;
			this.lastName = lastName;
			this.age = age;
			this.sex = sex;
			this.placeOfResidence = placeOfResidence;
		}

		

		public void Display()
		{
			Console.WriteLine($"Name: {name}\n Last name: {lastName}\n Age: {age}\n Sex: {sex}\n Place of residence: {placeOfResidence}");
			Console.ReadKey();
		}
	}
}
