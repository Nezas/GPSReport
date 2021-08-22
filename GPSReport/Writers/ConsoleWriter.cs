using System;

namespace GPSReport.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
