using System;
class Counter
{
    private int start;
    private int finish;
    private int curent;
    public Counter(int n)
    {
        Random rand = new Random();
        
        this.start = rand.Next(n);
        this.finish = rand.Next(n,60);
        this.curent = start;
    }
    public int GetStart()
    {
        return start;
    }
    public int GetFinish()
    {
        return finish;
    }

    public void Print()
    {
        Console.WriteLine("The Counter start at {0} second.", start);
        Console.WriteLine("The Counter finish at {0} second.", finish);
    }


    public int GetCurent()
    {
        Console.WriteLine("The Curent value of counter is {0} second.", curent);
        return finish;
    }

    public void AddCurent()
    {
        curent += 1;
        if (curent == finish + 1)
        {
            curent = start;
            Console.WriteLine("The counter's circle has reached its maximum and starts over.");
        }
    }

    static void Main()
    { 
        int now_second = DateTime.Now.Second;          //  set the current second
        Counter second = new Counter(now_second);      //call the constructor to randomly set the minimum and maximum time
        second.GetStart();                             //get start and finish of time span
        second.GetFinish();
        second.Print();
        second.GetCurent();
        for (int i = second.GetStart(); i <= second.GetFinish() ; i++)
            {
            second.GetCurent();
            second.AddCurent();
            }
        Console.ReadKey();
    }
}
