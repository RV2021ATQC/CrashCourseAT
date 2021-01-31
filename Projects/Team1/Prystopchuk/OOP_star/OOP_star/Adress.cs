using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_star
{
    public struct AdressInfo
    {
        public string city, street, str_num;

        public AdressInfo(string city, string street) : this(city, street, default) { }
        public AdressInfo(string city, string street, string str_num)
        {
            this.city = city;
            this.street = street;
            this.str_num = str_num;
        }

        public override String ToString()
        {
            return string.Join("", city, ", ", street, " ", str_num);
        }

        public AdressInfo(string adress)
        {
            string[] adr = new string((from c in adress
                                       where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                       select c).ToArray()).Split();
            city = adr[0];
            street = adr.Length > 1 ? adr[1] : default;
            str_num = adr.Length > 2 ? adr[2] : default;
        }
    }

}
