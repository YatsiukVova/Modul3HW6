using System;
using System.Collections.Generic;
using System.Threading;

namespace Modul3HW6.Patterns
{
    public class Publisher
    {
        private readonly int _id;
        private readonly Random _random;
        private readonly Mutex _mutex;
        private readonly Queue<int> _queue;

        public Publisher(int id, Queue<int> queue, Mutex mutex)
        {
            _id = id;
            _random = new Random();
            _mutex = mutex;
            _queue = queue;
        }

        public void Write()
        {
            _mutex.WaitOne();
            var upcomingValue = _random.Next(500);

            _queue.Enqueue(upcomingValue);
            Console.WriteLine($" Added element {upcomingValue} id {_id}");
            _mutex.ReleaseMutex();
        }
    }
}
