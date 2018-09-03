using System;
using ThreeFourteen.AlphaVantage.Builders;

namespace ThreeFourteen.AlphaVantage
{
    public static class ICanSetTimePeriodExtensions
    {
        public static T SetTimePeriod<T>(this T builder, int period)
            where T : BuilderBase, ICanSetTimePeriod
        {
            if (period <= 0) throw new ArgumentException(nameof(period), "Must be positive");

            builder.SetField(ParameterFields.TimePeriod, period.ToString());

            return builder;
        }
    }
}
