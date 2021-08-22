using System.Collections.Generic;

namespace GPSReport.DataRepositories
{
    public interface IDataRepository<T>
    {
        List<T> GetData(string fileName);
    }
}
