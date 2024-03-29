﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Globalization;
using TrackCalculator.Models;

namespace EnduroTrackReader;

public class TrackReader
{
    public TrackReader(string path)
    {
        _path = path;
    }

    private readonly string _path;

    public Track GetTrack()
    {
        var track = new Track(GetAllPoints().ToList());
        return track;
    }

    private IEnumerable<TrackPoint> GetAllPoints()
    {
        var gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
        var gpxDoc = XDocument.Load(_path);

        var points = gpxDoc.Descendants(gpx + "trkpt")
            .Select(point => new TrackPoint()
            {
                Latitude = double.Parse(point.Attribute("lon").Value, CultureInfo.InvariantCulture),
                Longitude = double.Parse(point.Attribute("lat").Value, CultureInfo.InvariantCulture),
                Altitude = double.Parse(point.Descendants(gpx + "ele").FirstOrDefault().Value,
                    CultureInfo.InvariantCulture),
                DateTime = DateTime.Parse(point.Descendants(gpx + "time").FirstOrDefault().Value,
                    CultureInfo.InvariantCulture)
            });
        return points;
    }
}