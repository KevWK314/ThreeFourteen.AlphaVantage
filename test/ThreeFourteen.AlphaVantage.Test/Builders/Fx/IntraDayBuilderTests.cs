using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Fx
{
    public class IntraDayBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Fx.IntraDay("EUR", "USD")
                .SetInterval(Interval.FiveMinutes)
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.FromSymbol].ShouldBe("EUR");
            ServiceMock.LatestParameters[ParameterFields.ToSymbol].ShouldBe("USD");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Fx.IntraDay.Value);

            result.Meta.Count.ShouldBe(7);
            result.Meta["Information"].ShouldBe("FX Intraday (5min) Time Series");
            result.Meta["From Symbol"].ShouldBe("EUR");
            result.Meta["To Symbol"].ShouldBe("USD");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-22 06:15:00");
            result.Meta["Interval"].ShouldBe("5min");
            result.Meta["Output Size"].ShouldBe("Compact");
            result.Meta["Time Zone"].ShouldBe("UTC");

            result.Data.Length.ShouldBe(100);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-22 06:15:00"));
            first.Open.ShouldBe(1.1572);
            first.High.ShouldBe(1.1572);
            first.Low.ShouldBe(1.1569);
            first.Close.ShouldBe(1.1571);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-21 22:00:00"));
            last.Open.ShouldBe(1.1571);
            last.High.ShouldBe(1.1575);
            last.Low.ShouldBe(1.1570);
            last.Close.ShouldBe(1.1574);
        }
    }
}
