using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport
{
	class ForeignPassport : Passport
	{
		public string visaDetails { get; set; }

		public int serialNumber { get; set; }
		
		public ForeignPassport(string name, string lastName, int age, string sex, string placeOfResidence, string visaDetails, int serialNumber) :base (name, lastName, age, sex, placeOfResidence)
		{
			this.visaDetails = visaDetails;
			this.seriadlnumber = serialNumber;
		}
		public void Display()
		{
			Console.WriteLine($"Name: {name}\n Last name: {lastName}\n Age: {age}\n Sex: {sex}\n Place of residence: {placeOfResidence}\n " +
				$"\nVisa details: {visaDetails}\n Serial number: {serialNumber}");
			Console.ReadKey();
		}
	}
}
