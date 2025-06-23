using System;

namespace DesignPatterns.Adapter
{
    // Adaptee
    public class LegacyPrinter
    {
        public void PrintOld(string text) => Console.WriteLine(text);
    }

    // Target interface
    public interface IPrinter
    {
        void Print(string message);
    }

    // Adapter
    public class PrinterAdapter : IPrinter
    {
        private readonly LegacyPrinter _legacy = new LegacyPrinter();
        public void Print(string message) => _legacy.PrintOld(message);
    }

    public static class Demo
    {
        public static void Run()
        {
            IPrinter printer = new PrinterAdapter();
            printer.Print("Adapter works");
        }
    }
}
