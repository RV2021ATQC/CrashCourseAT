using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;

namespace Animals
{
	[Serializable]
	[XmlInclude(typeof(Fish))]
	public class Animals
	{
		[XmlElement()]
		public  int yearOfBirth;
		[XmlElement()]
		public  string color;

		public Animals(int yearOfBirth, string color)
		{
			this.yearOfBirth = yearOfBirth;
			this.color = color;
		}
		public Animals()
		{

		}
		public override string ToString()
		{
			return String.Format("Voice: {0}", Voice());
		}
		public string Voice()
		{
			return "Gav - gav";
		}
	}
}
