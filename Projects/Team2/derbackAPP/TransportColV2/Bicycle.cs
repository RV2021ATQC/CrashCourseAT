using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Bicycle: Transport
    {
        public Bicycle(int speed, string model,
           string mark, string transportType, int yearOfExploatation, bool isWorking, double price)
           : base(model, mark, price, transportType, yearOfExploatation, speed, isWorking)
        {
            TransportType = transportType;
            YearOfExploatation = yearOfExploatation;
            IsWorking = isWorking;
            Speed = speed;
            Model = model;
            Mark = mark;
            Price = price;
        }
    }
}
