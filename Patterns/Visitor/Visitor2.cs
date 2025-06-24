using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor.Better
{
    // Visitor interface
    public interface IVisitor
    {
        void Visit(Text text);
        void Visit(Image image);
        void Visit(Table table);
        void Visit(CodeBlock code);
    }

    // Element interface
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Concrete elements
    public class Text : IElement
    {
        public string Content { get; } = "Hello, visitor!";
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class Image : IElement
    {
        public string Path { get; } = "photo.jpg";
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class Table : IElement
    {
        public int Rows => 3;
        public int Columns => 2;
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    public class CodeBlock : IElement
    {
        public string Language => "C#";
        public string Code => "Console.WriteLine(\"Hello\");";
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }

    // Concrete visitor
    public class RenderVisitor : IVisitor
    {
        public void Visit(Text text) => Console.WriteLine($"Rendering text: {text.Content}");
        public void Visit(Image image) => Console.WriteLine($"Rendering image from {image.Path}");
        public void Visit(Table table) => Console.WriteLine($"Rendering table: {table.Rows} rows x {table.Columns} columns");
        public void Visit(CodeBlock code) => Console.WriteLine($"Rendering {code.Language} code: {code.Code}");
    }

    // Demo
    public static class Demo
    {
        public static void Run()
        {
            var doc = new List<IElement>
            {
                new Text(),
                new Image(),
                new Table(),
                new CodeBlock()
            };

            IVisitor renderer = new RenderVisitor();

            foreach (var part in doc)
                part.Accept(renderer);
        }
    }
}
