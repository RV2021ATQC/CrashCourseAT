using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the width of figure: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the height of figure: ");
            int height = Convert.ToInt32(Console.ReadLine());
            string StringHeight = "", StringWidth = "", figure = "";
            int i;
            for (i = 0; i < width; i++)
                StringWidth += "*";
            StringHeight += "*";
            for (i = 0; i < width - 2; i++)
                StringHeight += " ";
            StringHeight += "*";
            figure += StringWidth + "\n";
            for (i = 0; i < height - 2; i++)
                figure += StringHeight + "\n";
            figure += StringWidth;
            Console.WriteLine(figure);
            Console.ReadKey();
        }
    }
}
