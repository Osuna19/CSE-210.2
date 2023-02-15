class Program
{
    static void Main(string[] args)
    {

    }
}

// Super Class
class Assignment{
     private string _studentName;
     private string _topic;

    public Assignment(string studentName, string topic){
       _studentName = studentName;
       _topic = topic;

    }  

    public string getName(){
        return _studentName;
    }

    public string getTopic() {
        return _topic;
    }
}

class MathAssignment: Assignment {
    private string _textBookSection;
    private string _problems; 
    
    public MathAssignment(string name, string topic, string textBook, string problems): base(name, topic) {
        _textBookSection = textBook;
        _problems = problems;
    }
    public string getName() {

    }
}

class WritingAssignment: Assignment {

}