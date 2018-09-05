using System;
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
