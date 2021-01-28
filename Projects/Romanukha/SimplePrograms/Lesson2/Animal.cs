using System;
using System.Xml.Serialization;

namespace Lesson2
{
    [Serializable]
    //Позначаємо для Xml серіалізації, що клас Animal може включати об'єкти класу Cat
    [XmlInclude(typeof(Cat))]
    public class Animal
    {
        //різні модифікатори доступу
        private int _form; // доступний лише всередині класу
        
        [XmlElement()] //позначаємо кожне поле, яке має бути серіалізоване
        public int age;  // доуступний для інших класів
        [XmlElement()]
        public int weight; // доступний з класів нащадків
        [XmlElement()]
        public int speed;

        const string CLASS_NAME = "ТВАРИНИ";

        //---------------------------СТАТИЧНІ ПОЛЯ І МЕТОДИ--------------------------------------------
        //статичні поля і методи належать класу а не конкретному об'єкту цього класу
        //статичні елементи створюються під час компіляції програми, а не під час створення нового об'єкту класу
        //можемо викликати статичні сутності без створення нових об'єтктів а через ім'я класу. У даному випадку Animals.countOfAnimals

        private static int countOfAnimals; //інкапсулювати лічильник тварин, його неможливо змінити напряму, а ЛИШЕ через виклик методів
        
        public static void increaseCountOfAnimals()
        {
            countOfAnimals++;        
        }

        public static string GetCountOfAnimals()
        {
            return countOfAnimals.ToString();
        }
        public static void decreaseCountOfAnimals() => countOfAnimals--;  // скорочене оголошення методу через оператор =>


        //---------------------------КОНСТРУКТОРИ--------------------------------------------
        //конструктор - це метод, який ініціалізує "будує" об'єкт, можемо викликати необхідну логіку при створенні об'єкта


        //конструктор "по замовчуванню" - без параметрів
        public Animal() { }         

        // як і інші методи ми може мо мати перегружені конструктори
        public Animal(int age, int speed, int weight)
        {
            //в даному випадку відразу задаємо значення для полів об'єкту
            this.age = age;
            this.speed = speed;
            this.weight = weight;


            //виклик статичного методу, що належить класу Animals
            Animal.increaseCountOfAnimals();

        }

        public int GetWeight()
        {
            return this.weight;
        }

        //---------------------------------------------------------------------------------

        //Віртуальний (virtual) метод - його можна змінювати переписувати (override) у класах нащадках - реалізація принципу ООП поліморфізму
        public virtual int move(int a, int b = 1)
        {
            return (a + b) * speed;
        }

    }

}
