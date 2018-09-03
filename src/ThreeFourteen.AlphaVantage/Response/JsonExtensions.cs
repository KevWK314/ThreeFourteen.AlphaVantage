using Newtonsoft.Json.Linq;
using ThreeFourteen.AlphaVantage.Model;

namespace ThreeFourteen.AlphaVantage.Response
{
    public static class JsonExtensions
    {
        public static TimeSeriesEntry ToTimeSeries(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new TimeSeriesEntry
            {
                Timestamp = date,
                Open = token.First.Value<double>("1. open"),
                High = token.First.Value<double>("2. high"),
                Low = token.First.Value<double>("3. low"),
                Close = token.First.Value<double>("4. close"),
                Volume = token.First.Value<long>("5. volume")
            };

            return entry;
        }

        public static TimeSeriesAdjustedEntry ToTimeSeriesAdjusted(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new TimeSeriesAdjustedEntry
            {
                Timestamp = date,
                Open = token.First.Value<double>("1. open"),
                High = token.First.Value<double>("2. high"),
                Low = token.First.Value<double>("3. low"),
                Close = token.First.Value<double>("4. close"),
                AdjustedClose = token.First.Value<double>("5. adjusted close"),
                Volume = token.First.Value<long>("6. volume"),
                DividendAmount = token.First.Value<double>("7. dividend amount")
            };

            return entry;
        }

        public static FxEntry ToFx(this JProperty token)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new FxEntry
            {
                Timestamp = date,
                Open = token.First.Value<double>("1. open"),
                High = token.First.Value<double>("2. high"),
                Low = token.First.Value<double>("3. low"),
                Close = token.First.Value<double>("4. close")
            };

            return entry;
        }

        public static TechnicalEntry ToTechnical(this JProperty token, string valueKey)
        {
            var date = Formats.ParseDateTime(token.Name);
            var entry = new TechnicalEntry
            {
                Timestamp = date,
                Value = token.First.Value<double>(valueKey),
            };

            return entry;
        }     
    }
}
