using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("For behold, this is my work and my glory, to bring to pass the inmmortality and eternal life of man.");
        Word word = new Word(scripture);
        Reference chapter = new Reference();
        while (true)
        {
            Console.Clear(); 
            Console.WriteLine(chapter.getReference() + scripture.ToString());
            Console.WriteLine();
            Console.WriteLine("Press Enter to replace another word. Type quit to end program.");
            string endProgram = Console.ReadLine();
            if (endProgram == "quit"){
                break;
            }

            word.ReplaceRandomWord();
            Console.ReadLine();

            if (scripture.IsCompletelyReplaced)
            {
                
                Console.WriteLine("All words are replaced.");
                Console.WriteLine("Did you memorize the scripture? If yes type the scripture to see if you memorize it:");
                string memory = ("For behold, this is my work and my glory, to bring to pass the immortality and eternal life of man."); 
                string memory2 = Console.ReadLine();
                if (memory == memory2){
                    Console.WriteLine("You learned a new scripture!");
                }
                else {
                    Console.WriteLine("Oh, you almost got it! the scripture was " + scripture.OriginalVerse);
                }
                break;
            }
        }
    }
}