using System;

namespace DesignPatterns.Mediator
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev);
    }

    public abstract class Colleague
    {
        protected IMediator mediator;
        public Colleague(IMediator mediator) => this.mediator = mediator;
    }

    public class Component1 : Colleague
    {
        public Component1(IMediator mediator) : base(mediator) { }
        public void DoA()
        {
            Console.WriteLine("Component1 does A");
            mediator.Notify(this, "A");
        }
        public void DoB() => Console.WriteLine("Component1 reacts to B");
    }

    public class Component2 : Colleague
    {
        public Component2(IMediator mediator) : base(mediator) { }
        public void DoB()
        {
            Console.WriteLine("Component2 does B");
            mediator.Notify(this, "B");
        }
        public void DoA() => Console.WriteLine("Component2 reacts to A");
    }

    public class ConcreteMediator : IMediator
    {
        public Component1 Component1 { get; set; }
        public Component2 Component2 { get; set; }
        public void Notify(Colleague sender, string ev)
        {
            if (ev == "A") Component2.DoA();
            if (ev == "B") Component1.DoB();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var mediator = new ConcreteMediator();
            var c1 = new Component1(mediator);
            var c2 = new Component2(mediator);
            mediator.Component1 = c1;
            mediator.Component2 = c2;
            c1.DoA();
            c2.DoB();
        }
    }
}
