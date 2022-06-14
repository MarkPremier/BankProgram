using System;
using SplashKitSDK;


public enum MenuOption
{
    Withdraw,
    Deposit,
    Print,
    Transfer,
    NewAccount,
    PrintHistory,
    Quit
}

public class Program
{
    public static void Main()
    {
        Account jakeAccount = new Account("Jake ", 13000);
        Account markAccount = new Account("Mark ", 20000);
        Bank newBank = new Bank();
        MenuOption userSelection;
    do
    {
       userSelection = ReadUserOption();
        switch (userSelection)
        {
            case MenuOption.Withdraw:
                DoWithdraw(newBank);
                break;
            case MenuOption.Deposit:
                DoDeposit(newBank);
                break;
            case MenuOption.Transfer:
                DoTransfer(newBank);
                break;
            case MenuOption.Print:
                DoPrint(newBank);
                break;
            case MenuOption.NewAccount:
                addAccount(newBank);
                break;
            case MenuOption.PrintHistory:
                newBank.PrintTransactionHistory();
                break;
            case MenuOption.Quit:
                Console.WriteLine("See You!");
                break;
        } 
          } while (userSelection != MenuOption.Quit);

     Console.WriteLine(userSelection);                


    }

    private static MenuOption ReadUserOption()
    {
    int option;
    Console.WriteLine("1 will Withdraw");
    Console.WriteLine("2 will Deposit");
    Console.WriteLine("3 will Print");
    Console.WriteLine("4 will transfer money");
    Console.WriteLine("5 will Add a new Account");
    Console.WriteLine("6 will print transaction history");
    Console.WriteLine("7 will Quit");

        do
        {
            Console.Write("Choose an options [1-7]");
        try
        {
            option = Convert.ToInt32(Console.ReadLine());
        }
          catch (Exception)
        {
            Console.WriteLine("There is an error with your selection");
            option = -1;
        }
        } 
        while((option < 1) || (option > 7));

        return (MenuOption)(option - 1);
}


        private static void DoDeposit (Bank toBank)
    {
        Account account = FindAccount(toBank);
        if (account !=null)
        {
            Console.WriteLine("Type amount to deposit: ");
            try{
                decimal depositNum = Convert.ToDecimal(Console.ReadLine());
                DepositTransaction DepNum = new DepositTransaction(account, depositNum);
                toBank.ExecuteTransaction(DepNum);
                DepNum.Print();

                if (DepNum.Success == true)
                {
                    Console.WriteLine("Do you want to rollback the depsosit? Y or N");
                    string? RollbackQ = Console.ReadLine();
                    if (RollbackQ == "Y")
                    {
                        DepNum.Rollback();
                    }
                    else if (RollbackQ == "N")
                    {
                        Console.WriteLine("Transaction completed");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Please enter a correct value");
            }
        }

    }

    private static void DoWithdraw (Bank toBank)
    {
        Account account = FindAccount(toBank);
        if (account != null)
        {
            Console.WriteLine("Type amount to Withdraw: ");
            try
            {
                decimal withdrawNum = Convert.ToDecimal(Console.ReadLine());
                WithdrawTransaction withNum = new WithdrawTransaction(account, withdrawNum);
                toBank.ExecuteTransaction(withNum);
                withNum.Print();

                if (withNum.Success == true)
                {
                    Console.WriteLine("Rollback Withdraw? Type Y or N");
                    string? RollbackQ = Console.ReadLine();
                    if (RollbackQ == "Y")
                    {
                        withNum.Rollback();
                    }
                    else if (RollbackQ == "N")
                    {
                        Console.WriteLine("Transaction Completed");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Enter a valid amount");
            }
        }
    }


    private static void DoTransfer (Bank bank)
    {

        Console.Write("Tranfer from account: ");
        Account fromAccount = FindAccount(bank);

        if (fromAccount != null)
        {
            try
            {
                Console.WriteLine("Transfer to account: ");
                Account toAccount = FindAccount(bank);

                if (toAccount != null)
                {
                    Console.WriteLine("Transfer Amount: ");
                    decimal transferNum = Convert.ToDecimal(Console.ReadLine());
                    TransferTransaction transNum = new TransferTransaction(fromAccount, toAccount, transferNum);
                    bank.ExecuteTransaction(transNum);
                    transNum.Print();

                    if (transNum.Executed == true)
                    {
                        Console.WriteLine("Rollback transaction? Y or N");
                        string? RollbackQ = Console.ReadLine();
                        if (RollbackQ == "Y")
                        {
                            transNum.Rollback();
                        }
                        else if (RollbackQ == "N")
                        {
                            Console.WriteLine("transaction complete");
                        }
                    }

                }
            }
            catch
            {
                Console.WriteLine("Enter a valid account");
            }
        }

    }



    public static void addAccount (Bank bank)
    {
        Console.WriteLine("Type name of account: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Type the starting balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        if (balance > 0)
        {
            Account addNew = new Account(name, balance);
            bank.AddAccount(addNew);
        }
        else{
            Console.WriteLine("Please add more money.");
        }
    }

    private static Account FindAccount(Bank fromBank)
    {
        Console.Write("Enter account name: ");
        String? name = Console.ReadLine();
        Account returnName = fromBank.GetAccount(name);

        if ( returnName == null)
        {
            Console.WriteLine($"No account found with name {name}");
        }
        return returnName;
    }


    private static void DoPrint (Bank bank)
    {
        Account account = FindAccount(bank);
        account.Print();

    }

}



