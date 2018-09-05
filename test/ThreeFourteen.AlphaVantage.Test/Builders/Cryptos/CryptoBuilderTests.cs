using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeFourteen.AlphaVantage.Test.Builders;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.ExampleData.Cryptos
{
    public class CryptoBuilderTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_ShouldReturnValidData()
        {
            var result = await AlphaVantage.Cryptos.Daily("BTC", "EUR").GetAsync();

            ServiceMock.LatestParameters[ParameterFields.Symbol].ShouldBe("BTC");
            ServiceMock.LatestParameters[ParameterFields.Market].ShouldBe("EUR");
            ServiceMock.LatestParameters[ParameterFields.Function].ShouldBe(Function.Crypto.Daily.Value);

            result.Meta.Count.ShouldBe(7);
            result.Meta["Information"].ShouldBe("Daily Prices and Volumes for Digital Currency");
            result.Meta["Digital Currency Code"].ShouldBe("BTC");
            result.Meta["Digital Currency Name"].ShouldBe("Bitcoin");
            result.Meta["Market Code"].ShouldBe("EUR");
            result.Meta["Market Name"].ShouldBe("Euro");
            result.Meta["Last Refreshed"].ShouldBe("2018-09-04 (end of day)");
            result.Meta["Time Zone"].ShouldBe("UTC");

            result.Data.Length.ShouldBe(1618);
            var first = result.Data.First();
            first.Timestamp.ShouldBe(Formats.ParseDateTime("2018-09-04"));
            first.Open.ShouldBe(6262.92605909);
            first.High.ShouldBe(6403.78907389);
            first.Low.ShouldBe(6212.11595943);
            first.Close.ShouldBe(6346.03891043);
            first.OpenUsd.ShouldBe(7275.50121638);
            first.HighUsd.ShouldBe(7399.24828944);
            first.LowUsd.ShouldBe(7206.65612459);
            first.CloseUsd.ShouldBe(7351.98107268);
            first.Volume.ShouldBe(15786.65979924);
            first.MarketCapUsd.ShouldBe(116063224.04482706);
            var last = result.Data.Last();
            last.Timestamp.ShouldBe(Formats.ParseDateTime("2014-04-01"));
            last.Open.ShouldBe(337.24368327);
            last.High.ShouldBe(364.98051975);
            last.Low.ShouldBe(337.24368327);
            last.Close.ShouldBe(358.78143188);
            last.OpenUsd.ShouldBe(464.98412099);
            last.HighUsd.ShouldBe(503.40127051);
            last.LowUsd.ShouldBe(464.98412099);
            last.CloseUsd.ShouldBe(494.89346671);
            last.Volume.ShouldBe(3611.19706722);
            last.MarketCapUsd.ShouldBe(1787157.83556112);
        }
    }
}