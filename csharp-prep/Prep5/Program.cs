using System;

class Program
{
  
    static void Main(string[] args)
    {
        DisplayMessage();

        string userName = TheUserName();
        int userNumber = TheUserNumber();
        int squareNumber = SquareUserNumber(userNumber);

        GiveResult(userName, squareNumber);
    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string TheUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int TheUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    static int SquareUserNumber(int number)
    {
        int answer = number * number;
        return answer;
    }

    static void GiveResult(string name, int answer)
    {
        Console.WriteLine($"{name}, the square of your number is {answer}");
    }


}