using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       Menu menu = new Menu();
    }
}

class Menu {
    List<Goal> goals = new List<Goal>();
    public Files myFile = new Files();
    public Menu(){
        int totalPoints = GetThePoints(goals);
         while (true) // infinite loop
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("1. Simple Goal.");
                Console.WriteLine("2. Eternal Goal.");
                Console.WriteLine("3. Checklist Goal.");
                Console.Write("Which type of goal would you like to create? ");
                string goal = Console.ReadLine();
                string nameOfGoal;
                string description;
                int amountOfPoints;
                int bonusPoints;

                Console.Write("What is the name of your goal? ");
                nameOfGoal = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string inputPoints = Console.ReadLine();
                if (!int.TryParse(inputPoints, out amountOfPoints))
                {
                    Console.WriteLine("Invalid input. Please enter a valid value.");
                    continue;
                }
                else
                {
                    bonusPoints = 0;
                }

                if (goal == "1") {
                    SimpleGoal simple = new SimpleGoal(nameOfGoal, description, amountOfPoints, bonusPoints);
                    goals.Add(simple);
                }

                if (goal == "2") {
                    EternalGoal eternal = new EternalGoal(nameOfGoal, description, amountOfPoints, bonusPoints);
                    goals.Add(eternal);
                }

                if (goal == "3")
                {
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    string times = Console.ReadLine();
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    string bonus = Console.ReadLine();
                    if (!int.TryParse(bonus, out bonusPoints))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid value.");
                        continue;
                    }
                    ChecklistGoal checklistGoal = new ChecklistGoal(nameOfGoal, description, amountOfPoints, bonusPoints, int.Parse(times));
                    goals.Add(checklistGoal); 
                }
            } 

            else if (choice == "2")
            {
                Console.WriteLine("The goals are:");
                int points = 0; 
                for (int i = 0; i < goals.Count; i++) {
                    if (goals[i] is EternalGoal eternalGoal) {
                        Console.WriteLine($"{i+1}. [ ] {goals[i].NameOfGoal} ({goals[i].Description})");   
                    }
                    else if (goals[i].IsComplete()) {
                        Console.WriteLine($"{i+1}. [X] {goals[i].NameOfGoal} ({goals[i].Description})");
                    }
                    else if (goals[i] is ChecklistGoal checklistGoal) {
                        Console.WriteLine($"{i+1}. {checklistGoal.ToString()}");
                    }
                    else {
                        Console.WriteLine($"{i+1}. [ ] {goals[i].NameOfGoal} ({goals[i].Description})");
                    }
                    points += goals[i].AmountOfPoints;
                }

                // Code to list goals
            } 
            else if (choice == "3")
            {
                    Console.WriteLine("Enter a file name to save: ");
                    string fileName = Console.ReadLine();
                    myFile.Save(goals, totalPoints);
                    Console.WriteLine($"Data saved to file: {fileName}");

            } 
            else if (choice == "4")
            {
                    Console.WriteLine("write the file name to load: ");
                    // string fileName = Console.ReadLine();
                    Files files = new Files();
                    (List<Goal> goals, totalPoints) = files.Load();
                     foreach (Goal goal in goals) {
                        Console.WriteLine();
                        Console.WriteLine($"Goal: {goal.NameOfGoal}");
                        Console.WriteLine($"Description: {goal.Description}");
                        Console.WriteLine($"Points: {goal.AmountOfPoints}");
                        Console.WriteLine($"Bonus Points: {goal.BonusPoints}");
                        Console.WriteLine($"Times: {goal.GetTimes}");
                        Console.WriteLine($"The Points: {goal.ThePoints}");
                        Console.WriteLine($"Is Complete: {goal.IsComplete()}");
                    }
            } 
                else if (choice == "5")
                {
                    Console.WriteLine("The goals are:");
                    for (int i = 0; i < goals.Count; i++) {
                        Console.WriteLine($"{i+1}. {goals[i].NameOfGoal}");
                    }
                    Console.Write("Which goal did you accomplish? ");
                    if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= goals.Count)
                    {
                        // int points = 0; 
                        Goal completedGoal = goals[goalNumber - 1];
                            if (completedGoal.IsComplete())
                            {
                                Console.WriteLine("This goal has already been completed.");
                            }
                            else 
                            {
                                if (completedGoal is ChecklistGoal) {                               
                                ChecklistGoal checklistGoal = (ChecklistGoal)completedGoal;
                                checklistGoal.RecordPoints();
                                totalPoints += checklistGoal.ThePoints;
                                if (checklistGoal.IsComplete())
                                    {
                                        checklistGoal.RecordPoints();
                                        totalPoints += checklistGoal.ThePoints;  
                                    }
                                       
                                }   
                            else
                            {
                                completedGoal.MarkCompleted();
                                int points = completedGoal.AmountOfPoints;
                                totalPoints += points;
                                if (completedGoal.IsComplete())
                                {
                                // completedGoal.RecordBonusPoints();
                                totalPoints += completedGoal.BonusPoints;
                                }
                        }
                    } 
                }
                else 
                { 
                    Console.WriteLine("Invalid Value. Please enter a valid number."); 
                }
                // Code to record event
            } 
            else if (choice == "6")
            {
                break; // exit the loop and terminate the program
            }
            else 
            {
                Console.WriteLine("Invalid choice. Please select again other choice.");
            }
            
            Console.WriteLine();
            Console.Write("Your points are: ");
            Console.WriteLine($"{totalPoints}");
            Console.WriteLine();
        }
    }

                  static int GetThePoints(List<Goal> goals) {
                int totalPoints = 0;
                for (int i = 0; i < goals.Count; i++) {
                    totalPoints += goals[i].AmountOfPoints;
                }
                return totalPoints;
            }
}

abstract class Goal {
    protected string _nameOfGoal;
    protected string _description;
    protected int _amountOfPoints;
    // For the total points that are always display after each selection of the menu.
    protected int _bonusPoints = 0;
    protected int CurrentPoints { get; set; }
    protected int _times { get; set; }
    

    public Goal(string nameOfGoal, string description, int amountOfPoints, int bonusPoints) {
        _nameOfGoal = nameOfGoal;
        _description = description;
        _amountOfPoints = amountOfPoints;
        _bonusPoints = bonusPoints;
        
    }

    public string NameOfGoal {
        get { return _nameOfGoal; }
    }

    public string Description {
        get { return _description; }
    }

    public int AmountOfPoints {
        get { return _amountOfPoints; }
    }

    public int BonusPoints {
        get { return _bonusPoints; }
    }

    public int GetTimes { get { return _times; } }

    public int ThePoints { get { return CurrentPoints; } }

    public abstract bool IsComplete();
    public abstract bool MarkCompleted();

}

class SimpleGoal : Goal {
    private bool _isCompleted;
    public SimpleGoal(string nameOfGoal, string description, int amountOfPoints, int bonusPoints) : base(nameOfGoal, description, amountOfPoints, bonusPoints){
     }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override bool MarkCompleted()
    {
        return _isCompleted = true;
    }

}

class EternalGoal : Goal{
    private bool _isCompleted;
    public EternalGoal(string nameOfGoal, string description, int amountOfPoints, int bonusPoints) : base(nameOfGoal, description, amountOfPoints, bonusPoints){
        _isCompleted = false;
    }
    public override bool IsComplete()
    {
        return _isCompleted;
    }

       public override bool MarkCompleted()
    {
        return _isCompleted = false;
    }
}


class ChecklistGoal : Goal{
    private int _completedTimes; 
    private bool _isCompleted;

    public ChecklistGoal(string nameOfGoal, string description, int amountOfPoints, int bonusPoints, int times) : base(nameOfGoal, description, amountOfPoints, bonusPoints){
        _times = times;
    }

    public int timesCompleted {
        get { return _completedTimes; }
        set { _completedTimes = value; }
    }
    public override bool IsComplete()
    {
        return _completedTimes >= _times;
    }

public override bool MarkCompleted()
    {
        if (!_isCompleted) {
            RecordGoal();
            if (_completedTimes == 1) {
                RecordBonusPoints(); 
            }
        }
        _isCompleted = IsComplete();
        if (_isCompleted){
            RecordBonusPoints();
            ThePoints = CurrentPoints + BonusPoints + AmountOfPoints;
        }
        else if(_completedTimes > 1) {
            ThePoints = BonusPoints;
        }
        else { ThePoints = AmountOfPoints + BonusPoints; }
        return _isCompleted;
        
    }

    public void RecordGoal() {
        _completedTimes++;
    }

    public void RecordBonusPoints() {
        CurrentPoints += BonusPoints;
    }


    public override string ToString()
    {
        string completedString = $"(complete {_completedTimes}/{_times} times)";
        string checkbox = _isCompleted ? "[X]" : "[ ]";
        return $"{checkbox} {_nameOfGoal} {completedString}";
    }

    
    public void RecordPoints() {
        if (IsComplete()){
            ThePoints = CurrentPoints + AmountOfPoints;
        }
        else { ThePoints = BonusPoints; }
        RecordGoal();
    }

    public new int ThePoints { get; set; }
}



    

