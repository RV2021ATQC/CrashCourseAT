using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            [TestCase("01/06/2021", ExpectedResult =18)]
            [TestCase("19/06/2020", ExpectedResult = 365)]
            [TestCase("20/06/2021", ExpectedResult = -1)]
            [TestCase("19/06/2021", ExpectedResult = 0)]

            public int TestGetCreatedDate(string date_1)
            {
               Figure figure = new Figure("test_figure", DateTime.Parse(date_1));
               return figure.GetCreatedDate(DateTime.Parse("19/06/2021"));
            }

            [Test]
            [TestCase("01/06/2020", null)]  
            [TestCase("01/06/2030", typeof(ArgumentOutOfRangeException))] 
            [TestCase("fgg", typeof(ArgumentException))]
            [TestCase("02.02", null)]
        public void TestCorrect_Parse_DateTime(string date_1, Type expectedException)
                 {
               if (expectedException is not null)
                  Assert.Throws(expectedException, () => Figure.Correct_Parse_DateTime(date_1)); 
               else Assert.DoesNotThrow(() => Figure.Correct_Parse_DateTime(date_1));
        }


             [Test]
             public void TestSortByHeight()
             {
                 //Given
                 List<Figure> figureCollection = new List<Figure>();           
                 figureCollection.Add(new Figure("test_figure", DateTime.Parse("19/06/2021")));
                 figureCollection.Add(new Rectangle("test_rectangle", DateTime.Today, 30, 34.3));
                 figureCollection.Add(new Figure());
                 figureCollection.Add(new Rectangle());
                 string ExpectedValue = $"\n\n----------Rectangles sorted by heights----------\n\n\n"+
                 "Rectangle № 0\nShape: rectangle\nName: Default name\nCreation date: 01.01.2021\n"+
                 "Days from creations: 174\nColor: red\nArea: 100 sm.kv.\nWirth: 10 sm\nHeight: 10 sm\n\n"+
                 "Rectangle № 1\nShape: rectangle\nName: test_rectangle\nCreation date: 24.06.2021\n"+
                 "Days from creations: 0\nColor: red\nArea: 1029 sm.kv.\nWirth: 30 sm\nHeight: 34,3 sm";

                 //When
                 string ActualValue = Program.SortByHeight(figureCollection);

                 //Then
                 Assert.AreEqual(ActualValue, ExpectedValue);
             }
        
    }

}
