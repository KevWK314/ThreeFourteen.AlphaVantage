using System;
using ThreeFourteen.AlphaVantage.Builder;
using ThreeFourteen.AlphaVantage.Configuration;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage
{
    public class AlphaVantage
    {
        private AlphaVantageConfig _config;
        private Lazy<IAlphaVantageService> _service;

        public AlphaVantage()
        {
            _config = new AlphaVantageConfig();
            _service = new Lazy<IAlphaVantageService>(() => _config.Service ?? new AlphaVantageService(_config));
        }

        public CustomBuilder Custom(string symbol)
        {
            return new CustomBuilder(_service.Value, symbol);
        }

        public TimeSeriesIntraDayBuilder TimeSeriesIntraDay(string symbol)
        {
            return new TimeSeriesIntraDayBuilder(_service.Value, symbol);
        }

        public TimeSeriesWeeklyBuilder TimeSeriesWeekly(string symbol)
        {
            return new TimeSeriesWeeklyBuilder(_service.Value, symbol);
        }

        public void Configure(Action<AlphaVantageConfig> configureAction)
        {
            configureAction?.Invoke(_config);
        }
    }
}
