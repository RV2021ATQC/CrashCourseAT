namespace CCTask1
{
    class Counter
    {

        private int min, max, count, lap = 1;
        public Counter() : this(0, 60, 0) { }
        public Counter(int max) : this(0, max, 0) { }
        public Counter(int min, int max, int count)
        {
            if (count < min || count > max || min >= max)
                throw new System.Exception("Invalid parameters provided");
            this.min = min; this.max = max; this.count = count;
        }

        public static Counter operator +(Counter c, int incr) {
            c.count += incr;
            while (c.count > c.max) {
                c.count -= c.max - c.min;
                c.lap++;
            }

            return c;
        }

        public static Counter operator ++(Counter c)
        {
            if (c.count < c.max)
                c.count++;
            else
            {
                c.count = c.min + 1;
                c.lap++;
            }
            return c;
        }

        public void Current()
        {
            System.Console.WriteLine($"{count}/{max} Lap {lap}");
        }
    }  

    class Program
    {
        static void Main()
        {
            try
            {
                System.Console.WriteLine("Test 1:");
                Counter test1 = new Counter();
                test1.Current();
                test1 += 10;
                test1.Current();

                System.Console.WriteLine("\nTest 2:");
                Counter test2 = new Counter();
                test2.Current();
                test2++;
                test2.Current();

                System.Console.WriteLine("\nTest 3:");
                Counter test3 = new Counter(10, 40, 11);
                test3.Current();
                test3 += 61;
                test3.Current();

                System.Console.WriteLine("\nTest 4:");
                Counter test4 = new Counter(15);
                test4.Current();
                test4+=40;
                test4.Current();

                System.Console.WriteLine("\nTest 5:");
                Counter test5 = new Counter(10, 40, 5);
                test5.Current();
                test5 += 2;
                test5.Current();

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}