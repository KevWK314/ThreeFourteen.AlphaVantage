using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class ExponentialMovingAverageBuilder : BuilderBase, IIntervalBuilder
    {
        internal ExponentialMovingAverageBuilder(IAlphaVantageService service, string symbol) 
            : base(service, symbol)
        {
        }

        protected override string[] RequiredFields => throw new System.NotImplementedException();

        protected override Function Function => throw new System.NotImplementedException();

        public Interval[] ValidIntervals()
        {
            return Interval.All;
        }
    }
}
