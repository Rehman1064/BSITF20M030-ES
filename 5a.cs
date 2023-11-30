using System;

interface ISortAlgorithm
{
    void Sort(int[] array);
}

class BubbleSort : ISortAlgorithm
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Bubble Sort");
    }
}

class QuickSort : ISortAlgorithm
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Sorting using Quick Sort");
    }
}

class SortContext
{
    private ISortAlgorithm sortAlgorithm;

    public void SetSortAlgorithm(ISortAlgorithm algorithm)
    {
        sortAlgorithm = algorithm;
    }

    public void ExecuteSort(int[] array)
    {
        sortAlgorithm.Sort(array);
    }
}

class Program
{
    static void Main()
    {
        var sortContext = new SortContext();

        var bubbleSortAlgorithm = new BubbleSort();
        sortContext.SetSortAlgorithm(bubbleSortAlgorithm);
        sortContext.ExecuteSort(new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 });

        Console.WriteLine();

        var quickSortAlgorithm = new QuickSort();
        sortContext.SetSortAlgorithm(quickSortAlgorithm);
        sortContext.ExecuteSort(new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 });
    }
}
