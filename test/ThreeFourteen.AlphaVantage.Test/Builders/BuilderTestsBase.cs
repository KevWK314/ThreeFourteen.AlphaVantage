using ThreeFourteen.AlphaVantage.Test.Mock;

namespace ThreeFourteen.AlphaVantage.Test.Builders
{
    public abstract class BuilderTestsBase
    {
        protected BuilderTestsBase()
        {
            ServiceMock = new AlphaVantageServiceMock();
            AlphaVantage = new AlphaVantage();
            AlphaVantage.Configure(x => x.Service = ServiceMock);
        }

        protected AlphaVantage AlphaVantage { get; }

        protected AlphaVantageServiceMock ServiceMock { get; }
    }
}
