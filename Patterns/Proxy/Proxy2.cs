using System;
using System.Collections.Generic;

namespace DesignPatterns.Proxy.Door
{
    public interface IDoor
    {
        void Open(string person);
    }

    public class RealDoor : IDoor
    {
        public void Open(string person)
        {
            Console.WriteLine($"🔓 Door opened for {person}");
        }
    }

    public class DoorProxy : IDoor
    {
        private readonly RealDoor _door = new RealDoor();
        private readonly HashSet<string> _authorizedPeople;

        public DoorProxy(IEnumerable<string> authorizedPeople)
        {
            _authorizedPeople = new HashSet<string>(authorizedPeople);
        }

        public void Open(string person)
        {
            if (_authorizedPeople.Contains(person))
            {
                _door.Open(person);
            }
            else
            {
                Console.WriteLine($"⛔ Access denied to {person}");
            }
        }

        // Optional: dynamic modification
        public void Authorize(string person) => _authorizedPeople.Add(person);
        public void Revoke(string person) => _authorizedPeople.Remove(person);
    }

    public static class Demo
    {
        public static void Run()
        {
            var door = new DoorProxy(new[] { "Alice", "Charlie" });

            door.Open("Bob");     // ❌ Denied
            door.Open("Alice");   // ✅ Opened
            door.Open("Charlie"); // ✅ Opened

            // Add a new authorized person at runtime
            ((DoorProxy)door).Authorize("Bob");
            door.Open("Bob");     // ✅ Now allowed
        }
    }
}
