namespace TrackCalculator.Interfaces;

public interface IFluentTrackCalculator
{
    ICalculatorAdder AddCalculator(ITrackCalculator calculator);
}