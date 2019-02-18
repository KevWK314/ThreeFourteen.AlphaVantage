using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Fx
{
    public class ExchangeRateBuilder : BuilderBase, IHaveData<FxExchangeRate>
    {
        public ExchangeRateBuilder(IAlphaVantageService service, string from, string to)
            : base(service)
        {
            SetField(ParameterFields.FromCurrency, from);
            SetField(ParameterFields.ToCurrency, to);
        }

        protected override string[] RequiredFields => new[]
        {
            ParameterFields.FromCurrency,
            ParameterFields.ToCurrency
        };

        protected override Function Function => Function.Fx.ExchangeRate;

        public async Task<FxExchangeRate> GetAsync()
        {
            var res = await GetRawDataAsync();
            JToken node = JToken.Parse(res);

            ValidateResponse(node as JObject);

            var dataNode = node.Root["Realtime Currency Exchange Rate"];
            if (dataNode == null)
            {
                throw new AlphaVantageException("Result does not seem to be valid", Fields);
            }

            var rate = new FxExchangeRate
            {
                FromCurrencyCode = dataNode.Value<string>("1. From_Currency Code"),
                FromCurrencyName = dataNode.Value<string>("2. From_Currency Name"),
                ToCurrencyCode = dataNode.Value<string>("3. To_Currency Code"),
                ToCurrencyName = dataNode.Value<string>("4. To_Currency Name"),
                ExchangeRate = dataNode.Value<double>("5. Exchange Rate"),
                LastRefreshed = Formats.ParseDateTime(dataNode.Value<string>("6. Last Refreshed")),
                TimeZone = dataNode.Value<string>("7. Time Zone")
            };

            return rate;
        }
    }
}