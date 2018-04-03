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

        public Interval[] ValidIntervals()
        {
            return Interval.All;
        }
    }
}
