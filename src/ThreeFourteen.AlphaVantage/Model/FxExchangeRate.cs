using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeFourteen.AlphaVantage.Model
{
    public class FxExchangeRate
    {
        public string FromCurrencyCode { get; internal set; }
        public string FromCurrencyName { get; internal set; }
        public string ToCurrencyCode { get; internal set; }
        public string ToCurrencyName { get; internal set; }
        public double ExchangeRate { get; internal set; }
        public DateTime LastRefreshed { get; internal set; }
        public string TimeZone { get; internal set; }
    }
}
