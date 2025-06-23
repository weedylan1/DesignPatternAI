using System;

namespace DesignPatterns.Builder
{
    // Product
    public class Sandwich
    {
        public string Bread { get; set; }
        public string Filling { get; set; }

        public void Show() => Console.WriteLine($"Sandwich with {Bread} and {Filling}");
    }

    // Builder interface
    public interface ISandwichBuilder
    {
        void AddBread();
        void AddFilling();
        Sandwich Build();
    }

    // Concrete builder
    public class HamSandwichBuilder : ISandwichBuilder
    {
        private readonly Sandwich _sandwich = new Sandwich();
        public void AddBread() => _sandwich.Bread = "White bread";
        public void AddFilling() => _sandwich.Filling = "Ham";
        public Sandwich Build() => _sandwich;
    }

    // Director
    public class SandwichDirector
    {
        public Sandwich Make(ISandwichBuilder builder)
        {
            builder.AddBread();
            builder.AddFilling();
            return builder.Build();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var director = new SandwichDirector();
            var sandwich = director.Make(new HamSandwichBuilder());
            sandwich.Show();
        }
    }
}
