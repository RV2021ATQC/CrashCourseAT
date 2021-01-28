using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class Fish :  Animal, ICook
    {
        bool IsOceanic { get; set; }

        bool isEdible;

        public Food GetFood() {

            Console.WriteLine("It is your sushi");
            return isEdible ? new Food() : new Food();
        }
    }
}
