using System;
using System.Collections.Generic;
using System.IO;

namespace Develop02
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.displayMenu();
        }
    }

    class Menu
    {
        public Journal journal = new Journal();

        public void displayMenu()
        {
            bool displayMenu = true;
            while (displayMenu)
            {
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Save");
                Console.WriteLine("4. Load");
                Console.WriteLine("5. Exit");
                Console.Write("What would you like to do? ");

                int option = int.Parse(Console.ReadLine());
                
                if (option == 1)
                {

                    var prompts = new List<String> 
                    { "Who was the most interesting person I interacted with today?", "Tell us a secret", "What was the worst part of the day?", 
                    "What is the next type of music you will listen to?", "Is there wa something that get you mad today?"};   
                    var rdm = new Random();
                    var randomIndex = rdm.Next(prompts.Count);
        
                    Console.WriteLine(prompts[randomIndex]);
                    Console.Write("Write on your Journal: ");
                    string text = Console.ReadLine();
                    DateTime currentDate = DateTime.Now;
                    journal.AddEntry(text, currentDate);
                    Console.WriteLine();
                }
                else if (option == 2)
                {
                    journal.displayEntries();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Enter a file name to save: ");
                    string fileName = Console.ReadLine();
                    journal.save(fileName);
                }
                else if (option == 4)
                {
                    Console.WriteLine("write the file name to load: ");
                    string fileName = Console.ReadLine();
                    journal.Load(fileName);
                }
                else if (option == 5)
                {
                    displayMenu = false;
                }
                else 
                {
                    Console.WriteLine("Select a valid option.");
                }
            }
        }
    }

    class Journal
    {

        public void save(string fileName){
            using (var file = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    file.WriteLine(entry.Date.ToString());
                    file.WriteLine(entry.Text);
                }
            }
        }

        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
                    {
                        Console.WriteLine("File was not found. Try again.");
                    }
            else{

                using (var load = new StreamReader(fileName))
                    {
                        string date = load.ReadLine();
                        string text = load.ReadLine();
                    }
                }
        }
        public List<Entry> entries = new List<Entry>();
        public void AddEntry(string journalText, DateTime currentDate)
        {
            var entry = new Entry(DateTime.Now);
            entry.Text = journalText;
            entries.Add(entry);
        }

        public void displayEntries()
        {
            int i = 1; 
            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date.ToString()} - {entry.Text} ");
                Console.WriteLine("");
                i++;
            }
        }

    }

    class Entry
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }

            public Entry(DateTime date)
        {
            Date = date;
        }
         public Entry(string text)
        {
            Text = text;
        }
    }
}