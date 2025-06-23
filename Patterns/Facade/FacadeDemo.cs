using System;

namespace DesignPatterns.Facade
{
    // Complex subsystem
    public class CPU { public void Freeze() => Console.WriteLine("CPU Freeze"); }
    public class Memory { public void Load(string data) => Console.WriteLine($"Load {data}"); }
    public class HardDrive { public string Read() => "OS"; }

    // Facade
    public class Computer
    {
        private readonly CPU cpu = new CPU();
        private readonly Memory memory = new Memory();
        private readonly HardDrive hd = new HardDrive();

        public void Start()
        {
            cpu.Freeze();
            memory.Load(hd.Read());
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var computer = new Computer();
            computer.Start();
        }
    }
}
