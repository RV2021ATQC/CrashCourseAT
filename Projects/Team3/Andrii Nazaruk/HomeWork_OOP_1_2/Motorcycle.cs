using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1_2
{
    public class Motorcycle : Transport
    {
        public Motorcycle(int speed, string model,
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
