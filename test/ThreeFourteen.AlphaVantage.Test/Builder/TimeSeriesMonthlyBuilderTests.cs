using Shouldly;
using System.Linq;
using ThreeFourteen.AlphaVantage.Parameters;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesMonthlyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.TimeSeriesMonthly("MSFT")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.TimeSeriesMonthly.Value);

            timeseries.Meta.Count.ShouldBe(4);
            timeseries.Meta["Information"].ShouldBe("Monthly Prices (open, high, low, close) and Volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-16 12:46:09");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(283);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-16"));
            first.Open.ShouldBe(106.0300);
            first.High.ShouldBe(110.1600);
            first.Low.ShouldBe(104.8400);
            first.Close.ShouldBe(108.2000);
            first.Volume.ShouldBe(224684427);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-02-28"));
            last.Open.ShouldBe(59.3800);
            last.High.ShouldBe(63.2500);
            last.Low.ShouldBe(58.3800);
            last.Close.ShouldBe(63.0000);
            last.Volume.ShouldBe(62416100);
        }
    }
}
