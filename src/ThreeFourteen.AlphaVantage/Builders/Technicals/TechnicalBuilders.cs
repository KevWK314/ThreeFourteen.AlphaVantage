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

        public BasicTechnicalBuilder ExponentialMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.ExponentialMovingAverage);
        }

        public BasicTechnicalBuilder WeightedMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.WeightedMovingAverage);
        }

        public BasicTechnicalBuilder DoubleExponentialMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.DoubleExponentialMovingAverage);
        }

        public BasicTechnicalBuilder TripleExponentialMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.TripleExponentialMovingAverage);
        }

        public BasicTechnicalBuilder TriangularExponentialMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.TriangularExponentialMovingAverage);
        }

        public BasicTechnicalBuilder KaufmanAdaptiveMovingAverage(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.KaufmanAdaptiveMovingAverage);
        }

        public BasicTechnicalBuilder AverageDirectionalMovementIndex(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.AverageDirectionalMovementIndex);
        }

        public BasicTechnicalBuilder CommodityChannelIndex(string symbol)
        {
            return new BasicTechnicalBuilder(_getService(), symbol, Function.Technicals.CommodityChannelIndex);
        }
    }
}
