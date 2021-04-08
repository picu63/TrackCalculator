namespace EnduroCalculator
{
    public interface IPrintCalculation
    {
        void PrintAllCalculations();
        IPrintCalculation PrintCalculationFor(ITrackCalculator trackCalculator);
    }
}