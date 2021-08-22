using System;

namespace GPSReport.Models
{
    public interface IData
    {
        int Altitude { get; set; }
        int Angle { get; set; }
        DateTime GetTime { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        int Satellites { get; set; }
        int Speed { get; set; }
    }
}