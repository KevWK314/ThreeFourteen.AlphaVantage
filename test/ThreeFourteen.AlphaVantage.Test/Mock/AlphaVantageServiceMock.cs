using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Test.Mock
{
    public class AlphaVantageServiceMock : IAlphaVantageService
    {
        private string _forcedResponseKey;

        public IDictionary<string, string> LatestParameters { get; private set; }

        private static readonly Dictionary<string, string> FileLookup = new Dictionary<string, string>
        {
            // Stock
            { "TIME_SERIES_INTRADAY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesIntraDay.json" },
            { "TIME_SERIES_DAILY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesDaily.json" },
            { "TIME_SERIES_DAILY_ADJUSTED", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesDailyAdjusted.json" },
            { "TIME_SERIES_WEEKLY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesWeekly.json" },
            { "TIME_SERIES_WEEKLY_ADJUSTED", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesWeeklyAdjusted.json" },
            { "TIME_SERIES_MONTHLY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesMonthly.json" },
            { "TIME_SERIES_MONTHLY_ADJUSTED", "ThreeFourteen.AlphaVantage.Test.ExampleData.Stocks.TimeSeriesMonthlyAdjusted.json" },
            // FX
            { "FX_INTRADAY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Fx.IntraDay.json" },
            { "FX_DAILY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Fx.Daily.json" },
            { "FX_WEEKLY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Fx.Weekly.json" },
            { "FX_MONTHLY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Fx.Monthly.json" },
            { "CURRENCY_EXCHANGE_RATE", "ThreeFourteen.AlphaVantage.Test.ExampleData.Fx.ExchangeRate.json" },
            // Cryptos
            { "DIGITAL_CURRENCY_DAILY", "ThreeFourteen.AlphaVantage.Test.ExampleData.Cryptos.Daily.json" },
            // Technicals
            { "SMA", "ThreeFourteen.AlphaVantage.Test.ExampleData.Technicals.SimpleMovingAverage.json" },
            { "RSI", "ThreeFourteen.AlphaVantage.Test.ExampleData.Technicals.RelativeStrengthIndex.json" },
            
            // Other
            { "ERROR", "ThreeFourteen.AlphaVantage.Test.ExampleData.Error.json" },
            { "PREMIUM", "ThreeFourteen.AlphaVantage.Test.ExampleData.PremiumMessage.json" }
        };

        public Task<string> GetRawDataAsync(IDictionary<string, string> parameters)
        {
            LatestParameters = parameters;

            string file = FileLookup[_forcedResponseKey ?? parameters[ParameterFields.Function]];

            return LoadExampleData(file);
        }

        public void ForceResponse(string responseKey)
        {
            _forcedResponseKey = responseKey;
        }

        private async Task<string> LoadExampleData(string fileName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }
    }
}
