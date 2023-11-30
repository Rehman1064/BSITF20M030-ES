using System;

class TrafficSignal
{
    private ISignalState currentState;

    public TrafficSignal()
    {
        currentState = new RedSignalState();
    }

    public void SetState(ISignalState state)
    {
        currentState = state;
    }

    public void Change()
    {
        currentState.Change(this);
    }
}

interface ISignalState
{
    void Change(TrafficSignal trafficSignal);
}

class RedSignalState : ISignalState
{
    public void Change(TrafficSignal trafficSignal)
    {
        Console.WriteLine("Traffic Signal is now RED");
        trafficSignal.SetState(new GreenSignalState());
    }
}

class GreenSignalState : ISignalState
{
    public void Change(TrafficSignal trafficSignal)
    {
        Console.WriteLine("Traffic Signal is now GREEN");
        trafficSignal.SetState(new YellowSignalState());
    }
}

class YellowSignalState : ISignalState
{
    public void Change(TrafficSignal trafficSignal)
    {
        Console.WriteLine("Traffic Signal is now YELLOW");
        trafficSignal.SetState(new RedSignalState());
    }
}

class Program
{
    static void Main()
    {
        var trafficSignal = new TrafficSignal();

        trafficSignal.Change();
        trafficSignal.Change();
        trafficSignal.Change();
        trafficSignal.Change();
    }
}
