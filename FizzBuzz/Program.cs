namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                bool isFizz = i % 3 == 0;
                bool isBuzz = i % 5 == 0;
                Console.Write(
                    $"{(isFizz ? "Fizz" : String.Empty)}" +
                    $"{(isBuzz ? "Buzz" : String.Empty)}" +
                    $"{(!(isFizz || isBuzz) ? i : String.Empty)}" +
                    $"{(i < 100 ? ", " : String.Empty)}"
                );
            }
        }
    }
}
