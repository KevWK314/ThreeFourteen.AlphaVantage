using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class TimeSeriesIntraDayBuilder : BuilderBase, IHaveData<TimeSeriesEntry>, IIntervalBuilder, IOutputSizeBuilder
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
                : base(service, symbol)
        {
        }

        protected override string[] RequiredFields => new[]
        {
            ParameterFields.Interval,
        };

        protected override Function Function => Function.TimeSeriesIntraDay;

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
            if (!Regex.IsMatch(properties?.Name, "Time Series(.)"))
            {
                throw new InvalidOperationException($"Unexpected node value: {properties?.Name ?? "null"}");
            }

            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}
