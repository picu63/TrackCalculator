using TrackCalculator.Models;

namespace TrackCalculator.Interfaces;

public interface ITrackCalculator
{
    void Calculate(TrackPoint nextPoint);
    double Slope { get; set; }
    double TimeFilter { get; set; }
    void PrintResult();
}