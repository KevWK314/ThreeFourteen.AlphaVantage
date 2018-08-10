using System;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Response;

namespace ThreeFourteen.AlphaVantage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Environment.GetEnvironmentVariable("AlphaVantageApiKey", EnvironmentVariableTarget.User);

            //var data = AlphaVantage.Custom("MSFT")
            //    .Set("function", "TIME_SERIES_INTRADAY")
            //    .Set("interval", "60min")
            //    .Set("outputsize", "compact")
            //    .Set("apikey", "")
            //    .GetRawDataAsync().Result;

            //Console.WriteLine(data);


            AlphaVantage.Configure(x => x.ApiKey = key);

            var timeseries = AlphaVantage.TimeSeriesIntraDay("MSFT")
                .SetInterval(Interval.FiveMinutes)
                .SetOutputSize(OutputSize.Compact)
                .GetRawDataAsync().Result;

            Console.WriteLine(timeseries);        

            Console.ReadKey();
        }
    }
}
