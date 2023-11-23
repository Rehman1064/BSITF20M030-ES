using System;

namespace MyDecoratorPattern
{
    // Component
    interface IWidget
    {
        void Display();
    }

    // Concrete Component
    class BasicWidget : IWidget
    {
        public void Display()
        {
            Console.WriteLine("BasicWidget Display");
        }
    }

    // Decorator
    abstract class Decorator : IWidget
    {
        protected IWidget _widget;

        protected Decorator(IWidget widget)
        {
            _widget = widget;
        }

        public virtual void Display()
        {
            _widget.Display();
        }
    }

    class Program
    {
        // Concrete Decorator 1
        class BorderDecorator : Decorator
        {
            public BorderDecorator(IWidget widget) : base(widget) { }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("BorderDecorator Display");
            }
        }

        // Concrete Decorator 2
        class ScrollDecorator : Decorator
        {
            public ScrollDecorator(IWidget widget) : base(widget) { }

            public override void Display()
            {
                base.Display();
                Console.WriteLine("ScrollDecorator Display");
            }
        }

        static void Main(string[] args)
        {
            // Example usage
            IWidget basicWidget = new BasicWidget();
            IWidget widgetWithBorder = new BorderDecorator(basicWidget);
            IWidget widgetWithScrollAndBorder = new ScrollDecorator(widgetWithBorder);

            Console.WriteLine("Displaying Basic Widget:");
            basicWidget.Display();

            Console.WriteLine("\nDisplaying Widget with Border:");
            widgetWithBorder.Display();

            Console.WriteLine("\nDisplaying Widget with Scroll and Border:");
            widgetWithScrollAndBorder.Display();
        }
    }
}
