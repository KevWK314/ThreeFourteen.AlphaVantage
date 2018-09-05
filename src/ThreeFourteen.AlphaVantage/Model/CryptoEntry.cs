using System;

namespace ThreeFourteen.AlphaVantage.Model
{
    public class CryptoEntry
    {
        public DateTime Timestamp { get; internal set; }
        public double Open { get; internal set; }
        public double High { get; internal set; }
        public double Low { get; internal set; }
        public double Close { get; internal set; }
        public double OpenUsd { get; internal set; }
        public double HighUsd { get; internal set; }
        public double LowUsd { get; internal set; }
        public double CloseUsd { get; internal set; }
        public double Volume { get; internal set; }
        public double MarketCapUsd { get; internal set; }
    }
}
