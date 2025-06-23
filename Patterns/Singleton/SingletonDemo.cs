using System;

namespace DesignPatterns.Singleton
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
        public static Singleton Instance => _instance;
        private Singleton() { }
        public void Hello() => Console.WriteLine("Hello from singleton");
    }

    public static class Demo
    {
        public static void Run()
        {
            Singleton.Instance.Hello();
        }
    }
}
