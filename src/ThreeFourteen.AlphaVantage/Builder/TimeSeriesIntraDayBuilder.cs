using ThreeFourteen.AlphaVantage.Parameters;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public class TimeSeriesIntraDayBuilder : BuilderBase, IIntervalBuilder, IOutputSizeBuilder
    {
        internal TimeSeriesIntraDayBuilder(IAlphaVantageService service, string symbol)
            : base(service, symbol)
        {
        }

        protected override string[] RequiredFields => new[]
        {
            ParameterFields.Interval,
        };

        protected override Function Function => Function.TimeSeriesIntraDay;

        public Interval[] ValidIntervals()
        {
            return Interval.OneToSixtyMinutes;
        }
    }
}
