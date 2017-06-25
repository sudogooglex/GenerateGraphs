using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace GenerateGraphs.src.Conf
{
    public static class Ut
    {
        /// <summary>
        /// Read the configuration file.
        /// </summary>
        public static (string transactionPath, List<string> ignoreList) ReadTransactionPath() {
            var transactionPath = "";
            var ignoreList = new List<string>();
            var configDir = "./config.txt";
            using (TextReader reader = File.OpenText(configDir)) {
                transactionPath = reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length >= 1 && !line[0].Equals('#')) { // skip comments and empty lines
                        ignoreList.Add(line);
                    }
                }
            }
            return (transactionPath, ignoreList);
        }
    }
}