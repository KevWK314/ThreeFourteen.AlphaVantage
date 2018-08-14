namespace ThreeFourteen.AlphaVantage.Parameters
{
    public class Function
    {
        public static readonly Function TimeSeriesIntraDay = new Function("TIME_SERIES_INTRADAY");

        public static readonly Function TimeSeriesWeekly = new Function("TIME_SERIES_WEEKLY");

        private Function(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
