using System;
using System.Reflection;

class Program
{
    static string optioninput = "";
    static void Main(string[] args)
    {
        while (optioninput.Length == 0)
        {
            Console.WriteLine("Specify a pattern name. Available options:");
            foreach (var d in typeof(Program).Assembly.GetTypes())
            {
                if (d.Name == "Demo" && d.Namespace?.StartsWith("DesignPatterns") == true)
                {
                    Console.WriteLine("- " + d.Namespace?.Substring("DesignPatterns.".Length));
                }
            }
            optioninput = Console.ReadLine();
            // return;
        }

        var pattern = optioninput;
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
