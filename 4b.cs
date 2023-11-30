using System;
using System.Collections.Generic;

interface IStockSubject
{
    void AddStockObserver(IInvestorObserver observer);
    void RemoveStockObserver(IInvestorObserver observer);
    void NotifyStockObservers();
}

interface IInvestorObserver
{
    void UpdateStock(string stockSymbol, decimal stockPrice);
}

class Stock : IStockSubject
{
    private List<IInvestorObserver> investorObservers = new List<IInvestorObserver>();
    private string symbol;
    private decimal currentPrice;

    public Stock(string symbol, decimal initialPrice)
    {
        this.symbol = symbol;
        this.currentPrice = initialPrice;
    }

    public void AddStockObserver(IInvestorObserver investorObserver)
    {
        investorObservers.Add(investorObserver);
    }

    public void RemoveStockObserver(IInvestorObserver investorObserver)
    {
        investorObservers.Remove(investorObserver);
    }

    public void NotifyStockObservers()
    {
        foreach (var investorObserver in investorObservers)
        {
            investorObserver.UpdateStock(symbol, currentPrice);
        }
    }

    public void SetCurrentPrice(decimal newPrice)
    {
        if (newPrice != currentPrice)
        {
            currentPrice = newPrice;
            NotifyStockObservers();
        }
    }
}

class Investor : IInvestorObserver
{
    private readonly string investorName;

    public Investor(string investorName)
    {
        this.investorName = investorName;
    }

    public void UpdateStock(string stockSymbol, decimal stockPrice)
    {
        Console.WriteLine($"{investorName} received update: {stockSymbol} price is {stockPrice:C}");
    }
}

class Program
{
    static void Main()
    {
        var stock = new Stock("ABC", 120.00m);

        var investorJohn = new Investor("John Doe");
        var investorJane = new Investor("Jane Smith");

        stock.AddStockObserver(investorJohn);
        stock.AddStockObserver(investorJane);

        stock.SetCurrentPrice(125.50m);
        Console.WriteLine();

        stock.RemoveStockObserver(investorJohn);

        stock.SetCurrentPrice(118.75m);
    }
}
