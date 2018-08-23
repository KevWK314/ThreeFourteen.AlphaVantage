using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Stocks
{
    public class TimeSeriesDailyAdjustedBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.Stocks.TimeSeriesDailyAdjusted("MSFT")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Stocks.TimeSeriesDailyAdjusted.Value);

            timeseries.Meta.Count.ShouldBe(5);
            timeseries.Meta["Information"].ShouldBe("Daily Time Series with Splits and Dividend Events");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-20");
            timeseries.Meta["Output Size"].ShouldBe("Compact");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(100);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-20"));
            first.Open.ShouldBe(107.5100);
            first.High.ShouldBe(107.9000);
            first.Low.ShouldBe(106.4800);
            first.Close.ShouldBe(106.8700);
            first.AdjustedClose.ShouldBe(106.8700);
            first.Volume.ShouldBe(17326964);
            first.DividendAmount.ShouldBe(0.0000);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2018-03-29"));
            last.Open.ShouldBe(90.1800);
            last.High.ShouldBe(92.2900);
            last.Low.ShouldBe(88.4000);
            last.Close.ShouldBe(91.2700);
            last.AdjustedClose.ShouldBe(90.5240);
            last.Volume.ShouldBe(45867548);
            last.DividendAmount.ShouldBe(0.0000);
        }
    }
}
