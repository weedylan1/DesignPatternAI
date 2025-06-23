using System;

namespace DesignPatterns.Proxy
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string filename;
        public RealImage(string filename)
        {
            this.filename = filename;
            LoadFromDisk();
        }
        private void LoadFromDisk() => Console.WriteLine($"Loading {filename}");
        public void Display() => Console.WriteLine($"Displaying {filename}");
    }

    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private readonly string filename;
        public ProxyImage(string filename) => this.filename = filename;
        public void Display()
        {
            realImage ??= new RealImage(filename);
            realImage.Display();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            IImage img = new ProxyImage("photo.jpg");
            img.Display();
            img.Display();
        }
    }
}
