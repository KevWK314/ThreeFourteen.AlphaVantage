using System;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Stocks
{
    public class StockBuilders
    {
        private readonly Func<IAlphaVantageService> _getService;

        internal StockBuilders(Func<IAlphaVantageService> getService)
        {
            _getService = getService;
        }

        public TimeSeriesIntraDayBuilder TimeSeriesIntraDay(string symbol)
        {
            return new TimeSeriesIntraDayBuilder(_getService(), symbol);
        }

        public TimeSeriesDailyBuilder TimeSeriesDaily(string symbol)
        {
            return new TimeSeriesDailyBuilder(_getService(), symbol);
        }

        public TimeSeriesDailyAdjustedBuilder TimeSeriesDailyAdjusted(string symbol)
        {
            return new TimeSeriesDailyAdjustedBuilder(_getService(), symbol);
        }

        public TimeSeriesWeeklyBuilder TimeSeriesWeekly(string symbol)
        {
            return new TimeSeriesWeeklyBuilder(_getService(), symbol);
        }

        public TimeSeriesWeeklyAdjustedBuilder TimeSeriesWeeklyAdjusted(string symbol)
        {
            return new TimeSeriesWeeklyAdjustedBuilder(_getService(), symbol);
        }

        public TimeSeriesMonthlyBuilder TimeSeriesMonthly(string symbol)
        {
            return new TimeSeriesMonthlyBuilder(_getService(), symbol);
        }

        public TimeSeriesMonthlyAdjustedBuilder TimeSeriesMonthlyAdjusted(string symbol)
        {
            return new TimeSeriesMonthlyAdjustedBuilder(_getService(), symbol);
        }

    }
}
