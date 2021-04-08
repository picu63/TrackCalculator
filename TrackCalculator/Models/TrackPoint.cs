using System;
using GeoCoordinatePortable;

namespace TrackCalculator.Models
{
    public class TrackPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateTime { get; set; }
        public double Altitude { get; set; }
        public GeoCoordinate GetGeoCoordinate() => new GeoCoordinate(Latitude, Longitude, Altitude);
        public override string ToString()
        {
            return $"LA:{Latitude}, LO:{Longitude}, A:{Altitude}, T:{DateTime.ToLongTimeString()}";
        }
    }
}
