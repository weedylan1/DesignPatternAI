using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit(Element element);
    }

    public class Element
    {
        public string Name { get; }
        public Element(string name) => Name = name;
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class ConcreteVisitor : IVisitor
    {
        public void Visit(Element element) => Console.WriteLine($"Visited {element.Name}");
    }

    public static class Demo
    {
        public static void Run()
        {
            var elements = new List<Element> { new Element("A"), new Element("B") };
            var visitor = new ConcreteVisitor();
            foreach (var e in elements) e.Accept(visitor);
        }
    }
}
