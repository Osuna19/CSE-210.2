using System;

class Program
{
    static void Main(string[] args)
    {
        while (true) {

        
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Opinion :)");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string x = Console.ReadLine();
            if (x == "1"){
                BreathingActivity one = new BreathingActivity();
                Console.Clear();
                one.Start();
            }

            if (x == "2"){
                ReflectionActivity two = new ReflectionActivity();
                Console.Clear();
                two.Start();
            }

            if (x == "3"){
                ListingActivity three = new ListingActivity();
                Console.Clear();
                three.Start();

            }

            if (x == "4"){
                Opinion four = new Opinion();
                Console.Clear();
                four.Start();
            }

            if (x == "5"){
                break;
            }
        }
    }
}

class Activity{
    private string _endMessage;
    protected List<string> _animation;
    public int duration;


    public Activity(){
        _animation = new List<string>();
        _animation.Add("|");
        _animation.Add("\\");
        _animation.Add("-");
        _animation.Add("/");
        _animation.Add("|");
        _animation.Add("\\");
        _animation.Add("-");

        _endMessage = "Well done!!";
    }

    public List<string> getAnimation(){
        return _animation; 
    }


    public void Run(){
        Console.Clear();
        Console.WriteLine("Get Ready...");

        for (int i = 0; i < _animation.Count; i++){
        Console.Write(_animation[i]);
        Thread.Sleep(500);
        Console.Write("\b \b");
        }
        // return;
    }


    public void EndMessage(){

        Console.WriteLine(_endMessage);
        for (int i = 0; i < _animation.Count; i++){
        Console.Write(_animation[i]);
        Thread.Sleep(1000);
        Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    public void Seconds(){
        Console.Write("How long, in seconds, would you like for your session? ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    }



    public void animationRun(){
        for (int i = 0; i < _animation.Count; i++){
        Console.Write(_animation[i]);
        Thread.Sleep(1000);
        Console.Write("\b \b");
        }
    }


}

class BreathingActivity : Activity{
    private string _name;
    private string _startingMessage;
    public BreathingActivity(): base() {
        _name = "Breathing Activity";
        _startingMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Start(){
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine($"{_startingMessage}");
        Console.WriteLine();
        // Activity seconds = new Activity();
        // seconds.Seconds();
        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Activity activity = new Activity();
        activity.Run();

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime){
        Console.Write("Breathe in...");
        for (int j = 4; j > 0; j--){
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");            
        }
        Console.WriteLine();
        Console.Write("Breathe out...");
        for (int j = 4; j > 0; j--){
            Console.Write(j);
            Thread.Sleep(1000);
            Console.Write("\b \b");           
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    // endMessage
    Activity endMessage = new Activity();
    endMessage.EndMessage();
    Console.WriteLine($"You have completed another {duration} seconds of the {_name}");
    animationRun();
    Console.Clear();
    }
}

class ListingActivity : Activity
{
        private string _name;
        private string _startingMessage;
        private Random _random;
        private List<string> _prompts;
        private int _itemCount;

        public ListingActivity() : base()
        {
            _name = "Listing Activity";
            _startingMessage = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
            _random = new Random();
            _prompts = new List<string>()
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public void Start()
        {
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine($"{_startingMessage}");
            Console.WriteLine();
            // Countdown timer for thinking about the prompt
            Console.Write("How long, in seconds, would you like for your session? ");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            // Activity seconds = new Activity();
            // seconds.Seconds();
            Activity activity = new Activity();
            activity.Run();

            // Select a random prompt from the list
            Console.WriteLine();
            Console.WriteLine("List as many responses you can to the following propmt:");
            int index = _random.Next(_prompts.Count);
            string prompt = _prompts[index];
            Console.WriteLine($"--- {prompt} ---");
            Console.Write("You may begin in: ");
            for (int j = 4; j > 0; j--){
                Console.Write(j);
                Thread.Sleep(1000);
                Console.Write("\b \b");  
            }
            Console.WriteLine();

        bool timeIsUp = false;
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (!timeIsUp && DateTime.Now < endTime){
            Console.Write("> ");
            string input = Console.ReadLine();

                _itemCount++;
            timeIsUp = DateTime.Now >= endTime;
        }
            Console.WriteLine($"You listed {_itemCount} items.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Activity endMessage = new Activity();
            endMessage.EndMessage();

            Console.WriteLine($"You have completed another {duration} seconds of the {_name}");
            animationRun();
            Console.Clear();
        }
 
    }



class ReflectionActivity : Activity{
    private string _name;
    private string _startingMessage;
    private Random _random;
    private List<string> _reflectQuestions;
    private List<string> _reflectMessage;


    public ReflectionActivity(): base() {
        _name = "Reflection Activity";
        _startingMessage = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _random = new Random();

        _reflectMessage = new List<string>() {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
        };

        _reflectQuestions = new List<string>() {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };
    }

    public string getRefelctQuestions(){
        int index = _random.Next(_reflectQuestions.Count);
        return _reflectQuestions[index];

    }

    public string getReflectMessages() {
        int index2 = _random.Next(_reflectMessage.Count);
        return _reflectMessage[index2];
    }

    public void Start(){
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine($"{_startingMessage}");
            Console.WriteLine();
            // Countdown timer for thinking about the prompt
            Console.Write("How long, in seconds, would you like for your session? ");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            // Activity seconds = new Activity();
            // seconds.Seconds();
            Activity activity = new Activity();
            activity.Run();


            Console.WriteLine( "Consider the following prompt: ");
            int index = _random.Next(_reflectMessage.Count);
            string prompt = _reflectMessage[index];
            Console.WriteLine();
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            for (int j = 4; j > 0; j--){
                Console.Write(j);
                Thread.Sleep(1000);
                Console.Write("\b \b");  
            }
            Console.Clear();

            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime){
                int index2 = _random.Next(_reflectQuestions.Count);
                string prompt2 = _reflectQuestions[index2];
                Console.Write($"> {prompt2} ");
                Activity animation = new Activity();
                animation.animationRun();
                Console.WriteLine();
            }
            Console.WriteLine();

            // endMessage
            Activity endMessage = new Activity();
            endMessage.EndMessage();
            Console.WriteLine($"You have completed another {duration} seconds of the {_name}");
            animationRun();
            Console.Clear();



    }
}

class Opinion : Activity {

    private List<string> _activities;

    public Opinion() : base(){
        _activities = new List<string>() {
            "Breathing Activity",
            "Reflection Activity",
            "Listing Activity"
        };


    }

    public void Start() {
         Console.WriteLine("From all this activities, which one of the following was your favorite?");
        
        for (int i = 0; i < _activities.Count; i++) {
        Console.WriteLine($"{i + 1}. {_activities[i]}");
        }   
        string answer = Console.ReadLine();
        if (answer == "Breathing activity" || answer == "breathing activity") {
            Console.WriteLine("Why do yo selected the breathing activity?");
            Console.WriteLine("> ");
            Console.ReadLine();
            Console.WriteLine("Do you feel stressed?");
            animationRun();
            Console.WriteLine("Answer with yes or no.");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "yes" || yesOrNo == "y"){ Console.WriteLine("You should consider go to the gym!");}

            if (yesOrNo == "no" || yesOrNo == "no"){ 
                Console.WriteLine("What is your secret to don't feel stressed?");
                Console.ReadLine();
                Console.WriteLine("That makes sense.");
                } else {
                    Console.WriteLine("You didn't answer my question!");
                }

            if (answer == "Reflection activity" || answer == "reflection activity") {
                Console.WriteLine("Does this activity makes you reflect? Just think.");
                animationRun();
        }
            if (answer == "Listing Activity" || answer == "listing activity") {
                Console.WriteLine("Do you think listing our thoughts is an important thing?");
                Console.ReadLine();
                Console.WriteLine("I believe it helps us to know when we felt happiness or sadness. It is a good thing to remember our experiences.");
            }

            Console.WriteLine("Thanks for your opinion!");
            animationRun();

        }

    }
}
   
