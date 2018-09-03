using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Technicals
{
    public class SimpleMovingAverageBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Technicals.SimpleMovingAverage("MSFT")
                .SetInterval(Interval.Weekly)
                .SetSeriesType(SeriesType.Open)
                .SetTimePeriod(10)
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Technicals.SimpleMovingAverave.Value);
            ServiceMock.LatestParameters[ParameterFields.Interval].ShouldBe(Interval.Weekly.Value);
            ServiceMock.LatestParameters[ParameterFields.SeriesType].ShouldBe(SeriesType.Open.Value);
            ServiceMock.LatestParameters[ParameterFields.TimePeriod].ShouldBe("10");

            result.Meta.Count.ShouldBe(7);
            result.Meta["Indicator"].ShouldBe("Simple Moving Average (SMA)");
            result.Meta["Symbol"].ShouldBe("MSFT");
            result.Meta["Interval"].ShouldBe("weekly");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-31 12:38:59");
            result.Meta["Time Period"].ShouldBe("10");
            result.Meta["Series Type"].ShouldBe("open");
            result.Meta["Time Zone"].ShouldBe("US/Eastern");

            result.Data.Length.ShouldBe(1225);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-31 12:38:59"));
            first.Value.ShouldBe(105.2775);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-03-17"));
            last.Value.ShouldBe(62.1140);
        }
    }
}
