using System;

class CeilingCooler
{
    private ICoolerState currentState;

    public CeilingCooler()
    {
        currentState = new OffCoolerState();
    }

    public void SetState(ICoolerState state)
    {
        currentState = state;
    }

    public void PullChain()
    {
        currentState.Pull(this);
    }
}

interface ICoolerState
{
    void Pull(CeilingCooler ceilingCooler);
}

class OffCoolerState : ICoolerState
{
    public void Pull(CeilingCooler ceilingCooler)
    {
        Console.WriteLine("Turning the cooler ON at low speed");
        ceilingCooler.SetState(new LowCoolerState());
    }
}

class LowCoolerState : ICoolerState
{
    public void Pull(CeilingCooler ceilingCooler)
    {
        Console.WriteLine("Increasing the cooler speed to MEDIUM");
        ceilingCooler.SetState(new MediumCoolerState());
    }
}

class MediumCoolerState : ICoolerState
{
    public void Pull(CeilingCooler ceilingCooler)
    {
        Console.WriteLine("Increasing the cooler speed to HIGH");
        ceilingCooler.SetState(new HighCoolerState());
    }
}

class HighCoolerState : ICoolerState
{
    public void Pull(CeilingCooler ceilingCooler)
    {
        Console.WriteLine("Turning the cooler OFF");
        ceilingCooler.SetState(new OffCoolerState());
    }
}

class Program
{
    static void Main()
    {
        var ceilingCooler = new CeilingCooler();

        ceilingCooler.PullChain();
        ceilingCooler.PullChain();
        ceilingCooler.PullChain();
        ceilingCooler.PullChain();
        ceilingCooler.PullChain();
    }
}
