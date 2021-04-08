using System.Collections.Generic;

namespace TrackCalculator.Models
{
    public class Track
    {
        public Track(ICollection<TrackPoint> trackPoints)
        {
            TrackPoints = trackPoints;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TrackPoint> TrackPoints { get; }
    }
}
