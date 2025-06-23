using System;
using System.Collections.Generic;

namespace DesignPatterns.Command
{
    // Command interface
    public interface ICommand
    {
        void Execute();
    }

    // Receiver
    public class Light
    {
        public void On() => Console.WriteLine("Light on");
        public void Off() => Console.WriteLine("Light off");
    }

    // Concrete commands
    public class LightOnCommand : ICommand
    {
        private readonly Light _light;
        public LightOnCommand(Light light) => _light = light;
        public void Execute() => _light.On();
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;
        public LightOffCommand(Light light) => _light = light;
        public void Execute() => _light.Off();
    }

    // Invoker
    public class Remote
    {
        private readonly IList<ICommand> _commands = new List<ICommand>();
        public void AddCommand(ICommand cmd) => _commands.Add(cmd);
        public void Run()
        {
            foreach (var c in _commands) c.Execute();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var light = new Light();
            var remote = new Remote();
            remote.AddCommand(new LightOnCommand(light));
            remote.AddCommand(new LightOffCommand(light));
            remote.Run();
        }
    }
}
