using Shouldly;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Parameters;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesIntraDayBuilderTests : BuilderTestsBase
    {
        [Fact]
        public void Test()
        {
            var timeseries = AlphaVantage.TimeSeriesIntraDay("MSFT")
                .SetInterval(Interval.FiveMinutes)
                .SetOutputSize(OutputSize.Compact)
                .GetRawDataAsync().Result;

            timeseries.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
