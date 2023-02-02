using System;

class Program
{
    static void Main(string[] args)
    {
        TopBottom Example1 = new TopBottom();
        Console.WriteLine(Example1.GetFraction());
        Console.WriteLine(Example1.GetDecimal());

        TopBottom Example2 = new TopBottom(5);
        Console.WriteLine(Example2.GetFraction());
        Console.WriteLine(Example2.GetDecimal());

        TopBottom Example3 = new TopBottom(3, 4);
        Console.WriteLine(Example3.GetFraction());
        Console.WriteLine(Example3.GetDecimal());

        TopBottom Example4 = new TopBottom(1, 3);
        Console.WriteLine(Example4.GetFraction());
        Console.WriteLine(Example4.GetDecimal());

        TopBottom Example5 = new TopBottom(973, 47);
        Console.WriteLine(Example5.GetFraction());
        Console.WriteLine(Example5.GetDecimal());
       
    }
}