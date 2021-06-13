using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace Star_3_Figure
{
    class Program
    {
        // serialization the collection to an Json file
        public static List<Figure> JSONSerializer(List<Figure> jsoncollection)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
            using (var file = File.CreateText("figure.json"))
                file.Write(JsonConvert.SerializeObject(jsoncollection, settings));

            System.IO.StreamReader sr = File.OpenText("figure.json");
            return JsonConvert.DeserializeObject<List<Figure>>(sr.ReadToEnd(), settings);
        }

        // serialization the collection to an XML file
        public static List<Figure> XmlSerializer(List<Figure> xmlCollection)
        {
            //serialization the collection to an XML file
            XmlSerializer formatter = new(typeof(List<Figure>), new[] { typeof(List<Rectangle>) });
            FileStream fs = new("figure.xml", FileMode.Create);
            formatter.Serialize(fs, xmlCollection);
            fs.Close();
            FileStream fs2 = new("figure.xml", FileMode.OpenOrCreate);
            return (List<Figure>)formatter.Deserialize(fs2);
        }
        public static void Main()
        {
            var figure = new List<Figure>();
              
              //figure0
              Console.WriteLine("\nUnvisible creating new figure0...\n");        
              Figure figure0 = new ("circle", DateTime.Parse("19/02/2000"));
              figure.Add(figure0);

              //rectangle1
              Console.WriteLine("Initializing new rectangle1:");
              Rectangle rectangle1 = new ();
              rectangle1.SetNewInfo();
              figure.Add(rectangle1);

              //figure2
              Console.WriteLine("\nUnvisible creating new figure2...\n");
              Figure figure2 = new();
              figure.Add(figure2);

              //rectangle3 (from figure2)
              Console.WriteLine("\nConverting existing figure2 to a rectangle3:");
              Rectangle rectangle3 = Rectangle.ConvertToRectangle(figure2);
              rectangle3.SetNewInfo(false);
              figure.Add(rectangle3);

            var name = new string("_");
            var date = DateTime.Parse("02/02/2011");

            //random figures 
            foreach (int k in Enumerable.Range(0, 3))
            {
                figure.Add(new Figure(name + k + "f", new DateTime(DateTime.Today.Year, DateTime.Today.Month, new Random().Next(1, DateTime.Today.Day))));
            }

            //random rectangles
            foreach (int k in Enumerable.Range(0, 3))
            {
                figure.Add(new Rectangle(name + k + "r", new DateTime(DateTime.Today.Year, DateTime.Today.Month, new Random().Next(1, DateTime.Today.Day)), 20, new Random().Next(1, 20)));
            }

              Console.WriteLine("\n----------Original Collection----------");
              foreach (var it in figure.Select((x, i) => new { item = x, index = i }))
              {
                  Console.Write($"\n{it.item.GetType().Name} № {it.index}");
                  it.item.Display();
              } 

              Console.WriteLine("\n----------Restored JSON Collection----------");
              foreach (var it in JSONSerializer(figure).Select((x, i) => new { item = x, index = i }))
              {
                  Console.Write($"\n{it.item.GetType().Name} № {it.index}");
                  it.item.Display();
              }
            

            Console.WriteLine("\n----------Restored XML Collection----------");
            foreach (var it in XmlSerializer(figure).Select((x, i) => new { item = x, index = i }))
            {
                Console.Write($"\n{it.item.GetType().Name} № {it.index}");
                it.item.Display();
            }
               
               //List of figures which date creation are less then 7 days
               Console.WriteLine("\n\n" +
               "----------List of figures which date creation are less then 7 days----------\n");
               foreach (var it in new List<Figure>(from it in figure
               where it.GetCreatedDate() < 7
               select it).Select((x, i) => new { item = x, index = i }))
               {
                   Console.Write($"\n{it.item.GetType().Name} № {it.index}");
                   it.item.Display();
               }
/*
               //Rectangles sorted by heights
               var RectanglesByHeights = figure.OfType<Rectangle>().OrderBy(it => Rectangle.Correct_Double(it.Height)).ToList();
               Console.WriteLine("\n\n" +
               "----------Rectangles sorted by heights----------\n");
               foreach (var it in RectanglesByHeights.Select((x, i) => new { item = x, index = i }))
               {
                    Console.Write($"\n{it.item.GetType().Name} № {it.index}");
                    it.item.Display();
               }*/
            Console.WriteLine(SortByHeight(figure));

            Console.ReadKey();
        }
        public static string SortByHeight(List<Figure> figure)
        {
            StringBuilder result = new StringBuilder();
            var RectanglesByHeights = figure.OfType<Rectangle>().OrderBy(it => Rectangle.Correct_Double(it.Height)).ToList();
            result.Append("\n\n" +
            "----------Rectangles sorted by heights----------\n");
            foreach (var it in RectanglesByHeights.Select((x, i) => new { item = x, index = i }))
            {
                result.Append($"\n\n{it.item.GetType().Name} № {it.index}");
                result.Append(it.item.ToString());
            }
            return result.ToString();
        }
    }
}