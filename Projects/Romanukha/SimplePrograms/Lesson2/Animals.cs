using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public class Animals
    {
        //різні модифікатори доступу
        private int _form; // доступний лише всередині класу
        public int age;  // доуступний для інших класів

        protected int weight; // доступний з класів нащадків

        const string CLASS_NAME = "ТВАРИНИ";

        public int speed;

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
        public Animals() { }         

        // як і інші методи ми може мо мати перегружені конструктори
        public Animals(int age, int speed, int weight)
        {
            //в даному випадку відразу задаємо значення для полів об'єкту
            this.age = age;
            this.speed = speed;
            this.weight = weight;


            //виклик статичного методу, що належить класу Animals
            Animals.increaseCountOfAnimals();

        }


        //---------------------------------------------------------------------------------

        //Віртуальний (virtual) метод - його можна змінювати переписувати (override) у класах нащадках - реалізація принципу ООП поліморфізму
        public virtual int move(int a, int b = 1)
        {
            return (a + b) * speed;
        }

    }

}
