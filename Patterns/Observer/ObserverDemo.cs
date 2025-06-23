using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    public interface IObserver { void Update(int value); }

    public class Subject
    {
        private readonly List<IObserver> observers = new();
        private int state;
        public void Attach(IObserver o) => observers.Add(o);
        public void SetState(int value)
        {
            state = value;
            foreach (var o in observers) o.Update(state);
        }
    }

    public class ConcreteObserver : IObserver
    {
        private readonly string name;
        public ConcreteObserver(string name) => this.name = name;
        public void Update(int value) => Console.WriteLine($"{name} got {value}");
    }

    public static class Demo
    {
        public static void Run()
        {
            var subject = new Subject();
            subject.Attach(new ConcreteObserver("A"));
            subject.Attach(new ConcreteObserver("B"));
            subject.SetState(5);
        }
    }
}
