// Question 1

using System;
using System.Collections.Generic;

// Defining Transaction record
public record Transaction(int Id, DateTime Date, decimal Amount, string Category);

// Defining ITransactionProcessor interface
public interface ITransactionProcessor
{
    void Process(Transaction transaction);
}

// Implementation of processors
public class BankTransferProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Bank Transfer] Processing {transaction.Amount:C} for {transaction.Category}");
    }
}

public class MobileMoneyProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Mobile Money] Processing {transaction.Amount:C} for {transaction.Category}");
    }
}

public class CryptoWalletProcessor : ITransactionProcessor
{
    public void Process(Transaction transaction)
    {
        Console.WriteLine($"[Crypto Wallet] Processing {transaction.Amount:C} for {transaction.Category}");
    }
}

// Base Account class
public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void ApplyTransaction(Transaction transaction)
    {
        Balance -= transaction.Amount;
    }
}

// Sealed SavingsAccount class
public sealed class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber, decimal initialBalance) : base(accountNumber, initialBalance)
    {
    }

    public override void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Amount > Balance)
        {
            Console.WriteLine($"Insufficient funds for transaction ID {transaction.Id}. Balance: {Balance:C}");
        }
        else
        {
            Balance -= transaction.Amount;
            Console.WriteLine($"Transaction applied. New balance: {Balance:C}");
        }
    }
}

// Main Application
public class FinanceApp
{
    private List<Transaction> _transactions = new();

    public void Run()
    {
        var account = new SavingsAccount("ACC123456", 1000m);

        var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
        var t2 = new Transaction(2, DateTime.Now, 250m, "Utilities");
        var t3 = new Transaction(3, DateTime.Now, 1200m, "Entertainment");

        ITransactionProcessor p1 = new MobileMoneyProcessor();
        ITransactionProcessor p2 = new BankTransferProcessor();
        ITransactionProcessor p3 = new CryptoWalletProcessor();

        p1.Process(t1);
        account.ApplyTransaction(t1);
        _transactions.Add(t1);

        p2.Process(t2);
        account.ApplyTransaction(t2);
        _transactions.Add(t2);

        p3.Process(t3);
        account.ApplyTransaction(t3);
        _transactions.Add(t3);
    }
}

// Entry point
class Program
{
    static void Main(string[] args)
    {
        FinanceApp app = new FinanceApp();
        app.Run();
    }
}
