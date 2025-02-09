namespace SingleInstanceApplication;

delegate void Printer(string msg);

internal class Counter
{
    public event Printer? Printers;

    public int Count { get; private set; }

    public Counter IncreaseByValue(int value)
    {
        Count += value;
        Printers?.Invoke($"Counter incresed by {value}, count is {Count}");
        return this;
    }

    public Counter Increase()
    {
        Count += 1;
        Printers?.Invoke($"Count increased, count is {Count}");
        return this;
    }

    public Counter Decrease()
    {
        Count -= 1;
        Printers?.Invoke($"Count decreased, count is {Count}");
        return this;
    }
}
