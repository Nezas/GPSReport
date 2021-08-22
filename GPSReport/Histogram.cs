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

        public void DrawSpeed()
        {
            var data = Data.Select(i => i.Speed).ToArray();
            int maxValue = data.Max();

            int stepValue = 750;

            _writer.Write("Histogram of speeds\n");
            _writer.Write("\n   Speed                                                                   Hits\n");
            for(int i = 0; i <= maxValue; i += 10)
            {
                int speedHits = data.Count(value => value >= i + 9);
                string line;
                if(speedHits < 750 && speedHits != 0)
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
