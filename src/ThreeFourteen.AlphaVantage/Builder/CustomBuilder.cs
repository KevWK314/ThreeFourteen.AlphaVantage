using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class CustomBuilder : BuilderBase
    {
        internal CustomBuilder(IAlphaVantageService service, string symbol)
            : base(service, symbol)
        {
        }

        public CustomBuilder Set(string key, string value)
        {
            SetField(key, value);
            return this;
        }
    }
}
