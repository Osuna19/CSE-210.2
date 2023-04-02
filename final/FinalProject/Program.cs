using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> animation = new List<string>();
        animation = new List<string>();
        animation.Add("|");
        animation.Add("\\");
        animation.Add("-");
        animation.Add("/");
        animation.Add("|");
        animation.Add("\\");
        animation.Add("-");

        

        // The card number is: 1234567890
        // The PIN is: 9393
        // for both cards the info is the same

        // Console.WriteLine("Holi");
    
        // CreditCard card = new CreditCard(9393, 1234567890);

        CardHolder Ian = null;

        Console.WriteLine("Welcome to your personal ATM!");
        for (int i = 0; i < animation.Count; i++){
        Console.Write(animation[i]);
        Thread.Sleep(500);
        Console.Write("\b \b");
        }
        Console.Clear();

        Console.WriteLine("Please, especified wich account you want to acces...");
        Console.WriteLine("");
        Console.WriteLine("DEBIT CARD / CREDIT CARD");
        string CreditOrDebit = Console.ReadLine();
        Console.WriteLine("");

        if (CreditOrDebit == "debit" || CreditOrDebit == "Debit" || CreditOrDebit == "DEBIT" || CreditOrDebit == "d" || CreditOrDebit == "D")
        {
            CreditOrDebit = "Debit";
            DebitCard card = new DebitCard(9393, 1234567890);
            Ian = new CardHolder(100, card);

            while(true)
        {
            Console.WriteLine("Choose an option from the menu:");
            Console.WriteLine("1. Deposit...");
            Console.WriteLine("2. Withdraw...");
            Console.WriteLine("3. Show Balance...");
            Console.WriteLine("4. Log out...");
            Console.Write("Select an option from the menu: ");
            string choice = Console.ReadLine();

            for (int i = 0; i < animation.Count; i++){
            Console.Write(animation[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            }
            Console.Clear();

            if (choice == "1")
            {
                Console.Write("Insert your Debit Card number: ");
                int cardNumber = int.Parse(Console.ReadLine());
                Console.Write("Insert your PIN number: ");
                int PIN = int.Parse(Console.ReadLine());
                Console.Write("Hom much would you deposit? ");
                int ammount = int.Parse(Console.ReadLine());

                Ian.Deposit(cardNumber, PIN, ammount);
                Console.Clear();
                // Console.WriteLine(Ian.GetBalance());
                
            }

            if (choice == "2")
            {
                Console.Write($"Insert your {CreditOrDebit} Card number: ");
                int cardNumber = int.Parse(Console.ReadLine());
                Console.Write("Insert your PIN number: ");
                int PIN = int.Parse(Console.ReadLine());
                Console.Write("Hom much would you withdraw? ");
                int ammount = int.Parse(Console.ReadLine());

                Ian.Withdraw(cardNumber, PIN, ammount);
                Console.WriteLine(Ian.GetBalance());
                
            }

            if (choice == "3")
            {
                Ian.ShowBalance();
                Console.WriteLine("");
            }
            
            if (choice == "4")
            {
                Console.WriteLine("Thanks for choosing personal ATM. Good Bye :))");
                break;
            }

        }
        }

        if (CreditOrDebit == "credit" || CreditOrDebit == "c" || CreditOrDebit == "Credit" || CreditOrDebit == "C" || CreditOrDebit == "CREDIT")
        {
            CreditOrDebit = "Credit";
            CreditCard card = new CreditCard(9393, 1234567890);
            Ian = new CardHolder(500, card);

            while(true)
        {
            Console.WriteLine("Choose an option from the menu:");
            Console.WriteLine("1. Deposit...");
            Console.WriteLine("2. Withdraw...");
            Console.WriteLine("3. Show Balance...");
            Console.WriteLine("4. Log out...");
            Console.WriteLine("Select an option from the menu: ");
            string choice = Console.ReadLine();

            for (int i = 0; i < animation.Count; i++){
            Console.Write(animation[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            }
            Console.Clear();

            if (choice == "1")
            {
                Console.Write("Insert your Credit Card number: ");
                int cardNumber = int.Parse(Console.ReadLine());
                Console.Write("Insert your PIN number: ");
                int PIN = int.Parse(Console.ReadLine());
                Console.Write("Hom much would you deposit? ");
                int ammount = int.Parse(Console.ReadLine());

                Ian.Deposit(cardNumber, PIN, ammount);
                Console.Clear();
                // Console.WriteLine(Ian.GetBalance());
                
            }

            if (choice == "2")
            {
                Console.Write($"Insert your {CreditOrDebit} Card number: ");
                int cardNumber = int.Parse(Console.ReadLine());
                Console.Write("Insert your PIN number: ");
                int PIN = int.Parse(Console.ReadLine());

                Console.Write("The user can withdraw more money because of his credit history... ");
                Console.WriteLine("Credit money: " + 250);
                Console.WriteLine("How much will you withdraw from your card? ");
                int ammount = int.Parse(Console.ReadLine());

                // Ian.GetBalance() + Ian.GetMaxTransaction();
                Ian.Withdraw(cardNumber, PIN, ammount);
                Console.Clear();
                // Console.WriteLine(Ian.GetBalance());
                
            }

            if (choice == "3")
            {
                Console.WriteLine("");
                Ian.ShowBalance();
                Console.WriteLine("");
            }
            
            if (choice == "4")
            {
                Console.WriteLine("Thanks for choosing personal ATM. Good Bye :))");
                break;
            }

        }
        }

        if (Ian == null)    
        {
            Console.WriteLine("Invalid option");
            return; // exit the program
        }
    }
}

class CardHolder
{
    private int _balance;
    private Card _card;

    public CardHolder(int balance, Card card)
    {
        _balance = balance;
        _card = card;
    }

    public int GetBalance()
    {
        return _balance;
    }

    public void Deposit(int cardNumber, int PIN, int ammount)
    {

        if (_card.AuthorizeUser(cardNumber, PIN))
        {
            _balance += ammount;

        }
    }

    public void Withdraw(int cardNumber, int PIN, int ammount)
    {
        if (_card.AuthorizeUser(cardNumber, PIN))
        {
            if (_card is CreditCard)
            {
                _balance += ((CreditCard)_card).GetMaxTransaction();
            }
            _balance -= ammount;
            
        }
    }

    public void ShowBalance()
    {
        if (_card is CreditCard)
            {
                int totalCredit = _balance + ((CreditCard)_card).GetMaxTransaction();
                Console.WriteLine($"Your balance: {totalCredit}");
            }
            
        if (_card is DebitCard)
        {
            Console.WriteLine($"Your balance: {_balance}");
        }
    }
}

class Card 
{
    private int _PIN;
    private int _cardNumber;

    public Card(int PIN, int cardNumber)
    {
        _PIN = PIN;
        _cardNumber = cardNumber;
    }

    public bool AuthorizeUser(int cardNumber, int PIN)
    {
        if (_cardNumber == cardNumber && _PIN == PIN)
        {
            return true;
        }
        else { Console.WriteLine("Your information does not match");
        return false; }
    }

    public virtual int GetMaxTransaction()
    {
        return 0;
    }


}

class CreditCard : Card
{   
    public CreditCard(int PIN, int cardNumber) : base(PIN, cardNumber)
    {

    }

    public override int GetMaxTransaction()
    {
        return 250;
    }
}


class DebitCard : Card
{
    public DebitCard(int PIN, int cardNumber) : base(PIN, cardNumber)
    {

    }

    public override int GetMaxTransaction()
    {
        return base.GetMaxTransaction();
    }

}
