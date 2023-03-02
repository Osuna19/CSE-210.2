using System;

class Program
{
    static void Main(string[] args)
    {

        var employees = new List<Employee>();

        var salary = new Employee();
        var hourly = new HourlyEmployee();
        var exec = new Executive();

        employees.Add(salary);
        employees.Add(hourly);
        employees.Add(exec);

        foreach (var e in employees) {
            e.CalculatePay();
        }

        // Console.WriteLine(salary.CalculatePay());
        // Console.WriteLine(hourly.CalculatePay());
    }
}

class Employee {

    protected int Salary = 100000;
    virtual public int CalculatePay() {
        return Salary; 
    }
}

abstract class Person {
    abstract public string Speak();

}

class NicePerson : Person
{
    public override string Speak()
    {
        return "Hello baby.";
    }
}

class MeanPerson : Person
{
    public override string Speak()
    {
        return "Ay chiquita.";
    }
}

class Executive: Employee {

    private int bonus = 1000000000;
    public override int CalculatePay()
    {
        return Salary + bonus;
    }
}

class HourlyEmployee: Employee {

    private int HourlyWaige = 25;
    private int HoursPerYear = 2000;
    public override int CalculatePay()
    {
        return HourlyWaige * HoursPerYear;
    }
}