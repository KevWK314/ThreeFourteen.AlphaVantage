using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class TimeSeriesIntraDayBuilder : BuilderBase, IHaveData<TimeSeriesIntraDay>, IIntervalBuilder, IOutputSizeBuilder
    {
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
            return Interval.OneToSixtyMinutes;
        }

        public Task<Result<TimeSeriesIntraDay>> GetAsync()
        {
            return GetDataAsync<TimeSeriesIntraDay>(Parse);
        }

        private IEnumerable<TimeSeriesIntraDay> Parse(JToken token)
        {
            var properties = token as JProperty;
            if (properties?.Name != "Time Series (15min)")
            {
                throw new InvalidOperationException($"Unexpected node value: {properties?.Name ?? "null"}");
            }

            var series = new List<TimeSeriesIntraDay>();
            foreach (JProperty day in properties.First.Children())
            {
                var date = DateTime.ParseExact(day.Name, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var data = new TimeSeriesIntraDay { Timestamp = date };
                data.Open = day.First.Value<double>("1. open");
                data.High = day.First.Value<double>("2. high");
                data.Low = day.First.Value<double>("3. low");
                data.Close = day.First.Value<double>("4. close");
                data.Volume = day.First.Value<int>("5. volume");
                series.Add(data);
            }

            return series;
        }
    }
}
