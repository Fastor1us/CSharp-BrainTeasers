namespace SingleInstanceApplication;

internal class Program
{
    static void Main(string[] args)
    {
        // Single Instance Application
        using (new Mutex(true, @"Global\M", out var createdNew))
        {
            if (!createdNew) return;

            var counter = new Counter();

            counter.Printers += PrintToConsole;
            counter
                .Increase()
                .Increase()
                .Decrease()
                .IncreaseByValue(10);

            Console.ReadKey();
        }
    }

    private static void PrintToConsole(string msg)
    {
        Console.WriteLine(msg);
    }
}

