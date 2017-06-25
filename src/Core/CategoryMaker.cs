using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using GenerateGraphs.src.Conf;
using System.IO;

namespace GenerateGraphs.src.Core
{
    public class CategoryMaker
    {
        public List<Transaction> Transactions;
        public Dictionary<string, CategoryTotalAmount> Categories;
        public List<CategoryTotalAmount> SortedCategories;
        public List<string> IgnoreList;

        public CategoryMaker(List<Transaction> transactions, List<string> ignoreList) {
            Transactions = transactions;
            IgnoreList = ignoreList;
        }

        /// <summary>
        /// From a list of transactions, generate a list of CategoryTotalAmount.
        /// </summary>
        public int MakeCategory() {
            Categories = new Dictionary<string, CategoryTotalAmount>();
            UpdateTransactions(); // map
            GenerateCategories(); // reduce
            SortCategories(); // sort
            var categoriesNumber = WriteOutPut();
            return categoriesNumber;
        }

        /// <summary>
        /// Remove ignore regex. Trim.
        /// </summary>
        public void UpdateTransactions() {
            Transactions.ForEach(t => {
                var label = t.Label;
                // 1. Remove ignoreList
                IgnoreList.ForEach(ignoreRegex => {
                    label = Regex.Replace(label, ignoreRegex, "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                });

                // 2. Trim
                label = label.Trim();
                t.Label = label;
            });
        }

        /// <summary>
        /// Generate a list of categories.
        /// </summary>
        public void GenerateCategories() {
            Transactions.ForEach(t => {
                var label = t.Label;
                if (Categories.ContainsKey(label)) {
                    var categoryTotalAmount = Categories[label];
                    categoryTotalAmount.AddTransaction(t);
                } else {
                    var categoryTotalAmount = new CategoryTotalAmount(t);
                    Categories.Add(label, categoryTotalAmount);
                }
            });
        }

        /// <summary>
        /// Sort Categories To a List.
        /// </summary>
        public void SortCategories() {
            SortedCategories = Categories.Select(kv => {
                return kv.Value;
            }).OrderBy(t => t.TotalAmount).ToList();
        }

        /// <summary>
        /// Write all the categories in the output.csv file.
        /// </summary>
        public int WriteOutPut() {
            var outputPath = "./output.csv";
            var csv = new StringBuilder();
            csv.AppendLine("Label; TotalAmount; TransactionNumber");

            SortedCategories.ForEach(category => {
                csv.AppendLine($"{category.Label}; {category.TotalAmount}; {category.Transactions.Count}");
            });
            var res = csv.ToString();
            File.WriteAllText(outputPath, res);
            return SortedCategories.Count;
        }
    }
}
