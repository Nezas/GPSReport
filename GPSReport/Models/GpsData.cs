using System;

namespace GPSReport.Models
{
    public class GpsData : IData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime GetTime { get; set; }
        public int Speed { get; set; }
        public int Angle { get; set; }
        public int Altitude { get; set; }
        public int Satellites { get; set; }
    }
}
