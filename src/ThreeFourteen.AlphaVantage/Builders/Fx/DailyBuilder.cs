using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Fx
{
    public class DailyBuilder : BuilderBase, IHaveData<FxEntry>, ICanSetOutputSize
    {
        public DailyBuilder(IAlphaVantageService service, string from, string to)
            : base(service)
        {
            SetField(ParameterFields.FromSymbol, from);
            SetField(ParameterFields.ToSymbol, to);
        }

        protected override string[] RequiredFields => new[]
        {
            ParameterFields.FromSymbol,
            ParameterFields.ToSymbol
        };

        protected override Function Function => Function.Fx.Daily;

        public Task<Result<FxEntry>> GetAsync()
        {
            return GetDataAsync(Parse);
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