namespace BlockingQueue;

class BlockingQueue<T>
{
    private readonly object _lock = new();
    private readonly Queue<T> _queue = new();

    public void Enqueue(T value)
    {
        Monitor.Enter(_lock);
        try
        {
            _queue.Enqueue(value);
            if (_queue.Count == 1)
            {
                Monitor.Pulse(_lock);
            }
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }

    public T Dequeue()
    {
        Monitor.Enter(_lock);
        try
        {
            while (_queue.Count == 0)
            {
                Monitor.Wait(_lock);
            }
            return _queue.Dequeue();
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }
}
