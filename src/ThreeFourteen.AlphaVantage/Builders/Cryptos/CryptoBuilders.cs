using System;
using ThreeFourteen.AlphaVantage.Builders.Fx;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Cryptos
{
    public class CryptoBuilders
    {
        private readonly Func<IAlphaVantageService> _getService;

        internal CryptoBuilders(Func<IAlphaVantageService> getService)
        {
            _getService = getService;
        }

        public ExchangeRateBuilder ExchangeRate(string from, string to)
        {
            return new ExchangeRateBuilder(_getService(), from, to);
        }

        public CryptoBuilder Daily(string symbol, string market)
        {
            return new CryptoBuilder(_getService(), Function.Crypto.Daily, symbol, market);
        }

        public CryptoBuilder Weekly(string symbol, string market)
        {
            return new CryptoBuilder(_getService(), Function.Crypto.Weekly, symbol, market);
        }

        public CryptoBuilder Monthly(string symbol, string market)
        {
            return new CryptoBuilder(_getService(), Function.Crypto.Monthly, symbol, market);
        }
    }
}
