using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Fx
{
    public class FxMonthlyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Fx.Monthly("EUR", "USD")
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.FromSymbol].ShouldBe("EUR");
            ServiceMock.LatestParameters[ParameterFields.ToSymbol].ShouldBe("USD");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Fx.Monthly.Value);

            result.Meta.Count.ShouldBe(5);
            result.Meta["Information"].ShouldBe("Forex Monthly Prices (open, high, low, close)");
            result.Meta["From Symbol"].ShouldBe("EUR");
            result.Meta["To Symbol"].ShouldBe("USD");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-31 14:10:00");
            result.Meta["Time Zone"].ShouldBe("GMT+8");

            result.Data.Length.ShouldBe(220);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-31"));
            first.Open.ShouldBe(1.1686);
            first.High.ShouldBe(1.1733);
            first.Low.ShouldBe(1.1300);
            first.Close.ShouldBe(1.1677);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2000-05-31"));
            last.Open.ShouldBe(0.9115);
            last.High.ShouldBe(0.9411);
            last.Low.ShouldBe(0.8842);
            last.Close.ShouldBe(0.9357);
        }
    }
}