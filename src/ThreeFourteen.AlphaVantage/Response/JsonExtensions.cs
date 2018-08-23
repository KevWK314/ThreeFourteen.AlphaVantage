using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace ThreeFourteen.AlphaVantage.Response
{
    public static class JsonExtensions
    {
        public static TimeSeriesEntry ToTimeSeries(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new TimeSeriesEntry { Timestamp = date };
            entry.Open = token.First.Value<double>("1. open");
            entry.High = token.First.Value<double>("2. high");
            entry.Low = token.First.Value<double>("3. low");
            entry.Close = token.First.Value<double>("4. close");
            entry.Volume = token.First.Value<long>("5. volume");

            return entry;
        }

        public static TimeSeriesAdjustedEntry ToTimeSeriesAdjusted(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new TimeSeriesAdjustedEntry { Timestamp = date };
            entry.Open = token.First.Value<double>("1. open");
            entry.High = token.First.Value<double>("2. high");
            entry.Low = token.First.Value<double>("3. low");
            entry.Close = token.First.Value<double>("4. close");
            entry.AdjustedClose = token.First.Value<double>("5. adjusted close");
            entry.Volume = token.First.Value<long>("6. volume");
            entry.DividendAmount = token.First.Value<double>("7. dividend amount");

            return entry;
        }

        public static FxEntry ToFx(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new FxEntry { Timestamp = date };
            entry.Open = token.First.Value<double>("1. open");
            entry.High = token.First.Value<double>("2. high");
            entry.Low = token.First.Value<double>("3. low");
            entry.Close = token.First.Value<double>("4. close");

            return entry;
        }
    }
}
