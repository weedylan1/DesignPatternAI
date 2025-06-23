using System;
using System.Collections.Generic;

namespace DesignPatterns.Strategy
{
    public interface ISortStrategy
    {
        void Sort(List<int> list);
    }

    public class BubbleSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Bubble sort");
            list.Sort();
        }
    }

    public class QuickSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Quick sort");
            list.Sort();
        }
    }

    public class Sorter
    {
        private ISortStrategy strategy;
        public Sorter(ISortStrategy strategy) => this.strategy = strategy;
        public void SetStrategy(ISortStrategy strategy) => this.strategy = strategy;
        public void Sort(List<int> list) => strategy.Sort(list);
    }

    public static class Demo
    {
        public static void Run()
        {
            var sorter = new Sorter(new BubbleSort());
            sorter.Sort(new List<int> {3,1,2});
            sorter.SetStrategy(new QuickSort());
            sorter.Sort(new List<int> {3,1,2});
        }
    }
}
