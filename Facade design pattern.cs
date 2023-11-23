using System;

namespace MyFacadePattern
{
    // Subsystem 1
    class OrderProcessingSystem
    {
        public void ProcessOrder()
        {
            Console.WriteLine("OrderProcessingSystem is processing the order");
        }
    }

    // Subsystem 2
    class ShippingSystem
    {
        public void ShipOrder()
        {
            Console.WriteLine("ShippingSystem is shipping the order");
        }
    }

    // Facade
    class OrderProcessingFacade
    {
        private OrderProcessingSystem _orderProcessingSystem;
        private ShippingSystem _shippingSystem;

        public OrderProcessingFacade()
        {
            _orderProcessingSystem = new OrderProcessingSystem();
            _shippingSystem = new ShippingSystem();
        }

        public void ProcessOrderAndShip()
        {
            Console.WriteLine("Order Processing and Shipping using Facade:");
            _orderProcessingSystem.ProcessOrder();
            _shippingSystem.ShipOrder();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            OrderProcessingFacade orderProcessingFacade = new OrderProcessingFacade();
            orderProcessingFacade.ProcessOrderAndShip();
        }
    }
}
