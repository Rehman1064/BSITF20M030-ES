using System;
using System.Collections.Generic;

interface IIterator
{
    bool HasNext();
    object Next();
}

class CustomListIterator : IIterator
{
    private readonly List<object> customList;
    private int currentIndex;

    public CustomListIterator(List<object> customList)
    {
        this.customList = customList;
        currentIndex = 0;
    }

    public bool HasNext()
    {
        return currentIndex < customList.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            return customList[currentIndex++];
        }
        else
        {
            throw new InvalidOperationException("No more elements");
        }
    }
}

interface ICustomAggregate
{
    IIterator CreateIterator();
}

class CustomListAggregate : ICustomAggregate
{
    private readonly List<object> customList;

    public CustomListAggregate()
    {
        customList = new List<object>();
    }

    public void AddItem(object item)
    {
        customList.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new CustomListIterator(customList);
    }
}

class IteratorApp
{
    static void Main()
    {
        var customAggregate = new CustomListAggregate();
        customAggregate.AddItem("Custom Item 1");
        customAggregate.AddItem("Custom Item 2");
        customAggregate.AddItem("Custom Item 3");

        var customIterator = customAggregate.CreateIterator();

        while (customIterator.HasNext())
        {
            Console.WriteLine(customIterator.Next());
        }
    }
}
