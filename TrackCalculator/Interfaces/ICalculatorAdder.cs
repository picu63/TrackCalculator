namespace TrackCalculator.Interfaces
{
    public interface ICalculatorAdder : IAllCalculating, ICalculatorOptions
    {
        ICalculatorAdder AddCalculator(ITrackCalculator calculator);
    }
}