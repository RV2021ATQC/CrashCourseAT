using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StarProject
{
    [Serializable]
    public class Fish : Animals
    {
        private string _kind;
        [XmlElementAttribute]
        public string kind
        {
            get
            {
                return _kind;
            }
            set
            {
                _kind = value;
            }
        }
        private double _weight;
        [XmlElementAttribute]
        public double weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }

        //перезаписане поле із виведенням іншої інформації(на ввідміну від батьківського класу) при заповненні
        [XmlElementAttribute]
        public override double born_year
        {
            set
            {
                _born_year = value;
                Console.WriteLine($"Age of this fish is {Convert.ToInt32(DateTime.Now.Year) - _born_year}");
            }
            get
            {
                return _born_year;
            }
        }
        private string _species;
        public string species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
            }
        }
        public Fish() { }
        //конструктор
        public Fish(double born_year, string color, string kind, string species)
            : base(born_year, color)
        {
            this.kind = kind;
            this.species = species;
            this.weight = 0.1;
        }
        public double Feed(double foodstuff)
        {
            double WeightIncrease = foodstuff * 0.1;
            this.weight += WeightIncrease;
            return WeightIncrease;
        }
        public override string Voice()
        {
            return "Blop!!!";
        }
    }
}
