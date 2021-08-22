using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace GPSReport.DataRepositories
{
    public class CsvDataRepository<T> : IDataRepository<T>
    {
        public List<T> GetData(string fileName)
        {
            List<T> data = new();

            try
            {
                StreamReader reader = new(fileName);
                var config = new CsvConfiguration(CultureInfo.InvariantCulture);
                config.HasHeaderRecord = false;
                CsvReader csv = new(reader, config);
                data = csv.GetRecords<T>().ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }
    }
}
