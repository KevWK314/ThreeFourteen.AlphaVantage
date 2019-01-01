namespace ThreeFourteen.AlphaVantage.Model
{
    public class TimeSeriesAdjustedEntry : TimeSeriesEntry
    {
        public double AdjustedClose { get; internal set; }

        public double DividendAmount { get; internal set; }
        public double SplitCoefficient { get; internal set; }
    }
}
