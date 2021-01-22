using System;
using System.Collections.Generic;

namespace HomeWork5._2
{
    //Написати клас, що описує групу студентів.Студент також реалізується за допомогою відповідного класу.
    class Program
    {
        class Class
        {
            public Class(int id,string className,int auditoriumNumber)
            {
                this.id = id;
                this.className = className;
                this.auditoriumNumber = auditoriumNumber;
            }
            public int id { get; set; }

            public string className { get; set; }

            public int auditoriumNumber { get; set; }
            public  void GetInfo()
            {
                Console.WriteLine($"Class Id : "+id);
                Console.WriteLine($"ClassName : " + className);
                Console.WriteLine($"Auditorium Number : "+auditoriumNumber);
            }
            public static void AddStudentsAndGetInfo() {
                List<Student> students = new List<Student>(5);
                students.Add(new Student { id = 1, sexType = "Male", age = 21, phoneNumber = "+380437545", faculty = "Math", name = "Anton" });
                students.Add(new Student { id = 2, sexType = "Male", age = 22, phoneNumber = "+380327545", faculty = "Phisichs", name = "Anton" });
                students.Add(new Student { id = 3, sexType = "Famele", age = 20, phoneNumber = "+380237545", faculty = "Informatic", name = "Anton" });
                students.Add(new Student { id = 4, sexType = "Male", age = 21, phoneNumber = "+380347545", faculty = "English", name = "Anton" });
                students.Add(new Student { id = 5, sexType = "Famele", age = 22, phoneNumber = "+3803217545", faculty = "Ukrainian", name = "Anton" });
                foreach (Student s in students)
                {
                    Console.WriteLine($"ID :{s.id} |  SexType : {s.sexType} |  PhoneNumber : {s.phoneNumber} |  Faculty : {s.faculty} |  Name : {s.name}");
                }
            }     
        }
        class Student
        {                    
            public int id { get; set; }
            public string name { get; set; }
            public string phoneNumber { get; set; }
            public string sexType { get; set; }
            public string faculty { get; set; }
            public int age { get; set; }
        }
        static void Main(string[] args)
        {
            Class firstClass = new Class(1, "FirstClassName", 146);
            firstClass.GetInfo();
            Class.AddStudentsAndGetInfo();
        }

    }
}
