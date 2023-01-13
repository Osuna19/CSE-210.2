using System;

class Program
{
    static void Main(string[] args)
    {

        Random generator = new Random();
        int magicNumber = generator.Next(1, 11);

        bool keepPlaying = true;

        while(keepPlaying)
        {
            Console.Write("Guess a number between 1 and 10: ");
            int userGuess = int.Parse(Console.ReadLine() ??"");

            if (magicNumber == userGuess)
            {
                Console.WriteLine("Correct, nice!");
                keepPlaying = false;
            }
            else if (magicNumber > userGuess)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }



        //Console.Write("what is your magical number? ");
        //string magiNumber = Console.ReadLine();
        //Console.Write("what is your number? ");
        //string guessNumber = Console.ReadLine();

        //int x = int.Parse(magicNumber);
        //int y = int.Parse(guessNumber);

        //if (x > y)
        //{
       //     Console.WriteLine("Higher");
       // }
       // else if (x < y)
       // {
//Console.WriteLine("Lower");
       // }
       // else
       // {
       //     Console.WriteLine("Correct");
       // }

    }


}