class Program
{
    static void Main(string[] args)
    {
        Assignment info = new Assignment("Osuna Ramirez", "Multiplication");
        Console.WriteLine(info.getSummary());

        MathAssignment info2 = new MathAssignment("Don Julion", "Linear inequalities", "3.4", "12-19");
        Console.WriteLine(info2.getSummary());
        Console.WriteLine(info2.getHomework());

        WritingAssignment info3 = new WritingAssignment("Juan el luchador", "Basic writting", "Commas");
        Console.WriteLine(info3.getSummary());
        Console.WriteLine(info3.getInformation());
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

        public string getSummary(){
            return _studentName + " - " + _topic;
        }
    }

    class MathAssignment: Assignment {
        private string _textBookSection;
        private string _problems; 
        
        public MathAssignment(string name, string topic, string textBook, string problems): base(name, topic) {
            _textBookSection = textBook;
            _problems = problems;
        }
        public string getHomework() {
            return $"Section {_textBookSection} Problems {_problems}"; 
        }
    }

class WritingAssignment: Assignment {
    private string _title;

    public WritingAssignment(string name, string topic, string title): base(name, topic) {
        _title = title;
    }

    public string getInformation() {
        string studentName = getName();
        return $"{_title} by {studentName}";
    }

}