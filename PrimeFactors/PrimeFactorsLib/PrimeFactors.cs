namespace PrimeFactorsLib
{
  public static class PrimeFactors
  {
    public static string Calc(int number, string res = "")
    {
      if (number == 1) return "1";
      for (int i = 2; i < number; i++)
      {
        if (i == number) return number.ToString();
        if (number % i == 0)
        {
          return Calc(number / i, AddNumberToResString(i, res));
        }
      }
      return AddNumberToResString(number, res);
    }
    private static string AddNumberToResString(int number, string res)
    {
      if (res.Length > 0)
      {
        return number.ToString() + " x " + res;
      }
      return number.ToString();
    }
  }
}
