using System;

namespace ThreeFourteen.AlphaVantage.Model
{
    public class CryptoEntry : Entry
    {
        public double OpenUsd { get; internal set; }
        public double HighUsd { get; internal set; }
        public double LowUsd { get; internal set; }
        public double CloseUsd { get; internal set; }
        public double Volume { get; internal set; }
        public double MarketCapUsd { get; internal set; }
    }
}