using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class TimeSeriesWeeklyBuilder : BuilderBase, IHaveData<TimeSeriesEntry>
    {
        public TimeSeriesWeeklyBuilder(IAlphaVantageService service, string symbol)
            : base(service, symbol)
        {
        }

        protected override string[] RequiredFields => new string[0];

        protected override Function Function => Function.TimeSeriesWeekly;

        public Task<Result<TimeSeriesEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
        }

        private IEnumerable<TimeSeriesEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            if (properties?.Name != "Weekly Time Series")
            {
                throw new InvalidOperationException($"Unexpected node value: {properties?.Name ?? "null"}");
            }

            var series = new List<TimeSeriesEntry>();
            foreach (JProperty day in properties.First.Children())
            {
                var date = Formats.ParseDateTime(day.Name);
                var data = new TimeSeriesEntry { Timestamp = date };
                data.Open = day.First.Value<double>("1. open");
                data.High = day.First.Value<double>("2. high");
                data.Low = day.First.Value<double>("3. low");
                data.Close = day.First.Value<double>("4. close");
                data.Volume = day.First.Value<long>("5. volume");
                series.Add(data);
            }

            return series;
        }
    }
}
