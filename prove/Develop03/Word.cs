public class Word{

private readonly Scripture _word;
    private readonly Random _random;

    public Word(Scripture word)
    {
        _word = word;
        _random = new Random();
    }

    public void ReplaceRandomWord()
    {
        int wordNumber;
        do
        {
            wordNumber = _random.Next(0, _word.Words.Length);
        } while (_word.Replace[wordNumber]);

        _word.ReplaceWord(wordNumber);
        

    }

}