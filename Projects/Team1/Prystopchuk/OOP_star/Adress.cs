using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_star
{
    [Serializable]
    public struct AdressInfo
    {
        public string city, street;

        //public AdressInfo(string city, string street) : this(city, street) { }
        public AdressInfo(string city, string street)
        {
            this.city = city;
            this.street = street;
        }

        public override String ToString()
        {
            return city != default ? string.Join(", ", city, street) : "Has no adress yet";
        }

        public AdressInfo(string adress)
        {
            try
            {
                string[] adr = new string((from c in adress
                                           where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                           select c).ToArray()).Split();
                city = adr[0];
                street = adr.Length > 1 ? adr[1] : default;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Invalid adress format {adress}");
                city = street = default;
            }
        }
    }

}
