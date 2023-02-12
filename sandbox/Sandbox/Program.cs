using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Verse verse = new Verse("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        WordReplacer wordReplacer = new WordReplacer(verse);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(verse.ToString());
            Console.WriteLine();
            Console.WriteLine("Press Enter to replace another word, type quit to end program.");
            string endProgram = Console.ReadLine();
            if (endProgram == "quit"){
                break;
            }

            Console.ReadLine();
            wordReplacer.ReplaceRandomWord();

              if (verse.IsCompletelyReplaced)
            {
                
                Console.WriteLine("All words are replaced.");
                Console.WriteLine("Did you memorize the scripture? If yes type the scripture to see if you memorize it:");
                string memory = Console.ReadLine();
                if (memory == verse.OriginalVerse){
                    Console.WriteLine("You learned a new scripture!");
                }
                else {
                    Console.WriteLine("Oh, you almost got it! the scripture is " + verse.OriginalVerse);
                }
                break;
            }
        }
    }
}

class Verse
{
    private readonly string _originalVerse;
    private readonly string[] _words;
    private readonly List<bool> _isReplaced;

    public Verse(string verse)
    {
        _originalVerse = verse;
        _words = verse.Split(' ');
        _isReplaced = new List<bool>(_words.Length);

        for (int i = 0; i < _words.Length; i++)
        {
            _isReplaced.Add(false);
        }
    }
    public string[] Words
{
    get
    {
        return _words;
    }
}


    public bool IsCompletelyReplaced
    {
        get
        {
            return _isReplaced.All(replaced => replaced == true);
        }
    }

    public string OriginalVerse
    {
        get
        {
            return _originalVerse;
        }
    }

    public void ReplaceWord(int index)
    {
        _isReplaced[index] = true;
    }

    public override string ToString()
    {
        string verse = "";

        for (int i = 0; i < _words.Length; i++)
        {
            if (_isReplaced[i])
            {
                verse += "_ ";
            }
            else
            {
                verse += _words[i] + " ";
            }
        }

        return verse;
    }

        public List<bool> Replace
    {
        get
        {
            return _isReplaced;
        }
    }
}

class WordReplacer
{
    private readonly Verse _verse;
    private readonly Random _random;

    public WordReplacer(Verse verse)
    {
        _verse = verse;
        _random = new Random();
    }

    public void ReplaceRandomWord()
    {
        int wordIndex = _random.Next(0, _verse.Words.Length);

        while (_verse.Replace[wordIndex] == true)
        {
            wordIndex = _random.Next(0, _verse.Words.Length);
        }

        _verse.ReplaceWord(wordIndex);
    }
}
