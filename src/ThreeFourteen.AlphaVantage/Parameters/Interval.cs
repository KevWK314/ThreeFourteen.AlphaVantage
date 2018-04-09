namespace ThreeFourteen.AlphaVantage.Parameters
{
    public class Interval
    {
        public static readonly Interval OneMinute = new Interval("1min");

        public static readonly Interval FiveMinutes = new Interval("5min");

        public static readonly Interval FifteenMinutes = new Interval("15min");

        public static readonly Interval ThirtyMinutes = new Interval("30min");

        public static readonly Interval SixtyMinutes = new Interval("60min");

        public static readonly Interval Daily = new Interval("daily");

        public static readonly Interval Weekly = new Interval("weekly");

        public static readonly Interval Monthly = new Interval("monthly");

        internal static Interval[] OneToSixtyMinutes
        {
            get
            {
                return new[]
                {
                    OneMinute,
                    FiveMinutes,
                    FifteenMinutes,
                    ThirtyMinutes,
                    SixtyMinutes
                };
            }
        }

        internal static Interval[] All
        {
            get
            {
                return new[]
                {
                    OneMinute,
                    FiveMinutes,
                    FifteenMinutes,
                    ThirtyMinutes,
                    SixtyMinutes,
                    Daily,
                    Weekly,
                    Monthly
                };
            }
        }

        private Interval(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
