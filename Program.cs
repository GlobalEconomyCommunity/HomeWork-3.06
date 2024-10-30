using System;
using System.Collections.Generic;

public class Builder : IComparable<Builder>
{
    public int YearBuilt { get; set; }
    public int NumberOfOffices { get; set; }
    public double TotalArea { get; set; }

    public Builder(int yearBuilt, int numberOfOffices, double totalArea)
    {
        YearBuilt = yearBuilt;
        NumberOfOffices = numberOfOffices;
        TotalArea = totalArea;
    }

    // Реализация метода CompareTo для сравнения по году постройки
    public int CompareTo(Builder other)
    {
        if (other == null) return 1;
        return YearBuilt.CompareTo(other.YearBuilt);
    }

    public override string ToString()
    {
        return $"Year: {YearBuilt}, Offices: {NumberOfOffices}, Area: {TotalArea}";
    }
}

public class SortOfficeBuilderComparer : IComparer<Builder>
{
    // Сравнение по количеству офисов
    public int Compare(Builder x, Builder y)
    {
        if (x == null || y == null) return 0;
        return x.NumberOfOffices.CompareTo(y.NumberOfOffices);
    }
}

public class SortAreaBuilderComparer : IComparer<Builder>
{
    // Сравнение по общей площади
    public int Compare(Builder x, Builder y)
    {
        if (x == null || y == null) return 0;
        return x.TotalArea.CompareTo(y.TotalArea);
    }
}

class Program
{
    static void Main()
    {
        List<Builder> builders = new List<Builder>
        {
            new Builder(2000, 10, 500.5),
            new Builder(1995, 15, 300.0),
            new Builder(2010, 5, 400.0),
            new Builder(2005, 20, 600.0)
        };

        Console.WriteLine("Список зданий до сортировки по году постройки:");
        foreach (var builder in builders)
        {
            Console.WriteLine(builder);
        }

        // Сортировка по году постройки
        builders.Sort();
        Console.WriteLine("\nСписок зданий после сортировки по году постройки:");
        foreach (var builder in builders)
        {
            Console.WriteLine(builder);
        }

        // Сортировка по количеству офисов
        builders.Sort(new SortOfficeBuilderComparer());
        Console.WriteLine("\nСписок зданий после сортировки по количеству офисов:");
        foreach (var builder in builders)
        {
            Console.WriteLine(builder);
        }

        // Сортировка по общей площади
        builders.Sort(new SortAreaBuilderComparer());
        Console.WriteLine("\nСписок зданий после сортировки по общей площади:");
        foreach (var builder in builders)
        {
            Console.WriteLine(builder);
        }
    }
}