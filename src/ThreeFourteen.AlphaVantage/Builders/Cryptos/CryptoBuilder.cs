using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Cryptos
{
    public class CryptoBuilder : BuilderBase, IHaveData<CryptoEntry[]>
    {
        private readonly string _market;

        public CryptoBuilder(IAlphaVantageService service, Function function, string symbol, string market)
            : base(service)
        {
            Function = function;
            _market = market;
            SetField(ParameterFields.Symbol, symbol);
            SetField(ParameterFields.Market, market);
        }

        protected override string[] RequiredFields => new[] { ParameterFields.Symbol, ParameterFields.Market };

        protected override Function Function { get; }

        public Task<Result<CryptoEntry[]>> GetAsync()
        {
            return GetSeriesDataAsync(Parse);
        }

        private IEnumerable<CryptoEntry> Parse(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToCrypto(_market))
                .ToList();
        }
    }
}
