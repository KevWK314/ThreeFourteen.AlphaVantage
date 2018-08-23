using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ThreeFourteen.AlphaVantage.Test.Builders
{
    public class BuilderErrorTests : BuilderTestsBase
    {
        [Fact]
        public void Get_WhenError_ShouldThrowValidException()
        {
            Func<Task<string>> get = () => AlphaVantage.Custom("MSFT")
                .Set("function", "ERROR")
                .Set("interval", "60min")
                .Set("outputsize", "compact")
                .GetRawDataAsync();

            get.ShouldThrowAsync<InvalidOperationException>("Invalid API call. Please retry or visit the documentation (https://www.alphavantage.co/documentation/) for CMO.");
        }
    }
}
