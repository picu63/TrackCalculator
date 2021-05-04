using System;

namespace TrackCalculator.Interfaces
{
    public interface ICalculatorOptions
    {
        IAllCalculating WithOptions(Action<CalculatorOptions> options);
    }
}