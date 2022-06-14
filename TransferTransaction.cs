using System;
using SplashKitSDK;

public class TransferTransaction : Transaction
{
   private Account _toAccount;
   private Account _fromAccount;

   private DepositTransaction _theDeposit;
   private WithdrawTransaction _theWithdraw; 

    //private bool _executed = false;
    //private bool _reversed = false;


    public override bool Success
    {
        get
        {
            return _success;
        }
    }


    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount):base(amount)
    {
        _toAccount = toAccount;
        _fromAccount = fromAccount;
        //_amount = amount;

        _theWithdraw = new WithdrawTransaction(fromAccount, amount);
        _theDeposit = new DepositTransaction(toAccount, amount);
    }

    public override void Execute()
    {

        _theWithdraw.Execute();

        if(_theWithdraw.Success)
        {
            _theDeposit.Execute();
            _success = true;
        }
        else
        {
            throw new Exception("Transaction not executed");
        }


    }

    public override void Rollback()
    {
        if ( Executed == false)
        {
            throw new Exception("This transaction has already been executed");
        }
        if ( Reversed == true)
        {
            throw new Exception("This transaction has been reversed already");
        }
        if (_theWithdraw.Success)
            _theWithdraw.Rollback();
        if (_theDeposit.Success)
            _theDeposit.Rollback();

    }

        public override void Print()
    {
    Console.WriteLine("Transferred "+ _amount +" from "+ _fromAccount.Name +"'s Account to "+ _toAccount.Name+"'s Account");
    }

       
    


}