using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using static ConsoleApp2.Program;

namespace TransportCollection
{
    public class TransportData
    {
        public string DataString { get; set; }
        public List<string> Models { get; set; }
        public int agetd;

        public TransportData()
        {
            Models = new List<string>();
        }
        internal static int GetAge(int v)
        {
            return DateTime.Now.Year - v;
        }

        public static void TransportVoid()
        {
            string keyWord = "car";
            
            List<Transport> transportlist = new List<Transport>
            {
                new Transport {TransportName ="Audi",TransportAge = 3, Models = new List<string> {"car", "German", "A7" }},
                new Transport {TransportName ="Audi", TransportAge=3, Models = new List<string> {"car", "German", "A7" }},
                new Transport {TransportName ="Bmw", TransportAge=11, Models = new List<string> { "car", "German", "Hatchback" }},
                new Transport {TransportName="Porsche", TransportAge=2, Models = new List<string> { "car", "German", "911 Carrera" }},
                new Transport {TransportName="Vaz-2104", TransportAge=20, Models = new List<string> { "car", "Rassian", "Kalinka" }},
                new Transport {TransportName="Volvo", TransportAge=2, Models = new List<string> { "car", "Swedish", "C30" }},
                new Transport {TransportName="Ford", TransportAge=20, Models = new List<string> { "car", "American", "Focus" }},
                new Transport {TransportName = "BMX", TransportAge = 8, Models = new List<string> { "bicycle", "British", "SundaySoundwave" } },
                new Transport {TransportName = "CityBike", TransportAge = 9, Models = new List<string> { "bicycle", "American", "Treck" } }
            };

            var selectedTrans = transportlist.SelectMany(u => u.Models, (u, l) => new { tran = u, mod = l })
                          .Where(u => u.mod == keyWord && u.tran.TransportAge > 10)
                          .Select(u => u.tran);
            foreach (Transport transport in selectedTrans)
            {
                transport.TransportName += " " + keyWord.ToString();
                //Console.WriteLine($"{transport.TransportName} - year: {transport.TransportAge} ");
                Console.WriteLine($"{transport.TransportName} - year: {GetAge(transport.TransportAge)} ");
            }
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                XmlSerializer serializer = new XmlSerializer(typeof(TransportData));
                XmlWriterSettings settings = new XmlWriterSettings();
                using (FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, transportlist);
                }
                using (FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate))
                {
                    List<Transport> newList = (List<Transport>)formatter.Deserialize(fs);
                    Console.WriteLine("Deserialized!");
                    foreach (Transport transport in transportlist)
                    {
                        Console.WriteLine(transport.TransportName);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
