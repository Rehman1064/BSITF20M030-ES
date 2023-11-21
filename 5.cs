using System;
using System.Collections.Generic;

// Prototype interface
interface ICloneableShape
{
    ICloneableShape Clone();
    void Display();
}

// Concrete prototype classes
class Circle : ICloneableShape
{
    public int Radius { get; set; }

    public Circle(int radius)
    {
        Radius = radius;
    }

    public ICloneableShape Clone()
    {
        // Create a shallow copy of the object
        return MemberwiseClone() as ICloneableShape;
    }

    public void Display()
    {
        Console.WriteLine($"Circle with radius {Radius}");
    }
}

class Square : ICloneableShape
{
    public int Side { get; set; }

    public Square(int side)
    {
        Side = side;
    }

    public ICloneableShape Clone()
    {
        // Create a shallow copy of the object
        return MemberwiseClone() as ICloneableShape;
    }

    public void Display()
    {
        Console.WriteLine($"Square with side {Side}");
    }
}

// Prototype interface
interface ICloneableDocument
{
    ICloneableDocument Clone();
    void Display();
}

// Concrete prototype class
class Document : ICloneableDocument
{
    public string Title { get; set; }
    public List<string> Content { get; set; }

    public Document(string title, List<string> content)
    {
        Title = title;
        Content = content;
    }

    public ICloneableDocument Clone()
    {
        // Create a deep copy of the object by copying the list
        return new Document(Title, new List<string>(Content));
    }

    public void Display()
    {
        Console.WriteLine($"Document: {Title}");
        Console.WriteLine("Content:");
        foreach (var item in Content)
        {
            Console.WriteLine($"- {item}");
        }
        Console.WriteLine();
    }
}

// Client class
class Program
{
    static void Main()
    {
        // Create prototype objects
        ICloneableShape prototypeCircle = new Circle(5);
        ICloneableShape prototypeSquare = new Square(4);

        // Create new objects by cloning the prototypes
        ICloneableShape clonedCircle1 = prototypeCircle.Clone();
        ICloneableShape clonedCircle2 = prototypeCircle.Clone();
        ICloneableShape clonedSquare1 = prototypeSquare.Clone();
        ICloneableShape clonedSquare2 = prototypeSquare.Clone();

        // Display the original and cloned objects
        Console.WriteLine("Original prototypes:");
        prototypeCircle.Display();
        prototypeSquare.Display();

        Console.WriteLine("\nCloned objects:");
        clonedCircle1.Display();
        clonedCircle2.Display();
        clonedSquare1.Display();
        clonedSquare2.Display();

        // Create a prototype document
        ICloneableDocument prototypeDocument = new Document("Prototype Document", new List<string> { "Introduction", "Body", "Conclusion" });

        // Create new documents by cloning the prototype
        ICloneableDocument clonedDocument1 = prototypeDocument.Clone();
        ICloneableDocument clonedDocument2 = prototypeDocument.Clone();

        // Modify the content of the cloned documents
        ((Document)clonedDocument1).Content.Add("Appendix");
        ((Document)clonedDocument2).Content[0] = "Revised Introduction";

        // Display the original and cloned documents
        Console.WriteLine("Original prototype document:");
        prototypeDocument.Display();

        Console.WriteLine("Cloned documents:");
        clonedDocument1.Display();
        clonedDocument2.Display();
    }
}
