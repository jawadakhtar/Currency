using Xunit;
using Domain;
using System.Diagnostics;

namespace Domin.Tests
{
    public class CurrencyTest
    {
        [Theory]
        [InlineData(100, "One Hundred Dollors and Zero Cents")]
        [InlineData(1, "One Dollor and Zero Cents")]
        [InlineData(10023.23, "Ten Thousand Twenty Three Dollors and Twenty Three Cents")]
        [InlineData(90000.01, "Ninety Thousand Dollors and One Cent")]
        [InlineData(123000000.29, "One Hundred Twenty Three Million Dollors and Twenty Nine Cents")]
        public void Test_ToString_CurrencyInWords(decimal aCurrency, string aInWords)
        {
            Currency currency = new Currency(aCurrency);
            string inWords = currency.ToString();
            Assert.Equal(inWords, aInWords);
        }


        /// <summary>
        /// CPU profiling in unit test are very slow. Here it is just to make sure that any change in currency logic won't make it exceptionally slow without notice. 
        /// Any such changes should not be deployed on to Production
        /// </summary>
        [Fact]
        public void Profiling_ToString_CurrencyInWords()
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();
            int totalCurrencies = 1000000;
            for (int i = 0; i <= totalCurrencies; i++)
            {
                decimal value = (decimal)(random.Next(int.MaxValue) + random.NextDouble());

                stopwatch.Start();

                Currency currency = new Currency(value);
                string inWords = currency.ToString();

                stopwatch.Stop();
            }
            Assert.True(stopwatch.ElapsedMilliseconds < 2000, "Total time taken by " + totalCurrencies + " Currency::ToString() is " + stopwatch.ElapsedMilliseconds + " (ms)");
        }
    }
}