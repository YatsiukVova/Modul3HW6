using System;
using System.Collections.Generic;

namespace Modul3HW6.Patterns
{
   public class Subscriber
    {
        private readonly Queue<int> _someQueue;

        public Subscriber(Queue<int> queue)
        {
            _someQueue = queue;
        }

        public void Read()
        {
            if (_someQueue.Count > 0)
            {
                Console.Write("Flowing queue ");
                foreach (var item in _someQueue)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
                var res = _someQueue.Dequeue();
                Console.WriteLine($"It was read {res}");
            }
            else
            {
                Console.WriteLine($"Is empty");
            }
        }
    }
}
