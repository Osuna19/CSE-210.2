using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true) {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");

            string x = Console.ReadLine();
            if (x == "1"){
                BreathingActivity one = new BreathingActivity();
                Console.Clear();
                one.Start();
            }

            if (x == "2"){
                // ReflectionActivity two = new ReflectionActivity();
                Console.Clear();
                // two.Start();
            }

            if (x == "3"){
                ListingActivity three = new ListingActivity();
                Console.Clear();
                three.Start();
            }

            if (x == "4"){
                break;
            }

            else {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}

class Activity{
    protected string _startingMessage;
    protected string _endMessage;
    protected List<string> _animation;

    public Activity(){
        _animation = new List<string>();
        _animation.Add("|");
        _animation.Add("\\");
        _animation.Add("-");
        _animation.Add("/");
        _animation.Add("|");
        _animation.Add("\\");
        _animation.Add("-");
    }

    public virtual void Start(){
        Console.WriteLine("Starting activity...");
    }
}

class BreathingActivity : Activity{
    private string _name;
    private int _duration;

    public BreathingActivity() : base(){
        _name = "Breathing Activity";
        _startingMessage = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _endMessage = "Well done!";
    }

    public override void Start(){
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine($"{_startingMessage}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        Console.WriteLine("Get Ready...");
        Thread.Sleep(2000);

        for (int i = 1; i <= _duration; i++) {
            Console.WriteLine($"Inhale ({i}/{_duration})");
            for (int j = 4; j > 0; j--) {
                Console.Write($"{j}...");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Exhale");
            Thread.Sleep(1000);
        }

        Console.WriteLine(_endMessage);
    }
}

class ListingActivity : Activity{
    private Random _random;
    private int _countDown;
    private List<string> _prompts;

    public ListingActivity(): base() {
        _random = new Random();
        _prompts = new List<string>() {
            "List your favorite movies",
            "List your goals for the next year",
            "List your favorite foods",
            "List your dream travel destinations",
            "List your favorite books",
            "List your favorite hobbies",
            "List things you are grateful for"
        };
    }

    public override void Start() {}
}
       
