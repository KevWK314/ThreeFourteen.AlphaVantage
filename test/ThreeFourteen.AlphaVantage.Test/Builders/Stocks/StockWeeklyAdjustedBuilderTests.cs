using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Stocks
{
    public class StockWeeklyAdjustedBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.Stocks.TimeSeriesWeeklyAdjusted("MSFT")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Stocks.TimeSeriesWeeklyAdjusted.Value);

            timeseries.Meta.Count.ShouldBe(4);
            timeseries.Meta["Information"].ShouldBe("Weekly Adjusted Prices and Volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-16");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(1232);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-16"));
            first.Open.ShouldBe(109.2400);
            first.High.ShouldBe(109.7500);
            first.Low.ShouldBe(106.8200);
            first.Close.ShouldBe(107.6400);
            first.AdjustedClose.ShouldBe(107.6400);
            first.Volume.ShouldBe(85933126);
            first.DividendAmount.ShouldBe(0.4200);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-01-13"));
            last.Open.ShouldBe(60.8800);
            last.High.ShouldBe(63.0000);
            last.Low.ShouldBe(59.7500);
            last.Close.ShouldBe(62.7500);
            last.AdjustedClose.ShouldBe(2.5775);
            last.Volume.ShouldBe(11750000);
            last.DividendAmount.ShouldBe(0.0000);
        }
    }
}
