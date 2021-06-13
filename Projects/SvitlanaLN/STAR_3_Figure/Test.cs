using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Star_3_Figure
{
    [TestFixture]
    public class TestFigure
    {
           [Test]
            public void TestXMLserializer() 
            {
                var Actual = new List<Figure>();
                var name = new string("Test_figure");
                var Expected = new List<Figure>();
                foreach (int k in Enumerable.Range(0, 3))
                {
                    Actual.Add(new Figure(name, new DateTime(DateTime.Today.Year, DateTime.Today.Month, new Random().Next(1, DateTime.Today.Day))));
                    Actual.Add(new Rectangle(name, new DateTime(DateTime.Today.Year, DateTime.Today.Month, new Random().Next(1, DateTime.Today.Day)),
                        50, new Random().Next(1, 20)));                
                }
                Expected = Program.XmlSerializer(Actual);
                Assert.IsTrue(Actual.Count== Expected.Count);
                foreach (int k in Enumerable.Range(0, 6))
                    Assert.IsTrue((Actual[k].Area == Expected[k].Area)&
                              (Actual[k].Name == Expected[k].Name)&
                              (Actual[k].Create_date == Expected[k].Create_date) &
                              (Actual[k].Color == Expected[k].Color)
                              );          
                foreach (var rect in Actual.OfType<Rectangle>().ToList())
                {
                        Assert.IsTrue((rect.Width == Expected.OfType<Rectangle>().ToList()[Actual.OfType<Rectangle>().ToList().IndexOf(rect)].Width)&
                                      (rect.Height == Expected.OfType<Rectangle>().ToList()[Actual.OfType<Rectangle>().ToList().IndexOf(rect)].Height));
                }
             }

             [Test]
             public void Testconverter()
             {
             var Expected = new Rectangle();
             var Actual = Rectangle.ConvertToRectangle(new Figure());
             Assert.IsTrue((Actual.Name==Expected.Name)&
                           (Actual.Create_date == Expected.Create_date)&
                           (Actual.Area == Expected.Area)&
                           (Actual.Color == Expected.Color)&
                           (Actual.Width == Expected.Width)&
                           (Actual.Height == Expected.Height));
         }
              [Test]
              [TestCase("05", ExpectedResult =8)]
              [TestCase("05", ExpectedResult = 9)]
              [TestCase("05", ExpectedResult = 10)]
              [TestCase("05", ExpectedResult = 11)]

              public int TestGetCreatedDate(string day_s)
              {
                  Figure figure = new("test_figure", DateTime.Parse($"{day_s}/06/2021"));
                  return figure.GetCreatedDate();
              }
             

   /*     [Test]
        public void TestSortByHeight()
        {
            //Given
            List<Figure> figureCollection = new List<Figure>();
            //попередньо введені дані
            figureCollection.Add(new Figure("test_figure", DateTime.Parse("19/06/2021")));
            figureCollection.Add(new Rectangle("test_rectangle", DateTime.Today, 30, 34.3));
            figureCollection.Add(new Figure());
            figureCollection.Add(new Rectangle());
            string ExpectedValue = $"\n\n" +
            "----------Rectangles sorted by heights----------\n";

            //When
            string ActualValue = Program.SortByHeight(figureCollection);

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
   */
    }

}
