using Shouldly;
using System.Linq;
using ThreeFourteen.AlphaVantage.Parameters;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesWeeklyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.TimeSeriesWeekly("MSFT")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.TimeSeriesWeekly.Value);

            timeseries.Meta.Count.ShouldBe(4);
            timeseries.Meta["Information"].ShouldBe("Weekly Prices (open, high, low, close) and Volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-13");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(1232);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-13"));
            first.Open.ShouldBe(109.2400);
            first.High.ShouldBe(109.5800);
            first.Low.ShouldBe(108.1000);
            first.Close.ShouldBe(108.2100);
            first.Volume.ShouldBe(18469724);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-01-13"));
            last.Open.ShouldBe(60.8800);
            last.High.ShouldBe(63.0000);
            last.Low.ShouldBe(59.7500);
            last.Close.ShouldBe(62.7500);
            last.Volume.ShouldBe(11750000);
        }
    }
}
