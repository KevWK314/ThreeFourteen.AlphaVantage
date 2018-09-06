using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Fx
{
    public class FxIntraDayBuilder : BuilderBase, IHaveData<Result<FxEntry>>, ICanSetInterval, ICanSetOutputSize
    {
        private static readonly Interval[] Intervals = new[]
        {
            Interval.OneMinute,
            Interval.FiveMinutes,
            Interval.FifteenMinutes,
            Interval.ThirtyMinutes,
            Interval.SixtyMinutes
        };

        public FxIntraDayBuilder(IAlphaVantageService service, string from, string to)
            : base(service)
        {
            SetField(ParameterFields.FromSymbol, from);
            SetField(ParameterFields.ToSymbol, to);
        }

        protected override string[] RequiredFields => new[]
        {
            ParameterFields.FromSymbol,
            ParameterFields.ToSymbol,
            ParameterFields.Interval
        };

        protected override Function Function => Function.Fx.IntraDay;

        public Interval[] ValidIntervals => Intervals;

        public Task<Result<FxEntry>> GetAsync()
        {
            return GetSeriesDataAsync(Parse);
        }

        private IEnumerable<FxEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToFx())
                .ToList();
        }
    }
}
