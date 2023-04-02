using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> myList = new List<string>();
        myList.Add("apple");
        myList.Add("banana");
        myList.Add("cherry");

        foreach (string item in myList)
        {
            Console.WriteLine(item);
        }
    
    }
    

}
