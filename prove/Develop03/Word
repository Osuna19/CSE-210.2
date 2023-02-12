public class Word{

    private Scripture _word;
    private Random _random;

    public Word(Scripture word){
        _word = word;
        _random = new Random();
    }

    public void replaceWord(){
        int wordNumber = _random.Next(0, _word.Words.Length);

        while (_word.Replace[wordNumber] == true){
            wordNumber = _random.Next(0, _word.Words.Length);
        }

        _word.ReplaceWord(wordNumber);

    }

}