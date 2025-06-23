using System;

namespace DesignPatterns.Bridge
{
    // Implementor
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    // Concrete implementors
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius) => Console.WriteLine($"Raster circle of radius {radius}");
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius) => Console.WriteLine($"Vector circle of radius {radius}");
    }

    // Abstraction
    public abstract class Shape
    {
        protected readonly IRenderer renderer;
        protected Shape(IRenderer renderer) => this.renderer = renderer;
        public abstract void Draw();
    }

    // Refined abstraction
    public class Circle : Shape
    {
        private readonly float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer) => this.radius = radius;
        public override void Draw() => renderer.RenderCircle(radius);
    }

    public static class Demo
    {
        public static void Run()
        {
            var shape = new Circle(new RasterRenderer(), 5);
            shape.Draw();
        }
    }
}
