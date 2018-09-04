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

        public BasicTechnicalBuilder SimpleMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.SimpleMovingAverave);
        }

        public BasicTechnicalBuilder RelativeStrengthIndex(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.RelativeStrengthIndex);
        }
    }
}
