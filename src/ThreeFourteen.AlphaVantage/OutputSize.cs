namespace ThreeFourteen.AlphaVantage
{
    public class OutputSize
    {
        public static readonly OutputSize Compact = new OutputSize("compact");

        public static readonly OutputSize Full = new OutputSize("full");

        private OutputSize(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
