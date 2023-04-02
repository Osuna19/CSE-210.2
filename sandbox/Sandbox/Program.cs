using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DisplayMenu menu = new DisplayMenu();
        Console.WriteLine("Holi");
    }

}

class DisplayMenu
{
    string firstName;
    string lastName;
    int PIN;
    string cardNum;
    double balance;    
    public DisplayMenu()
    {
        DebitCard debit = new DebitCard(cardNum, PIN, firstName, lastName, balance);
        debit.DisplayCards();

        while (true)
        {
            Console.WriteLine("Choose an option from the menu:");
            Console.WriteLine("1. Deposit...");
            Console.WriteLine("2. Withdraw...");
            Console.WriteLine("3. Show Balance...");
            Console.WriteLine("4. Log out...");
            Console.WriteLine("Select an option from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Aqui va el deposito");
            }

            if (choice == "2")
            {
                Console.WriteLine("Aqui va el withdraw");
            }

            if (choice == "3")
            {
                Console.WriteLine("Aqui va el balance");
            }
            
            if (choice == "4")
            {
                break;
            }

        }
        
    }
}

abstract public class CardHolder
{
    protected string _cardNum;
    protected int _PIN;
    protected string _firstName;
    protected string _lastName;
    protected double _balance;

    public CardHolder(string cardNum, int PIN, string firstName, string lastName, double balance)
    {
        _cardNum = cardNum;
        _PIN = PIN;
        _firstName = firstName;
        _lastName = lastName;
        _balance = balance;
    }

    public string GetNum()
    {
        return _cardNum;
    }

    public int GetPIN() 
    {
        return _PIN;
    }

    public string GetfirstName()
    {
        return _firstName;
    }

    public string GetLastName()
    {
        return _lastName;
    }

    public double Getbalance()
    {
        return _balance;
    }

    public void setNum(string newCardNum)
    {
        _cardNum = newCardNum;
    }

    public void setPIN(int newPIN)
    {
        _PIN = newPIN;
    }

    public void setFirstName(string newFirstName)
    {
        _firstName = newFirstName;
    }

     public void setLastName(string newLastName)
    {
        _lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        _balance = newBalance;
    }

    public virtual void DisplayCards()
        {
        //     List<CardHolder> cardHolders = new List<CardHolder>();
        //     DebitCard card = new DebitCard("123456789098765", 6380, "nombre", "apellido", 748.32);
        //     cardHolders.Add(card);
        //     DebitCard card2 = new DebitCard("93939393939393", 2456, "nombre", "apellido", 245.32);
        //     cardHolders.Add(card2);
        //     DebitCard card3 = new DebitCard("83838838389298126", 5362, "nomre", "apellido", 92.22);
        //     cardHolders.Add(card3);

        //     List<CardHolder> creditHolders = new List<CardHolder>();
            
        //     CreditCard creditCard = new CreditCard("0564765432567898", 6530, "nombre", "apellido", 748.32);
        //     creditHolders.Add(creditCard);
        //     CreditCard creditCard2 = new CreditCard("6765434567890987", 5433, "nombre", "apellido", 245.32);
        //     creditHolders.Add(creditCard2);
        //     CreditCard creditCard3 = new CreditCard("3454345678909876", 0000, "nomre", "apellido", 92.22);
        //     creditHolders.Add(creditCard3);

        //     Console.WriteLine("Welcome to the SIMPLE ATM");
        //     //   for (int j = 4; j > 0; j--){
        //     //     Console.Write(j);
        //     //     Thread.Sleep(1000);
        //     //     Console.Write("\b \b");  
        //     // }
        //     Console.Clear();

        //     void Start()
        //     {
        //         Console.WriteLine("Please insert your Debit/Credit card: ");
        //         string user = "";
        //         CardHolder currentUser;

        //         while (true)
        // {
        //     try
        //     {
        //         user = Console.ReadLine();
        //         currentUser = cardHolders.FirstOrDefault(a => a.GetNum() == user);
        //         if (currentUser != null) { break; }
        //         else { Console.WriteLine("Card not recognized . Please try again"); }
        //     }
        //     catch 
        //     {
        //         Console.WriteLine("Invalid card number. Please try again.");
        //     }

        //     Console.WriteLine("Please enter your PIN from your account:");
        //     int userPIN = 0;
            
        //     while (true)
        //     {
        //         try
        //         {
        //             userPIN = int.Parse(Console.ReadLine());
        //             currentUser = cardHolders.FirstOrDefault(a => a.GetPIN() == userPIN);
        //             if (currentUser.GetPIN() == userPIN) { break; }
        //             else { Console.WriteLine("PIN Incorrect. Please try again"); }
        //         }
        //         catch 
        //         {
        //             Console.WriteLine("Incorrect PIN. Please try again.");
        //         }
        //     }
        // Console.WriteLine("Welcome " + currentUser.GetfirstName() + ".");
        // }
        //     }
            
            
        }
}



public class DebitCard : CardHolder
{
    public DebitCard(string cardNum, int PIN, string firstName, string lastName, double balance) : base(cardNum, PIN, firstName, lastName, balance)
    {     
    }

    
    public override void DisplayCards()
    {
        
        List<CardHolder> cardHolders = new List<CardHolder>();
        DebitCard card = new DebitCard("123456789098765", 6380, "nombre", "apellido", 748.32);
        cardHolders.Add(card);
        DebitCard card2 = new DebitCard("93939393939393", 2456, "nombre", "apellido", 245.32);
        cardHolders.Add(card2);
        DebitCard card3 = new DebitCard("83838838389298126", 5362, "nomre", "apellido", 92.22);
        cardHolders.Add(card3);

        base.DisplayCards();

        Console.WriteLine("Please insert your Debit/Credit card: ");
        CardHolder currentUser;

        while (true)
        {



            // try
            // {
            //     string cardNumber = Console.ReadLine();
            //     currentUser = cardHolders.FirstOrDefault(a => a.GetNum() == cardNumber);
            //     Console.WriteLine(currentUser);
            //     if (currentUser == null) { break; }
            //     else { Console.WriteLine("Card not recognized . Please try again"); }
            // }
            // catch 
            // {
            //     Console.WriteLine("Invalid card number. Please try again.");
            // }

            Console.WriteLine("Please enter your PIN from your account:");
            int userPIN = 0;
            
            while (true)
            {
                try
                {
                    userPIN = int.Parse(Console.ReadLine());
                    currentUser = cardHolders.FirstOrDefault(a => a.GetPIN() == userPIN);
                    if (currentUser.GetPIN() == userPIN) { break; }
                    else { Console.WriteLine("PIN Incorrect. Please try again"); }
                }
                catch 
                {
                    Console.WriteLine("Incorrect PIN. Please try again.");
                }
            }
        Console.WriteLine("Welcome " + currentUser.GetfirstName() + ".");
        }
    }
}

public class CreditCard : CardHolder
{
    public CreditCard(string cardNum, int PIN, string firstName, string lastName, double balance) : base(cardNum, PIN, firstName, lastName, balance)
        {
            
        }       

    public override void DisplayCards()
    {
        List<CardHolder> creditHolders = new List<CardHolder>();    
        CreditCard creditCard = new CreditCard("0564765432567898", 6530, "nombre", "apellido", 748.32);
        creditHolders.Add(creditCard);
        CreditCard creditCard2 = new CreditCard("6765434567890987", 5433, "nombre", "apellido", 245.32);
        creditHolders.Add(creditCard2);
        CreditCard creditCard3 = new CreditCard("3454345678909876", 0000, "nomre", "apellido", 92.22);
        creditHolders.Add(creditCard3);


    }
}

public class Deposit : CardHolder
{
    public Deposit(string cardNum, int PIN, string firstName, string lastName, double balance) : base(cardNum, PIN, firstName, lastName, balance)
        {
            
        }       
}

public class Withdraw : CardHolder
{
    public Withdraw(string cardNum, int PIN, string firstName, string lastName, double balance) : base(cardNum, PIN, firstName, lastName, balance)
        {
            
        }       
}