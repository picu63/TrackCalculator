﻿using System;

namespace TrackCalculator.Interfaces
{
    public interface ICalculatorCreator : ITrackCalculation, ICalculatorAdder, IFinalCalculation, ICalculatorOptions
    {

    }

    public interface IFinalCalculation
    {
        IPrintCalculation CalculateAll();
    }
    public interface ICalculatorAdder
    {
        ICalculatorCreator AddCalculator(ITrackCalculator calculator);
    }

    public interface ICalculatorOptions
    {
        IFinalCalculation WithOptions(Action<CalculatorOptions> options);
    }
}
