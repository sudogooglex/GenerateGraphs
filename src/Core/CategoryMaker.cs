using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GenerateGraphs.src.Conf;

namespace GenerateGraphs.src.Core
{
    public class CategoryMaker
    {
        public List<Transaction> Transactions;
        public List<CategoryTotalAmount> Categories;
        public List<string> IgnoreList = new List<string>() {
            "ACHAT CB", "CARTE NUMERO", " 814 ", "CARTE NO", // Ignore specific words
            @"((\d{2})([\.\/]{1})(\d{2})([\.\/]{1})(\d{2}))" // Ignore dates
        };

        public CategoryMaker(List<Transaction> transactions, List<string> ignoreList) {
            Transactions = transactions;
            IgnoreList = ignoreList;
        }

        /// <summary>
        /// From a list of transactions, generate a list of CategoryTotalAmount.
        /// </summary>
        public void MakeCategory() {
            Categories = new List<CategoryTotalAmount>();
            Transactions.ForEach(t => {
                var label = t.Label;
                // 1. Remove ignoreList
                IgnoreList.ForEach(ignoreRegex => {
                    label = Regex.Replace(label, ignoreRegex, "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                });

                // 2. Trim
                label = label.Trim();
            });
        }
    }
}