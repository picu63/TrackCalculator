using System;
using System.Collections.Generic;
using System.Linq;
using TrackCalculator.Interfaces;
using TrackCalculator.Models;

namespace TrackCalculator;

public class FluentTrackCalculator : IFluentTrackCalculator, ICalculatorAdder, IAllCalculating, ICalculatorOptions, IPrintCalculation
{
    private readonly Track _track;
    private readonly List<ITrackCalculator> _calculators = new List<ITrackCalculator>();
    public FluentTrackCalculator(Track track)
    {
        this._track = track;
    }

    public ICalculatorAdder AddCalculator(ITrackCalculator calculator)
    {
        if (calculator is null) throw new ArgumentNullException(nameof(calculator));
        this._calculators.Add(calculator);
        return this;
    }

    public IPrintCalculation CalculateAll()
    {
        SetCalculatorsOptions();
        foreach (var calculator in _calculators)
        {
            foreach (var trackPoint in _track.TrackPoints)
            {

                calculator.Calculate(trackPoint);
            }
        }

        return this;
    }

    private void SetCalculatorsOptions()
    {
        SetSlope(_options.Slope);
        SetTimeFilter(_options.MaxTimeBetween2Points);
    }

    public void PrintAllCalculations()
    {
        foreach (var calculator in _calculators)
        {
            calculator.PrintResult();
            Console.WriteLine();
        }
    }

    public IPrintCalculation PrintCalculationFor(ITrackCalculator trackCalculator)
    {
        if(!_calculators.Contains(trackCalculator)) throw new MissingMemberException(nameof(FluentTrackCalculator),nameof(trackCalculator));
        trackCalculator.PrintResult();
        return this;
    }

    /// <summary>
    /// Sets max percentage slope between 2 points to calculate if track is climb, flat or descent
    /// </summary>
    /// <param name="percentage"></param>
    /// <returns></returns>
    private void SetSlope(double percentage)
    {
        foreach (var calculator in _calculators)
        {
            calculator.Slope = percentage;
        }
    }

    /// <summary>
    /// Filters time between two next points to reduce undesirable breaks (i.e. lost signal).
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    private void SetTimeFilter(TimeSpan timeSpan)
    {
        foreach (var calculator in _calculators)
        {
            calculator.TimeFilter = timeSpan.TotalSeconds;
        }
    }

    private readonly CalculatorOptions _options = new();
    public IAllCalculating WithOptions(Action<CalculatorOptions> options)
    {
        options(this._options);
        return this;
    }
}

public class CalculatorOptions
{
    /// <summary>
    /// Time between two next points to reduce undesirable breaks (i.e. lost signal)
    /// </summary>
    public TimeSpan MaxTimeBetween2Points { get; set; }
    /// <summary>
    /// Max percentage slope between 2 points to calculate if track is climb, flat or descent
    /// </summary>
    public double Slope { get; set; }
}