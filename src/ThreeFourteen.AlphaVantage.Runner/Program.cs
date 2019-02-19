using System;
using System.Threading.Tasks;

namespace ThreeFourteen.AlphaVantage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = Environment.GetEnvironmentVariable("AlphaVantageApiKey", EnvironmentVariableTarget.User);

            TryItOut(apiKey).Wait();

            Console.WriteLine("All done.");
            Console.ReadKey();
        }

        private static async Task TryItOut(string apiKey)
        {
            var alphaVantage = new AlphaVantage(apiKey);


            Console.WriteLine("Get Exchange Rate");
            var exchangeRate = await alphaVantage.Fx.ExchangeRate("EUR", "GBP")
                .GetAsync();

            Console.WriteLine("Get FX");
            var fxData = await alphaVantage.Fx.IntraDay("EUR", "USD")
                .SetInterval(Interval.FifteenMinutes)
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            Console.WriteLine("Get Stock");
            var stockData = await alphaVantage.Stocks.Daily("MSFT")
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            Console.WriteLine("Get Crypto");
            var cryptoData = await alphaVantage.Cryptos.Daily("BTC", "GBP")
                .GetAsync();

            Console.WriteLine("Get Technical");
            var technicalData = await alphaVantage.Technicals.SimpleMovingAverage("MSFT")
                .SetInterval(Interval.Daily)
                .SetTimePeriod(200)
                .SetSeriesType(SeriesType.Close)
                .GetAsync();

            Console.WriteLine("Get Custom");
            var customData = await alphaVantage.Custom()
                .Set("symbol", "MSFT")
                .Set("function", "TIME_SERIES_INTRADAY")
                .Set("interval", "60min")
                .Set("outputsize", "compact")
                .GetRawDataAsync();
        }
    }
}
