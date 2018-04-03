using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class TimeSeriesIntraDayBuilder : BuilderBase, IIntervalBuilder
    {
        internal TimeSeriesIntraDayBuilder(IAlphaVantageService service, string symbol)
            : base(service, symbol)
        {
        }

        public Interval[] ValidIntervals()
        {
            return Interval.OneToSixtyMinutes;
        }
    }
}
