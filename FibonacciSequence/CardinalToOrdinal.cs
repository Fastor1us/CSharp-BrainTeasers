using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence
{
    internal static class CardinalToOrdinal
    {
        public static string Convert(int cardinalNumber)
        {
            switch (cardinalNumber)
            {
                case 11:
                case 12:
                case 13:
                    return $"{cardinalNumber}th";
                default:
                    int lastDigit = cardinalNumber % 10;

                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{cardinalNumber}{suffix}";
            }
        }
    }
}
