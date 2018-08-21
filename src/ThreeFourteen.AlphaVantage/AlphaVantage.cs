using System;
using ThreeFourteen.AlphaVantage.Builders;
using ThreeFourteen.AlphaVantage.Builders.Stocks;
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

            Stocks = new StockBuilders(() => _service.Value);
        }

        public StockBuilders Stocks { get; }

        public CustomBuilder Custom(string symbol)
        {
            return new CustomBuilder(_service.Value, symbol);
        }

        public void Configure(Action<AlphaVantageConfig> configureAction)
        {
            configureAction?.Invoke(_config);
        }
    }
}
