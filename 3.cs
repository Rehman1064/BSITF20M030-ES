using System;

// Abstract product interfaces
interface IChair
{
    void SitOn();
}

interface ITable
{
    void PutOn();
}

// Concrete product classes for a Modern Furniture family
class ModernChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a modern chair.");
    }
}

class ModernTable : ITable
{
    public void PutOn()
    {
        Console.WriteLine("Putting something on a modern table.");
    }
}

// Concrete product classes for a Victorian Furniture family
class VictorianChair : IChair
{
    public void SitOn()
    {
        Console.WriteLine("Sitting on a Victorian chair.");
    }
}

class VictorianTable : ITable
{
    public void PutOn()
    {
        Console.WriteLine("Putting something on a Victorian table.");
    }
}

// Abstract factory interface
interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

// Concrete factory classes implementing the Abstract Factory interface
class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new ModernChair();
    }

    public ITable CreateTable()
    {
        return new ModernTable();
    }
}

class VictorianFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new VictorianChair();
    }

    public ITable CreateTable()
    {
        return new VictorianTable();
    }
}


// Abstract product interfaces
interface IButton
{
    void Render();
}

interface ICheckbox
{
    void Render();
}

// Concrete product classes for a Windows UI family
class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows button.");
    }
}

class WindowsCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows checkbox.");
    }
}

// Concrete product classes for a MacOS UI family
class MacOSButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a MacOS button.");
    }
}

class MacOSCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a MacOS checkbox.");
    }
}

// Abstract factory interface
interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete factory classes implementing the Abstract Factory interface
class WindowsGUIFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

class MacOSGUIFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacOSButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacOSCheckbox();
    }
}

class Program
{
    static void Main()
    {
        // Create a modern furniture set
        IFurnitureFactory modernFactory = new ModernFurnitureFactory();
        IChair modernChair = modernFactory.CreateChair();
        ITable modernTable = modernFactory.CreateTable();

        modernChair.SitOn();   // Output: Sitting on a modern chair.
        modernTable.PutOn();   // Output: Putting something on a modern table.

        // Create a Victorian furniture set
        IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
        IChair victorianChair = victorianFactory.CreateChair();
        ITable victorianTable = victorianFactory.CreateTable();

        victorianChair.SitOn(); // Output: Sitting on a Victorian chair.
        victorianTable.PutOn(); // Output: Putting something on a Victorian table.
        // Create a Windows UI
        IGUIFactory windowsFactory = new WindowsGUIFactory();
        IButton windowsButton = windowsFactory.CreateButton();
        ICheckbox windowsCheckbox = windowsFactory.CreateCheckbox();

        windowsButton.Render();     // Output: Rendering a Windows button.
        windowsCheckbox.Render();   // Output: Rendering a Windows checkbox.

        // Create a MacOS UI
        IGUIFactory macosFactory = new MacOSGUIFactory();
        IButton macosButton = macosFactory.CreateButton();
        ICheckbox macosCheckbox = macosFactory.CreateCheckbox();

        macosButton.Render();       // Output: Rendering a MacOS button.
        macosCheckbox.Render();     // Output: Rendering a MacOS checkbox.

    }
}
