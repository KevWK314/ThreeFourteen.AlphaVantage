using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders
{
    public class CustomBuilder : BuilderBase
    {
        internal CustomBuilder(IAlphaVantageService service)
            : base(service)
        {
        }

        protected override string[] RequiredFields => new [] { ParameterFields.Function };

        protected override Function Function => null;

        public CustomBuilder Set(string key, string value)
        {
            SetField(key, value);
            return this;
        }
    }
}
