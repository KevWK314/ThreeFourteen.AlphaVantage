using System;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Parameters;

namespace ThreeFourteen.AlphaVantage.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Environment.GetEnvironmentVariable("AlphaVantageApiKey", EnvironmentVariableTarget.User);
            var alphaVantage = new AlphaVantage();

            //var data = AlphaVantage.Custom("MSFT")
            //    .Set("function", "TIME_SERIES_INTRADAY")
            //    .Set("interval", "60min")
            //    .Set("outputsize", "compact")
            //    .Set("apikey", "")
            //    .GetRawDataAsync().Result;

            //Console.WriteLine(data);


            alphaVantage.Configure(x => x.ApiKey = key);

            //var timeseries = alphaVantage.TimeSeriesIntraDay("MSFT")
            //    .SetInterval(Interval.SixtyMinutes)
            //    .SetOutputSize(OutputSize.Full)
            //    .GetAsync().Result;

            var timeseries = alphaVantage.TimeSeriesWeeklyAdjusted("MSFT")
                .GetAsync().Result;

            Console.WriteLine(timeseries.Meta["Information"]);        

            Console.ReadKey();
        }
    }
}
