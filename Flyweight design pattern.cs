using System;
using System.Collections.Generic;

namespace MyFlyweightPattern
{
    // Flyweight interface
    interface IDrawableShape
    {
        void Draw(int x, int y);
    }

    // Concrete Flyweight
    class ColoredCircle : IDrawableShape
    {
        private string _color;

        public ColoredCircle(string color)
        {
            _color = color;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing a {_color} circle at ({x}, {y})");
        }
    }

    // Flyweight Factory
    class DrawableShapeFactory
    {
        private Dictionary<string, IDrawableShape> _shapes = new Dictionary<string, IDrawableShape>();

        public IDrawableShape GetColoredCircle(string color)
        {
            if (!_shapes.TryGetValue(color, out IDrawableShape coloredCircle))
            {
                coloredCircle = new ColoredCircle(color);
                _shapes.Add(color, coloredCircle);
            }

            return coloredCircle;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            DrawableShapeFactory shapeFactory = new DrawableShapeFactory();

            IDrawableShape redCircle = shapeFactory.GetColoredCircle("Red");
            redCircle.Draw(10, 15);

            IDrawableShape blueCircle = shapeFactory.GetColoredCircle("Blue");
            blueCircle.Draw(30, 40);

            IDrawableShape redCircleAgain = shapeFactory.GetColoredCircle("Red");
            redCircleAgain.Draw(50, 60);
        }
    }
}
