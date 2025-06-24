using System;
using System.Collections.Generic;

namespace DesignPatterns.Composite.Advanced
{
    // Component interface
    public interface IFileSystemItem
    {
        string Name { get; }
        void Display(int indent = 0);
    }

    // Leaf
    public class File : IFileSystemItem
    {
        public string Name { get; }

        public File(string name) => Name = name;

        public void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}- {Name}");
        }
    }

    // Composite
    public class Folder : IFileSystemItem
    {
        public string Name { get; }
        private readonly List<IFileSystemItem> _children = new();

        public Folder(string name) => Name = name;

        public void Add(IFileSystemItem item) => _children.Add(item);

        public void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}+ {Name}/");
            foreach (var child in _children)
                child.Display(indent + 2);
        }
    }

    // Demo
    public static class Demo
    {
        public static void Run()
        {
            var root = new Folder("root");
            root.Add(new File("readme.txt"));
            root.Add(new File("setup.exe"));

            var src = new Folder("src");
            src.Add(new File("main.cs"));
            src.Add(new File("utils.cs"));

            var assets = new Folder("assets");
            assets.Add(new File("logo.png"));

            root.Add(src);
            root.Add(assets);

            root.Display();
        }
    }
}
