using System;
using System.Collections.Generic;

namespace GenerateGraphs.src.Core
{
    public class CategoryTotalAmount
    {
        public decimal TotalAmount;
        public List<Transaction> Transactions;
        public string Label;

        public CategoryTotalAmount(Transaction t) {
            Transactions = new List<Transaction>() {t};
            TotalAmount = t.Amount;
            Label = t.Label;
        }

        /// <summary>
        /// Add a transaction to a category.
        /// </summary>
        /// <param name="t">A transaction.</param>
        public void AddTransaction(Transaction t)
        {
            TotalAmount += t.Amount;
            Transactions.Add(t);
        }
    }
}
