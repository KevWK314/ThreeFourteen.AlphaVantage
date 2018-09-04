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

        public StockIntraDayBuilder IntraDay(string symbol)
        {
            return new StockIntraDayBuilder(_getService(), symbol);
        }

        public StockDailyBuilder Daily(string symbol)
        {
            return new StockDailyBuilder(_getService(), symbol);
        }

        public StockDailyAdjustedBuilder DailyAdjusted(string symbol)
        {
            return new StockDailyAdjustedBuilder(_getService(), symbol);
        }

        public StockWeeklyBuilder Weekly(string symbol)
        {
            return new StockWeeklyBuilder(_getService(), symbol);
        }

        public StockWeeklyAdjustedBuilder WeeklyAdjusted(string symbol)
        {
            return new StockWeeklyAdjustedBuilder(_getService(), symbol);
        }

        public StockMonthlyBuilder Monthly(string symbol)
        {
            return new StockMonthlyBuilder(_getService(), symbol);
        }

        public StockMonthlyAdjustedBuilder MonthlyAdjusted(string symbol)
        {
            return new StockMonthlyAdjustedBuilder(_getService(), symbol);
        }
    }
}
