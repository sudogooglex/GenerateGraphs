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
        public static string ReadTransactionPath() {
            var res = "";
            var configDir = "./config.txt";
            using (TextReader reader = File.OpenText(configDir)) {
                res = reader.ReadLine();
            }
            return res;
        }
    }
}