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

            Console.ReadKey();
        }

        private static async Task TryItOut(string apiKey)
        {
            var alphaVantage = new AlphaVantage(apiKey);

            var customData = await alphaVantage.Custom()
                .Set("symbol", "MSFT")
                .Set("function", "TIME_SERIES_INTRADAY")
                .Set("interval", "60min")
                .Set("outputsize", "compact")
                .Set("apikey", "")
                .GetRawDataAsync();

            var fxData = await alphaVantage.Fx.IntraDay("EUR", "USD")
                .SetInterval(Interval.Daily)
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            var stockData = await alphaVantage.Stocks.Daily("MSFT")
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            var technicalData = await alphaVantage.Technicals.SimpleMovingAverage("MSFT")
                .SetInterval(Interval.Daily)
                .SetTimePeriod(200)
                .SetSeriesType(SeriesType.Close)
                .GetAsync();
        }
    }
}
