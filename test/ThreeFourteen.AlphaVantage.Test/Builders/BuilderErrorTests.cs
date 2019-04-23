using System;
using System.Threading.Tasks;
using Shouldly;
using ThreeFourteen.AlphaVantage.Model;
using ThreeFourteen.AlphaVantage.Response;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders
{
    public class BuilderErrorTests : BuilderTestsBase
    {
        [Fact]
        public async void Get_WhenError_ShouldThrowValidException()
        {
            ServiceMock.ForceResponse("ERROR");

            Func<Task<Result<TimeSeriesEntry>>> get = () => AlphaVantage.Stocks.Daily("MSFT").GetAsync();

            var exception = await get.ShouldThrowAsync<AlphaVantageException>();
            exception.Message.ShouldBe("Invalid API call. Please retry or visit the documentation (https://www.alphavantage.co/documentation/) for CMO.");
        }

        [Fact]
        public async void Get_WhenPremiumMessage_ShouldThrowValidException()
        {
            ServiceMock.ForceResponse("PREMIUM");

            Func<Task<Result<TimeSeriesEntry>>> get = () => AlphaVantage.Stocks.Daily("MSFT").GetAsync();

            var exception = await get.ShouldThrowAsync<AlphaVantageException>();
            exception.Message.ShouldBe("Thank you for using Alpha Vantage! Please visit https://www.alphavantage.co/premium/ if you would like to have a higher API call volume.");
        }

        [Fact]
        public async void Get_WhenApiLimitMessage_ShouldThrowValidException()
        {
            ServiceMock.ForceResponse("APILIMIT");

            Func<Task<Result<TimeSeriesEntry>>> get = () => AlphaVantage.Stocks.Daily("MSFT").GetAsync();

            var exception = await get.ShouldThrowAsync<AlphaVantageApiLimitException>();
            exception.Message.ShouldBe("Thank you for using Alpha Vantage! Our standard API call frequency is 5 calls per minute and 500 calls per day. Please visit https://www.alphavantage.co/premium/ if you would like to target a higher API call frequency.");
        }
    }
}
