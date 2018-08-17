namespace ThreeFourteen.AlphaVantage.Parameters
{
    public class Function
    {
        public static readonly Function TimeSeriesIntraDay = new Function("TIME_SERIES_INTRADAY");

        public static readonly Function TimeSeriesDaily = new Function("TIME_SERIES_DAILY");

        public static readonly Function TimeSeriesWeekly = new Function("TIME_SERIES_WEEKLY");

        public static readonly Function TimeSeriesMonthly = new Function("TIME_SERIES_MONTHLY");

        private Function(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
