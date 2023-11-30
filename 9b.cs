using System;
using System.Collections.Generic;

class RomanInterpreterContext
{
    public string RomanNumeral { get; set; }
    public int DecimalValue { get; set; }
}

interface IRomanExpression
{
    void Interpret(RomanInterpreterContext context);
}

class SingleDigitExpression : IRomanExpression
{
    private readonly char symbol;
    private readonly int value;

    public SingleDigitExpression(char symbol, int value)
    {
        this.symbol = symbol;
        this.value = value;
    }

    public void Interpret(RomanInterpreterContext context)
    {
        if (context.RomanNumeral.StartsWith(symbol.ToString()))
        {
            context.DecimalValue += value;
            context.RomanNumeral = context.RomanNumeral.Substring(1);
        }
    }
}

class RomanNumeralInterpreter : IRomanExpression
{
    private readonly List<IRomanExpression> expressions = new List<IRomanExpression>();

    public void AddExpression(IRomanExpression expression)
    {
        expressions.Add(expression);
    }

    public void Interpret(RomanInterpreterContext context)
    {
        foreach (var expression in expressions)
        {
            expression.Interpret(context);
        }
    }
}

class RomanNumeralClient
{
    static void Main()
    {
        var context = new RomanInterpreterContext { RomanNumeral = "XIV" };

        var interpreter = new RomanNumeralInterpreter();
        interpreter.AddExpression(new SingleDigitExpression('X', 10));
        interpreter.AddExpression(new SingleDigitExpression('I', 1));
        interpreter.AddExpression(new SingleDigitExpression('I', 1));

        interpreter.Interpret(context);

        Console.WriteLine("Result: " + context.DecimalValue);
    }
}
