namespace ThreeFourteen.AlphaVantage.Response
{
    public class TimeSeriesAdjustedEntry : TimeSeriesEntry
    {
        public double AdjustedClose { get; internal set; }

        public double DividendAmount { get; internal set; }
    }
}
