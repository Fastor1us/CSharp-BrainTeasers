using System.Collections.Concurrent;

namespace BlockingQueue;

internal class Program
{
    static void Main(string[] args)
    {
        var q = new BlockingQueue<Action>();

        var t = new Thread(ProcessingThread)
        {
            IsBackground = true,
        };
        t.Start(q);

        Thread.Sleep(15000);

        q.Enqueue(() =>
        {
            Thread.Sleep(3000);
            Console.WriteLine("Action completed");
        });

        Console.WriteLine("Main thread is free");
        Console.ReadKey(true);

        //ThreadPool.QueueUserWorkItem(_ =>
        //{
        //    Thread.Sleep(3000);
        //    Console.WriteLine("Action completed");
        //});

        //ConcurrentQueue<string> q2 = new();
        //if (!q2.TryDequeue(out var item)) { }
    }

    private static void ProcessingThread(object? obj)
    {
        if (obj is not BlockingQueue<Action> q) throw new Exception();

        while (true)
        {
            var action = q.Dequeue();
            action();
        }
    }
}
