using System;

namespace DesignPatterns.State
{
    public interface IState
    {
        void Handle(Context context);
    }

    public class Context
    {
        public IState State { get; set; }
        public Context(IState state) => State = state;
        public void Request() => State.Handle(this);
    }

    public class StateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State A handling");
            context.State = new StateB();
        }
    }

    public class StateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("State B handling");
            context.State = new StateA();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var context = new Context(new StateA());
            context.Request();
            context.Request();
        }
    }
}
