using System;
using System.Collections.Generic;
using GPSReport.Writers;
using GPSReport.Models;
using Geolocation;

namespace GPSReport
{
    public class RoadSection
    {
        private readonly IWriter _writer;

        public RoadSection(IWriter writer)
        {
            _writer = writer;
        }

        public void FindRoadSection(List<GpsData> data)
        {
            double startLatitude = 0;
            double startLongitude = 0;
            DateTime startTime = new();
            double endLatitude = 0;
            double endLongitude = 0;
            DateTime endTime = new();
            double roadSection = 0;
            double shortestTime = 86400;

            for(int i = 0; i < data.Count - 1; i++)
            {
                double roadKm = GeoCalculator.GetDistance(data[i].Latitude, data[i].Longitude, data[i + 1].Latitude, data[i + 1].Longitude) * 1.60934;
                var time = data[i + 1].GetTime - data[i].GetTime;

                if(roadKm >= 100 && time.TotalSeconds < shortestTime)
                {
                    startLatitude = data[i].Latitude;
                    startLongitude = data[i].Longitude;
                    startTime = data[i].GetTime;
                    endLatitude = data[i + 1].Latitude;
                    endLongitude = data[i + 1].Longitude;
                    endTime = data[i + 1].GetTime;
                    shortestTime = time.TotalSeconds;
                    roadSection = roadKm;
                }
            }

            WriteInformation(shortestTime, roadSection, startLatitude, startLongitude, startTime, endLatitude, endLongitude, endTime);
        }

        public void WriteInformation(double shortestTime, double roadSection, double startLatitude, double startLongitude,
            DateTime startTime, double endLatitude, double endLongitude, DateTime endTime)
        {
            if(startLatitude == 0 && endLatitude == 0)
            {
                _writer.Write("There isn't any road section of at least 100km long.\n");
            }
            else
            {
                _writer.Write($"Fastest road section of at least 100km was driven over {shortestTime} and was {roadSection}km long.\n");
                _writer.Write($"Start position {startLatitude}; {startLongitude}\n");
                _writer.Write($"Start gps time {startTime}\n");
                _writer.Write($"End position {endLatitude}; {endLongitude}\n");
                _writer.Write($"End gps time {endTime}\n");
                _writer.Write($"Average speed: {roadSection / (shortestTime / 3600)} km/h\n");
            }
        }
    }
}
