using System;

namespace ThreeFourteen.AlphaVantage.Response
{
    public class TimeSeriesEntry
    {
        public DateTime Timestamp { get; internal set; }

        public double Open { get; internal set; }

        public double High { get; internal set; }

        public double Low { get; internal set; }

        public double Close { get; internal set; }

        public int Volume { get; internal set; }
    }
}
