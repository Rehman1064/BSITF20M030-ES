using System;

class CalculationContext
{
    public int OperandValue { get; set; }
}

interface IOperation
{
    int Execute(CalculationContext context);
}

class Operand : IOperation
{
    private readonly int value;

    public Operand(int value)
    {
        this.value = value;
    }

    public int Execute(CalculationContext context)
    {
        return value;
    }
}

class AdditionOperation : IOperation
{
    private readonly IOperation leftOperand;
    private readonly IOperation rightOperand;

    public AdditionOperation(IOperation left, IOperation right)
    {
        leftOperand = left;
        rightOperand = right;
    }

    public int Execute(CalculationContext context)
    {
        return leftOperand.Execute(context) + rightOperand.Execute(context);
    }
}

class CalculatorClient
{
    static void Main()
    {
        var calculationContext = new CalculationContext { OperandValue = 5 };

        IOperation operation = new AdditionOperation(
            new Operand(10),
            new Operand(2)
        );

        int result = operation.Execute(calculationContext);
        Console.WriteLine("Result: " + result);
    }
}
