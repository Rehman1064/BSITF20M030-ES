using System;

class CustomMemento
{
    public string Data { get; }

    public CustomMemento(string data)
    {
        Data = data;
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
        data = memento.Data;
        Console.WriteLine($"Restored to data: {data}");
    }
}

class CustomCaretaker
{
    public CustomMemento Memento { get; set; }
}

class MementoExample
{
    static void Main()
    {
        var customOriginator = new CustomOriginator();
        var customCaretaker = new CustomCaretaker();

        customOriginator.Data = "Data 1";
        customCaretaker.Memento = customOriginator.CreateMemento();

        customOriginator.Data = "Data 2";
        Console.WriteLine($"Current data: {customOriginator.Data}");

        customOriginator.RestoreMemento(customCaretaker.Memento);
        Console.WriteLine($"Restored data: {customOriginator.Data}");
    }
}
