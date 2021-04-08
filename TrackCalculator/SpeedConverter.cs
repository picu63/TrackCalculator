namespace TrackCalculator
{
    internal static class SpeedConverter
    {
        internal static double ToKilometersPerHour(this double metersPerSecond)
        {
            return metersPerSecond * 3600 / 1000;
        }
    }
}
