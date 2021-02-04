using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TransportCollection
{
    [XmlInclude(typeof(Transport))]
    [Serializable]
    public abstract class Transport
    {
        public string TypeOfTransport;
        public string Mark;
        public long Price;
        public int YearOfExploatation;
        public int Speed;

        public Transport() { }
        public Transport(string TypeOfTransport, string Mark, long Price, int YearOfExploatation, int Speed)
        {
            this.TypeOfTransport = TypeOfTransport;
            this.Mark = Mark;
            this.Price = Price;
            this.YearOfExploatation = YearOfExploatation;
            this.Speed = Speed;
        }
    }
}