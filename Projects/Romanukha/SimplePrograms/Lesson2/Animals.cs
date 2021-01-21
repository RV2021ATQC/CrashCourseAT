using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public class Animals
    {
        //різні модифікатори доступу
        private int form;
        public int age;
        public int speed;
        protected int weight;

        //------------------------------------------------------------------------------------
        //конструктор - ініціалізує "будує" об'єкт, можемо викликати необхідну логіку при створенні об'єкта
        public Animals(int age, int speed, int weight)
        {
            //в даному випадку відразу задаємо значення для полів об'єкту
            this.age = age;
            this.speed = speed;
            this.weight = weight;
        }
        
        //конструктор "по замовчуванню" - без параметрів
        //це теж свого роду перегружений метод
        public Animals() { }
        //---------------------------------------------------------------------------------

        //Віртуальний (virtual) метод - його можна змінювати переписувати (override) у класах нащадках
        public virtual int move(int a, int b = 1)
        {
            return (a + b) * speed;
        }

    }

}
