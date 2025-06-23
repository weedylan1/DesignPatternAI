using System;

namespace DesignPatterns.Decorator
{
    public interface IMessage
    {
        string GetContent();
    }

    public class TextMessage : IMessage
    {
        private readonly string _text;
        public TextMessage(string text) => _text = text;
        public string GetContent() => _text;
    }

    public abstract class MessageDecorator : IMessage
    {
        protected readonly IMessage message;
        protected MessageDecorator(IMessage message) => this.message = message;
        public abstract string GetContent();
    }

    public class HtmlDecorator : MessageDecorator
    {
        public HtmlDecorator(IMessage message) : base(message) { }
        public override string GetContent() => $"<p>{message.GetContent()}</p>";
    }

    public static class Demo
    {
        public static void Run()
        {
            IMessage msg = new HtmlDecorator(new TextMessage("Hello"));
            Console.WriteLine(msg.GetContent());
        }
    }
}
