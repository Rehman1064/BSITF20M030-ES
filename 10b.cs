using System;
using System.Collections.Generic;

interface ICustomIterator<T>
{
    bool HasNext();
    T Next();
}

class CustomCollectionIterator<T> : ICustomIterator<T>
{
    private readonly CustomCollection<T> customCollection;
    private int currentIndex;

    public CustomCollectionIterator(CustomCollection<T> collection)
    {
        customCollection = collection;
        currentIndex = 0;
    }

    public bool HasNext()
    {
        return currentIndex < customCollection.Count;
    }

    public T Next()
    {
        if (HasNext())
        {
            return customCollection[currentIndex++];
        }
        else
        {
            throw new InvalidOperationException("No more elements");
        }
    }
}

interface ICustomAggregate<T>
{
    ICustomIterator<T> CreateIterator();
}

class CustomCollection<T> : ICustomAggregate<T>
{
    private readonly List<T> items;

    public CustomCollection()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public int Count => items.Count;

    public T this[int index] => items[index];

    public ICustomIterator<T> CreateIterator()
    {
        return new CustomCollectionIterator<T>(this);
    }
}

class CustomIteratorApp
{
    static void Main()
    {
        var customCollection = new CustomCollection<string>();
        customCollection.AddItem("Custom Item 1");
        customCollection.AddItem("Custom Item 2");
        customCollection.AddItem("Custom Item 3");

        var customIterator = customCollection.CreateIterator();

        while (customIterator.HasNext())
        {
            Console.WriteLine(customIterator.Next());
        }
    }
}
