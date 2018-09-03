namespace ThreeFourteen.AlphaVantage
{
    public class SeriesType
    {
        public static SeriesType Open = new SeriesType("open");
        public static SeriesType Close = new SeriesType("close");
        public static SeriesType High = new SeriesType("high");
        public static SeriesType Low = new SeriesType("low");

        private SeriesType(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
