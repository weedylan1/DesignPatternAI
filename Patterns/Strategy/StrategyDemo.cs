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
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
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
