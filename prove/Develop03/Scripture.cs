public class Scripture{
    private string _originalVerse;
    private string[]  _words;
    private bool[] _isReplaced;
    private Random _random;
    private Scripture verse;

    public Scripture(string verse)
    {
        _originalVerse = verse;
        _words = verse.Split(' ');
        _isReplaced = new bool[_words.Length];
        _random = new Random();
    }
    public Scripture(string originalVerse, string[] words, bool[] isReplaced) : this(originalVerse)
    {
        _words = words;
        _isReplaced = isReplaced;
    }

    public Scripture(Scripture verse)
    {
        this.verse = verse;
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

    public void ReplaceWord(int number)
    {
        _words[number] = _originalVerse.Split(' ')[number];
        _isReplaced[number] = true;
    }

    public override string ToString()
    {
          string verse = "";

         for (int i = 0; i < _words.Length; i++)
        {                
            
            if (_isReplaced[i])
              {
                 verse += new string('_', _words[i].Length) + " ";
              }
              else
              {
                    verse += _words[i] + ' '; 
              }
        }

        return verse;
    }
        public bool[] Replace
    {
        get
        {
            return _isReplaced;
        }
    }
}
