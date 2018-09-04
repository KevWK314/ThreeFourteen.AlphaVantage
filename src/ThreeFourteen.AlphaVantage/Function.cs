namespace ThreeFourteen.AlphaVantage
{
    public class Function
    {
        public static class Stocks
        {
            public static readonly Function TimeSeriesIntraDay = new Function("TIME_SERIES_INTRADAY");
            public static readonly Function TimeSeriesDaily = new Function("TIME_SERIES_DAILY");
            public static readonly Function TimeSeriesDailyAdjusted = new Function("TIME_SERIES_DAILY_ADJUSTED");
            public static readonly Function TimeSeriesWeekly = new Function("TIME_SERIES_WEEKLY");
            public static readonly Function TimeSeriesWeeklyAdjusted = new Function("TIME_SERIES_WEEKLY_ADJUSTED");
            public static readonly Function TimeSeriesMonthly = new Function("TIME_SERIES_MONTHLY");
            public static readonly Function TimeSeriesMonthlyAdjusted = new Function("TIME_SERIES_MONTHLY_ADJUSTED");
        }

        public static class Fx
        {
            public static readonly Function IntraDay = new Function("FX_INTRADAY");
            public static readonly Function Daily = new Function("FX_DAILY");
            public static readonly Function Weekly = new Function("FX_WEEKLY");
            public static readonly Function Monthly = new Function("FX_MONTHLY");
        }

        public static class Technicals
        {
            public static readonly Function SimpleMovingAverave = new Function("SMA");
            public static readonly Function RelativeStrengthIndex = new Function("RSI");
            public static readonly Function ExponentialMovingAverage = new Function("EMA");
            public static readonly Function WeightedMovingAverage = new Function("WMA");
            public static readonly Function DoubleExponentialMovingAverage = new Function("DEMA");
            public static readonly Function TripleExponentialMovingAverage = new Function("TEMA");
            public static readonly Function TriangularExponentialMovingAverage = new Function("TRIMA");
            public static readonly Function KaufmanAdaptiveMovingAverage = new Function("KAMA");
            public static readonly Function AverageDirectionalMovementIndex = new Function("ADX");
            public static readonly Function CommodityChannelIndex = new Function("CCI");
        }

        private Function(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
