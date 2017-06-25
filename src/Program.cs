using System;
using System.IO;
using GenerateGraphs.src.Conf;
using GenerateGraphs.src.Core;

namespace GenerateGraphs.src
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Ut.ReadTransactionPath();

            CSVreader csvReader = new CSVreader(config.transactionPath);
            csvReader.UpdateCSV();

            var categoryMaker = new CategoryMaker(csvReader.Transactions, config.ignoreList);
            categoryMaker.MakeCategory();
        }
    }
}
