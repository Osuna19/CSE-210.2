using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {        
       // Person personOne = new Person();
       // personOne._firstName = "Pepe";
       // personOne._lastName = "Skywalker";

       // personOne.printName();
        
        Job job1 = new Job();
        job1._company = "Soriana";
        job1._jobTitle = "Cerillito";
        job1._startYear = 2014;
        job1._endYear = 2024;
        
        Job job2 = new Job();
        job2._company = "HM";
        job2._jobTitle = "Nails beauty";
        job2._startYear = 2021;
        job2._endYear = 2028;

        Resume resumeOne = new Resume();
        resumeOne._name = "Pepe Guzman";

        resumeOne._jobs.Add(job1);
        resumeOne._jobs.Add(job2);

        resumeOne.printJob();
    }
}

class Job
    {
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;

        public void printJob()
        {
            Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} {_endYear}");
        }

    }
    class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();

        public void printJob()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine("Jobs: ");

         foreach (Job job in _jobs)
          {
            job.printJob();
          }
        }
    }

    

/*
    class Person
{
    public string _firstName;
    public string _lastName;

    public void printName() 
    {
        Console.WriteLine($"Name: {_firstName} {_lastName}");
    }


}
*/
