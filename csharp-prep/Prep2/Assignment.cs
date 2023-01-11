using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string gradeOfUser = Console.ReadLine();

        int x = int.Parse(gradeOfUser);
        int a = 90;
        int b = 80;
        int c = 70;
        int d = 60;
        if (x >= a)
        {
            Console.WriteLine("Yor grade is A");
        }
        else if (x >= b && x < a)
        {
            Console.WriteLine("Yor grade is B");
        }
        else if (x >= c && x < b)
        {
            Console.WriteLine("Yor grade is C");
        }
        else if (x >= d && x < c)
        {
            Console.WriteLine("Yor grade is D");
        }
        else 
        {
            Console.WriteLine("Yor grade is F");
        }
        if (x >= c)
        {
            Console.WriteLine("We are so proud of your efforts");
        }
         else if (x < c)
            {
                Console.WriteLine("You can do best next time :)");
            }
    }
    
}