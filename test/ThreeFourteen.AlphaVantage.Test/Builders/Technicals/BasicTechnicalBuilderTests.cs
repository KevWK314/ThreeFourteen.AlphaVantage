using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Technicals
{
    public class BasicTechnicalBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_SMA_ShouldReturnValidData()
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

        [Fact]
        public async void Get_RSI_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Technicals.RelativeStrengthIndex("MSFT")
                .SetInterval(Interval.Monthly)
                .SetSeriesType(SeriesType.Close)
                .SetTimePeriod(100)
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("MSFT");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Technicals.RelativeStrengthIndex.Value);
            ServiceMock.LatestParameters[ParameterFields.Interval].ShouldBe(Interval.Monthly.Value);
            ServiceMock.LatestParameters[ParameterFields.SeriesType].ShouldBe(SeriesType.Close.Value);
            ServiceMock.LatestParameters[ParameterFields.TimePeriod].ShouldBe("100");

            result.Meta.Count.ShouldBe(7);
            result.Meta["Indicator"].ShouldBe("Relative Strength Index (RSI)");
            result.Meta["Symbol"].ShouldBe("MSFT");
            result.Meta["Interval"].ShouldBe("weekly");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-31");
            result.Meta["Time Period"].ShouldBe("10");
            result.Meta["Series Type"].ShouldBe("open");
            result.Meta["Time Zone"].ShouldBe("US/Eastern Time");

            result.Data.Length.ShouldBe(1224);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-31"));
            first.Value.ShouldBe(73.2229);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("1995-03-24"));
            last.Value.ShouldBe(75.0000);
        }
    }
}
