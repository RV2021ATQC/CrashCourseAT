using System;
using System.Collections.Generic;
using TransportCollection;

namespace ConsoleApp2
{
    class Program
    {
        [Serializable]
        public class Transport
        {
            public string TransportName { get; set; }
            public int TransportAge { get; set; }
            public List<string> Models { get; set; }
        }

        static void Main(string[] args)
        {
            TransportData.TransportVoid();
            Console.ReadLine();
        }
    }
}
