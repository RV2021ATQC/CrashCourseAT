using System;
using System.Collections.Generic;

namespace TransportCollection
{
    public class Bicycle : Transport
    {
        public Bicycle() { }
        public Bicycle(string TypeOfTransport, string Mark, long Price, int YearOfExploatation, int Speed) : base
            (TypeOfTransport, Mark, Price, YearOfExploatation, Speed)
        {  }
        public long SumPrice(Bicycle b1, Bicycle b2)
        {
            return b1.Price + b2.Price;
        }
    }
}
