using System;

namespace GenerateGraphs.src.Core
{
    public class Transaction
    {
        /// <summary>
        /// Date of the transaction.
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// Date of the transaction.
        /// </summary>
        public string Label;
        /// <summary>
        /// Amount of the transaction.
        /// </summary>
        public decimal Amount;

        public Transaction(DateTime date, string label, decimal amount) {
            Date = date;
            Label = label;
            Amount = amount;
        }

        public override string ToString() {
            return string.Format($"Date: {Date}, Label: {Label}, Amount: {Amount}");
        }
    }
}