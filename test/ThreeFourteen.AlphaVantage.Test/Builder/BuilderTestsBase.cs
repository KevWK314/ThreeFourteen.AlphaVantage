using ThreeFourteen.AlphaVantage.Test.Mock;

namespace ThreeFourteen.AlphaVantage.Test.Builder
{
    public abstract class BuilderTestsBase
    {
        public BuilderTestsBase()
        {
            ServiceMock = new AlphaVantageServiceMock();
            AlphaVantage.Configure(x => x.Service = ServiceMock);
        }

        protected AlphaVantageServiceMock ServiceMock { get; }
    }
}
