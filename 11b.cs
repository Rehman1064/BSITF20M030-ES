using System;
using System.Collections.Generic;

class CustomMemento
{
    public string StateData { get; }

    public CustomMemento(string stateData)
    {
        StateData = stateData;
    }
}

class CustomOriginator
{
    private string data;

    public string Data
    {
        get => data;
        set
        {
            Console.WriteLine($"Setting data to: {value}");
            data = value;
        }
    }

    public CustomMemento CreateMemento()
    {
        return new CustomMemento(data);
    }

    public void RestoreMemento(CustomMemento memento)
    {
        data = memento.StateData;
        Console.WriteLine($"Restored to data: {data}");
    }
}

class CustomCaretaker
{
    private readonly List<CustomMemento> mementos = new List<CustomMemento>();

    public void AddMemento(CustomMemento memento)
    {
        mementos.Add(memento);
    }

    public CustomMemento GetMemento(int index)
    {
        return mementos[index];
    }
}

class MementoExample
{
    static void Main()
    {
        var customOriginator = new CustomOriginator();
        var customCaretaker = new CustomCaretaker();

        customOriginator.Data = "Data 1";
        customCaretaker.AddMemento(customOriginator.CreateMemento());

        customOriginator.Data = "Data 2";
        customCaretaker.AddMemento(customOriginator.CreateMemento());

        Console.WriteLine($"Current data: {customOriginator.Data}");

        customOriginator.RestoreMemento(customCaretaker.GetMemento(0));
        Console.WriteLine($"Restored data: {customOriginator.Data}");

        customOriginator.RestoreMemento(customCaretaker.GetMemento(1));
        Console.WriteLine($"Restored data: {customOriginator.Data}");
    }
}
