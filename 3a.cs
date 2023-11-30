using System;

interface IApprover
{
    void ProcessRequest(PurchaseRequest request);
}

class Manager : IApprover
{
    public virtual void ProcessRequest(PurchaseRequest request)
    {
        if (request.Amount <= 1000)
        {
            Console.WriteLine($"Manager approves purchase request #{request.RequestNumber}");
        }
        else
        {
            Console.WriteLine($"Manager cannot approve purchase request #{request.RequestNumber}");
        }
    }
}

class Director : IApprover
{
    public virtual void ProcessRequest(PurchaseRequest request)
    {
        if (request.Amount <= 5000)
        {
            Console.WriteLine($"Director approves purchase request #{request.RequestNumber}");
        }
        else
        {
            Console.WriteLine($"Director cannot approve purchase request #{request.RequestNumber}");
        }
    }
}

class VicePresident : IApprover
{
    public virtual void ProcessRequest(PurchaseRequest request)
    {
        if (request.Amount <= 10000)
        {
            Console.WriteLine($"Vice President approves purchase request #{request.RequestNumber}");
        }
        else
        {
            Console.WriteLine($"Vice President cannot approve purchase request #{request.RequestNumber}");
        }
    }
}

class PurchaseRequest
{
    public int RequestNumber { get; }
    public double Amount { get; }

    public PurchaseRequest(int requestNumber, double amount)
    {
        RequestNumber = requestNumber;
        Amount = amount;
    }
}

class Program
{
    static void Main()
    {
        var vicePresident = new VicePresident();
        var director = new Director();
        var manager = new Manager();

        manager.ProcessRequest(new PurchaseRequest(1, 800));
        manager.ProcessRequest(new PurchaseRequest(2, 3500));
        manager.ProcessRequest(new PurchaseRequest(3, 12000));
    }
}
