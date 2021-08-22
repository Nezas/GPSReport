using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSReport.Models;
using GPSReport.Writers;

namespace GPSReport
{
    public class Histogram
    {
        public List<GpsData> Data;
        private readonly IWriter _writer;

        public Histogram(List<GpsData> data, IWriter writer)
        {
            Data = data;
            _writer = writer;
        }

        public void DrawSattelites()
        {
            var data = Data.Select(i => i.Satellites).ToArray();
            int maxValue = data.Max();

            int stepValue = 100;

            _writer.Write($"    Histogram of sattelites | # = {stepValue} \n");
            _writer.Write("\n");
            for(int i = 0; i <= maxValue; i++)
            {
                int sattelites = data.Count(value => value == i);
                string line = new('#', sattelites / stepValue);

                _writer.Write($"{i, 3} |{line} \n");
            }
            _writer.Write("     0 Hits\n");
        }
    }
}
