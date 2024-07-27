using PrimeFactorsLib;

namespace PrimeFactorsLibUnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(4, "2 x 2")]
        [InlineData(7, "7")]
        [InlineData(30, "5 x 3 x 2")]
        public void TestPrimeFactors(int number, string expected)
        {
            // Act
            string actual = PrimeFactors.Calc(number);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
