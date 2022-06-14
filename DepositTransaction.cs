using System;
using SplashKitSDK;

public class DepositTransaction : Transaction
{
    private Account _account;
    private bool _executed = false;
    private bool _success = false;
    private bool _reversed = false;


    public override bool Success
    {
        get
        {
            return _success;
        }
    }


    public DepositTransaction(Account account, decimal amount): base(amount)
    {
        _account = account;
        _amount = amount;
    }
    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);
    }


    public override void Rollback()
    {
        if ( _executed || _success )
        {
            throw new Exception("This transaction has not been executed yet");
        }
        if ( _reversed)
        {
            throw new Exception("This transaction has already been reversed");
        }
        if ( _account.Withdraw(_amount))
        {
            _reversed = true;
            _executed = false;
            _success = false;
        }
        else
        {
            _reversed = false;
            _executed = true;
            _success = true;
        } 

    }

        public override void Print()
    {

        if (_success)
        {
            Console.WriteLine(_amount + " deposited into "+ _account.Name +"'s account");
        }
        else
        {
            Console.WriteLine("Deposit failed");
            if (_reversed)
            Console.WriteLine("Deposit was reversed");
        }
       
    }
    
   
}