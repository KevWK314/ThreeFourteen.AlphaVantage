using Shouldly;
using System.Linq;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Parameters;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public class TimeSeriesDailyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var timeseries = await AlphaVantage.TimeSeriesDaily("MSFT")
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.TimeSeriesDaily.Value);
            ServiceMock.LatestParameters[ParameterFields.OutputSize].ShouldBe(OutputSize.Compact.Value);

            timeseries.Meta.Count.ShouldBe(5);
            timeseries.Meta["Information"].ShouldBe("Daily Prices (open, high, low, close) and Volumes");
            timeseries.Meta["Symbol"].ShouldBe("MSFT");
            timeseries.Meta["Output Size"].ShouldBe("Compact");
            timeseries.Meta["Last Refreshed"].ShouldBe("2018-08-16");
            timeseries.Meta["Time Zone"].ShouldBe("US/Eastern");

            timeseries.Data.Length.ShouldBe(100);
            var first = timeseries.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-16"));
            first.Open.ShouldBe(108.3000);
            first.High.ShouldBe(108.8600);
            first.Low.ShouldBe(107.3000);
            first.Close.ShouldBe(107.6400);
            first.Volume.ShouldBe(20687122);
            var last = timeseries.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2018-03-27"));
            last.Open.ShouldBe(94.9400);
            last.High.ShouldBe(95.1390);
            last.Low.ShouldBe(88.5100);
            last.Close.ShouldBe(89.4700);
            last.Volume.ShouldBe(53704562);
        }
    }
}
