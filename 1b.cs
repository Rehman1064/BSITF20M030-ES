using System;

interface IDocument
{
    void GenerateDocument();
}

abstract class Document : IDocument
{
    public void GenerateDocument()
    {
        AddHeader();
        AddBody();
        AddFooter();
    }

    protected void AddHeader()
    {
        Console.WriteLine("Adding document header");
    }

    protected abstract void AddBody();

    protected void AddFooter()
    {
        Console.WriteLine("Adding document footer");
    }
}

class Resume : Document
{
    protected override void AddBody()
    {
        Console.WriteLine("Adding resume content");
    }
}

class Letter : Document
{
    protected override void AddBody()
    {
        Console.WriteLine("Adding letter content");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Generating resume:");
        IDocument resume = new Resume();
        resume.GenerateDocument();

        Console.WriteLine("\nGenerating letter:");
        IDocument letter = new Letter();
        letter.GenerateDocument();
    }
}
