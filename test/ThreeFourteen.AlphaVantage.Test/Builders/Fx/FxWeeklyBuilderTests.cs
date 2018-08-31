using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Fx
{
    public class FxWeeklyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Fx.Weekly("EUR", "USD")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.FromSymbol].ShouldBe("EUR");
            ServiceMock.LatestParameters[ParameterFields.ToSymbol].ShouldBe("USD");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Fx.Weekly.Value);

            result.Meta.Count.ShouldBe(5);
            result.Meta["Information"].ShouldBe("Forex Weekly Prices (open, high, low, close)");
            result.Meta["From Symbol"].ShouldBe("EUR");
            result.Meta["To Symbol"].ShouldBe("USD");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-31 14:10:00");
            result.Meta["Time Zone"].ShouldBe("GMT+8");

            result.Data.Length.ShouldBe(958);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-31"));
            first.Open.ShouldBe(1.1628);
            first.High.ShouldBe(1.1733);
            first.Low.ShouldBe(1.1593);
            first.Close.ShouldBe(1.1677);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2000-04-28"));
            last.Open.ShouldBe(0.9374);
            last.High.ShouldBe(0.9450);
            last.Low.ShouldBe(0.9026);
            last.Close.ShouldBe(0.9090);
        }
    }
}