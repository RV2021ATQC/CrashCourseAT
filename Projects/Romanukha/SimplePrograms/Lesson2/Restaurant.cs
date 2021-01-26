using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class Restaurant
    {
        public void MadeFood(ICook someFood)
        {
            someFood.GetFood();
        }
    }
}
