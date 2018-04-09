using System;
using System.Linq;
using ThreeFourteen.AlphaVantage.Parameters;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public interface IIntervalBuilder
    {
        Interval[] ValidIntervals();
    }

    public static class IntervalExtensions
    {
        public static T SetInterval<T>(this T builder, Interval interval)
             where T : BuilderBase, IIntervalBuilder
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
