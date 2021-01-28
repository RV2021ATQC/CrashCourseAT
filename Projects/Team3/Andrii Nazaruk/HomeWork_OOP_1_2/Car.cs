using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HomeWork_OOP_1_2
{
    [Serializable]    
    public class Car : Transport
    {
        public Car()
        {

        }
        public Car(int speed, string model, string mark, string transportType, int yearOfExploatation, bool isWorking, double price)
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
