using System;
using ThreeFourteen.AlphaVantage.Parameters;

namespace ThreeFourteen.AlphaVantage.Builder
{
    public interface IOutputSizeBuilder
    {
    }

    public static class OutputSizeBuilderExtensions
    {
        public static T SetOutputSize<T>(this T builder, OutputSize outputSize)
             where T : BuilderBase, IOutputSizeBuilder
        {
            if (outputSize == null) throw new ArgumentNullException(nameof(outputSize));

            builder.SetField(ParameterFields.OutputSize, outputSize.Value);

            return builder;
        }
    }
}
