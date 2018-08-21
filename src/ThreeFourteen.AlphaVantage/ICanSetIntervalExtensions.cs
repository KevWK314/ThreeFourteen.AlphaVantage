using System;
using System.Linq;
using ThreeFourteen.AlphaVantage.Builders;

namespace ThreeFourteen.AlphaVantage
{
    public static class ICanSetIntervalExtensions
    {
        public static T SetInterval<T>(this T builder, Interval interval)
             where T : BuilderBase, ICanSetInterval
        {
            if (interval == null) throw new ArgumentNullException(nameof(interval));

            if (!builder.ValidIntervals().Contains(interval))
            {
                throw new InvalidOperationException($"Interval {interval.Value} not supported");
            }
            builder.SetField(ParameterFields.Interval, interval.Value);

            return builder;
        }
    }
}
