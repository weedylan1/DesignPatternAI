using System;
using System.Collections.Generic;

namespace DesignPatterns.Interpreter
{
    public interface IExpression
    {
        int Interpret(Dictionary<string, int> context);
    }

    public class Number : IExpression
    {
        private readonly int _value;
        public Number(int value) => _value = value;
        public int Interpret(Dictionary<string, int> context) => _value;
    }

    public class Variable : IExpression
    {
        private readonly string _name;
        public Variable(string name) => _name = name;
        public int Interpret(Dictionary<string, int> context) => context[_name];
    }

    public class Add : IExpression
    {
        private readonly IExpression _left, _right;
        public Add(IExpression left, IExpression right) { _left = left; _right = right; }
        public int Interpret(Dictionary<string, int> context) => _left.Interpret(context) + _right.Interpret(context);
    }

    public static class Demo
    {
        public static void Run()
        {
            var context = new Dictionary<string, int> { ["x"] = 2 };
            IExpression expr = new Add(new Variable("x"), new Number(3));
            Console.WriteLine(expr.Interpret(context)); // 5
        }
    }
}
