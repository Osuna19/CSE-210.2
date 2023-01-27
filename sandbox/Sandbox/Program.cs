using System;
using System.Collections.Generic;

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
        private Journal journal = new Journal();

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
                Console.WriteLine("What would you like to do?");

                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    string randomPrompt(){
                    var prompts = new List<String> { "how are you feeling?", "Tell us a secret", "How doy you with the homework?"};   
                    var rdm = new Random();
                    var randomIndex = rdm.Next(prompts.Count());
                    var randomPrompt = prompts[randomIndex];

                    return randomPrompt;

        }
                    Console.Write("Write on your Journal: ");
                    string text = Console.ReadLine();
                    journal.AddEntry(text);
                }
                else if (option == 2)
                {
                    journal.displayEntries();
                }
                else if (option == 5)
                {
                    displayMenu = false;
                }
                else 
                {
                    Console.WriteLine("Select the correct option.");
                }
            }
        }
    }

    class Journal
    {


        private List<Entry> entries = new List<Entry>();
        public void AddEntry(string journalText)
        {
            var entry = new Entry();
            entry.Text = journalText;
            entries.Add(entry);
        }

        public void displayEntries()
        {
            int i = 1; 
            foreach (var entry in entries)
            {
                Console.WriteLine($"{entry.Text}");
                i++;
            }
        }

    }

    class Entry
    {
        public string Text {get; set;}

    }
}

