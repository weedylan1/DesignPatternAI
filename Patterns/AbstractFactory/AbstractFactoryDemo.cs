using System;

namespace DesignPatterns.AbstractFactory
{
    // Abstract product
    public interface IButton
    {
        void Render();
    }

    // Concrete products
    public class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("Render Windows button");
    }

    public class MacButton : IButton
    {
        public void Render() => Console.WriteLine("Render Mac button");
    }

    // Abstract factory
    public interface IGUIFactory
    {
        IButton CreateButton();
    }

    // Concrete factories
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
    }

    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacButton();
    }

    // Client
    public static class Demo
    {
        public static void Run()
        {
            IGUIFactory factory = new WindowsFactory();
            var button = factory.CreateButton();
            button.Render();
        }
    }
}
