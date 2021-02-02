using System;
using System.Collections.Generic;

namespace TransportCollection
{
    public class Car : Transport
    {
        public Car() { }
        public Car(string TypeOfTransport, string Mark, long Price, int YearOfExploatation, int Speed) : base
            (TypeOfTransport, Mark, Price, YearOfExploatation, Speed)
        { }
    }
}
