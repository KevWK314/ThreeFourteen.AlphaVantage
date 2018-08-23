using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Stocks
{
    public class TimeSeriesIntraDayBuilder : BuilderBase, IHaveData<TimeSeriesEntry>, ICanSetInterval, ICanSetOutputSize
    {
        private static readonly Interval[] Intervals = new[]
        {
            Interval.OneMinute,
            Interval.FiveMinutes,
            Interval.FifteenMinutes,
            Interval.ThirtyMinutes,
            Interval.SixtyMinutes
        };

        internal TimeSeriesIntraDayBuilder(IAlphaVantageService service, string symbol)
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

        public Interval[] ValidIntervals()
        {
            return Intervals;
        }

        public Task<Result<TimeSeriesEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
        }

        private IEnumerable<TimeSeriesEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            properties.ValidateName("Time Series(.)");

            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}
