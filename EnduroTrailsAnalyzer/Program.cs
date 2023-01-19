using System;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using EnduroTrackReader;
using TrackCalculator;
using TrackCalculator.Calculators;
using TrackCalculator.Interfaces;

namespace EnduroTrailsAnalyzer;

class Program
{
    static void Main(string[] args)
    {

        var filePath = args.FirstOrDefault();
        if (!File.Exists(filePath)) return;

        var trackReader = new TrackReader(filePath);
        var track = trackReader.GetTrack();
        IFluentTrackCalculator fluentTrackCalculator = new FluentTrackCalculator(track);
        fluentTrackCalculator
            .AddCalculator(new DistanceCalculator())
            .AddCalculator(new ElevationCalculator())
            .AddCalculator(new SpeedCalculator())
            .AddCalculator(new TimeCalculator())
            .WithOptions(options =>
            {
                options.Slope = 2;
                options.MaxTimeBetween2Points = new TimeSpan(1, 30, 0);
            })
            .CalculateAll()
            .PrintAllCalculations();
    }
}