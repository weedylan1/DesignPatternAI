using System;

namespace DesignPatterns.TemplateMethod
{
    public abstract class Game
    {
        public void Play()
        {
            Start();
            End();
        }
        protected abstract void Start();
        protected abstract void End();
    }

    public class Chess : Game
    {
        protected override void Start() => Console.WriteLine("Start Chess");
        protected override void End() => Console.WriteLine("End Chess");
    }

    public static class Demo
    {
        public static void Run()
        {
            Game game = new Chess();
            game.Play();
        }
    }
}
