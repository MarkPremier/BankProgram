using System;
using SplashKitSDK;

public class Account
{
    private decimal _balance;
    private string _name;

    public string Name
    {
        get { return _name; }
    }
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
        
    }

    public string returnName()
    {
        return this._name;
    }

        public bool Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw > 0 && amountToWithdraw <= _balance)
        {
            _balance -= amountToWithdraw;
            return true;
        }
        else if (amountToWithdraw <= 0)
        {
            Console.WriteLine("Please submit a number higher than 0");
            return false;
        }
        else
        {
            Console.WriteLine("You do not have available funds");
            return false;
        }
        
    }

    public bool Deposit(decimal amountToDeposit)
    {

        if (amountToDeposit > 0)
        {
            _balance += amountToDeposit;
            return true;
        }
        else
        {
            Console.WriteLine("Please deposit a positive number");
            return false;
        }
        
    }

     public void Print()
    {
        Console.WriteLine(Name + " has " + _balance + " in the account");
    }
    

}

