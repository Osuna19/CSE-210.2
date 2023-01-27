
using System;
using System.Collections.Generic;

class Program
{
    private static object randomPrompt;

    public Program()
    {
    }

    static void Main(string[] args)
    {

}
public class Journal
{

        List<Entry> entries = new List<Entry>();

    public string randomPrompt(){


    
        var prompts = new List<String> { "how are you feeling?", "Tell us a secret", "How doy you with the homework?"};   
        var rdm = new Random();
        var randomIndex = rdm.Next(prompts.Count());
        var randomPrompt = prompts[randomIndex];


            return randomPrompt;
        
            }
}

class Entry 
{
   public List<Entry> entries = new List<Entry>();
   private Journal journal;
   public Entry(){
    journal = new Journal();
   }
   public void AddEntry()
   {
        Console.WriteLine("1. Write");
        string text = Console.ReadLine();
       // journal.AddEntry(text);
   }

}
}
