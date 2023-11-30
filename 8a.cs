using System;
using System.Collections.Generic;

interface IGeometry
{
    void Accept(IGeometryVisitor visitor);
}

class Circle : IGeometry
{
    public void Accept(IGeometryVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

class Square : IGeometry
{
    public void Accept(IGeometryVisitor visitor)
    {
        visitor.VisitSquare(this);
    }
}

interface IGeometryVisitor
{
    void VisitCircle(Circle circle);
    void VisitSquare(Square square);
}

class AreaCalculator : IGeometryVisitor
{
    public void VisitCircle(Circle circle)
    {
        Console.WriteLine("Calculating area of Circle");
    }

    public void VisitSquare(Square square)
    {
        Console.WriteLine("Calculating area of Square");
    }
}

class ShapeClient
{
    static void Main()
    {
        var geometryShapes = new List<IGeometry> { new Circle(), new Square() };
        var areaCalculator = new AreaCalculator();

        foreach (var geometryShape in geometryShapes)
        {
            geometryShape.Accept(areaCalculator);
        }
    }
}
