namespace TrackCalculator.Interfaces
{
    public interface IPrintCalculation
    {
        void PrintAllCalculations();
        IPrintCalculation PrintCalculationFor(ITrackCalculator trackCalculator);
    }
}