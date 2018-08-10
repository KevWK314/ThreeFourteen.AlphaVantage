using System;
using System.Globalization;

namespace ThreeFourteen.AlphaVantage
{
    public static class Formats
    {
        public const string TimestampFormat = "yyyy-MM-dd HH:mm:ss";

        public static DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, TimestampFormat, CultureInfo.InvariantCulture);
        }
    }
}
