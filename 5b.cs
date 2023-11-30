using System;

interface IPaymentMethod
{
    void ProcessPayment(float amount);
}

class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount:C}");
    }
}

class PayPalPayment : IPaymentMethod
{
    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount:C}");
    }
}

class ShoppingCart
{
    private IPaymentMethod paymentMethod;

    public void SetPaymentMethod(IPaymentMethod method)
    {
        paymentMethod = method;
    }

    public void Checkout(float totalAmount)
    {
        paymentMethod.ProcessPayment(totalAmount);
    }
}

class Program
{
    static void Main()
    {
        var shoppingCart = new ShoppingCart();

        var creditCardPayment = new CreditCardPayment();
        shoppingCart.SetPaymentMethod(creditCardPayment);
        shoppingCart.Checkout(100.50f);

        Console.WriteLine();

        var payPalPayment = new PayPalPayment();
        shoppingCart.SetPaymentMethod(payPalPayment);
        shoppingCart.Checkout(75.25f);
    }
}
