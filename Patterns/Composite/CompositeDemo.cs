using System;
using System.Collections.Generic;

namespace DesignPatterns.Composite
{
    public interface IGraphic
    {
        void Draw();
    }

    public class Circle : IGraphic
    {
        public void Draw() => Console.WriteLine("Drawing Circle");
    }

    public class Group : IGraphic
    {
        private readonly List<IGraphic> _children = new List<IGraphic>();
        public void Add(IGraphic graphic) => _children.Add(graphic);
        public void Draw()
        {
            foreach (var child in _children) child.Draw();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var group = new Group();
            group.Add(new Circle());
            group.Add(new Circle());
            group.Draw();
        }
    }
}
