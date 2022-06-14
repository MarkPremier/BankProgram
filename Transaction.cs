using System;
using SplashKitSDK;


public abstract class Transaction
{
   protected decimal _amount;
    protected bool _success;
   private bool _executed;
   private bool _reversed;
   private DateTime _dateStamp;
   protected Transaction(decimal amount)
   {
       _amount = amount;
   }

   public bool Executed
   {
       get
       {
           return _executed;
       }
       protected set
       {
           _executed = value;
       }
   }
    public abstract bool Success
    {
        get;
    }
    public bool Reversed
    {
        get
        {
            return _reversed;
        }
        protected set
       {
           _executed = value;
       }
    }

    public DateTime DateStamp
    {
        get
        {
            return _dateStamp;
        }
    }
    public abstract void Print();
    public virtual void Execute()
    {
        if(_executed)
        {
            throw new Exception ("cannot execute this transaction");
        }
        _dateStamp=DateTime.Now;
        Console.WriteLine(_dateStamp.ToString());
        _executed=true;

    }

    public virtual void Rollback()
    {
        if (_executed == false)
        {
            throw new Exception("Transaction is not executed");
        }   
        _executed = true;

        if (_reversed == true)
        {
            throw new Exception("Transaction not reversed");
        }
        _reversed = true;
    }

}