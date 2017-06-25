using System;
using System.IO;
using GenerateGraphs.src.Core;

namespace GenerateGraphs.src
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVreader csvReader = new CSVreader();
            csvReader.UpdateCSV();
        }
    }
}
