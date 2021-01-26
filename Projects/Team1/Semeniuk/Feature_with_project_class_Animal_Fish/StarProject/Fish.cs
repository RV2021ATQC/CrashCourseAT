using System;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    class Fish : Animals
    {
        private string _kind;
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
        //перезаписане поле із виведенням іншої інформації(на ввідміну від батьківського класу) при заповненні
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
        //конструктор
        public Fish(int born_year, string color, string kind, string species)    
            : base(born_year, color)
        {
            this.kind = kind;
            this.species = species;
        }

    }
}
