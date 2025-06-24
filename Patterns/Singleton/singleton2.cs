using System;

namespace DesignPatterns.Singleton.Logger
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        public static Logger Instance => _instance;

        private Logger() { }

        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }

    public class OrderService
    {
        public void PlaceOrder()
        {
            Logger.Instance.Log("Order placed.");
        }
    }

    public class PaymentService
    {
        public void ProcessPayment()
        {
            Logger.Instance.Log("Payment processed.");
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var orderService = new OrderService();
            var paymentService = new PaymentService();

            orderService.PlaceOrder();
            paymentService.ProcessPayment();
        }
    }
}
