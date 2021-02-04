using System;
using System.Collections.Generic;

namespace TransportCollection
{
    public class Ship : Transport
    {
        public Ship() { }
        public Ship(string TypeOfTransport, string Mark, long Price, int YearOfExploatation, int Speed) : base
            (TypeOfTransport, Mark, Price, YearOfExploatation, Speed)
        {  }
    }
}

