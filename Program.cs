using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Specify a pattern name. Available options:");
            foreach (var d in typeof(Program).Assembly.GetTypes())
            {
                if (d.Name == "Demo" && d.Namespace?.StartsWith("DesignPatterns") == true)
                {
                    Console.WriteLine("- " + d.Namespace?.Substring("DesignPatterns.".Length));
                }
            }
            return;
        }

        var pattern = args[0];
        var type = Type.GetType($"DesignPatterns.{pattern}.Demo");
        if (type == null)
        {
            Console.WriteLine($"Pattern '{pattern}' not found.");
            return;
        }
        var method = type.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
        method?.Invoke(null, null);
    }
}
