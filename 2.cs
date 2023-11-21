using System;

interface IVehicle
{
    void Drive();
}

class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
}

class Bike : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Bike is driving.");
    }
}

interface IVehicleFactory
{
    IVehicle CreateVehicle();
}

class CarFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Car();
    }
}

class BikeFactory : IVehicleFactory
{
    public IVehicle CreateVehicle()
    {
        return new Bike();
    }
}
interface IDocument
{
    void Display();
}

class Resume : IDocument
{
    public void Display()
    {
        Console.WriteLine("Resume document displayed.");
    }
}

class Report : IDocument
{
    public void Display()
    {
        Console.WriteLine("Report document displayed.");
    }
}

interface IDocumentFactory
{
    IDocument CreateDocument();
}

class ResumeFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new Resume();
    }
}

class ReportFactory : IDocumentFactory
{
    public IDocument CreateDocument()
    {
        return new Report();
    }
}

class Program
{
    static void Main()
    {
        IVehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();

        IVehicleFactory bikeFactory = new BikeFactory();
        IVehicle bike = bikeFactory.CreateVehicle();
        bike.Drive(); // Output: Bike is driving.
        IDocumentFactory resumeFactory = new ResumeFactory();
        IDocument resume = resumeFactory.CreateDocument();
        resume.Display(); // Output: Resume document displayed.

        IDocumentFactory reportFactory = new ReportFactory();
        IDocument report = reportFactory.CreateDocument();
        report.Display(); // Output: Report document displayed.
    }
}
