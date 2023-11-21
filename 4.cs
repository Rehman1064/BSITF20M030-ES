using System;

// Product class
class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GPU { get; set; }

    public void Display()
    {
        Console.WriteLine($"Computer Configuration:\nCPU: {CPU}\nRAM: {RAM}\nStorage: {Storage}\nGPU: {GPU}");
    }
}

// Abstract builder interface
interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGPU();
    Computer GetComputer();
}

// Concrete builder class
class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer;

    public GamingComputerBuilder()
    {
        computer = new Computer();
    }

    public void BuildCPU()
    {
        computer.CPU = "High-end gaming CPU";
    }

    public void BuildRAM()
    {
        computer.RAM = "16GB RAM";
    }

    public void BuildStorage()
    {
        computer.Storage = "1TB SSD";
    }

    public void BuildGPU()
    {
        computer.GPU = "NVIDIA RTX 3080";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// Director class
class ComputerDirector
{
    private IComputerBuilder computerBuilder;

    public ComputerDirector(IComputerBuilder builder)
    {
        computerBuilder = builder;
    }

    public void ConstructComputer()
    {
        computerBuilder.BuildCPU();
        computerBuilder.BuildRAM();
        computerBuilder.BuildStorage();
        computerBuilder.BuildGPU();
    }
}


// Product class
class Meal
{
    public string Burger { get; set; }
    public string Drink { get; set; }
    public string Fries { get; set; }

    public void Display()
    {
        Console.WriteLine($"Meal Contents:\nBurger: {Burger}\nDrink: {Drink}\nFries: {Fries}");
    }
}

// Abstract builder interface
interface IMealBuilder
{
    void BuildBurger();
    void BuildDrink();
    void BuildFries();
    Meal GetMeal();
}

// Concrete builder class
class VeggieMealBuilder : IMealBuilder
{
    private Meal meal;

    public VeggieMealBuilder()
    {
        meal = new Meal();
    }

    public void BuildBurger()
    {
        meal.Burger = "Veggie Burger";
    }

    public void BuildDrink()
    {
        meal.Drink = "Fruit Juice";
    }

    public void BuildFries()
    {
        meal.Fries = "Sweet Potato Fries";
    }

    public Meal GetMeal()
    {
        return meal;
    }
}

// Director class
class Waiter
{
    private IMealBuilder mealBuilder;

    public Waiter(IMealBuilder builder)
    {
        mealBuilder = builder;
    }

    public void ConstructMeal()
    {
        mealBuilder.BuildBurger();
        mealBuilder.BuildDrink();
        mealBuilder.BuildFries();
    }
}

class Program
{
    static void Main()
    {
        // Create a director and a builder for a gaming computer
        IComputerBuilder gamingComputerBuilder = new GamingComputerBuilder();
        ComputerDirector director = new ComputerDirector(gamingComputerBuilder);

        // Construct a gaming computer
        director.ConstructComputer();
        Computer gamingComputer = gamingComputerBuilder.GetComputer();

        // Display the gaming computer configuration
        gamingComputer.Display();
        // Create a waiter and a builder for a veggie meal
        IMealBuilder veggieMealBuilder = new VeggieMealBuilder();
        Waiter waiter = new Waiter(veggieMealBuilder);

        // Construct a veggie meal
        waiter.ConstructMeal();
        Meal veggieMeal = veggieMealBuilder.GetMeal();

        // Display the veggie meal contents
        veggieMeal.Display();
    }
}
