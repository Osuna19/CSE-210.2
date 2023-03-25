using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello FinalProject World!");
            
            menuDisplay menu = new menuDisplay();
          

            
            // Deposit depositOption = new Deposit();
        }
    }

class menuDisplay
{
   
        public menuDisplay()
        {
            while(true)
            {
            Console.WriteLine("Choose an option from the menu:");
            Console.WriteLine("1. Deposit...");
            Console.WriteLine("2. Withdraw...");
            Console.WriteLine("3. Show Balance...");
            Console.WriteLine("4. Log out...");
            Console.WriteLine("Select an option from the menu: ");
            string choice = Console.ReadLine();
            }
        }

    void Deposit(CardHolder user)
    {
        Console.WriteLine("Yout current balance is: " + user.GetBalance());
        Console.WriteLine("How much mone would you like to deposit?");
        int deposit = int.Parse(Console.ReadLine());
        user.setBalance(user.GetBalance() + deposit);
    }
}

abstract class CardHolder 
{   
    private string _firstName;
    private string _lastName;
    private int _cardNumber;
    private int _PIN;
    private int _balance;

    public CardHolder(string firstName, string lastName, int cardNumber, int PIN, int balance)
    {
        _firstName = firstName;
        _lastName = lastName;
        _cardNumber = cardNumber;
        _PIN = PIN;
        _balance = balance;

    } 

    public string GetFirstName() {
            return _firstName;
        }

    public string GetLastName() {
        return _lastName;
    }

    public int GetPIN() {
        return _PIN;
    }

    public int GetCardNum() {
        return _cardNumber;
    }

    public int GetBalance() {
        return _balance;
    }

    public void setFirstName(string firstName)
    {
        _firstName = firstName;
    }

    public void setLastName (string lastName)
    {
        _lastName = lastName;
    }

    public void setPIN(int PIN)
    {
        _PIN = PIN;
    }

    public void setBalance(int balance)
    {
        _balance = balance;
    }

    public void setCardNum(int cardNumber)
    {
        _cardNumber = cardNumber;
    }

  private List<CardHolder> cardHolders = new List<CardHolder>();
  public virtual void AddCardHolder(CardHolder cardHolder)
  {
    cardHolders.Add(cardHolder);
  }

}

class CreditCard : CardHolder
{
    private int _increaseLimit;
    public CreditCard(string firstName, string lastName, int PIN, int cardNumber, int balance, int increaseLimit) : base (firstName, lastName, PIN, cardNumber, balance)
    {
        _increaseLimit = increaseLimit;
    }

    public void IncreaseLimit(int amount)
    {
        _increaseLimit += amount;
        Console.WriteLine($"The credit limit has been increased for the credit card: {GetCardNum}. The credit limit is {_increaseLimit}.");
    }

    public override string ToString()
    {
        return $"The credit limit has been increased for the credit card: {GetCardNum}. The credit limit is {_increaseLimit}.";
    }

    // public override 

    // public override CardHolder
    // {

    // }

}

class DebitCard : CardHolder
{
     public DebitCard(string firstName, string lastName, int PIN, int cardNumber, int balance) : base (firstName, lastName, PIN, cardNumber, balance)
    {
    }

}

class Operations
{
    List<CardHolder> operations = new List<CardHolder>();
    private int _amount;

    public Operations(int amount)
    {
        _amount = amount;
    }

    public virtual void Deposit(int amount)
    {
        Console.WriteLine("Cannot Deposit from this account");
    } 

    public virtual void Withdraw(int amount)
    {
        Console.WriteLine("Cannot Deposit from this account");
    }


}

class MakeDeposit : Operations
{
    private int _balance;
    private int _amount;
    

    public MakeDeposit(int amount, int balance) : base (amount)
    {
       _balance = balance;
    }

    public override void Deposit(int amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited {amount}. Balance is now {_balance}");
    }

    
}

class MakeWithdraw : Operations
{
   private int _balance;
    private int _amount;

    public MakeWithdraw(int amount, int balance) : base (amount)
    {
       _balance = balance;
    }

    public override void Withdraw(int amount)
    {
        if (_balance - amount >=0)
        {
            _balance -= amount; 
            Console.WriteLine($"Withdrew {amount}. Balance now is {_balance}");
        }
        else {
            Console.WriteLine("Insufficient balance.");
        }   
    }
}