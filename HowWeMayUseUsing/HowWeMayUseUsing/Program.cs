namespace HowWeMayUseUsing;

readonly struct ConsoleForegroundContext : IDisposable
{
    private readonly ConsoleColor _previousColor;

    public ConsoleForegroundContext(ConsoleColor color)
    {
        _previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
    }

    public void Dispose()
    {
        Console.ForegroundColor = _previousColor;
    }
}

internal class Program
{
    static ConsoleForegroundContext SwitchForegroundConsoleColor(ConsoleColor color)
    {
        return new ConsoleForegroundContext(color);
    }

    static void Main(string[] args)
    {
        using (SwitchForegroundConsoleColor(ConsoleColor.Red))
        {
            Console.WriteLine("Red");
            using (SwitchForegroundConsoleColor(ConsoleColor.Green))
            {
                Console.WriteLine("Green");
            }
            Console.WriteLine("Red");
        }
        Console.WriteLine("White");
    }
}
