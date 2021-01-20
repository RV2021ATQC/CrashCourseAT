using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курси__Масиви_задача__1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] masiv = new int[6] { 1, 66, 900, 11, 75, 33 };
            for (int i = masiv.Length - 1; i >= 0; --i)
                Console.Write(masiv[i] + " , ");

            Console.ReadKey();
        }
    }
}
