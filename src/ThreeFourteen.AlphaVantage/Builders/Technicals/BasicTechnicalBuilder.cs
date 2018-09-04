using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Technicals
{
    public class BasicTechnicalBuilder : BuilderBase, IHaveData<TechnicalEntry>, ICanSetInterval, ICanSetTimePeriod, ICanSetSeriesType
    {
        internal BasicTechnicalBuilder(IAlphaVantageService service, string symbol, Function function)
            : base(service)
        {
            SetField(ParameterFields.Symbol, symbol);

            Function = function;
        }

        protected override string[] RequiredFields => new[] { ParameterFields.Interval, ParameterFields.TimePeriod };

        protected override Function Function { get; }

        public Interval[] ValidIntervals => Interval.All;

        public Task<Result<TechnicalEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
        }

        private IEnumerable<TechnicalEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTechnical(Function.Value))
                .ToList();
        }
    }
}
