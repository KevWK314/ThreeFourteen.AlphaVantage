using System;
using ThreeFourteen.AlphaVantage.Builders;

namespace ThreeFourteen.AlphaVantage
{
    public static class ICanSetOutputSizeExtensions
    {
        public static T SetOutputSize<T>(this T builder, OutputSize outputSize)
             where T : BuilderBase, ICanSetOutputSize
        {
            if (outputSize == null) throw new ArgumentNullException(nameof(outputSize));

            builder.SetField(ParameterFields.OutputSize, outputSize.Value);

            return builder;
        }
    }
}
