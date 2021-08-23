using System;
using System.Collections.Generic;
using System.Linq;
using GPSReport.Models;
using GPSReport.Writers;

namespace GPSReport
{
    public class Histogram
    {
        private readonly IWriter _writer;

        public Histogram(IWriter writer)
        {
            _writer = writer;
        }

        public void DrawSatellites(List<GpsData> data)
        {
            var satellitesData = data.Select(i => i.Satellites).ToArray();
            int maxValue = satellitesData.Max();

            int stepValue = 100;

            _writer.Write($"    Histogram of satellites\n");
            _writer.Write("\n");
            for(int i = 0; i <= maxValue; i++)
            {
                int satellites = satellitesData.Count(value => value == i);
                string line;
                if(satellites < stepValue && satellites != 0)
                {
                    line = "#";
                }
                else
                {
                    line = new('#', satellites / stepValue);
                }
                _writer.Write($"{i, 3} |{line} \n");
            }
            _writer.Write("     0 Hits\n");
        }

        public void DrawSpeed(List<GpsData> data)
        {
            var speedData = data.Select(i => i.Speed).ToArray();
            int maxValue = speedData.Max();

            int stepValue = 750;

            _writer.Write("Histogram of speeds\n");
            _writer.Write("\n   Speed                                                                   Hits\n");
            for(int i = 0; i <= maxValue; i += 10)
            {
                int speedHits = speedData.Count(value => value >= i + 9);
                string line;
                if(speedHits < stepValue && speedHits != 0)
                {
                    line = "#";
                }
                else
                {
                    line = new('#', speedHits / stepValue);
                }
                _writer.Write(String.Format("{0,6} | {1,-60} | {2,1}", $"{i,3} - {i + 9,3}", $"{line}", $"{speedHits}\n"));
            }
        }
    }
}
