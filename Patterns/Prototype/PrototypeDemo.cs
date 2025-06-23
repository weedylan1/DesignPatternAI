using System;

namespace DesignPatterns.Prototype
{
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract Shape Clone();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override Shape Clone() => (Shape)MemberwiseClone();
    }

    public static class Demo
    {
        public static void Run()
        {
            var original = new Rectangle { X = 1, Y = 2, Width = 3, Height = 4 };
            var clone = (Rectangle)original.Clone();
            Console.WriteLine($"Clone: {clone.X},{clone.Y},{clone.Width},{clone.Height}");
        }
    }
}
