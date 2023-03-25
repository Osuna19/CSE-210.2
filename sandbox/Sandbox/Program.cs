using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");
    }
}

public abstract class Account{
    public decimal Balance { get; protected set; }

    public virtual void Withdraw(int amount) {
        Console.WriteLine();
    }

    public virtual void Deposit(int amount){
        Console.WriteLine();
    }

}

public class SavingsAccount : Account {
    public SavingsAccount(int balance){
        Balance = balance;
    }

    public override void Withdraw(int amount) {
        if (Balance - amount >= 0)
        {
            Balance -= amount
            Console.WriteLine($"Withdrew {amount}. Balance is now {Balance}");
        }
        else { Console.WriteLine("Insufficient balance."); }
    }

}