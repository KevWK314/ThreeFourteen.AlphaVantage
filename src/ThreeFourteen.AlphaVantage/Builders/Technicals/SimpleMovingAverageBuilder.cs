using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Technicals
{
    public class SimpleMovingAverageBuilder : BuilderBase, IHaveData<TechnicalEntry>, ICanSetInterval, ICanSetTimePeriod, ICanSetSeriesType
    {
        private static readonly Interval[] Intervals =
            {
                Interval.OneMinute,
                Interval.FiveMinutes,
                Interval.FifteenMinutes,
                Interval.ThirtyMinutes,
                Interval.SixtyMinutes,
                Interval.Daily,
                Interval.Weekly,
                Interval.Monthly
            };

        internal SimpleMovingAverageBuilder(IAlphaVantageService service, string symbol)
            : base(service)
        {
            SetField(ParameterFields.Symbol, symbol);
        }

        protected override string[] RequiredFields => new[] { ParameterFields.Interval, ParameterFields.TimePeriod };

        protected override Function Function => Function.Technicals.SimpleMovingAverave;

        public Interval[] ValidIntervals()
        {
            return Intervals;
        }

        public Task<Result<TechnicalEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
        }

        private IEnumerable<TechnicalEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTechnical("SMA"))
                .ToList();
        }
    }
}
