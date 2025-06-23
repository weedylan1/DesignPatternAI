using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler Next { get; private set; }
        public Handler SetNext(Handler next) { Next = next; return next; }
        public abstract void Handle(int number);
    }

    public class EvenHandler : Handler
    {
        public override void Handle(int number)
        {
            if (number % 2 == 0) Console.WriteLine($"Even handler processed {number}");
            else Next?.Handle(number);
        }
    }

    public class DefaultHandler : Handler
    {
        public override void Handle(int number) => Console.WriteLine($"Default handler: {number}");
    }

    public static class Demo
    {
        public static void Run()
        {
            var h1 = new EvenHandler();
            var h2 = new DefaultHandler();
            h1.SetNext(h2);
            h1.Handle(5);
            h1.Handle(2);
        }
    }
}
