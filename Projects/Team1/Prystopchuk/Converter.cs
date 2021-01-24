/*Method that converts a given number 
 * from decimal to other base-N systems (N<=36)
 * Return type: string*/

namespace TEMP
{
    class Converter
    {
        
        static string convert(int num, int base_, string res = "")
        {
            try
            {
                if (base_ <= 1 || base_ > 36) throw new System.Exception("Invalid base provided");
                string alphabeth = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                if (num < base_)
                    return alphabeth[num].ToString();
                else return convert(num / base_, base_) + alphabeth[num % base_];
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return null;

            }

        }

        static void Main()
        {
            int x = -20;
            System.Console.SetBufferSize(700, 10000);
            for (int base_ = 2; base_ < 37; base_++)
            {
                int y = 0;
                System.Console.SetCursorPosition(x += 20, 0);
                System.Console.WriteLine($"Base-{base_}");
                for (int num = 0; num < 501; num++)
                {
                    System.Console.SetCursorPosition(x, ++y);
                    System.Console.WriteLine($"{num} --- {convert(num, base_)}");
                }
                //System.Console.SetCursorPosition(x+=10, 0);                
            }

        }


        //static string ToHex(int value)
        //{
        //    return System.String.Format("{0:X}", value);
        //}
        //static string Reverse(string str)
        //{
        //    char[] stringArray = str.ToCharArray();
        //    System.Array.Reverse(stringArray);
        //    return new string(stringArray);
        //}

        //static string convert(int num, int base_, string res = "")
        //{
        //    if (num == 0)
        //        return Reverse(res);
        //    int dig = num % base_;
        //    res += dig.ToString();
        //    return convert(num / base_, base_, res);
        //}
    }
}
