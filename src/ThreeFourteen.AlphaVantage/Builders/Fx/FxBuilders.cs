using System;
using ThreeFourteen.AlphaVantage.Service;

namespace ThreeFourteen.AlphaVantage.Builders.Fx
{
    public class FxBuilders
    {
        private readonly Func<IAlphaVantageService> _getService;

        public FxBuilders(Func<IAlphaVantageService> getService)
        {
            _getService = getService;
        }

        public IntraDayBuilder IntraDay(string from, string to)
        {
            return new IntraDayBuilder(_getService(), from, to);
        }
    }
}
