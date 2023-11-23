using System;

namespace MyBridgePattern
{
    // Renderer Interface
    interface IShapeRenderer
    {
        void RenderEllipse(float horizontalRadius, float verticalRadius);
    }

    // Concrete Renderer 1
    class LineRenderer : IShapeRenderer
    {
        public void RenderEllipse(float horizontalRadius, float verticalRadius)
        {
            Console.WriteLine($"Drawing an ellipse with lines - Horizontal Radius: {horizontalRadius}, Vertical Radius: {verticalRadius}");
        }
    }

    // Concrete Renderer 2
    class DotRenderer : IShapeRenderer
    {
        public void RenderEllipse(float horizontalRadius, float verticalRadius)
        {
            Console.WriteLine($"Drawing an ellipse with dots - Horizontal Radius: {horizontalRadius}, Vertical Radius: {verticalRadius}");
        }
    }

    // Abstraction
    abstract class Shape
    {
        protected IShapeRenderer _shapeRenderer;

        protected Shape(IShapeRenderer shapeRenderer)
        {
            _shapeRenderer = shapeRenderer;
        }

        public abstract void Draw();
    }

    // Refined Abstraction
    class Ellipse : Shape
    {
        private float _horizontalRadius;
        private float _verticalRadius;

        public Ellipse(IShapeRenderer shapeRenderer, float horizontalRadius, float verticalRadius) : base(shapeRenderer)
        {
            _horizontalRadius = horizontalRadius;
            _verticalRadius = verticalRadius;
        }

        public override void Draw()
        {
            _shapeRenderer.RenderEllipse(_horizontalRadius, _verticalRadius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            IShapeRenderer lineRenderer = new LineRenderer();
            Shape ellipseWithLines = new Ellipse(lineRenderer, 5.0f, 3.0f);
            ellipseWithLines.Draw();

            IShapeRenderer dotRenderer = new DotRenderer();
            Shape ellipseWithDots = new Ellipse(dotRenderer, 7.0f, 4.0f);
            ellipseWithDots.Draw();
        }
    }
}
