using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Stocks
{
    public class StockWeeklyBuilder : BuilderBase, IHaveData<Result<TimeSeriesEntry>>
    {
        public StockWeeklyBuilder(IAlphaVantageService service, string symbol)
            : base(service)
        {
            SetField(ParameterFields.Symbol, symbol);
        }

        protected override string[] RequiredFields => new[] { ParameterFields.Symbol };

        protected override Function Function => Function.Stocks.TimeSeriesWeekly;

        public Task<Result<TimeSeriesEntry>> GetAsync()
        {
            return GetSeriesDataAsync(Parse);
        }

        private IEnumerable<TimeSeriesEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties?.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}
