using Modul3HW6.Patterns;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Modul3HW6
{
   public class Starter
    {
        public void Run()
        {
            var mutex = new Mutex();
            var queue = new Queue<int>();
            var subscr = new Subscriber(queue);
            var firstPublisher = new Publisher(7, queue, mutex);
            var secondPublisher = new Publisher(12, queue, mutex);

            var firstTask = Task.Run(() =>
            {
                while (true)
                {
                    firstPublisher.Write();
                    Thread.Sleep(1000);
                }
            });

            var secondTask = Task.Run(() =>
            {
                while (true)
                {
                    secondPublisher.Write();
                    Thread.Sleep(1000);
                }
            });

            var read = Task.Run(() =>
            {
                while (true)
                {
                    subscr.Read();
                    Thread.Sleep(200);
                }
            });

            var tasksList = new List<Task>();
            tasksList.Add(firstTask);
            tasksList.Add(secondTask);
            tasksList.Add(read);
            Task.WaitAll(tasksList.ToArray());
        }
    }
}
