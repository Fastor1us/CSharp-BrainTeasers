using System.Diagnostics;

namespace DeadLock
{
    internal class Program
    {
        static long _counter = 0;
        const int THREADS_TO_START = 2;
        static readonly object _lockA = new();
        static readonly object _lockB = new();

        static void Main(string[] args)
        {
            Console.WriteLine("The program is running...");
            var stopwatch = Stopwatch.StartNew();

            var threads = new Thread[THREADS_TO_START];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new(i % 2 != 0 ? ThreadProcA : ThreadProcB)
                {
                    IsBackground = true,
                    Name = $"Thread #{i:00}"
                };
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++) threads[i].Join();

            stopwatch.Stop();
            Console.WriteLine($"Program was running {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"counter is {_counter}");
        }

        static void ThreadProcA()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_lockA)
                {
                    lock (_lockB)
                    {
                        _counter++;
                    }
                }
            }

            Console.WriteLine($"Thread #{Thread.CurrentThread.Name} is done");
        }

        static void ThreadProcB()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_lockB)
                {
                    lock (_lockA)
                    {
                        _counter++;
                    }
                }
            }
            Console.WriteLine($"Thread #{Thread.CurrentThread.Name} is done");
        }
    }
}
