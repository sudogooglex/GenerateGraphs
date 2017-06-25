using System;
using System.IO;
using System.Collections.Generic;
using GenerateGraphs.src.Core;
using GenerateGraphs.src.Conf;

namespace GenerateGraphs.src.Core
{
    public class CSVreader
    {
        public List<Transaction> Transactions;
        public string TransactionPath = "";

        public CSVreader() {
            Transactions = new List<Transaction>();
            TransactionPath = Ut.ReadTransactionPath();
        }
        public void UpdateCSV() {
            using(var fs = File.OpenRead(TransactionPath))
            using(var reader = new StreamReader(fs))
            {
                string headerLine = reader.ReadLine(); // skip header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    try {
                        var values = line.Split(';');
                        var date = DateTime.ParseExact(values[0], "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        var label = values[1];
                        var amount = decimal.Parse(values[2]);
                        var transaction = new Transaction(date, label, amount);
                        Transactions.Add(transaction);
                    } catch (Exception e) {
                        Console.WriteLine("A line failed to load : " + line + "\n" + e);
                    }
                }
            }
            Console.WriteLine("UpdateCSV: Parsed " + Transactions.Count + " lines.");
        }
    }
}