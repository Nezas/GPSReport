using System;
using System.IO;
using System.Linq;
using GPSReport.DataRepositories;
using GPSReport.Models;
using GPSReport.Writers;

namespace GPSReport
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataRepository<GpsData> json = new JsonDataRepository<GpsData>();
            IDataRepository<GpsData> csv = new CsvDataRepository<GpsData>();

            var jsonData = json.GetData("../../../../../2019-07.json");
            var csvData = csv.GetData("../../../../../2019-08.csv");
            var allData = jsonData.Concat(csvData).ToList();

            Histogram histogram = new(allData, new ConsoleWriter());
            //histogram.DrawSattelites();
            histogram.DrawSpeed();
        }
    }
}
