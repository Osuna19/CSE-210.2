
class Files {
    string filename = "goals.txt";
    public void Save(List<Goal> goals, int totalPoints) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            // Write the total points to the file
            writer.WriteLine(totalPoints);

            // Write each goal to the file
            foreach (Goal goal in goals) {
                writer.WriteLine($"{goal.GetType().Name},{goal.NameOfGoal},{goal.Description},{goal.AmountOfPoints},{goal.BonusPoints},{goal.GetTimes},{goal.ThePoints},{goal.IsComplete()}");
            }
        }
    }
    public (List<Goal>, int) Load() {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;

        if (!File.Exists("goals.txt")) {
            return (goals, totalPoints);
        }

        using (StreamReader reader = new StreamReader("goals.txt")) {
            // Read the total points from the file
            string line = reader.ReadLine();
            if (!int.TryParse(line, out totalPoints)) {
                Console.WriteLine("Invalid file. Unable to load total points.");
                return (goals, totalPoints);
            }

            // Read each goal from the file
            while ((line = reader.ReadLine()) != null) {
                string[] fields = line.Split(',');

                if (fields.Length != 8) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                string goalType = fields[0];
                string nameOfGoal = fields[1];
                string description = fields[2];
                int amountOfPoints = 0;
                int bonusPoints = 0;
                int times = 0;
                int thePoints = 0;
                bool isComplete = false;
                
                if (!int.TryParse(fields[3], out amountOfPoints)) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                if (!int.TryParse(fields[4], out bonusPoints)) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                if (!int.TryParse(fields[5], out times)) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                if (!int.TryParse(fields[6], out thePoints)) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                if (!bool.TryParse(fields[7], out isComplete)) {
                    Console.WriteLine($"Invalid file. Unable to load goal: {line}");
                    break;
                }

                Goal goal;
                switch (goalType) {
                    case "SimpleGoal":
                        goal = new SimpleGoal(nameOfGoal, description, amountOfPoints, bonusPoints);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(nameOfGoal, description, amountOfPoints, bonusPoints);
                        break;
                    case "ChecklistGoal":
                        goal = new ChecklistGoal(nameOfGoal, description, amountOfPoints, bonusPoints, times);
                        ((ChecklistGoal)goal).ThePoints = thePoints;
                        ((ChecklistGoal)goal).RecordGoal();
                        ((ChecklistGoal)goal).RecordPoints();
                        break;
                    default:
                        Console.WriteLine($"Invalid file. Unknown goal type: {goalType}");
                        continue;
                }
                
                if (isComplete) {
                    goal.MarkCompleted();
                }
                    
                goals.Add(goal);
            }
        } 
        return (goals, totalPoints);
    }
}
