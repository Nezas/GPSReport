using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GPSReport.DataRepositories
{
    public class JsonDataRepository<T> : IDataRepository<T>
    {
        public List<T> GetData(string fileName)
        {
            List<T> data = new();

            try
            {
                StreamReader reader = new(fileName);
                string json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }
    }
}
