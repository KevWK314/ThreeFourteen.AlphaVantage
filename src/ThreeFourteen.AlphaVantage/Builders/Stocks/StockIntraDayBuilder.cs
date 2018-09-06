using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Stocks
{
    public class StockIntraDayBuilder : BuilderBase, IHaveData<TimeSeriesEntry[]>, ICanSetInterval, ICanSetOutputSize
    {
        private static readonly Interval[] Intervals =
            {
                Interval.OneMinute,
                Interval.FiveMinutes,
                Interval.FifteenMinutes,
                Interval.ThirtyMinutes,
                Interval.SixtyMinutes
            };

        internal StockIntraDayBuilder(IAlphaVantageService service, string symbol)
            : base(service)
        {
            SetField(ParameterFields.Symbol, symbol);
        }

        protected override string[] RequiredFields => new[] 
        {
            ParameterFields.Symbol,
            ParameterFields.Interval
        };

        protected override Function Function => Function.Stocks.TimeSeriesIntraDay;

        public Interval[] ValidIntervals => Intervals;

        public Task<Result<TimeSeriesEntry[]>> GetAsync()
        {
            return GetSeriesDataAsync(Parse);
        }

        private IEnumerable<TimeSeriesEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}
