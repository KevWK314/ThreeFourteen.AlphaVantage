using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Stocks
{
    public class TimeSeriesDailyBuilder : BuilderBase, IHaveData<TimeSeriesEntry>, ICanSetOutputSize
    {
        public TimeSeriesDailyBuilder(IAlphaVantageService service, string symbol)
            : base(service, symbol)
        {
        }

        protected override string[] RequiredFields => new string[0];

        protected override Function Function => Function.TimeSeriesDaily;

        public Task<Result<TimeSeriesEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
        }

        private IEnumerable<TimeSeriesEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            if (properties?.Name != "Time Series (Daily)")
            {
                throw new InvalidOperationException($"Unexpected node value: {properties?.Name ?? "null"}");
            }

            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}