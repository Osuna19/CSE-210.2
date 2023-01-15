using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {

        List<int> data = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int agentNumber = -1;

    //Do-while loop to get the data (all the code to get the data has to be in te doo loop)
        do {
            Console.Write("Enter number: ");
            string userNumber = Console.ReadLine();
            agentNumber = int.Parse(userNumber);
            data.Add(agentNumber);
        } while(agentNumber != 0);
    
    // Sumn of the numbers
        int sum = 0;
        foreach (int number in data)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

    // Get the average, for that we need to use a float.
        float average = ((float)sum) / data.Count;
        Console.WriteLine($"The average of the number is: {average}");

    // Get the max number from the list.
        Console.WriteLine("The max number: "+data.Max());
        Console.WriteLine("The min number: "+data.Min());

        foreach(int sort in data){
            Console.WriteLine(sort);
        } 

    }
}