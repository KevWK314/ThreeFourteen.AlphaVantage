using System;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Configuration;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage
{
    public static class AlphaVantage
    {
        private static AlphaVantageConfig _config;
        private static Lazy<IAlphaVantageService> _service;

        static AlphaVantage()
        {
            _config = new AlphaVantageConfig();
            _service = new Lazy<IAlphaVantageService>(() => _config.Service ?? new AlphaVantageService(_config));
        }

        public static CustomBuilder Custom(string symbol)
        {
            return new CustomBuilder(_service.Value, symbol);
        }

        public static TimeSeriesIntraDayBuilder TimeSeriesIntraDay(string symbol)
        {
            return new TimeSeriesIntraDayBuilder(_service.Value, symbol);
        }

        public static TimeSeriesWeeklyBuilder TimeSeriesWeekly(string symbol)
        {
            return new TimeSeriesWeeklyBuilder(_service.Value, symbol);
        }

        public static void Configure(Action<AlphaVantageConfig> configureAction)
        {
            configureAction?.Invoke(_config);
        }
    }
}
