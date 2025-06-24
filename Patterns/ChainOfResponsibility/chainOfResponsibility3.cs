using System;

namespace DesignPatterns.ChainOfResponsibility.Numbers
{
    public abstract class NumberHandler
    {
        protected NumberHandler Next { get; private set; }

        public NumberHandler SetNext(NumberHandler next)
        {
            Next = next;
            return next;
        }

        public void Handle(int number)
        {
            if (!Process(number) && Next != null)
                Next.Handle(number);
        }

        // Return true if handled
        protected abstract bool Process(int number);
    }

    public class NegativeHandler : NumberHandler
    {
        protected override bool Process(int number)
        {
            if (number < 0)
            {
                Console.WriteLine($"NegativeHandler: {number} is negative");
                return true;
            }
            return false;
        }
    }

    public class DivisibleByThreeHandler : NumberHandler
    {
        protected override bool Process(int number)
        {
            if (number % 3 == 0)
            {
                Console.WriteLine($"DivisibleByThreeHandler: {number} is divisible by 3");
                return true;
            }
            return false;
        }
    }

    public class PrimeHandler : NumberHandler
    {
        protected override bool Process(int number)
        {
            if (IsPrime(number))
            {
                Console.WriteLine($"PrimeHandler: {number} is a prime number");
                return true;
            }
            return false;
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i * i <= n; i += 2)
                if (n % i == 0) return false;

            return true;
        }
    }

    public class DefaultHandler : NumberHandler
    {
        protected override bool Process(int number)
        {
            Console.WriteLine($"DefaultHandler: {number} does not match any condition");
            return true;
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var pipeline = new NegativeHandler();
            pipeline
                .SetNext(new DivisibleByThreeHandler())
                .SetNext(new PrimeHandler())
                .SetNext(new DefaultHandler());

            int[] testNumbers = { -5, 0, 3, 4, 5, 6, 9, 11, 15, 16 };

            foreach (var num in testNumbers)
            {
                Console.WriteLine($"\nInput: {num}");
                pipeline.Handle(num);
            }
        }
    }
}
