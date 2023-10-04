using System;

class Program
{
    static void Main(string[] args)
    {
        //concat();
        //substringfetch();
        //stringInterpolation();
        //arrDecInit();
        //arrIteration();
        arrIterationForEach();
        //sumArrayelem();
        //maxVal();
        //arrReverse();
        //boxInt();
        //boxDouble();
        //unboxInt();
        //unboxList();
        //dynamicKeyword();
        //decDynVar();

    }

    static void concat()
    {
        string firstName, lastName, Name;

        Console.Write("Enter your first name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();

        Name = firstName + " " + lastName;
        Console.WriteLine("Your full name is: " + Name);
    }
    static void substringfetch()
    {
        string sentence = "My name is Rehman";

        string lastFiveCharacters = sentence.Substring(sentence.Length - 5);

        Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
    }

    static void stringInterpolation()
    {
        double temperature;
        string city;

        Console.Write("Enter the temperature: ");
        temperature = double.Parse(Console.ReadLine());

        Console.Write("Enter the city: ");
        city = Console.ReadLine();

        // String interpolation
        Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
    }


    static void arrDecInit()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }


    static void arrIteration()
    {
        string[] fruits = { "Apple", "Banana", "Orange", "Grapes", "Strawberry" };

        Console.WriteLine("Fruits:");
        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine(fruits[i]);
        }
    }

    static void arrIterationForEach()
    {
        string[] colors = { "Red", "Blue", "Green" };

        Console.WriteLine("Colors:");
        foreach (var color in colors)
        {
            Console.Write($"{color}, ");
        }
    }

    static void sumArrayelem()
    {
        int[] scores = { 85, 92, 78, 95, 87, 90, 88, 89, 93, 91 };
        int sum = 0;

        foreach (var score in scores)
        {
            sum += score;
        }

        Console.WriteLine("Sum of scores: " + sum);
    }


    static void maxVal()
    {
        int[] values = { 12, 45, 67, 89, 34, 67, 23, 56, 78 };
        int max = values[0];

        for (int i = 1; i < values.Length; i++)
        {
            if (values[i] > max)
                max = values[i];
        }

        Console.WriteLine("Maximum value: " + max);

    }


    static void arrReverse()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Array.Reverse(numbers);

        Console.Write("Reversed array: ");
        foreach (var num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }


    static void boxInt()
    {
        int x = 42;

        object obj = x;

        int y = (int)obj;

        Console.WriteLine("Unboxed value: " + y);
    }

    static void boxDouble()
    {
        double doubleValue = 3.14159;

        object boxedValue = doubleValue;

        double unboxedValue = (double)boxedValue;

        Console.WriteLine("Unboxed double value: " + unboxedValue);
    }


    static void unboxInt()
    {
        int[] numbers = { 10, 20, 30 };

        foreach (var num in numbers)
        {
            object boxedValue = num;

            int unboxedValue = (int)boxedValue;
            int squaredValue = unboxedValue * unboxedValue;

            Console.WriteLine($"Original: {unboxedValue}, Squared: {squaredValue}");
        }
    }



    static void unboxList()
    {
        List<object> values = new List<object>();
        values.Add(42);
        values.Add(3.14);
        values.Add('A');

        foreach (var value in values)
        {
            Console.WriteLine($"Value: {value}, Type: {value.GetType()}");
        }
    }


    static void dynamicKeyword()
    {
        dynamic myVariable = 42;
        Console.WriteLine("Value of myVariable: " + myVariable);

        myVariable = "Hello, Dynamic!";
        Console.WriteLine("Value of myVariable: " + myVariable);
    }


    static void decDynVar()
    {
        dynamic myVariable2 = 42;
        Console.WriteLine("Type of myVariable2: " + myVariable2.GetType());

        myVariable2 = 3.14;
        Console.WriteLine("Type of myVariable2: " + myVariable2.GetType());

        myVariable2 = DateTime.Now;
        Console.WriteLine("Type of myVariable2: " + myVariable2.GetType());

        myVariable2 = "Dynamic Type";
        Console.WriteLine("Type of myVariable2: " + myVariable2.GetType());
    }
}
