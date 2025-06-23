using System;

namespace DesignPatterns.Memento
{
    // Memento
    public class Memento
    {
        public string State { get; }
        public Memento(string state) => State = state;
    }

    // Originator
    public class Editor
    {
        public string Text { get; set; }
        public Memento Save() => new Memento(Text);
        public void Restore(Memento m) => Text = m.State;
    }

    // Caretaker
    public static class Demo
    {
        public static void Run()
        {
            var editor = new Editor { Text = "A" };
            var m = editor.Save();
            editor.Text = "B";
            editor.Restore(m);
            Console.WriteLine(editor.Text); // A
        }
    }
}
