using ThreeFourteen.AlphaVantage.Test.Mock;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public abstract class BuilderTestsBase
    {
        static BuilderTestsBase()
        {
            ServiceMock = new AlphaVantageServiceMock();
            AlphaVantage.Configure(x => x.Service = ServiceMock);

        }

        protected static AlphaVantageServiceMock ServiceMock { get; }
    }
}
