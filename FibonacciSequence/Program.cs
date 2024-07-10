using System.Globalization;

namespace FibonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In mathematics, the Fibonacci sequence is a sequence
            // in which each number is the sum of the two preceding ones
            // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 and so on
            // F(0) = 0
            // F(1) = 1
            // F(n) = F(n-1) + F(n-2)
            // n = 2
            // F(2) = F(1) + F(0) = 1 + 0 = 1
            // n = 3
            // F(3) = F(2) + F(1) = 1 + 1 = 2
            // n = 4
            // F(4) = F(3) + F(2) = 2 + 1 = 3
            // n = 5
            // F(5) = F(4) + F(3) = 3 + 2 = 5

            Console.WriteLine(
                "It is a calculator for the Nth order of Fibonacci's sequence"
            );
            Console.Write("Now, write a number of N: ");

            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Error! The input isn't a valid integer");
                return;
            }

            try
            {
                Console.WriteLine(
                    "The {0} number in the Fibonacci sequence is {1}",
                    CardinalToOrdinal.Convert(n),
                    FibonacciSequence(n).ToString("N0", new CultureInfo("en-US"))
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static readonly Dictionary<int, long> cache = [];

        static long FibonacciSequence(int n)
        {
            checked
            {
                if (n == 1 || n == 2) return 1;

                if (!cache.TryGetValue(n, out long value))
                {
                    value = FibonacciSequence(n - 1) + FibonacciSequence(n - 2);
                    cache[n] = value;
                }

                return value;
            }
        }
    }
}
