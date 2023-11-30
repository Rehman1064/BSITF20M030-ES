using System;

interface IBeverage
{
    void BoilWater();
    void PourInCup();
}

abstract class CaffeineBeverage : IBeverage
{
    public virtual void PrepareRecipe()
    {
        BoilWater();
        Brew();
        BeforePourInCup(); // Call the hook method.
        PourInCup();
        AddCondiments();
    }

    protected void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    protected void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    protected virtual void BeforePourInCup()
    {
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();
}

class Coffee : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Brewing coffee grounds");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}

class Tea : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Making coffee:");
        var coffee = new Coffee();
        coffee.PrepareRecipe();

        Console.WriteLine("\nMaking tea:");
        var tea = new Tea();
        tea.PrepareRecipe();
    }
}
