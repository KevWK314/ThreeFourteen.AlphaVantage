using System;
using ThreeFourteen.AlphaVantage.Builders;
using ThreeFourteen.AlphaVantage.Builders.Fx;
using ThreeFourteen.AlphaVantage.Builders.Stocks;
using ThreeFourteen.AlphaVantage.Builders.Technicals;
using ThreeFourteen.AlphaVantage.Configuration;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage
{
    public class AlphaVantage
    {
        private readonly AlphaVantageConfig _config;
        private readonly Lazy<IAlphaVantageService> _service;

        public AlphaVantage(string apiKey)
        {
            _config = new AlphaVantageConfig { ApiKey = apiKey };
            _service = new Lazy<IAlphaVantageService>(() => _config.Service ?? new AlphaVantageService(_config));

            Stocks = new StockBuilders(() => _service.Value);
            Fx = new FxBuilders(() => _service.Value);
            Technicals = new TechnicalBuilders(() => _service.Value);
        }

        public StockBuilders Stocks { get; }

        public FxBuilders Fx { get; }

        public TechnicalBuilders Technicals { get; }

        public CustomBuilder Custom()
        {
            return new CustomBuilder(_service.Value);
        }

        public void Configure(Action<AlphaVantageConfig> configureAction)
        {
            configureAction?.Invoke(_config);
        }
    }
}
