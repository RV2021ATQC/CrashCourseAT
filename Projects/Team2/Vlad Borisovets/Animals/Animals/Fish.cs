using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Animals
{
	[Serializable]
	public class Fish: Animals
	{
		[XmlElement()]
		public string kind;
		[XmlElement()]
		public string species;
		public Fish()
		{

		}
		public Fish(int yearOfBirth, string color, string kind= "Mackerel", string species= "Amberjack") :base(yearOfBirth, color)
		{
			this.kind = kind;
			this.species = species;
		}
	}
}
