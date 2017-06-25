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
            var linesNb = csvReader.UpdateCSV();
            var categoryMaker = new CategoryMaker(csvReader.Transactions, config.ignoreList);
            var categoriesNb = categoryMaker.MakeCategory();
            var reduction = 100 * ((decimal)linesNb - (decimal)categoriesNb)/(decimal)linesNb;

            Console.WriteLine($"UpdateCSV: Parsed {linesNb} lines.");
            Console.WriteLine($"WriteOutPut: Written {categoriesNb} lines.");
            Console.WriteLine($"Main: Reduction of {reduction:0.00}%.");
        }
    }
}
