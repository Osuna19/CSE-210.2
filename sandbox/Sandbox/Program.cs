class Program
{
    static void Main(string[] args)
    {
        var p = new Person();
        var s = new Student();

        Console.WriteLine(p.getName());
        Console.WriteLine(s.getName());
    }
}

// Super Class
class Person{
    public string getName(){
        return "Osuna";
    }

}


// Sub class
class Student: Person {

}