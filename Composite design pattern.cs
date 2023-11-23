using System;
using System.Collections.Generic;

namespace MyCompositePattern
{
    // Component
    interface IGraphic
    {
        void Draw();
    }

    // Leaf
    class Leaf : IGraphic
    {
        private string _graphicName;

        public Leaf(string graphicName)
        {
            _graphicName = graphicName;
        }

        public void Draw()
        {
            Console.WriteLine($"Leaf: {_graphicName} drawn");
        }
    }

    // Composite
    class CompositeGraphic : IGraphic
    {
        private List<IGraphic> _graphics = new List<IGraphic>();

        public void Add(IGraphic graphic)
        {
            _graphics.Add(graphic);
        }

        public void Draw()
        {
            foreach (var graphic in _graphics)
            {
                graphic.Draw();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            IGraphic leaf1 = new Leaf("Circle");
            IGraphic leaf2 = new Leaf("Rectangle");

            CompositeGraphic compositeGraphic = new CompositeGraphic();
            compositeGraphic.Add(leaf1);
            compositeGraphic.Add(leaf2);

            Console.WriteLine("Drawing individual graphics:");
            leaf1.Draw();
            leaf2.Draw();

            Console.WriteLine("\nDrawing composite graphic:");
            compositeGraphic.Draw();
        }
    }
}
