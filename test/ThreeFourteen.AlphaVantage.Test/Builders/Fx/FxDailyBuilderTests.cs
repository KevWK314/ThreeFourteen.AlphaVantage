using Shouldly;
using System.Linq;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders.Fx
{
    public class FxDailyBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Fx.Daily("EUR", "USD")
                .SetOutputSize(OutputSize.Compact)
                .GetAsync();

            ServiceMock.LatestParameters[ParameterFields.FromSymbol].ShouldBe("EUR");
            ServiceMock.LatestParameters[ParameterFields.ToSymbol].ShouldBe("USD");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Fx.Daily.Value);
            ServiceMock.LatestParameters[ParameterFields.OutputSize].ShouldBe(OutputSize.Compact.Value);

            result.Meta.Count.ShouldBe(6);
            result.Meta["Information"].ShouldBe("Forex Daily Prices (open, high, low, close)");
            result.Meta["From Symbol"].ShouldBe("EUR");
            result.Meta["To Symbol"].ShouldBe("USD");
            result.Meta["Last Refreshed"].ShouldBe("2018-08-22 14:15:00");
            result.Meta["Output Size"].ShouldBe("Compact");
            result.Meta["Time Zone"].ShouldBe("GMT+8");

            result.Data.Length.ShouldBe(101);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-08-22"));
            first.Open.ShouldBe(1.1533);
            first.High.ShouldBe(1.1601);
            first.Low.ShouldBe(1.1526);
            first.Close.ShouldBe(1.1571);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2018-04-27"));
            last.Open.ShouldBe(1.2104);
            last.High.ShouldBe(1.2133);
            last.Low.ShouldBe(1.2053);
            last.Close.ShouldBe(1.2125);
        }
    }
}