using System;
using System.Collections.Generic;

namespace DesignPatterns.Flyweight
{
    // Flyweight
    public class Character
    {
        private readonly char _symbol;
        public Character(char symbol) => _symbol = symbol;
        public void Draw() => Console.WriteLine(_symbol);
    }

    // Flyweight factory
    public class CharacterFactory
    {
        private readonly Dictionary<char, Character> _cache = new();
        public Character Get(char c)
        {
            if (!_cache.ContainsKey(c))
                _cache[c] = new Character(c);
            return _cache[c];
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            var factory = new CharacterFactory();
            var a1 = factory.Get('a');
            var a2 = factory.Get('a');
            Console.WriteLine(ReferenceEquals(a1, a2)); // true
        }
    }
}
