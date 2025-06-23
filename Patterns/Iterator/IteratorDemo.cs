using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class Numbers : IEnumerable<int>
    {
        private readonly int[] _data = { 1, 2, 3 };
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var i in _data) yield return i;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class Demo
    {
        public static void Run()
        {
            foreach (var n in new Numbers())
                Console.WriteLine(n);
        }
    }
}
