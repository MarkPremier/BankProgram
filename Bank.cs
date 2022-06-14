using System;
using SplashKitSDK;


public class Bank
{

private static List<Account> _accounts = new List<Account>();
private static List<Transaction> _transaction = new List<Transaction>();
public void AddAccount(Account Account)
{
    _accounts.Add(Account);
}
public Account GetAccount(string name)
{
    foreach (Account account in _accounts)
    {
        if (account.returnName().Contains(name))
        {
            return account;
        }
    }
    return null;
}

public void ExecuteTransaction(Transaction transaction)
{
    _transaction.Add(transaction);
    transaction.Execute();
}

public void PrintTransactionHistory()
{
    for (int i = 0; i < _transaction.Count; i++)
            {
                Console.WriteLine("Transaction: " + i);
                Console.WriteLine(_transaction[i]);
                Console.WriteLine();
                _transaction[i].Print();
            }
}

}

