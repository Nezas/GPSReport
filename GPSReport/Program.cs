using System;
using System.IO;
using System.Linq;
using GPSReport.DataRepositories;
using GPSReport.Models;

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
        }
    }
}
