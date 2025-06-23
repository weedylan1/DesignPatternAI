using System;

namespace DesignPatterns.FactoryMethod
{
    // Product
    public interface IAnimal
    {
        void Speak();
    }

    // Concrete products
    public class Dog : IAnimal
    {
        public void Speak() => Console.WriteLine("Woof");
    }

    public class Cat : IAnimal
    {
        public void Speak() => Console.WriteLine("Meow");
    }

    // Creator
    public abstract class AnimalCreator
    {
        public abstract IAnimal Create();
    }

    // Concrete creators
    public class DogCreator : AnimalCreator
    {
        public override IAnimal Create() => new Dog();
    }

    public class CatCreator : AnimalCreator
    {
        public override IAnimal Create() => new Cat();
    }

    public static class Demo
    {
        public static void Run()
        {
            AnimalCreator creator = new DogCreator();
            var animal = creator.Create();
            animal.Speak();
        }
    }
}
