using System;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Fx
{
    public class FxBuilders
    {
        private readonly Func<IAlphaVantageService> _getService;

        internal FxBuilders(Func<IAlphaVantageService> getService)
        {
            _getService = getService;
        }

        public ExchangeRateBuilder ExchangeRate(string from, string to)
        {
            return new ExchangeRateBuilder(_getService(), from, to);
        }

        public FxIntraDayBuilder IntraDay(string from, string to)
        {
            return new FxIntraDayBuilder(_getService(), from, to);
        }

        public FxDailyBuilder Daily(string from, string to)
        {
            return new FxDailyBuilder(_getService(), from, to);
        }

        public FxWeeklyBuilder Weekly(string from, string to)
        {
            return new FxWeeklyBuilder(_getService(), from, to);
        }

        public FxMonthlyBuilder Monthly(string from, string to)
        {
            return new FxMonthlyBuilder(_getService(), from, to);
        }
    }
}
