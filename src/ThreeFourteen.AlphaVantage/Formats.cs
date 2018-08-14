using System;
using System.Globalization;

namespace ThreeFourteen.AlphaVantage
{
    public static class Formats
    {
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateFormat = "yyyy-MM-dd";

        public static DateTime ParseDateTime(string date)
        {
            return DateTime.ParseExact(date, new[] { DateFormat, DateTimeFormat }, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}
