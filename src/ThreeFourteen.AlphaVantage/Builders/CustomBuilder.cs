using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders
{
    public class CustomBuilder : BuilderBase
    {
        internal CustomBuilder(IAlphaVantageService service, string symbol)
            : base(service)
        {
            SetField(ParameterFields.Symbol, symbol);
        }

        protected override string[] RequiredFields => new string[] { ParameterFields.Function };

        protected override Function Function => null;

        public CustomBuilder Set(string key, string value)
        {
            SetField(key, value);
            return this;
        }
    }
}
