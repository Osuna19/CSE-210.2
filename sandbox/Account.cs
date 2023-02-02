class Account {
    private List<int> deposits = new List<int>();

//Havign a private class will not allow the code to acces to it, it only can accesed using the public string getName with the return.
   // private string _name = "Dr. Who";
    private string _firstName = "Dr.";
    private string _lastName = "Who";
    public string GetName(){
        return $"{_firstName} {_lastName}";
    }

    // setter
    public void SetName(string newName){
        _lastName = newName;
    }
  
    public void Deposit (int amount){
        _deposits.Add(amount);
    }

    public int GetBalance(){
        int balance = 0;
        foreach (var deposit in _deposits){
            balance += deposit;
        }
        return balance;
    }
}