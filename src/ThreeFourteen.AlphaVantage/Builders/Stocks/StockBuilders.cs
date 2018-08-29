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

        public StockIntraDayBuilder TimeSeriesIntraDay(string symbol)
        {
            return new StockIntraDayBuilder(_getService(), symbol);
        }

        public StockDailyBuilder TimeSeriesDaily(string symbol)
        {
            return new StockDailyBuilder(_getService(), symbol);
        }

        public StockDailyAdjustedBuilder TimeSeriesDailyAdjusted(string symbol)
        {
            return new StockDailyAdjustedBuilder(_getService(), symbol);
        }

        public StockWeeklyBuilder TimeSeriesWeekly(string symbol)
        {
            return new StockWeeklyBuilder(_getService(), symbol);
        }

        public StockWeeklyAdjustedBuilder TimeSeriesWeeklyAdjusted(string symbol)
        {
            return new StockWeeklyAdjustedBuilder(_getService(), symbol);
        }

        public StockMonthlyBuilder TimeSeriesMonthly(string symbol)
        {
            return new StockMonthlyBuilder(_getService(), symbol);
        }

        public StockMonthlyAdjustedBuilder TimeSeriesMonthlyAdjusted(string symbol)
        {
            return new StockMonthlyAdjustedBuilder(_getService(), symbol);
        }

    }
}
