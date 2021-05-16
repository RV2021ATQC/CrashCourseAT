using System;
 namespace OOP_2_1_Constructor
    {
    public class Person
    {
        //class variables
        private string name;
        private int age;
        private bool female;
        private string telephone;

        //set the values through the properties
        public string Name
        {
            set 
            {   if (value=="") name = "Unknown name";
                else name = value;
            }          
        }
        public string Age
        {
            set
            {
                int number;
                while (!Int32.TryParse(value, out number)^((Int32.TryParse(value, out number))&((number<0)^(number>150))))
                {   if (!Int32.TryParse(value, out number))
                    Console.WriteLine($"Could not convert '{value}' to an int. Input age (int value) again: ");                   
                    else if ((Int32.TryParse(value, out number)) & ((number < 0) ^ (number > 150)))
                        Console.WriteLine($"Age must be from 0 till 150. Input age (int value) again: ");
                    value = Console.ReadLine();
                }                            
                age = number;
            }          
        }
        public string Female
        {
            set
            {
                while ((value!="0")&(value!="1"))
                {
                    Console.WriteLine($"Gender must be 0 or 1. Input agender again: ");
                    value = Console.ReadLine();
                }
                if (value=="0") female = false;
                else if (value=="1") female=true;
            }
        }
        public string Telephone
        {
            set
            {
                if (value == "") telephone = "Unknown tel";
                else telephone = value;
            }
        }

        //different constructors for a different set of input parameters
        public Person(string name, int age, bool female, string telephone)
        {
            this.name = name;
            this.age = age;
            this.female = female;
            this.telephone = telephone;
        }
        public Person(string name, int age, bool female) : this(name, age, female, "Unknovn tel") {}
        public Person(string name, int age, string telephone) : this(name, age, false, telephone){}
        public Person(string name, bool female, string telephone) : this(name, 18, female, telephone){}
        public Person(int age, bool female, string telephone): this("Unknown name", age, female, telephone){}
        public Person(string name, int age) : this(name, age, false) {}
        public Person(string name, bool female): this(name, 18, female){}
        public Person(string name, string telephone): this(name,18,telephone){}
        public Person( int age, bool female): this("Unknown name",age,female){}
        public Person( int age, string telephone): this("Unknown name",age,telephone){}
        public Person(bool female, string telephone) : this("Unknown name", female, telephone) {}
        public Person(string name) : this(name, 18) {}
        public Person(int age) : this("Unknown name",age) {}
        public Person(bool female) : this("Unknown name", female) {}
        public Person() : this("Unknown name") { }

        //display formatted data about the person
        public void Print()
        {   string gender;
        if (female) gender = "female"; else gender = "male"; 
            Console.WriteLine("\r\nName: {0}\r\nAge: {1} years\r\nGender: {2}\r\nTelephone: {3}", name,age,gender,telephone);
        }
    }
    }

