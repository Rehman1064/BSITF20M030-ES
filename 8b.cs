using System;
using System.Collections.Generic;

interface IWorker
{
    void Accept(IWorkerVisitor visitor);
}

class Manager : IWorker
{
    public void Accept(IWorkerVisitor visitor)
    {
        visitor.VisitManager(this);
    }
}

class Developer : IWorker
{
    public void Accept(IWorkerVisitor visitor)
    {
        visitor.VisitDeveloper(this);
    }
}

interface IWorkerVisitor
{
    void VisitManager(Manager manager);
    void VisitDeveloper(Developer developer);
}

class SalaryCalculator : IWorkerVisitor
{
    public void VisitManager(Manager manager)
    {
        Console.WriteLine("Calculating salary for Manager");
    }

    public void VisitDeveloper(Developer developer)
    {
        Console.WriteLine("Calculating salary for Developer");
    }
}

class EmployeeClient
{
    static void Main()
    {
        var workers = new List<IWorker> { new Manager(), new Developer() };
        var salaryCalculator = new SalaryCalculator();

        foreach (var worker in workers)
        {
            worker.Accept(salaryCalculator);
        }
    }
}
