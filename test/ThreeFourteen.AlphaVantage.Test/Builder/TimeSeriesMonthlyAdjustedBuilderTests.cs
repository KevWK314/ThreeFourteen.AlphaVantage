using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesMonthlyAdjustedBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.Stocks.TimeSeriesMonthlyAdjusted("MSFT")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.TimeSeriesMonthlyAdjusted.Value);

            timeseries.Meta.Count.ShouldBe(4);
            timeseries.Meta["Information"].ShouldBe("Monthly Adjusted Prices and Volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-20");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(283);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-20"));
            first.Open.ShouldBe(106.0300);
            first.High.ShouldBe(110.1600);
            first.Low.ShouldBe(104.8400);
            first.Close.ShouldBe(106.8700);
            first.AdjustedClose.ShouldBe(106.8700);
            first.Volume.ShouldBe(274693160);
            first.DividendAmount.ShouldBe(0.4200);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-02-28"));
            last.Open.ShouldBe(59.3800);
            last.High.ShouldBe(63.2500);
            last.Low.ShouldBe(58.3800);
            last.Close.ShouldBe(63.0000);
            last.AdjustedClose.ShouldBe(2.5878);
            last.Volume.ShouldBe(62416100);
            last.DividendAmount.ShouldBe(0.0000);
        }
    }
}
