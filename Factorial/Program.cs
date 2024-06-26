namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Let's calculate factorial! Enter a valid number: ");
                bool isInt = int.TryParse(Console.ReadLine(), out int number);
                if (isInt)
                {
                    int factorial = Factorial(number);
                    Console.WriteLine($"Factorial {number} is {factorial:N0}");
                }
                else
                {
                    Console.WriteLine("Can't parse a number :C");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Factorial 5 = 5*4*3*2*1 = 120
        // Factorial(3) = 3 * Factorial(2)
        // Factorial(2) = 2 * Factorial(1)
        // Factorial(1) = 1

        static int Factorial(int number)
        {
            checked
            {
                return number < 2 ? 1 : number * Factorial(number - 1);
            }
        }
    }
}
