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
