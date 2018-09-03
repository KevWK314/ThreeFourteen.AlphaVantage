using System;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Technicals
{
    public class TechnicalBuilders
    {
        private readonly Func<IAlphaVantageService> _getService;

        internal TechnicalBuilders(Func<IAlphaVantageService> getService)
        {
            _getService = getService;
        }

        public SimpleMovingAverageBuilder SimpleMovingAverage(string symbol)
        {
            return new SimpleMovingAverageBuilder(_getService(), symbol);
        }
    }
}
