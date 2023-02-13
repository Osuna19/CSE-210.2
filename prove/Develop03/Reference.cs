public class Reference{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endverse;

    public Reference(){
        _book = "Moses";
       _chapter = 1;
       _startVerse = 49;
       _endverse  = 50;
    }


    public Reference(string book, int chapter, int start){
       _book = book;
       _chapter = chapter;
       _startVerse = start;


    }

    public Reference(string book, int chapter, int start, int end){
        _book = book;
        _chapter = chapter;
        _startVerse = start;
        _endverse = end;
    }        

    public string getReference(){
        string reference = $"{_book} {_chapter}:{_startVerse} ";
        return reference; 
    }
}